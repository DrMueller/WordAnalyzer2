using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Servants
{
    public interface IWordFactory
    {
        IReadOnlyCollection<IWord> CreateWords(Document document);
    }
}