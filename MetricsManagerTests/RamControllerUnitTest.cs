using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class RamControllerUnitTest
    {
        private RamMetricsController controller;

        public RamControllerUnitTest()
        {
            controller = new RamMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var available = 0;

            //Act
            var result = controller.GetMetricsFromAgent(available);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
