using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.Rules.GlossaryWords
{
    public class GlossaryWordsUsedRule : IRule
    {
        private const string RuleName = "Glossard words used";

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            var glossaryTable = document.Tables.Single(f => f.Description.PlainDescription.EndsWith("Glossar"));

            var missingWords = new List<string>();

            var glossaryCells = glossaryTable.Cells.Where(f => f.RowIndex > 1 && f.ColumnIndex == 1);

            foreach (var cell in glossaryCells)
            {
                var cellWord = cell.Words.Single();

                if (document.Words.Count(f => f.Characters.Text == cellWord.Characters.Text) == 1)
                {
                    missingWords.Add(cellWord.Characters.Text);
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