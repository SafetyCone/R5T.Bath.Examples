﻿using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.Bath.Examples.Lib;
using R5T.Richmond;


namespace R5T.Bath.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program.TestDispose();

            //Program.SendHumanOutput<StandardStartup>();
            //Program.SendHumanOutput<ConsoleStandardStartup>();
            //Program.SendHumanOutput<FileStandardStartup>();
            //Program.SendHumanOutput<FileThessalonikiStandardStartup>();
            Program.SendHumanOutput<FileChamaviaStandardStartup>();

            //GC.WaitForFullGCComplete();
        }

        public static void SendHumanOutput(IServiceProvider serviceProvider)
        {
            var humanOutput = serviceProvider.GetRequiredService<IHumanOutput>();

            humanOutput.WriteLine("1. Line written synchronously");

            async Task DelayedWrite()
            {
                await Task.Delay(1000);

                await humanOutput.WriteLineAsync("2. Line written asynchronously.");
            }

            var task = DelayedWrite();

            humanOutput.WriteLine("3. Another line written synchronously.");

            task.Wait();
        }

        public static void SendHumanOutput<TStartup>()
            where TStartup: class, IStartup
        {
            using (var serviceProvider = ServiceProviderBuilder.NewUseStartup<TStartup>() as ServiceProvider)
            {
                Program.SendHumanOutput(serviceProvider);
            }
        }

        private static void TestDispose()
        {
            var serviceProvider = new ServiceCollection()
                //.AddTransient<ITestDisposable, TestDisposable>()
                //.AddSingleton<ITestDisposable, TestDisposable>()
                .AddSingleton<TestDisposable>()
                //.AddScoped<TestDisposable>()
                //.AddTransient<TestDisposable>()
                .BuildServiceProvider();

            //var testService = serviceProvider.GetRequiredService<ITestDisposable>();
            var testService = serviceProvider.GetRequiredService<TestDisposable>();

            testService.A();

            serviceProvider.Dispose();

            //using (var serviceScope = serviceProvider.CreateScope())
            //{
            //    //var testService = serviceScope.ServiceProvider.GetRequiredService<ITestDisposable>();
            //    var testService = serviceScope.ServiceProvider.GetRequiredService<TestDisposable>();

            //    testService.A();

            //    //serviceScope.Dispose();
            //}

            //GC.WaitForFullGCComplete();
        }
    }
}
