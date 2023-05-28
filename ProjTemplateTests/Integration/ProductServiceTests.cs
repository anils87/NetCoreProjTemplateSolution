using ApprovalTests;
using ApprovalTests.Reporters;
using Moq;
using Newtonsoft.Json;
using ProjTemplateCommon.DTOs;
using ProjTemplateData;
using ProjTemplateData.Entities;
using ProjTemplateService;
using ProjTemplateTests.TestConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateTests.Integration
{
    [Collection(TestFixtureConstants.IntegrationTestCollection)]
    [UseReporter(typeof(DiffReporter))]
    public class ProductServiceTests : IntegrationTestProcessorBase
    {
        public ProductServiceTests(IntegrationTestFixture integrationTestFixture): base(integrationTestFixture)
        {

        }
        // This pattern is mix of xUnit , mock and diff reporter which compare the json files stored as approval
        [Fact]
        public async Task GetAllProducts_ReturnList()
        {
            //Arrange
            var productList = new List<Product>()
            { 
                new Product { Id = 1,ProductName="Product 1",CategoryId=1,IsActive=1,CreatedBy=1,CreatedDate=DateTime.Now,ModifiedBy=1,ModifiedDate=DateTime.Now},
                new Product { Id = 2,ProductName="Product 2",CategoryId=2,IsActive=1,CreatedBy=1,CreatedDate=DateTime.Now,ModifiedBy=1,ModifiedDate=DateTime.Now}
            };
            var productRepositoryMock = _ReplaceWithMock<IProductRepository>();
            productRepositoryMock.Setup(x => x.GetAllProducts()).ReturnsAsync(productList);

            //Act
            var productService = _integrationTestFixture.GetApplicationService<IProductService>();
            var response = await productService.GetAllProducts();

            //Assert
            Approvals.Verify(JsonConvert.SerializeObject(response,Formatting.Indented));
        }
        
        // This test case is purely written using xUnit & mock pattern - latest one and faster
        [Fact]
        public async Task GetAllProducts_ReturnList_UsingMock()
        {
            //Arrange
            var productList = new List<Product>()
            {
                new Product { Id = 1,ProductName="Product 1",CategoryId=1,IsActive=1,CreatedBy=1,CreatedDate=DateTime.Now,ModifiedBy=1,ModifiedDate=DateTime.Now},
                new Product { Id = 2,ProductName="Product 2",CategoryId=2,IsActive=1,CreatedBy=1,CreatedDate=DateTime.Now,ModifiedBy=1,ModifiedDate=DateTime.Now}
            };
            var productRepositoryMock = _ReplaceWithMock<IProductRepository>();
            productRepositoryMock.Setup(x => x.GetAllProducts()).ReturnsAsync(productList);

            //Act
            var productService = _integrationTestFixture.GetApplicationService<IProductService>();
            var response = await productService.GetAllProducts();

            //Assert
            Assert.NotNull(response);
            Assert.Equal(2, response.Count);
        }
    }
}
