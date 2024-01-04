using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApplication1.Commands;
using ClassLibrary1;

namespace WpfApplication1.ViewModels
{
    public class MainViewModel
    {
        public ICommand Search { get; set; }
        public ObservableCollection<Ligne> ShowData { get; set; }
        private double _lon;
        private double _lat;
        private double _dist;
        private FormatData _newRequest;

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
            ShowData = new ObservableCollection<Ligne>();
            _lon = 5.731181509376984;
            _lat = 45.18486504179179;
            _dist = 0;
        }

        private bool CanDoNewRequest(object arg)
        {
            return true;
        }

        private void NewRequest(object obj)
        {
            _newRequest = new FormatData(_lon, _lat, _dist);
            List<Ligne> allLines = _newRequest.LinesList;
            foreach (var line in allLines)
            {
                ShowData.Add(line);
            }
        }
    }
}