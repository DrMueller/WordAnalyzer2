using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;
using nat = Microsoft.Office.Interop.Word;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories.Implementation
{
    public class CharactersFactory : ICharactersFactory
    {
        private static readonly IReadOnlyCollection<string> _nonCharacters = new List<string>
        {
            Environment.NewLine,
            "\r"
        };

        public async Task<ICharacters> CreateAllAsync(nat.Document document)
        {
            return await Task.Run(() =>
            {
                var ranges = document
                    .Characters
                    .Cast<nat.Range>()
                    .Where(f => !_nonCharacters.Contains(f.Text))
                    .ToList();

                var charEntries = ranges
                    .Select(CreateCharList)
                    .SelectMany(f => f)
                    .ToList();

                return new Characters(charEntries);
            });
        }

        public ICharacters CreateFromRange(nat.Range range)
        {
            var charList = CreateCharList(range);

            return new Characters(charList);
        }

        private static IReadOnlyCollection<ICharacter> CreateCharList(nat.Range range)
        {
            return range
                .Characters
                .Cast<nat.Range>()
                .Where(f => !_nonCharacters.Contains(f.Text))
                .Select(MapSingleCharacter)
                .ToList();
        }

        private static ICharacter MapSingleCharacter(nat.Range range)
        {
             var font = new Font(range.Font.Name);

            return new Character(range.Text, font);
        }
    }
}