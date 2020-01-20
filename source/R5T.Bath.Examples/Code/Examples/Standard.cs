using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Richmond;


namespace R5T.Bath.Examples
{
    static class Standard
    {
        public static void SubMain()
        {
            using (var serviceProvider = ServiceProviderBuilder.NewUseStartup<StandardStartup>() as ServiceProvider)
            {
                Program.SendHumanOutput(serviceProvider);
            }
        }
    }
}
