using ProjTemplateCommon.BaseClasses;
using ProjTemplateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateService
{
    [Injectible]
    public class CommonServiceDependencies : ICommonServiceDependencies
    {
        public CommonServiceDependencies(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }
        public IProductRepository ProductRepository { get; private set; }
    }
}
