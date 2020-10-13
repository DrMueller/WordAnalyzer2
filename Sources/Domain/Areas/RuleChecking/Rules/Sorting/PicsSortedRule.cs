using Mmu.WordAnalyzer2.Domain.Areas.Matching.Services;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.Sorting
{
    public class PicsSortedRule : ElementSortedRuleBase
    {
        protected override string ElementPrefix { get; } = Constants.WordIdentifiers.Pic;
        protected override string RuleName { get; } = "PICs sorted";

        public PicsSortedRule(IWordMatcher wordMatcher) : base(wordMatcher)
        {
        }
    }
}