using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.ShapeDescriptions
{
    public class ShapeDescriptionSortedRule : IRule
    {
        public const string ShapePrefix = "Abbildung";
        private const string RuleName = "Shapes sorted";

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            var wrongDescriptions = new List<string>();

            for (var i = 1; i <= document.Shapes.Count; i++)
            {
                var shape = document.Shapes.ElementAt(i - 1);
                var expectedShapePrefix = $"{ShapePrefix} {i}";

                if (!shape.Description.PlainDescription.StartsWith(expectedShapePrefix))
                {
                    wrongDescriptions.Add(shape.Description.PlainDescription);
                }
            }

            if (wrongDescriptions.Any())
            {
                var str = string.Join(", ", wrongDescriptions);

                return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, str));
            }

            return Task.FromResult(RuleCheckResult.CreatePassed(RuleName));
        }
    }
}