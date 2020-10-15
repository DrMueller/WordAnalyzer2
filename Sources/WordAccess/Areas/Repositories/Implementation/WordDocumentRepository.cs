using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;
using Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories;
using Mmu.WordAnalyzer2.WordAccess.Areas.Services;
using nat = Microsoft.Office.Interop.Word;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Implementation
{
    public class WordDocumentRepository : IWordDocumentRepository
    {
        private readonly IExternalHyperLinkFactory _externalHyperLinkFactory;
        private readonly IListFactory _listFactory;
        private readonly ISectionsFactory _sectionsFactory;
        private readonly IShapeFactory _shapeFactory;
        private readonly ITableFactory _tableFactory;
        private readonly IWordFactory _wordFactory;
        private readonly IWordKiller _wordKiller;

        public WordDocumentRepository(
            IWordKiller wordKiller,
            IExternalHyperLinkFactory externalHyperLinkFactory,
            IWordFactory wordFactory,
            ITableFactory tableFactory,
            IShapeFactory shapeFactory,
            IListFactory listFactory,
            ISectionsFactory sectionsFactory)
        {
            _wordKiller = wordKiller;
            _externalHyperLinkFactory = externalHyperLinkFactory;
            _wordFactory = wordFactory;
            _tableFactory = tableFactory;
            _listFactory = listFactory;
            _sectionsFactory = sectionsFactory;
            _shapeFactory = shapeFactory;
        }

        public async Task<IWordDocument> LoadAsync(string filePath)
        {
            nat.Application app = null;
            nat.Document doc = null;

            try
            {
                app = new nat.Application();
                doc = app.Documents.Open(filePath);

                IReadOnlyCollection<IExternalHyperLink> externalLinks = null;
                IReadOnlyCollection<IWord> words = null;
                IReadOnlyCollection<ITable> tables = null;
                IReadOnlyCollection<IShape> shapes = null;
                IListOfShapes listOfShapes = null;
                IListOfTables listOfTables = null;
                ISections sections = null;

                var tasks = new List<Task>
                {
                    Task.Run(
                        async () =>
                        {
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } starting words");
                            words = await _wordFactory.CreateAllAsync(doc);
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } finished words");

                        }),
                    Task.Run(
                        async () =>
                        {
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } starting externalLinks");
                            externalLinks = await _externalHyperLinkFactory.CreateAllAsync(doc);
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } finished externalLinks");

                        }),
                    Task.Run(
                        async () =>
                        {
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } starting tables");
                            tables = await _tableFactory.CreateAllAsync(doc);
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } finished tables");

                        }),
                    Task.Run(
                        async () =>
                        {
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } starting shapes");
                            shapes = await _shapeFactory.CreateAllAsync(doc);
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } finished shapes");

                        }),
                    Task.Run(
                        async () =>
                        {
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } starting listOfShapes");
                            listOfShapes = await _listFactory.CreateListOfShapesAsync(doc);
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } finished listOfShapes");

                        }),
                    Task.Run(
                        async () =>
                        {
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } starting listOfTables");
                            listOfTables = await _listFactory.CreateListOfTablesAsync(doc);
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } finished listOfTables");

                        }),
                    Task.Run(
                        async () =>
                        {
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } starting sections");
                            sections = await _sectionsFactory.CreateAsync(doc);
                            Console.WriteLine($"{ DateTime.Now.ToLongTimeString() } finished sections");
                        })
                };

                await Task.WhenAll(tasks);

                IWordDocument result = new WordDocument(
                    externalLinks,
                    words,
                    tables,
                    shapes,
                    listOfShapes,
                    listOfTables,
                    sections);

                return result;
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

                _wordKiller.KillAllInstances();
            }
        }
    }
}