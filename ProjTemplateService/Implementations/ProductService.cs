using Microsoft.Extensions.Logging;
using ProjTemplateCommon.BaseClasses;
using ProjTemplateCommon.DTOs;
using ProjTemplateData;
using ProjTemplateData.Entities;
using ProjTemplateService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateService
{
    [Injectible]
    public class ProductService : ProductServiceBase<ProductService>, IProductService
    {
        #region Private Variables        
        #endregion

        #region Constructor
        public ProductService(IServiceDependencies serviceDependencies,ILogger<ProductService> logger,ICommonServiceDependencies commonServiceDependencies) : base(serviceDependencies,logger,commonServiceDependencies)
        {
        
        }
        
        #endregion

        #region Methods
        
        public async Task<bool> DeleteProduct(int id)
        {
            var existingProduct =await _productRepository.GetProductByID(id);
            if (existingProduct == null)
                throw new ApplicationException("Invalid Product Id");

            return await _productRepository.DeleteProduct(existingProduct);
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            if (products == null)
                throw new ApplicationException($"Product List is not available");

            return (List<ProductDTO>) Mapper.MapToList<ProductDTO>(products);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _productRepository.GetProductByID(id);
            if (product == null)
                throw new ApplicationException($"Invalid Product Id");

            return (ProductDTO)Mapper.MapTo<ProductDTO>(product);
        }

        public async Task<bool> SaveProduct(ProductDTO productDTO)
        {
            if (productDTO == null)
                throw new ApplicationException($"Product values cannot be null");

            if (productDTO.Id > 0)
            {
                var existingProduct = await _productRepository.GetProductByID(productDTO.Id);
                if(existingProduct == null)
                    throw new ArgumentNullException("Invalid Product Id");
                return await _productRepository.UpdateProduct(Mapper.MapTo<Product>(productDTO));
            }
            else 
                return await _productRepository.InsertProduct(Mapper.MapTo<Product>(productDTO));

        }
        #endregion
    }
}
