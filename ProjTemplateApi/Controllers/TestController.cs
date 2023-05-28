using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjTemplateCommon.BaseClasses;
using ProjTemplateData;
using ProjTemplateService;

namespace ProjTemplateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : CommonSecureController
    {
        private readonly IProductService _productService;
        public TestController(IProductService productService,IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("test")]
        public string Test()
        {
            return "Hello";
        }
    }
}
