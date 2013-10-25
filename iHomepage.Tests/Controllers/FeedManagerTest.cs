using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iHomepage;
using iHomepage.Models;
using System.ServiceModel.Syndication;

namespace iHomepage.Tests.Controllers
{
    [TestClass]
    public class FeedManagerTest
    {
        [TestMethod]
        public void GetAllFeedsReturnsCorrectType()
        {

            iHomepageEntities context = new iHomepageEntities();

            // Arrange
            FeedManager fm = new FeedManager(context);

            // Act
            var feeds = fm.GetAllFeeds();

            // Assert
            Assert.IsNotNull(feeds);
            Assert.IsInstanceOfType(feeds, typeof(List<SyndicationFeed>));
        }

    }
}
