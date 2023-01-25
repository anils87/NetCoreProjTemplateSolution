using Microsoft.Extensions.Logging;
using ProjTemplateCommon.BaseClasses;
using ProjTemplateCommon.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateService
{
    public abstract class ServiceBase<T> : CommonBase
    {
        private readonly IServiceDependencies _commonServiceDependencies;
        //private readonly ILogger<ILogger> _logger;
        protected ServiceBase(IServiceDependencies commonServiceDependencies,ILogger<T> logger) : base(logger)
        {
            _commonServiceDependencies =  commonServiceDependencies;          
        }
        protected virtual IMappingEngine Mapper { get => _commonServiceDependencies.Mapper; }
    }
}
