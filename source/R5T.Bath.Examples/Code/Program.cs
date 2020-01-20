using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;



namespace R5T.Bath.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleStandard.SubMain();
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
    }
}
