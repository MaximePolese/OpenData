﻿using System;
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
        private Location _center;
        private double _zoom;
        private readonly IDataAccess _request1;

        public ObservableCollection<BusStop> BusStopList { get; set; }
        public ObservableCollection<Location> BusStopArroundMe { get; set; }
        public ObservableCollection<Location> MyPosition { get; set; }

        public MainViewModel()
        {
            _lon = 5.731181509376984;
            _lat = 45.18486504179179;
            _dist = 300;
            _zoom = 13;
            _center = new Location(Lat, Lon);
            _request1 = new MetroData();
            BusStopList = new ObservableCollection<BusStop>();
            BusStopArroundMe = new ObservableCollection<Location>();
            MyPosition = new ObservableCollection<Location>();
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

        private bool CanDoNewRequest(object arg)
        {
            return true;
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
            else if (dist > 1500 && dist <= 2000)
            {
                val = 14.3;
            }
            return val;
        }
    }
}