using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.Font
{
    public class FontRule : IRule
    {
        private const string RuleName = "Same Font";

        private static readonly IReadOnlyCollection<string> _nonFonts = new List<string>
        {
            "Font Awesome 5 Free Solid",
            "Wingdings"
        };

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            var differentFonts = document
                .Words
                .SelectMany(f => f.Characters.Entries)
                .Select(f => f.Font)
                .Select(f => f.Name)
                .Where(f => !_nonFonts.Contains(f))
                .Distinct()
                .ToList();

            if (differentFonts.Count() == 1)
            {
                return Task.FromResult(RuleCheckResult.CreatePassed(RuleName));
            }

            var differents = string.Join(", ", differentFonts);

            return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, $"Found the following different Fonts: {differents}"));
        }
    }
}