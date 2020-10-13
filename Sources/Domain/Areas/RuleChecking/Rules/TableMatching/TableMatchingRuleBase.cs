using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.Matching.Services;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.TableMatching
{
    public abstract class TableMatchingRuleBase : IRule
    {
        private readonly IWordMatcher _wordMatcher;

        protected TableMatchingRuleBase(IWordMatcher wordMatcher)
        {
            _wordMatcher = wordMatcher;
        }

        protected abstract string RuleName { get; }
        protected abstract string TableDescriptionSuffix { get; }
        protected abstract string WordPrefix { get; }

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            var words = _wordMatcher.MatchWords(document, WordPrefix);
            var table = document.Tables.Single(f => f.Description.PlainDescription.EndsWith(TableDescriptionSuffix));

            var tableEntries = table
                .Cells
                .Where(f => f.ColumnIndex == 1)
                .Skip(1)
                .Select(f => f.Words.Single())
                .Select(f => f.Characters.Text)
                .ToList();

            if (words.Count != tableEntries.Count())
            {
                return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, $"Found {words.Count} words, but {tableEntries.Count} table entries"));
            }

            for (var i = 0; i < words.Count; i++)
            {
                var word = words.ElementAt(i).Value;
                var tableValue = $"[{tableEntries.ElementAt(i)}]";

                if (word != tableValue)
                {
                    return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, $"Found {word} word, but {tableValue} in table"));
                }
            }

            return Task.FromResult(RuleCheckResult.CreatePassed(RuleName));
        }
    }
}