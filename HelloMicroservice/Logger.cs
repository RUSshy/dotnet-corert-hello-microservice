using System;
using System.Net;

namespace HelloMicroservice
{
    public class Logger
    {
        public static void logApi(HttpListenerRequest request, string name)
        {
            Console.WriteLine("--- REQUEST ---");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Total Length: {request.ContentLength64}");
            Console.WriteLine($"MethodMethod: {request.HttpMethod}");
            Console.WriteLine($"URL: {request.RawUrl}");
            Console.WriteLine("---------------");
        }
    }
}