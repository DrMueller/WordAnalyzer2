using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;
using Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Servants;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Implementation
{
    public class WordDocumentRepository : IWordDocumentRepository
    {
        private readonly IWordFactory _wordFactory;

        public WordDocumentRepository(IWordFactory wordFactory)
        {
            _wordFactory = wordFactory;
        }

        public Task<IWordDocument> LoadAsync(string filePath)
        {
            Application app = null;
            Document doc = null;

            try
            {
                app = new Application();
                doc = app.Documents.Open(filePath);

                var words = _wordFactory.CreateWords(doc);

                IWordDocument result = new WordDocument(words);

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
            }
        }
    }
}