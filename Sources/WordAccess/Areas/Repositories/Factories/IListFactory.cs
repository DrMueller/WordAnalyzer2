using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories
{
    public interface IListFactory
    {
        Task<IListOfShapes> CreateListOfShapesAsync(Document document);

        Task<IListOfTables> CreateListOfTablesAsync(Document document);
    }
}