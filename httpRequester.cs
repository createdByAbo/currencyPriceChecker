﻿using System; 
using System.Net.Http;

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
                    Console.WriteLine($"price is {jsonController.getValFromJson(responseBody.Replace("[", "").Replace("]", ""))} PLN");
                }
                else
                {
                    Console.WriteLine($"price is {jsonController.getValFromJson(responseBody)} PLN");
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
