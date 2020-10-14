using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Repositories.Factories.Implementation
{
    public class ExternalHyperLinkFactory : IExternalHyperLinkFactory
    {
        public Task<IReadOnlyCollection<IExternalHyperLink>> CreateAllAsync(Document document)
        {
            return System.Threading.Tasks.Task.Run(
                () =>
                {
                    IReadOnlyCollection<IExternalHyperLink> docs = document
                        .Hyperlinks
                        .Cast<Hyperlink>()
                        .Where(hyperLink => !string.IsNullOrEmpty(hyperLink.Address))
                        .Select(hyperLink => hyperLink.Address)
                        .Select(str => new Uri(str))
                        .Select(uri => new ExternalHyperLink(uri))
                        .ToList();

                    return docs;
                });
        }
    }
}