using Microsoft.AspNetCore.Mvc;
using ProjTemplateCommon.ApiResponse;
using ProjTemplateCommon.BaseClasses;
using ProjTemplateCommon.DTOs;
using ProjTemplateService;

namespace ProjTemplateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CommonSecureController
    {
        #region Private Variables
        private readonly IProductService _productService;
        
        #endregion

        #region Constructor
        public ProductController(IProductService productService , IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)   
        {
            _productService = productService;
            
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// This enpoint returns list of products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getproducts")]
        public async Task<ApiListResponseTyped<ProductDTO>> GetAllProducts()
        {
            //_logger.LogInformation("GetAllProducts Call started" + DateTime.Now);
            var products = await _productService.GetAllProducts();
            return ExecuteAndConvertToApiListResponse(() => { return products; });
        }

        /// <summary>
        /// This enpoint returns product detail by product id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getproduct/{id}")]
        public async Task<ApiItemResponseTyped<ProductDTO>> GetProductById([FromRoute] int id)
        {
            var product = await _productService.GetProductById(id);
            return ExecuteAndConvertToApiResponse(() => { return product; });
        }

        /// <summary>
        /// This enpoint delete product detail by product id
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ApiResponse> DeleteProductById([FromRoute] int id)
        {
            var product = await _productService.DeleteProduct(id);
            return ExecuteAndConvertToApiResponse(() => { return product; });
        }

        /// <summary>
        /// This enpoint save / update product detail
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("saveupdate")]
        public async Task<ApiResponse> SaveUpdateProductById([FromBody] ProductDTO productDTO)
        {
            var product = await _productService.SaveProduct(productDTO);
            return ExecuteAndConvertToApiResponse(() => { return product; });
        }
        #endregion
    }
}
