using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.Lists
{
    public class ListOfShapesMatchesShapesRule : IRule
    {
        private const string RuleName = "List of shapes";

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            if (!CheckMatching(document, document.Shapes.Count) || !CheckMatching(document, document.ListOfShapes.Entries.Count))
            {
                return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, "List of shapes not matching"));
            }

            return Task.FromResult(RuleCheckResult.CreatePassed(RuleName));
        }

        private static bool CheckMatching(IWordDocument document, int itemsCount)
        {
            for (var i = 0; i < itemsCount; i++)
            {
                var shape = document.Shapes.ElementAtOrDefault(i);
                var figuresShape = document.ListOfShapes.Entries.ElementAtOrDefault(i);

                if (shape == null || figuresShape == null)
                {
                    return false;
                }

                if (!figuresShape.Text.StartsWith(shape.Description.PlainDescription))
                {
                    return false;
                }
            }

            return true;
        }
    }
}