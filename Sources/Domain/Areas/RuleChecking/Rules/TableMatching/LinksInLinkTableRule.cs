using Mmu.WordAnalyzer2.Domain.Areas.Matching.Services;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.TableMatching
{
    public class LinksInLinkTableRule : TableMatchingRuleBase
    {
        public LinksInLinkTableRule(IWordMatcher wordMatcher)
            : base(wordMatcher)
        {
        }

        protected override string RuleName { get; } = "Links in link table";
        protected override string TableDescriptionSuffix { get; } = Constants.Tables.LinkTableSuffix;
        protected override string WordPrefix { get; } = Constants.WordIdentifiers.Link;
    }
}