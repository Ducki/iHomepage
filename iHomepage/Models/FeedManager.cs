using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns list of ConfiguredFeed objects, which contain config options from database
        /// </summary>
        /// <returns>List<ConfiguredFeed></returns>
        public List<SyndicationFeed> GetConfiguredFeeds()
        {
            var dbFeeds = context.Feeds.ToList();

            List<SyndicationFeed> feeds = new List<SyndicationFeed>();

            var httpClient = new HttpClient();

            var tasks = dbFeeds.Select(dbfeed => httpClient.GetStringAsync(dbfeed.Uri)
                                    .ContinueWith(task =>
                                    {
                                        using (TextReader reader = new StringReader(task.Result))
                                        {
                                            XmlReader xmlfeed = XmlReader.Create(reader);

                                            SyndicationFeed sfeed = SyndicationFeed.Load(xmlfeed);

                                            sfeed.Items = sfeed.Items.Take((int)dbfeed.DisplayItemCount);

                                            feeds.Add(sfeed);
                                        }

                                        return task.Result;
                                    }));

            Task.WaitAll(tasks.ToArray());

            return feeds;
        }
    }
}