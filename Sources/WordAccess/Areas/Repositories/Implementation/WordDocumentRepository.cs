using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;
using Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Implementation
{
    public class WordDocumentRepository : IWordDocumentRepository
    {
        private readonly IWordFactory _wordFactory;
        private readonly IExternalHyperLinkFactory _externalHyperLinkFactory;

        public WordDocumentRepository(
            IWordFactory wordFactory,
            IExternalHyperLinkFactory externalHyperLinkFactory)
        {
            _wordFactory = wordFactory;
            _externalHyperLinkFactory = externalHyperLinkFactory;
        }

        public Task<IWordDocument> LoadAsync(string filePath)
        {
            Application app = null;
            Document doc = null;

            try
            {
                app = new Application();
                doc = app.Documents.Open(filePath);
                var words = _wordFactory.CreateAll(doc);
                var externalLinks = _externalHyperLinkFactory.CreateAll(doc);

                IWordDocument result = new WordDocument(externalLinks, words);

                return System.Threading.Tasks.Task.FromResult(result);
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