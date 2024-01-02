using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClassLibrary1
{
    public class FormatData
    {
        private List<Ligne> _lineList;
        private readonly IRequest _newRequest;

        public FormatData(double lon, double lat, double dist)
            : this(new Request(lon, lat, dist))
        {
        }

        public FormatData(IRequest newRequest)
        {
            _lineList = new List<Ligne>();
            _newRequest = newRequest;
        }

        public List<Ligne> DeserializeData()
        {
            _lineList = JsonConvert.DeserializeObject<List<Ligne>>(_newRequest.GetData());
            return _lineList;
        }
    }
}