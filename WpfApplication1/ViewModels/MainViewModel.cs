using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApplication1.Commands;
using ClassLibrary1;

namespace WpfApplication1.ViewModels
{
    public class MainViewModel
    {
        public ICommand Search { get; set; }
        public ObservableCollection<FormatData> ShowData { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double Dist { get; set; }

        public MainViewModel()
        {
            Search = new RelayCommand(NewRequest, CanDoNewRequest);
            
        }

        private bool CanDoNewRequest(object arg)
        {
            return true;
        }

        private void NewRequest(object obj)
        {
            FormatData newRequest = new FormatData(Lon, Lat, Dist);
            ShowData = new ObservableCollection<FormatData>(newRequest.LinesList);
        }
        // double lon = 5.731181509376984;
        // double lat = 45.18486504179179;
        // double dist = 0;
    }
}