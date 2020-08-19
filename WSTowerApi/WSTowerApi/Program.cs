using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WsTowerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            string nome = Dns.GetHostName();

            IPAddress[] ip = Dns.GetHostAddresses(nome);
            return WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://" + ip[5] + ":5000;https://" + ip[5] + ":5001;")
            .UseStartup<Startup>();
        }
    }
}
