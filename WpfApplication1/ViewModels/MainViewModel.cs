using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WpfApplication1.Commands;
using ClassLibrary1;
using Microsoft.Maps.MapControl.WPF;

namespace WpfApplication1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ICommand _search;
        public event PropertyChangedEventHandler PropertyChanged;
        private double _lon;
        private double _lat;
        private double _dist;
        private FormatData _request1;
        public ObservableCollection<BusStop> BusStopList { get; set; }
        public ObservableCollection<Location> BusStopArroundMe { get; set; }

        public MainViewModel()
        {
            _lon = 5.731181509376984;
            _lat = 45.18486504179179;
            _dist = 0;
            _request1 = new FormatData();
            BusStopList = new ObservableCollection<BusStop>();
            BusStopArroundMe = new ObservableCollection<Location>();
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

        private bool CanDoNewRequest(object arg)
        {
            return true;
        }

        private void NewRequest(object obj)
        {
            BusStopList.Clear();
            BusStopArroundMe.Clear();
            List<BusStop> busStopArroundMe = _request1.GetBusStopArroundMe(_lon, _lat, _dist);
            foreach (var busStop in busStopArroundMe)
            {
                BusStopList.Add(busStop);
                BusStopArroundMe.Add(new Location(busStop.lat, busStop.lon));
            }
        }

        // private void MapWithPushpins_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}