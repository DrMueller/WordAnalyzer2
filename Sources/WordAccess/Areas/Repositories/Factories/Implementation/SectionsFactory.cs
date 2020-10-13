using System.Collections.Generic;
using System.Linq;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;
using nat = Microsoft.Office.Interop.Word;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories.Implementation
{
    public class SectionsFactory : ISectionsFactory
    {
        public ISections Create(nat.Document document)
        {
            var sections = document.Sections.Cast<nat.Section>().ToList();

            var newSections = new List<ISection>();

            foreach (var sec in sections)
            {
                var pageNumberDefs = new List<IPageNumberDefinition>();
                var footers = sec.Footers.Cast<nat.HeaderFooter>().ToList();

                foreach (var footer in footers)
                {
                    var np = new PageNumberDefinition(
                        footer.PageNumbers.RestartNumberingAtSection,
                        footer.PageNumbers.ShowFirstPageNumber,
                        footer.PageNumbers.StartingNumber);

                    // It seems like we receive a `HeaderFooter` object per actual page, so we just add the different ones
                    // Might always be exactly one, but we can't besure add the moment
                    if (!pageNumberDefs.Contains(np))
                    {
                        pageNumberDefs.Add(np);
                    }
                }

                newSections.Add(new Section(pageNumberDefs));
            }

            return new Sections(newSections);
        }
    }
}