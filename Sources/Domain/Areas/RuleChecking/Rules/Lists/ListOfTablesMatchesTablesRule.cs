using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.Lists
{
    public class ListOfTablesMatchesTablesRule : IRule
    {
        private const string RuleName = "List of tables";

        public Task<RuleCheckResult> CheckRuleAsync(IWordDocument document)
        {
            if (!CheckMatching(document, document.Tables.Count) || !CheckMatching(document, document.ListOfTables.Entries.Count))
            {
                return Task.FromResult(RuleCheckResult.CreateFailure(RuleName, "List of tables not matching"));
            }

            return Task.FromResult(RuleCheckResult.CreatePassed(RuleName));
        }

        private static bool CheckMatching(IWordDocument document, int itemsCount)
        {
            for (var i = 0; i < itemsCount; i++)
            {
                var table = document.Tables.ElementAtOrDefault(i);
                var tableFromList = document.ListOfTables.Entries.ElementAtOrDefault(i);

                if (table == null || tableFromList == null)
                {
                    return false;
                }

                if (!tableFromList.Text.StartsWith(table.Description.PlainDescription))
                {
                    return false;
                }
            }

            return true;
        }
    }
}