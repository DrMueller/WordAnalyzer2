using Mmu.WordAnalyzer2.Domain.Areas.Rules.Font;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.Rules.Font
{
    public class FontRuleUnitTests
    {
        private readonly FontRule _sut;

        public FontRuleUnitTests()
        {
            _sut = new FontRule();
        }

        [Fact]
        public void Test()
        {
            Assert.True(true);
        }
    }
}