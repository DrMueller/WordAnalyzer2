using System;
using System.Net;

namespace Mmu.WordAnalyzer2.Domain.Areas.Rules.ExternalLinks
{
    internal class HeadWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var baseRequest = base.GetWebRequest(address);

            if (baseRequest != null)
            {
                baseRequest.Method = "HEAD";
            }

            return baseRequest;
        }
    }
}