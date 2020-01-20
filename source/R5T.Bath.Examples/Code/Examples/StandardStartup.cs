using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Bath.Standard;
using R5T.Richmond;


namespace R5T.Bath.Examples
{
    class StandardStartup : StartupBase
    {
        public StandardStartup(ILogger<StandardStartup> logger)
            : base(logger)
        {
        }

        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services.AddHumanOutput();
        }
    }
}
