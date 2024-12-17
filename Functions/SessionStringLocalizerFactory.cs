using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Functions.Localization
{
    public class SessionStringLocalizerFactory : IStringLocalizerFactory
    {
        private IHttpContextAccessor _httpContextAccesor;
        private IDistributedCache _cache;

        public SessionStringLocalizerFactory(IHttpContextAccessor context, IDistributedCache cache)
        {
            _httpContextAccesor = context;
            _cache = cache;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new SessionStringLocalizer(_httpContextAccesor, _cache);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new SessionStringLocalizer(_httpContextAccesor, _cache);
        }
    }
}
