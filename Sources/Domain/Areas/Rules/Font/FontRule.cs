using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.Rules.Font
{
    public class FontRule : IRule
    {
        private const string RuleName = "Same Font";

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            var differentFontsCount = document
                .Characters
                .Entries
                .Select(f => f.Font)
                .Select(f => f.Name)
                .Distinct()
                .Count();

            if (differentFontsCount == 1)
            {
                return Task.FromResult(RuleCheckResult.CreatePassed(RuleName));
            }

            return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, $"Found {differentFontsCount} different Fonts."));
        }
    }
}