using ProjTemplateCommon.Mapping;
using ProjTemplateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateService
{
    public interface IServiceDependencies
    {
        IMappingEngine Mapper { get; }
        IProductRepository ProductRepository { get; }
    }
}
