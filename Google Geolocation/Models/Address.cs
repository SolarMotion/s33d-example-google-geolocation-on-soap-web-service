using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Google_Geolocation.Models
{
    public class LongLatRequest
    {
        public string Address { get; set; }
    }

    public class LongLatResponse
    {
        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public bool ResponseFlag { get; set; }

        public string ResponseMessage { get; set; }
    }

    #region Google Geocoding Api

    public class GoogleGeoCodeResponse
    {
        public string status { get; set; }
        public results[] results { get; set; }
        public string error_message { get; set; }
    }

    public class results
    {
        public string formatted_address { get; set; }
        public geometry geometry { get; set; }
        public string[] types { get; set; }
        public address_component[] address_components { get; set; }
    }

    public class geometry
    {
        public string location_type { get; set; }
        public location location { get; set; }
    }

    public class location
    {
        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }

    public class address_component
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }

    #endregion
}