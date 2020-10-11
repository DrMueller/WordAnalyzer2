using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.Rules.ShapeDescriptions
{
    public class ShapeDescriptionBelowRule : IRule
    {
        private const string RuleName = "Shape descriptions below";
        public const string NoDescription = "(No description)";

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            var shapeDescNotBelow = document
                .Shapes
                .Where(f => f.Description.Position != Position.Below)
                .ToList();

            if (shapeDescNotBelow.Any())
            {
                var str = string.Join(", ", shapeDescNotBelow.Select(f =>
                {
                    var str = f.Description.PlainDescription;
                    if (string.IsNullOrEmpty(str))
                    {
                        str = NoDescription;
                    }

                    return str;
                }));

                return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, str));
            }

            return Task.FromResult(RuleCheckResult.CreatePassed(RuleName));
        }
    }
}
