using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.Matching.Services;
using Mmu.WordAnalyzer2.Domain.Areas.Matching.Services.Implementation;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.Sorting
{
    public abstract class ElementSortedRuleBase : IRule
    {
        private readonly IWordMatcher _wordMatcher;

        protected ElementSortedRuleBase(IWordMatcher wordMatcher)
        {
            _wordMatcher = wordMatcher;
        }

        protected abstract string ElementPrefix { get; }
        protected abstract string RuleName { get; }

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            var matches = _wordMatcher.MatchWords(document, ElementPrefix);
            var numbers = new List<int>();

            foreach (var matchingWord in matches)
            {
                var numStr = matchingWord.Groups.Single(f => f.Name == WordMatcher.NumberGroupName).Value;
                var num = int.Parse(numStr);
                numbers.Add(num);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                var expectedLinkNumber = i + 1;

                if (numbers.ElementAt(i) != expectedLinkNumber)
                {
                    return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, $"{numbers.ElementAt(i)} not matching"));
                }
            }

            return Task.FromResult(RuleCheckResult.CreatePassed(RuleName));
        }
    }
}