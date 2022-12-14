using BLL.DTO.Response;
using ConsumerAPI.Controllers.Realizations;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerCatalogTests.TestConsumerController
{
    public class ConsumerControllerTests
    {
        private readonly ConsumerController Controller;
        private readonly ConsumerServiceFake Service;

        public ConsumerControllerTests()
        {
            Service = new ConsumerServiceFake();
            Controller = new ConsumerController(Service);
            
        }

        [Fact]
        public void GetById_UnknownId_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = Controller.GetConsumerById(100);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        /*[Fact]
        public void GetById_ExistingId_ReturnsItem()
        {
            // Arrange
            var testId = 1;
            // Act
            var okResult = Controller.GetConsumerById(testId) as OkObjectResult;
            // Assert
            Assert.IsType<ConsumerResponse>(okResult.Value) ;
            Assert.Equal(testId, (okResult.Value as ConsumerResponse).Id);
        }*/
    }
}