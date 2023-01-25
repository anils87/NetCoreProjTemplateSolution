using ProjTemplateCommon.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateService
{
    public interface IProductService
    {
        
        Task<List<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);        
        Task<bool> SaveProduct(ProductDTO productDTO);
        Task<bool> DeleteProduct(int id);
        
    }
}
