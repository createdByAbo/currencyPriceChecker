using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace currencyPriceChecker
{
    class httpRequester
    {
        static readonly HttpClient client = new HttpClient();
        internal static async void getRequest(string link)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(link);
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonController.getValFromJson(responseBody.Replace("[", "").Replace("]", "")));
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
