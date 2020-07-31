using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace HelloMicroservice
{
    public class Handlers
    {
        struct Status
        {
            public string msg;
            public string version;

            public byte[] serialize()
            {
                var options = new JsonWriterOptions
                {
                    Indented = true
                };

                using var stream = new MemoryStream();
                using var writer = new Utf8JsonWriter(stream, options);
                
                writer.WriteStartObject();
                writer.WriteString("msg", msg);
                writer.WriteString("version", version);
                writer.WriteEndObject();

                return stream.ToArray();
            }
        }
        
        
        public static void getStatusEndpoint(HttpListenerResponse response)
        {
            Console.WriteLine("=> GetStatusEndpoint");
            
            var status = new Status();
            status.msg = "Hello World CoreRT";
            status.version = "1.0.1";
            
            var buffer = status.serialize();
            
            response.ContentLength64 = buffer.Length;
            var output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
        }
    }
}