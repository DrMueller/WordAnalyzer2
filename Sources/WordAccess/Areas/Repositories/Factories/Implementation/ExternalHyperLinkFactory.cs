using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Word;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories.Implementation
{
    public class ExternalHyperLinkFactory : IExternalHyperLinkFactory
    {
        public IReadOnlyCollection<IExternalHyperLink> CreateAll(Document document)
        {
            return document
                .Hyperlinks
                .Cast<Hyperlink>()
                .Where(hyperLink => !string.IsNullOrEmpty(hyperLink.Address))
                .Select(hyperLink => hyperLink.Address)
                .Select(str => new Uri(str))
                .Select(uri => new ExternalHyperLink(uri))
                .ToList();
        }
    }
}