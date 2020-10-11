using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;
using Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories;
using nat = Microsoft.Office.Interop.Word;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Implementation
{
    public class WordDocumentRepository : IWordDocumentRepository
    {
        private readonly ICharactersFactory _characterFactory;
        private readonly IExternalHyperLinkFactory _externalHyperLinkFactory;
        private readonly ITableFactory _tableFactory;
        private readonly IShapeFactory _shapeFactory;
        private readonly IWordFactory _wordFactory;

        public WordDocumentRepository(
            ICharactersFactory characterFactory,
            IExternalHyperLinkFactory externalHyperLinkFactory,
            IWordFactory wordFactory,
            ITableFactory tableFactory,
            IShapeFactory shapeFactory)
        {
            _characterFactory = characterFactory;
            _externalHyperLinkFactory = externalHyperLinkFactory;
            _wordFactory = wordFactory;
            _tableFactory = tableFactory;
            _shapeFactory = shapeFactory;
        }

        public Task<IWordDocument> LoadAsync(string filePath)
        {
            nat.Application app = null;
            nat.Document doc = null;

            try
            {
                app = new nat.Application();
                doc = app.Documents.Open(filePath);
                var characters = _characterFactory.CreateAll(doc);
                var externalLinks = _externalHyperLinkFactory.CreateAll(doc);
                var words = _wordFactory.CreateAll(doc);
                var tables = _tableFactory.CreateAll(doc);
                var shapes = _shapeFactory.CreateAll(doc);

                IWordDocument result = new WordDocument(
                    externalLinks,
                    characters,
                    words,
                    tables,
                    shapes);

                return Task.FromResult(result);
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();
                    Marshal.ReleaseComObject(doc);
                }

                if (app != null)
                {
                    app.Quit();
                    Marshal.ReleaseComObject(app);
                }

                Process
                    .GetProcesses()
                    .Where(f => f.ProcessName.ToUpper(CultureInfo.CurrentCulture).Contains("WINWORD"))
                    .ForEach(proc => proc.Kill());
            }
        }
    }
}