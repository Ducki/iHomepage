using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel.Syndication;
using System.Xml;


namespace iHomepage.Controllers
{
    public class FeedController : Controller
    {
        //
        // GET: /Feed/
        public ActionResult Index()
        { 
            return View();
        }


        public JsonResult GetAllFeeds()
        {
            throw new NotImplementedException();
        }
	}
}