using System;
//TODO optimalize reapair returning mid value from api response 
namespace currencyPriceChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stop = false;
            while(!stop)
            {
                Console.WriteLine("Type currency code");
                httpRequester.getRequest(Console.ReadLine().ToLower());
                Console.WriteLine("you want to check next currency? /c to continue /s to stop");
                string userInput = Console.ReadLine();
                if (userInput == "/c")
                {
                    continue;
                }else if (userInput == "/s")
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
