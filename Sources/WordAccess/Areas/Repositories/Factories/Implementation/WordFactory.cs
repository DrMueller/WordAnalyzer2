using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories.Implementation
{
    public class WordFactory : IWordFactory
    {
        private static readonly IReadOnlyCollection<string> _nonWords = new List<string>
        {
            Environment.NewLine,
            "\r"
        };
        private readonly ICharactersFactory _charFactory;

        public WordFactory(ICharactersFactory charFactory)
        {
            _charFactory = charFactory;
        }

        public async Task<IReadOnlyCollection<IWord>> CreateAllAsync(Document document)
        {
            return await System.Threading.Tasks.Task.Run(() =>
            {
                var wordRanges = document
                    .Words
                    .Cast<Range>()
                    .Where(range => !_nonWords.Contains(range.Text))
                    .ToList();

                var words = CreateFromRanges(wordRanges);
                return words;
            });
        }

        public IReadOnlyCollection<IWord> CreateFromRange(Range range)
        {
            return CreateFromRanges(
                range.Words.Cast<Range>()
                    .Where(r => !_nonWords.Contains(r.Text))
                    .ToList());
        }

        private IReadOnlyCollection<Word> CreateFromRanges(IReadOnlyCollection<Range> ranges)
        {
            return ranges.Select(
                wr =>
                {
                    var chars = _charFactory.CreateFromRange(wr);

                    return new Word(chars);
                }).ToList();
        }
    }
}