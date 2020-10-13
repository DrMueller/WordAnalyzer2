using System;

namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class PageNumberDefinition : IPageNumberDefinition, IEquatable<PageNumberDefinition>
    {
        public PageNumberDefinition(
            bool restartNumberingAtSection,
            bool showFirstPageNumber,
            int startingNumber)
        {
            RestartNumberingAtSection = restartNumberingAtSection;
            ShowFirstPageNumber = showFirstPageNumber;
            StartingNumber = startingNumber;
        }

        public bool RestartNumberingAtSection { get; }
        public bool ShowFirstPageNumber { get; }
        public int StartingNumber { get; }

        public bool Equals(PageNumberDefinition other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return RestartNumberingAtSection == other.RestartNumberingAtSection && ShowFirstPageNumber == other.ShowFirstPageNumber && StartingNumber == other.StartingNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj.GetType() == this.GetType() && Equals((PageNumberDefinition)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = RestartNumberingAtSection.GetHashCode();
                hashCode = (hashCode * 397) ^ ShowFirstPageNumber.GetHashCode();
                hashCode = (hashCode * 397) ^ StartingNumber;

                return hashCode;
            }
        }
    }
}