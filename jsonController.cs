using Newtonsoft.Json;
using System;

namespace currencyPriceChecker
{
    public class jsonController
    {
        internal static double getValFromJson(string json)
        {
            Console.WriteLine(json.Length);

            if (json.Length > 80)
            {
                CurResponse response = JsonConvert.DeserializeObject<CurResponse>(json);
                return response.Rates[0].price;
            }
            else
            {
                GldResponse response = JsonConvert.DeserializeObject<GldResponse>(json);
                return response.price;
            }
        }
    }
    public partial class CurResponse
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
        public double price { get; set; }
    }

    public partial class GldResponse
    {
        [JsonProperty("data")]
        public DateTimeOffset date { get; set; }
        [JsonProperty("cena")]
        public double price { get; set; }
    }
}
