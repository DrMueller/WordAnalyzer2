using System;
using System.Collections.Generic;
using System.Linq;
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

        public IReadOnlyCollection<IWord> CreateAll(Document document)
        {
            var ranges = document
                .Words
                .Cast<Range>()
                .Where(range => !_nonWords.Contains(range.Text))
                .ToList();

            var result = ranges.Select(Map).ToList();

            return result;
        }

        private static IWord Map(Range range)
        {
            var font = new Models.Implementation.Font(range.Font.Name);

            return new Word(range.Text, font);
        }
    }
}