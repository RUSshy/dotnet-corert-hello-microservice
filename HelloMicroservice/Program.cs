using System;
using System.IO;
using System.Net;

namespace HelloMicroservice
{
    struct Route
    {
        public string name;
        public string method;
        public string pattern;
        public Action<HttpListenerResponse> handlerFunc;
    }
    
    class Program
    {
        private static Route[] routes = new[]
        {
            new Route()
            {
                name = "GetStatusEndpoint",
                method = "GET",
                pattern = "/status",
                handlerFunc = Handlers.getStatusEndpoint
            }, 
        };
        
        static void Main(string[] args)
        {
            using var listener = new HttpListener();
            
            listener.Prefixes.Add("http://localhost:8080/");

            listener.Start();

            for (;;)
            {
                Console.WriteLine("Listening...");

                var context = listener.GetContext();
                var request = context.Request;

                for (int i = 0; i < routes.Length; i++)
                {
                    ref var route = ref routes[i];
                    if (route.method == request.HttpMethod && route.pattern == request.RawUrl)
                    {
                        Logger.logApi(request, route.name);
                        route.handlerFunc.Invoke(context.Response);
                    }
                }
            }
        }
    }
}