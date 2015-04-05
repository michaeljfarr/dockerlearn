using System.Collections.Generic;
using Umbraco.Core.Configuration.UmbracoSettings;

namespace Herolab.Umbraco
{
    public class DistributedCallSection : IDistributedCallSection
    {
        public DistributedCallSection()
        {
            Servers = new List<IServer>();
        }
        public bool Enabled { get; }
        public int UserId { get; }
        public IEnumerable<IServer> Servers { get; }
    }
}