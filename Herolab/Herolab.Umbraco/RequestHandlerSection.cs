using System.Collections.Generic;
using Umbraco.Core.Configuration.UmbracoSettings;

namespace Herolab.Umbraco
{
    public class RequestHandlerSection : IRequestHandlerSection
    {
        public RequestHandlerSection()
        {
            CharCollection = new List<IChar>();
        }
        public bool UseDomainPrefixes { get; }
        public bool AddTrailingSlash { get; }
        public bool RemoveDoubleDashes { get; }
        public bool ConvertUrlsToAscii { get; }
        public IEnumerable<IChar> CharCollection { get; }
    }
}