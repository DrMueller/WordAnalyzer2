using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.Rules.Font
{
    public class FontRule : IRule
    {
        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            return Task.FromResult(new RuleCheckResult(false, "Tra", "Tre"));
        }
    }
}