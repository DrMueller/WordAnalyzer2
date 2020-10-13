using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Services
{
    public interface IRuleChecker
    {
        Task<IReadOnlyCollection<RuleCheckResult>> CheckAllRulesAsync();
    }
}