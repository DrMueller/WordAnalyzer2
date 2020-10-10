using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.Rules.ExternalLinks
{
    public class ExternalLinksRule : IRule
    {
        private const string RuleName = "External Links";

        public async Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            using var webClient = new HeadWebClient();

            var invalidUris = new List<Uri>();

            foreach (var link in document.ExternalHyperLinks)
            {
                try
                {
                    await webClient.DownloadDataTaskAsync(link.Uri);
                }
                catch (WebException)
                {
                    invalidUris.Add(link.Uri);
                }
            }

            if (!invalidUris.Any())
            {
                return RuleCheckResult.CreatePassed(RuleName);
            }

            var missingUrls = string.Join(", ", invalidUris.Select(f => f.AbsoluteUri));

            return RuleCheckResult.CreateFailure(RuleName, missingUrls);
        }
    }
}