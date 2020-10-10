using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.Domain.Areas.Models
{
    public class RuleCheckResult
    {
        public RuleCheckResult(bool rulePassed, string ruleName, string errorMessage)
        {
            Guard.StringNotNullOrEmpty(() => ruleName);

            RulePassed = rulePassed;
            RuleName = ruleName;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
        public string RuleName { get; }
        public bool RulePassed { get; }
    }
}