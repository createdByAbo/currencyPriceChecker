using System;
using Newtonsoft.Json;

namespace currencyPriceChecker
{
    public class jsonController
    {
        internal static Response getValFromJson(string json)
        {
            Response response = JsonConvert.DeserializeObject<Response>(json);
            return response;
        }
    }
    public partial class Response
    {
        [JsonProperty("table")]
        public string Table { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("rates")]
        public Rate[] Rates { get; set; }
    }

    public partial class Rate
    {
        [JsonProperty("no")]
        public string No { get; set; }

        [JsonProperty("effectiveDate")]
        public DateTimeOffset EffectiveDate { get; set; }

        [JsonProperty("mid")]
        public double Mid { get; set; }
    }
}
