using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iHomepage;
using iHomepage.Controllers;

namespace iHomepage.Tests.Controllers
{
    [TestClass]
    public class FeedControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            FeedController controller = new FeedController();

            // Act
            JsonResult result = controller.GetAllConfiguredFeeds() as JsonResult;

            // Assert
            Assert.IsNotNull(result);
        }


    }
}
