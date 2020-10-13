using System.Collections.Generic;
using System.Linq;
using Mmu.WordAnalyzer2.Domain.Areas.Matching.Models;
using Mmu.WordAnalyzer2.Domain.Areas.Matching.Models.Implementation;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using nat = System.Text.RegularExpressions;

namespace Mmu.WordAnalyzer2.Domain.Areas.Matching.Services.Implementation
{
    public class WordMatcher : IWordMatcher
    {
        public const string NumberGroupName = "number";

        public IReadOnlyCollection<IMatch> MatchWords(IWordDocument document, string elementPrefix)
        {
            var linkRegex = new nat.Regex($@"(\[({elementPrefix})(?<{NumberGroupName}>[0-9]+)\])");

            var matches = document
                .Words
                .Select(f => linkRegex.Match(f.Characters.Text))
                .Where(f => f.Success)
                .ToList();

            var result = new List<IMatch>();

            foreach (var match in matches)
            {
                var grps = match
                    .Groups
                    .Cast<nat.Group>()
                    .Select(f => new MatchGroup(f.Name, f.Value))
                    .ToList();

                result.Add(new Match(match.Value, grps));
            }

            return result;
        }
    }
}