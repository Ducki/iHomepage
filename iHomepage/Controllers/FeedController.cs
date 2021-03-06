using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel.Syndication;
using System.Xml;
using iHomepage.Models;
using System.Web.Helpers;


namespace iHomepage.Controllers
{
    public class FeedController : Controller
    {

        iHomepage.Models.iHomepageEntities context = new Models.iHomepageEntities();

        //
        // GET: /Feed/
        public ActionResult Index()
        { 
            return View();
        }


        public JsonResult GetAllFeeds()
        {
            return Json(new FeedManager(context).GetAllFeeds(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllConfiguredFeeds()
        {
            FeedManager fm = new FeedManager(context);

            List<ConfiguredFeed> feeds = fm.GetConfiguredFeeds();

            return Json(feeds, JsonRequestBehavior.AllowGet);
        }
	}
}