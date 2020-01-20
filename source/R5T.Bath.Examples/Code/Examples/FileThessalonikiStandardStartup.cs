using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Bath.File;
using R5T.Bath.File.Default;
using R5T.Bath.File.Thessaloniki.Standard;
using R5T.Lombardy;
using R5T.Richmond;


namespace R5T.Bath.Examples
{
    class FileThessalonikiStandardStartup : StartupBase
    {
        public FileThessalonikiStandardStartup(ILogger<FileThessalonikiStandardStartup> logger)
            : base(logger)
        {
        }

        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services
                .AddSingleton<IHumanOutput, FileHumanOutput>()
                .AddHumanOutputFilePathProvider_TemporaryDirectoryBased<SpecifiedHumanOutputFileNameProvider, StringlyTypedPathOperator>()
                .AddSingleton<IHumanOutputFileNameProvider, SpecifiedHumanOutputFileNameProvider>(serviceProvider =>
                {
                    var specifiedHumanOutputFileNameProvider = new SpecifiedHumanOutputFileNameProvider("The Human Output File.txt");
                    return specifiedHumanOutputFileNameProvider;
                })
                ;
        }
    }
}
