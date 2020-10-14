using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;
using nat = Microsoft.Office.Interop.Word;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories.Implementation
{
    public class ShapeFactory : IShapeFactory
    {
        private const string PictureDescriptionPrefix = "Abbildung";

        private readonly IElementDescriptionFactory _descFactory;

        public ShapeFactory(IElementDescriptionFactory descFactory)
        {
            _descFactory = descFactory;
        }

        public async Task<IReadOnlyCollection<IShape>> CreateAllAsync(nat.Document document)
        {
            return await Task.Run(
                () =>
                {
                    var inlineShapes = document
                        .InlineShapes
                        .Cast<nat.InlineShape>()
                        .ToList();

                    var shapeDescriptions = inlineShapes.Select(f => _descFactory.CreateFromRange(f.Range, PictureDescriptionPrefix));
                    var shapes = shapeDescriptions.Select(sd => new Shape(sd)).ToList();

                    return shapes;
                });
        }
    }
}