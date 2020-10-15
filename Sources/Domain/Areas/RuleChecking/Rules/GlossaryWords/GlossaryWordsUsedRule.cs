using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.GlossaryWords
{
    public class GlossaryWordsUsedRule : IRule
    {
        private const string RuleName = "Glossard words used";

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            var glossaryTables = document
                .Tables
                .Where(f => f.Description.PlainDescription.EndsWith("Glossar"))
                .ToList();

            if (!glossaryTables.Any())
            {
                return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, "GlossaryTable not found"));
            }

            if (glossaryTables.Count > 1)
            {
                return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, "More than one GlossaryTable found"));
            }

            var missingWords = new List<string>();
            var glossaryTable = glossaryTables.Single();

            var glossaryCells = glossaryTable.Cells.Where(f => f.RowIndex > 1 && f.ColumnIndex == 1);

            foreach (var cell in glossaryCells)
            {
                var cellWord = string.Join(string.Empty, cell.Words.Select(f => f.Characters.Text));

                if (document.Words.Count(f => f.Characters.Text == cellWord) == 1)
                {
                    missingWords.Add(cellWord);
                }
            }

            if (missingWords.Any())
            {
                var str = string.Join(", ", missingWords);

                return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, str));
            }

            return Task.FromResult(RuleCheckResult.CreatePassed(RuleName));
        }
    }
}