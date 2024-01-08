using System.Collections.Generic;

namespace ClassLibrary1
{
    public interface IDataAccess
    {
        List<BusStop> GetBusStopArroundMe(double lon, double lat, double dist);

        Line GetLineInfo(string lineCode);
    }
}