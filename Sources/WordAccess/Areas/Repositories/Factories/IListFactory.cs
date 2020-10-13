using Microsoft.Office.Interop.Word;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories
{
    public interface IListFactory
    {
        IListOfShapes CreateListOfShapes(Document document);

        IListOfTables CreateListOfTables(Document document);
    }
}