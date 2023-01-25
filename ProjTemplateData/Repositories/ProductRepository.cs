using Microsoft.EntityFrameworkCore;
using ProjTemplateCommon.BaseClasses;
using ProjTemplateData;
using ProjTemplateData.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateData
{
    [Injectible]
    public class ProductRepository : IProductRepository
    {
        #region Private Variables
        private readonly ProjTemplateDboContext _projTemplateDboContext;
        #endregion

        #region Constructor
        public ProductRepository(ProjTemplateDboContext projTemplateDboContext)
        {
            _projTemplateDboContext = projTemplateDboContext;
        }
        #endregion

        #region Methods
        public async Task<bool> DeleteProduct(Product product)
        {
            if(product == null)
                throw new ArgumentNullException(nameof(product));
            _projTemplateDboContext.Products.Remove(product);
            return await _projTemplateDboContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Product>> GetAllProducts()
        {            
            return await _projTemplateDboContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByID(int Id)
        {
            return await _projTemplateDboContext.Products.FirstOrDefaultAsync(m=>m.Id == Id);
        }

        public async Task<bool> InsertProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            _projTemplateDboContext.Products.Add(product);
            return await _projTemplateDboContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            _projTemplateDboContext.Products.Update(product);
            return await _projTemplateDboContext.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
