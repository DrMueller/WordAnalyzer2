using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.Sections;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Moq;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.RuleChecking.Rules.Sections
{
    public class FirstSectionHasNoPageNumberRuleUnitTests
    {
        private readonly FirstSectionHasNoPageNumberRule _sut;
        private readonly Mock<IWordDocument> _documentMock;

        public FirstSectionHasNoPageNumberRuleUnitTests()
        {
            _documentMock = new Mock<IWordDocument>();
            _sut = new FirstSectionHasNoPageNumberRule();
        }

        [Fact]
        public async Task CheckingRule_HavingNoFootersInFirstSection_ReturnsNotPassed()
        {
            // Arrange
            var sections = new Mock<ISections>();
            var section = new Mock<ISection>();

            section.Setup(f => f.PageNumberDefinitions).Returns(new List<IPageNumberDefinition>());
            sections.Setup(f => f.Entries).Returns(new List<ISection> { section.Object });
            _documentMock.Setup(f => f.Sections).Returns(sections.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
            Assert.Equal(FirstSectionHasNoPageNumberRule.FailureNoPageNumbers, actualResult.ErrorMessage);
        }

        [Fact]
        public async Task CheckingRule_HavingNoSections_ReturnsNotPassed()
        {
            // Arrange
            var sections = new Mock<ISections>();

            sections.Setup(f => f.Entries).Returns(new List<ISection>());
            _documentMock.Setup(f => f.Sections).Returns(sections.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
            Assert.Equal(FirstSectionHasNoPageNumberRule.FailureNoSections, actualResult.ErrorMessage);
        }

        [Fact]
        public async Task CheckingRule_NotShowingFirstPageNumber_ReturnsPassed()
        {
            // Arrange
            var sections = new Mock<ISections>();
            var section = new Mock<ISection>();

            var pn = new Mock<IPageNumberDefinition>();
            pn.Setup(f => f.ShowFirstPageNumber).Returns(false);
            section.Setup(f => f.PageNumberDefinitions).Returns(new List<IPageNumberDefinition> { pn.Object });
            sections.Setup(f => f.Entries).Returns(new List<ISection> { section.Object });
            _documentMock.Setup(f => f.Sections).Returns(sections.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.True(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_ShowingFirstPageNumber_ReturnsNotPassed()
        {
            // Arrange
            var sections = new Mock<ISections>();
            var section = new Mock<ISection>();

            var pn = new Mock<IPageNumberDefinition>();
            pn.Setup(f => f.ShowFirstPageNumber).Returns(true);
            section.Setup(f => f.PageNumberDefinitions).Returns(new List<IPageNumberDefinition> { pn.Object });
            sections.Setup(f => f.Entries).Returns(new List<ISection> { section.Object });
            _documentMock.Setup(f => f.Sections).Returns(sections.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
            Assert.Equal(FirstSectionHasNoPageNumberRule.FailurePageNumber, actualResult.ErrorMessage);
        }
    }
}