using System;

using R5T.Richmond;


namespace R5T.Bath.Examples
{
    public static class ConsoleStandard
    {
        public static void SubMain()
        {
            var serviceProvider = ServiceProviderBuilder.NewUseStartup<ConsoleStandardStartup>();

            Program.SendHumanOutput(serviceProvider);
        }
    }
}
