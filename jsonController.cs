using System;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json;

namespace currencyPriceChecker
{
    class jsonController
    {
        public Response getValFromJson(string json)
        {
            Response response = JsonConvert.DeserializeObject<Response>(json);
            return response;
        }
    }
    public class Response
    {
        public string table { get; set; }
        public string currency { get; set; }
        public string code { get; set; }
        public IList<string> rates { get; set; }
    }
}
