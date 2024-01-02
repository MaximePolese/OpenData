using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenData
{
    public class FormatData
    {
        private List<Ligne> _lineList;
        private readonly IRequest _newRequest;

        public FormatData()
            : this(new Request(5.731181509376984, 45.18486504179179, 0))
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