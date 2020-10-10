using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class ExternalHyperLink : IExternalHyperLink
    {
        public ExternalHyperLink(Uri uri)
        {
            Guard.ObjectNotNull(() => uri);
            Uri = uri;
        }

        public Uri Uri { get; }
    }
}