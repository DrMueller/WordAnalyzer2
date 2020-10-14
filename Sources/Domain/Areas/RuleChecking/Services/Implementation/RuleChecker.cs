using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules;
using Mmu.WordAnalyzer2.WordAccess.Areas.Repositories;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Services.Implementation
{
    public class RuleChecker : IRuleChecker
    {
        private readonly IRule[] _rules;
        private readonly IWordDocumentRepository _wordRepo;

        public RuleChecker(
            IWordDocumentRepository wordRepo,
            IRule[] rules)
        {
            _wordRepo = wordRepo;
            _rules = rules;
        }

        public async Task<IReadOnlyCollection<RuleCheckResult>> CheckAllRulesAsync()
        {
            var wordDocument = await _wordRepo.LoadAsync(@"C:\Users\mlm\Dropbox\BFH\MAS\Dokumente\MAS - Kopie.docx");

            var ruleTasks = _rules.Select(f => f.CheckRuleAsync(wordDocument));

            var result = await Task.WhenAll(ruleTasks);

            return result;
        }
    }
}