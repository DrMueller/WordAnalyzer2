using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules
{
    public interface IRule
    {
        Task<RuleCheckResult> CheckRuleAsync(IWordDocument document);
    }
}