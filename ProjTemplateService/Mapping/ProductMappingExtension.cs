using ProjTemplateCommon.DTOs;
using ProjTemplateData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateService.Mapping
{
    public static class ProductMappingExtension
    {
        public static void SetDefaultAudit(this Product product)
        {   
            product.CreatedBy = 1;
            product.CreatedDate = DateTime.Now;
            product.ModifiedBy = 1;
            product.ModifiedDate = DateTime.Now;
        }
    }
}
