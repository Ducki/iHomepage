using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Syndication;

namespace iHomepage.Models
{
    public class ConfiguredFeed
    {
        public SyndicationFeed Feed { get; set; }
        public int DisplayColumn { get; set; }
        public int DisplayRow { get; set; }
    }


}
