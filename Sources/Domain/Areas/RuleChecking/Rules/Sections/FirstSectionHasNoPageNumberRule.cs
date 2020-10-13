using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.Sections
{
    public class FirstSectionHasNoPageNumberRule : IRule
    {
        private const string RuleName = "first section no page number";

        public const string FailurePageNumber = "ShowFirstPageNumber is true";
        public const string FailureNoPageNumbers = "No page numbers found";
        public const string FailureNoSections = "No sections found";

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            if (!document.Sections.Entries.Any())
            {
                return Failure(FailureNoSections);
            }

            var firstSection = document.Sections.Entries.First();
            if (!firstSection.PageNumberDefinitions.Any())
            {
                return Failure(FailureNoPageNumbers);
            }

            if (firstSection.PageNumberDefinitions.First().ShowFirstPageNumber)
            {
                return Failure(FailurePageNumber);
            }
            
            return Task.FromResult(RuleCheckResult.CreatePassed(RuleName));
        }

        private static Task<RuleCheckResult> Failure(string message)
        {
            return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, message));
        }
    }

}
