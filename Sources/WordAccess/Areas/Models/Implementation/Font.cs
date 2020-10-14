namespace Mmu.WordAnalyzer2.WordAccess.Areas.Models.Implementation
{
    public class Font : IFont
    {
        public Font(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}