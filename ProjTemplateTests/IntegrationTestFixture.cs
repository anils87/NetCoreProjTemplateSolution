using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using ProjTemplateCommon.ConfigClasses;
using ProjTemplateCommon.Enums;
using ProjTemplateCommon.Extensions;
using ProjTemplateCommon.Mapping;
using ProjTemplateData;
using ProjTemplateService;
using ProjTemplateService.Implementations;
using System.ComponentModel.Design;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;

namespace ProjTemplateTests
{
    public class IntegrationTestFixture
    {
        private readonly IConfiguration _config;
        private readonly bool _useInMemoryDatabase;
        public readonly IServiceCollection _services;
        //private readonly IServiceProvider serviceProvider;

        
        public IntegrationTestFixture()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _useInMemoryDatabase = true;
            _services = new ServiceCollection();

            AddDefaultServices();

            if (_useInMemoryDatabase)
            {
                _services.RemoveAll<ProjTemplateDboContext>()
                    .RemoveAll<DbContextOptions>();

                _services.AddDbContext<ProjTemplateDboContext>(opts =>
                {
                    opts.UseInMemoryDatabase("ProjTemplateDB");
                });
            }
        }
        public void AddDefaultServices()
        {
            _services.AddLogging(builder => builder.AddConsole());
            _services.AddSingleton<IConfiguration>(_config);
            _services.Configure<AppSettings>(_config.GetSection("AppSettings"));
            _services.UseProjTemplateServices(_config);
        }

        public T GetApplicationService<T>() where T : class 
        {
            var serviceProvider = _services.BuildServiceProvider();
            return serviceProvider.GetService<T>();
        }

    }
}