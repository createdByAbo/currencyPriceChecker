using System;
namespace currencyPriceChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Type currency code / gld for gold");
                string currency = Console.ReadLine().ToLower();
                if (currency == "gld")
                {
                    httpRequester.getRequest("http://api.nbp.pl/api/cenyzlota/?format=json");
                }
                else
                {
                    httpRequester.getRequest($"http://api.nbp.pl/api/exchangerates/rates/a/{currency}/last/1/?format=json");
                }
                Console.WriteLine("you want to check next currency? /c to continue /s to stop");
                string userInput = Console.ReadLine();
                if (userInput == "/c")
                {
                    continue;
                }
                else if (userInput == "/s")
                {
                    stop = true;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Beep();
                    Console.WriteLine("error");
                    Console.ResetColor();
                }
            }
        }
    }
}
