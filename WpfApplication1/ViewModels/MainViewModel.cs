using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WpfApplication1.Commands;
using ClassLibrary1;
using Microsoft.Maps.MapControl.WPF;

namespace WpfApplication1.ViewModels
{
    public class MainViewModel
    {
        public ICommand Search { get; set; }
        public ObservableCollection<BusStop> ShowData { get; set; }
        private double _lon;
        private double _lat;
        private double _dist;
        // private FormatData request1;
        // public ObservableCollection<Pushpin> Pin { get; set; }
        // public ObservableCollection<Line> Line { get; set; }

        public double Lon
        {
            get => _lon;
            set => _lon = value;
        }

        public double Lat
        {
            get => _lat;
            set => _lat = value;
        }

        public double Dist
        {
            get => _dist;
            set => _dist = value;
        }

        public MainViewModel()
        {
            Search = new RelayCommand(NewRequest, CanDoNewRequest);
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
            FormatData request1 = new FormatData();
            string url = request1.BusStopArroundMe(_lon, _lat, _dist);
            string json = request1.GetData(url);
            List<BusStop> busStopArroundMe = request1.DeserializeBusStopData(json);
            foreach (var busStop in busStopArroundMe)
            {
                ShowData.Add(busStop);
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
        }
    }
}