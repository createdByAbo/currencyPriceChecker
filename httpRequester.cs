using System;
using System.IO;
using System.Net;

namespace currencyPriceChecker
{
    class httpRequester
    {
        public static void request(string currency)
        {
            WebRequest request = WebRequest.Create($"http://api.nbp.pl/api/exchangerates/rates/a/{currency}/last/1/?format=json");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}
