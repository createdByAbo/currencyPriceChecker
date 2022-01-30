using System;
using System.Collections.Generic;
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
                if (responseBody[0] == '[' && responseBody[responseBody.Length - 1] == ']')
                {
                    Console.WriteLine(jsonController.getValFromJson(responseBody.Replace("[", "").Replace("]", "")));
                }
                else
                {
                    Console.WriteLine(jsonController.getValFromJson(responseBody));
                }
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
