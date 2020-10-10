using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Word;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Servants.Implementation
{
    public class WordFactory : IWordFactory
    {
        private static IReadOnlyCollection<string> _nonWords = new List<string>
        {
            Environment.NewLine,
            "\r"
        };
        
        public IReadOnlyCollection<IWord> CreateWords(Document document)
        {
            var allWordTexts = document
                .Words
                .Cast<Range>()
                .Select(r => r.Text)
                .ToList();

            var filteredWordTexts = allWordTexts.Except(_nonWords);
            var result = filteredWordTexts.Select(text => new Word(text)).ToList();

            return result;
        }
    }
}