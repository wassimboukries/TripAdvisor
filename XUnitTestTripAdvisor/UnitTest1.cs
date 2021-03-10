using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SwaggerAPI.Controllers;
using System;
using Xunit;

namespace XUnitTestTripAdvisor
{
    public class UnitTest1
    {

        private Mock<LocationController>  _location;
        private Mock<TripAdvisorContext> _TripAdvisorContext;

        public UnitTest1(TripAdvisorContext TripAdvisorContext)
        {
            _TripAdvisorContext = new Mock<TripAdvisorContext>(TripAdvisorContext);
            _location = new Mock<LocationController>(TripAdvisorContext);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _location.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
