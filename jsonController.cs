using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace currencyPriceChecker
{
    public class jsonController
    {
        internal static string getValFromJson(string json)
        {
            if (JSONChecker.IsValidJson(json) == true | JSONChecker.IsValidJson(json.Replace("[", "").Replace("]", "")) == true)
            {
                if (json.Length > 80)
                {
                    CurResponse response = JsonConvert.DeserializeObject<CurResponse>(json);
                    return $"Price is: {response.Rates[0].price} PLN";
                }
                else
                {
                    GldResponse response = JsonConvert.DeserializeObject<GldResponse>(json.Replace("[", "").Replace("]", ""));
                    return $"Price is: {response.price} PLN";
                }
            }
            else
            {
                return $"RAW OUTPUT BECOUSE API RESPONDED BAD DATA FORMAT OR DATA NOT FOUND / BAD REQUEST  -> {json}";
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

    public class JSONChecker
    {
        public static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
