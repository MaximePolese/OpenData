using System;
using System.IO;
using System.Net;

namespace OpenData
{
    public class Request : IRequest
    {
        private WebRequest _newRequest;
        private HttpWebResponse _response;
        private Stream _dataStream;
        private StreamReader _reader;
        private string _responseFromServer;

        public void Connection()
        {
            _newRequest = newRequest;
            _response = Response;
            _dataStream = DataStream;
            _reader = Reader;
        }

        public void CloseConnection()
        {
            _reader.Close();
            _dataStream.Close();
            _response.Close();
        }

        public WebRequest newRequest
        {
            get => WebRequest.Create(
                "http://data.mobilites-m.fr/api/linesNear/json?x=5.731181509376984&y=45.18486504179179&dist=0&details=true");
        }

        public HttpWebResponse Response
        {
            get => (HttpWebResponse)_newRequest.GetResponse();
        }

        public Stream DataStream
        {
            get => _response.GetResponseStream();
        }

        public StreamReader Reader
        {
            get => new StreamReader(_dataStream);
        }

        public string ResponseFromServer
        {
            get => _reader.ReadToEnd();
        }
    }
}