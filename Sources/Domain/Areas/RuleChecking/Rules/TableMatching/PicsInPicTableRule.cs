using Mmu.WordAnalyzer2.Domain.Areas.Matching.Services;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.TableMatching
{
    public class PicsInPicTableRule : TableMatchingRuleBase
    {
        public PicsInPicTableRule(IWordMatcher wordMatcher) : base(wordMatcher)
        {
        }

        protected override string RuleName { get; } = "PICs in PIC table";
        protected override string TableDescriptionSuffix { get; } = Constants.Tables.PicTableSuffix;
        protected override string WordPrefix { get; } = Constants.WordIdentifiers.Pic;
    }
}