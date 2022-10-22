using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Google_Geolocation.Models;
using RestSharp;
using Newtonsoft.Json;

namespace Google_Geolocation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Address" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Address.svc or Address.svc.cs at the Solution Explorer and start debugging.
    public class Address : IAddress
    {
        public string Heartbeat(string name)
        {
            return $"Hello, {name}";
        }

        public LongLatResponse GetLongLat(LongLatRequest request)
        {
            var response = new LongLatResponse();

            try
            {
                var googleResponseSuccess = "OK";
                var restsharpResponseSuccess = "OK";
                var googleApiKey = "AIzaSyAV4CujjrTlLS44LUQC3GmNabAu5mS-i2M";
                var googleGeocodingBaseUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=";
                var formattedAddress = request.Address.Replace(" ", "+");
                var googleGeocodingFinalUrl = $"{googleGeocodingBaseUrl}{formattedAddress}&key={googleApiKey}";

                var client = new RestClient(googleGeocodingFinalUrl);
                var apiRequest = new RestRequest();
                var apiResponse = client.Execute(apiRequest);

                if (apiResponse.StatusCode.ToString() == restsharpResponseSuccess && apiResponse.ErrorException == null)
                {
                    var googleResult = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(apiResponse.Content);
                    if (googleResult.status == googleResponseSuccess)
                    {
                        response.Latitude = googleResult.results == null ? 0 : googleResult.results.First().geometry.location.lat;
                        response.Longitude = googleResult.results == null ? 0 : googleResult.results.First().geometry.location.lng;
                        response.ResponseFlag = true;
                    }
                    else // calling Google geocoding api result fail
                    {
                        response.ResponseMessage = "Api fail.";
                        // log the googleResult.error_message

                    }
                }
                else // RestSharp fail
                {
                    response.ResponseMessage = "Plugin fail.";
                    // log the apiResponse.ErrorException
                }
            }
            catch (Exception ex)
            {
                throw;
				// log the exception
            }         

            return response;
        }

    }
}
