using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace aa_time_1 {

    public class Program {

        public static async
        Task Main(string[] args) {
            await Atividade1.Executar();
            Atividade2.Executar();

            CreateHostBuilder(args).Build().Run();
        } // Main


        public static
        IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        // CreateHostBuilder

    } // Program

} // namespace aa_time_1
