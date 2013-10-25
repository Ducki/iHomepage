using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Xml;

namespace iHomepage.Models
{
    public class FeedManager
    {

        iHomepageEntities context;

        public FeedManager(iHomepageEntities context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns a list of SyndicationFeed objects of all feeds in database
        /// </summary>
        /// <returns>List<SyndicationFeed></returns>
        public List<SyndicationFeed> GetAllFeeds()
        {
            var dbFeeds = context.Feeds.ToList();

            List<SyndicationFeed> feeds = new List<SyndicationFeed>();

            foreach (var item in dbFeeds)
            {
                XmlReader xmlfeed = XmlReader.Create(item.Uri);

                feeds.Add(SyndicationFeed.Load(xmlfeed));
            }            

            return feeds;
        }


        public List<ConfiguredJsonFeed> GetConfiguredJsonFeeds()
        {

            var dbFeeds = context.Feeds.ToList();

            List<ConfiguredJsonFeed> JsonFeeds = new List<ConfiguredJsonFeed>();

            foreach (var feed in dbFeeds)
            {

                XmlReader xmlfeed = XmlReader.Create(feed.Uri);

                SyndicationFeed sf = SyndicationFeed.Load(xmlfeed);

                ConfiguredJsonFeed jsonFeed = new ConfiguredJsonFeed()
                {
                    DisplayColumn = (int)feed.DisplayColumn,
                    DisplayRow = (int)feed.DisplayRow,
                    FeedItems = sf.Items.Take((int)feed.DisplayItemCount).ToList()
                };

                JsonFeeds.Add(jsonFeed);
            }

            return JsonFeeds;
        }
    }
}