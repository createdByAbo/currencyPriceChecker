using System; 
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
                Console.WriteLine(jsonController.getValFromJson(responseBody));
            }
            catch (Exception e)
            {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error");
                Console.Write(e.Message);
                Console.ResetColor();
            }
        }
    }
}
