using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Bath.File.Standard;
using R5T.Richmond;


namespace R5T.Bath.Examples
{
    class FileStandardStartup : StartupBase
    {
        public FileStandardStartup(ILogger<FileStandardStartup> logger)
            : base(logger)
        {
        }

        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services.AddFileHumanOutput();
        }
    }
}
