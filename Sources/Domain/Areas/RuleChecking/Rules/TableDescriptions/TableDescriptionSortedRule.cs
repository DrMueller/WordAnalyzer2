using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.TableDescriptions
{
    public class TableDescriptionSortedRule : IRule
    {
        public const string TablePrefix = "Tabelle";
        private const string RuleName = "Tables sorted";

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            var wrongDescriptions = new List<string>();

            for (var i = 1; i <= document.Tables.Count; i++)
            {
                var table = document.Tables.ElementAt(i - 1);
                var expectedTableprefix = $"{TablePrefix} {i}";

                if (!table.Description.PlainDescription.StartsWith(expectedTableprefix))
                {
                    wrongDescriptions.Add(table.Description.PlainDescription);
                }
            }

            if (wrongDescriptions.Any())
            {
                var str = string.Join(", ", wrongDescriptions);

                return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, str));
            }

            return Task.FromResult(RuleCheckResult.CreatePassed(RuleName));
        }
    }
}