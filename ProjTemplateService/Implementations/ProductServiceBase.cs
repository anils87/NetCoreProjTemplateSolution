using Microsoft.Extensions.Logging;
using ProjTemplateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateService
{
    public abstract class ProductServiceBase<T>: ServiceBase<T>
    {        
        protected readonly IProductRepository _productRepository;
        protected ProductServiceBase(IServiceDependencies serviceDependencies, ILogger<T> logger,ICommonServiceDependencies commonServiceDependencies) : base(serviceDependencies, logger)
        {
            _productRepository = commonServiceDependencies.ProductRepository;
        }
        
    }
}
