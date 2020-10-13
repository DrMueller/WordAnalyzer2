using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.ShapeDescriptions
{
    public class ShapeDescriptionBelowRule : IRule
    {
        public const string NoDescription = "(No description)";
        private const string RuleName = "Shape descriptions below";

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            var shapeDescNotBelow = document
                .Shapes
                .Where(f => f.Description.Position != Position.Below)
                .ToList();

            if (shapeDescNotBelow.Any())
            {
                var str = string.Join(
                    ", ",
                    shapeDescNotBelow.Select(
                        f =>
                        {
                            var plainDesc = f.Description.PlainDescription;

                            if (string.IsNullOrEmpty(plainDesc))
                            {
                                plainDesc = NoDescription;
                            }

                            return plainDesc;
                        }));

                return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, str));
            }

            return Task.FromResult(RuleCheckResult.CreatePassed(RuleName));
        }
    }
}