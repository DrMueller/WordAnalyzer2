using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models
{
    public class RuleCheckResult
    {
        private RuleCheckResult(bool rulePassed, string ruleName, string errorMessage)
        {
            Guard.StringNotNullOrEmpty(() => ruleName);

            RulePassed = rulePassed;
            RuleName = ruleName;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
        public string RuleName { get; }
        public bool RulePassed { get; }

        public static RuleCheckResult CreateFailure(string ruleName, string errorMessage)
        {
            return new RuleCheckResult(false, ruleName, errorMessage);
        }

        public static RuleCheckResult CreatePassed(string ruleName)
        {
            return new RuleCheckResult(true, ruleName, string.Empty);
        }
    }
}