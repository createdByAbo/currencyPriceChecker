using System;
using System.IO;
using System.Net;

namespace currencyPriceChecker
{
    class httpRequester
    {
        public static void getRequest(string currency)
        {
            try
            {
                WebRequest request = WebRequest.Create($"http://api.nbp.pl/api/exchangerates/rates/a/{currency}/last/1/?format=json");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                Console.WriteLine(jsonController.getValFromJson(responseFromServer).Rates[0].Mid);
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception e)
            {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error");
                Console.Write(e);
                Console.ResetColor();
            }
        }
    }
}
