using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WpfApplication1.Commands;
using ClassLibrary1;
using Microsoft.Maps.MapControl.WPF;
using WpfApplication1.ViewModels.Tools;

namespace WpfApplication1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ICommand _search;
        public event PropertyChangedEventHandler PropertyChanged;
        private double _lon;
        private double _lat;
        private double _dist;
        private string _code;
        private Location _center;
        private double _zoom;
        private readonly IDataAccess _request1;
        private ICommand _displayLine;
        private readonly IDataAccess _request2;

        public ObservableCollection<BusStop> BusStopList { get; set; }
        public ObservableCollection<Location> BusStopArroundMe { get; set; }
        public ObservableCollection<Location> MyPosition { get; set; }
        public LocationCollection Line { get; set; }

        public MainViewModel()
        {
            _lon = 5.731181509376984;
            _lat = 45.18486504179179;
            _dist = 300;
            _code = "SEM:13";
            _center = new Location(Lat, Lon);
            _zoom = 13;
            _request1 = new MetroData();
            _request2 = new MetroData();
            BusStopList = new ObservableCollection<BusStop>();
            BusStopArroundMe = new ObservableCollection<Location>();
            MyPosition = new ObservableCollection<Location>();
            Line = new LocationCollection();
        }

        public ICommand Search
        {
            get => _search ?? (_search = new RelayCommand(NewRequest, CanDoNewRequest));
            set
            {
                if (value != null)
                {
                    _search = value;
                }
            }
        }

        private bool CanDoNewRequest(object arg)
        {
            return true;
        }

        public ICommand DisplayLine
        {
            get => _displayLine ?? (_displayLine = new RelayCommand(DisplayLineExe, CanDisplayLineExe));
            set
            {
                if (value != null)
                {
                    _displayLine = value;
                }
            }
        }

        private bool CanDisplayLineExe(object arg)
        {
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            // Autre syntaxe
            // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public double Lon
        {
            get => _lon;
            set
            {
                _lon = value;
                OnPropertyChanged("Lon");
            }
        }

        public double Lat
        {
            get => _lat;
            set
            {
                _lat = value;
                OnPropertyChanged("Lat");
            }
        }

        public double Dist
        {
            get => _dist;
            set
            {
                _dist = value;
                OnPropertyChanged("Dist");
            }
        }

        public string Code
        {
            get => _code;
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }

        public Location Center
        {
            get { return _center; }
            set
            {
                _center = value;
                OnPropertyChanged("Center");
            }
        }

        public double Zoom
        {
            get => _zoom;
            set
            {
                _zoom = value;
                OnPropertyChanged("Zoom");
            }
        }

        private void NewRequest(object obj)
        {
            MyPosition.Clear();
            BusStopList.Clear();
            BusStopArroundMe.Clear();

            MyPosition.Add(new Location(Lat, Lon));
            Center = new Location(Lat, Lon);
            Zoom = Scale(Dist);

            List<BusStop> busStopArroundMe = _request1.GetBusStopArroundMe(Lon, Lat, Dist);
            foreach (var busStop in busStopArroundMe)
            {
                BusStopList.Add(busStop);
                BusStopArroundMe.Add(new Location(busStop.lat, busStop.lon));
            }
        }

        private void DisplayLineExe(object obj)
        {
            Line.Clear();
            Line lineinfo = _request2.GetLineInfo(Code);
            foreach (var feature in lineinfo.features)
            {
                foreach (var coordinateSet in feature.geometry.coordinates)
                {
                    foreach (var coordinate in coordinateSet)
                    {
                        Line.Add(new Location(coordinate[1], coordinate[0]));
                    }
                }
            }

            Zoom = 12;
            Center = LineCenter(Line);
        }

        private Location LineCenter(LocationCollection Line)
        {
            double startLat = Line.First().Latitude;
            double startLon = Line.First().Longitude;
            double endLat = Line.Last().Latitude;
            double endLon = Line.Last().Longitude;
            double lati = (startLat + endLat) / 2;
            double longi = (endLon + startLon) / 2;
            return new Location(lati, longi);
        }

        private double Scale(double dist)
        {
            double val = 13;
            if (dist <= 500)
            {
                val = 17.5;
            }
            else if (dist > 500 && dist <= 1000)
            {
                val = 15.4;
            }
            else if (dist > 1000 && dist <= 1500)
            {
                val = 14.7;
            }
            else if (dist > 1500)
            {
                val = 14.3;
            }

            return val;
        }
    }
}