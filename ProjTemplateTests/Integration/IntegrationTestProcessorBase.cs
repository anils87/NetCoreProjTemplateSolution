using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateTests.Integration
{
    public abstract class IntegrationTestProcessorBase : IClassFixture<IntegrationTestFixture>
    {
        protected readonly IntegrationTestFixture _integrationTestFixture;
        private readonly List<string> _serviceMocks = new List<string>();
        

        protected IntegrationTestProcessorBase(IntegrationTestFixture integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;            
        }

        public Mock<T> _ReplaceWithMock<T>() where T : class
        {
            var mockService = new Mock<T>();
            _integrationTestFixture._services.AddSingleton(mockService.Object);
            _serviceMocks.Add(typeof(T).Name);
            return mockService;
        }
        protected T GetApplicationService<T>() where T : class
        => _integrationTestFixture.GetApplicationService<T>();
        
    }
}
