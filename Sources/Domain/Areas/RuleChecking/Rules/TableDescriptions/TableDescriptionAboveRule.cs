using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.TableDescriptions
{
    public class TableDescriptionAboveRule : IRule
    {
        private const string RuleName = "Table descriptions above";

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            var tableDescsNotAbove = document
                .Tables
                .Where(f => f.Description.Position != Position.Above)
                .ToList();

            if (tableDescsNotAbove.Any())
            {
                var str = string.Join(", ", tableDescsNotAbove.Select(f => f.Description.PlainDescription));

                return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, str));
            }

            return Task.FromResult(RuleCheckResult.CreatePassed(RuleName));
        }
    }
}