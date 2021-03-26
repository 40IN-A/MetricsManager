using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class HddControllerUnitTest
    {
        private HddMetricsController controller;

        public HddControllerUnitTest()
        {
            controller = new HddMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var left = 0;
            
            //Act
            var result = controller.GetMetricsFromAgent(left);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
