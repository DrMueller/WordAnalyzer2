using Mmu.WordAnalyzer2.Domain.Areas.Matching.Services;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.Sorting
{
    public class LinksSortedRule : ElementSortedRuleBase
    {
        protected override string ElementPrefix { get; } = Constants.WordIdentifiers.Link;
        protected override string RuleName { get; } = "Links sorted";

        public LinksSortedRule(IWordMatcher wordMatcher) : base(wordMatcher)
        {
        }
    }
}