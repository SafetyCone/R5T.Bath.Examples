using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Bath.File;
using R5T.Bath.File.Chamavia.Standard;
using R5T.Lombardy;
using R5T.Richmond;


namespace R5T.Bath.Examples
{
    class FileChamaviaStandardStartup : StartupBase
    {
        public FileChamaviaStandardStartup(ILogger<FileChamaviaStandardStartup> logger)
            : base(logger)
        {
        }

        protected override void ConfigureConfigurationBody(IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            configurationBuilder.AddJsonFile("appsettings.json");
        }

        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services
                .AddSingleton<IHumanOutput, FileHumanOutput>()
                .AddHumanOutputFilePathProvider_DirectConfigurationBased<StringlyTypedPathOperator>()
                ;
        }
    }
}
