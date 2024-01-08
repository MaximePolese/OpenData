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
        public ObservableCollection<BusStop> ShowData { get; set; }
        private FormatData request1;
        private double _lon;
        private double _lat;

        private double _dist;

        // private FormatData request1;
        // public ObservableCollection<Pushpin> Pin { get; set; }
        // public ObservableCollection<Line> Line { get; set; }
        public ICommand Search
        {
            get => _search ?? (_search = new RelayCommand(NewRequest, CanDoNewRequest));
            set
            {
                if (value != null) _search = value;
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
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
                _lon = value;
                OnPropertyChanged("Lat");
            }
        }

        public double Dist
        {
            get => _dist;
            set
            {
                _lon = value;
                OnPropertyChanged("Dist");
            }
        }

        public MainViewModel()
        {
            request1 = new FormatData();
            ShowData = new ObservableCollection<BusStop>();
            _lon = 5.731181509376984;
            _lat = 45.18486504179179;
            _dist = 0;
            // Pin = new ObservableCollection<Pushpin>();
        }

        private bool CanDoNewRequest(object arg)
        {
            return true;
        }

        private void NewRequest(object obj)
        {
            ShowData.Clear();
            List<BusStop> busStopArroundMe = request1.GetBusStopArroundMe(_lon, _lat, _dist);
            foreach (var busStop in busStopArroundMe)
            {
                ShowData.Add(busStop);
            }
        }
    }
}

// myPath = new Path();
// myPath.Stroke = System.Windows.Media.Brushes.Black;
// myPath.Fill = System.Windows.Media.Brushes.MediumSlateBlue;
// myPath.StrokeThickness = 4;
// myPath.HorizontalAlignment = HorizontalAlignment.Left;
// myPath.VerticalAlignment = VerticalAlignment.Center;
// EllipseGeometry myEllipseGeometry = new EllipseGeometry();
// myEllipseGeometry.Center = new System.Windows.Point(_lat,_lon);
// myEllipseGeometry.RadiusX = 25;
// myEllipseGeometry.RadiusY = 25;
// myPath.Data = myEllipseGeometry;
// myGrid.Children.Add(myPath);