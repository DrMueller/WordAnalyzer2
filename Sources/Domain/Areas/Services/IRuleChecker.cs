using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.Services
{
    public interface IRuleChecker
    {
        Task<IReadOnlyCollection<RuleCheckResult>> CheckAllRulesAsync();
    }
}