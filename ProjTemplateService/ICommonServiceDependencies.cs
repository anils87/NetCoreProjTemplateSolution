using ProjTemplateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateService
{
    public interface ICommonServiceDependencies
    {
        IProductRepository ProductRepository { get; }
    }
}
