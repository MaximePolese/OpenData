using System.Collections.Generic;

namespace OpenData
{
    public interface IRequest
    {
        List<Ligne> GetData();
    }
}