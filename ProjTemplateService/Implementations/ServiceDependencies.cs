using ProjTemplateCommon.BaseClasses;
using ProjTemplateCommon.Mapping;
using ProjTemplateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateService.Implementations
{
    [Injectible]
    public class ServiceDependencies : IServiceDependencies
    {
        public ServiceDependencies(IMappingEngine mapper, IProductRepository productRepository)
        {
            Mapper = mapper;
            ProductRepository = productRepository;
        }

        public IMappingEngine Mapper { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
    }
}
