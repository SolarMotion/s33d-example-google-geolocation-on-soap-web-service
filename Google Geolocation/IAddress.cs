using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Google_Geolocation.Models;

namespace Google_Geolocation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAddress" in both code and config file together.
    [ServiceContract]
    public interface IAddress
    {
        [OperationContract]
        string Heartbeat(string name);

        [OperationContract]
        LongLatResponse GetLongLat(LongLatRequest request);
    }
}
