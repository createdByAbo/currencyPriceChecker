using System;
using System.IO;
using System.Net;

namespace currencyPriceChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            httpRequester.request(Console.ReadLine());
        }
    }
}
