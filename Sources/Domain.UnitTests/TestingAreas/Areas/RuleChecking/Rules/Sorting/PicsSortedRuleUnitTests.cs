using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.Matching.Models;
using Mmu.WordAnalyzer2.Domain.Areas.Matching.Services;
using Mmu.WordAnalyzer2.Domain.Areas.Matching.Services.Implementation;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.Sorting;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Moq;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.RuleChecking.Rules.Sorting
{
    public class PicsSortedRuleUnitTests
    {
        private readonly PicsSortedRule _sut;
        private readonly Mock<IWordDocument> _documentMock;
        private readonly Mock<IWordMatcher> _wordMatcherMock;

        public PicsSortedRuleUnitTests()
        {
            _documentMock = new Mock<IWordDocument>();
            _wordMatcherMock = new Mock<IWordMatcher>();
            _sut = new PicsSortedRule(_wordMatcherMock.Object);
        }

        [Fact]
        public async Task CheckingRule_PicsNotSorted_ReturnsNotPassed()
        {
            // Arrange
            var matches = new List<IMatch>();

            for (var i = 1; i <= 5; i++)
            {
                var match = new Mock<IMatch>();
                var matchGroup = new Mock<IMatchGroup>();
                var picInt = i * i;
                matchGroup.Setup(f => f.Value).Returns($"{picInt}");
                matchGroup.Setup(f => f.Name).Returns(WordMatcher.NumberGroupName);
                match.Setup(f => f.Groups).Returns(new List<IMatchGroup> { matchGroup.Object });

                matches.Add(match.Object);
            }

            _wordMatcherMock.Setup(f => f.MatchWords(It.IsAny<IWordDocument>(), It.IsAny<string>())).Returns(matches);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
            Assert.StartsWith("4", actualResult.ErrorMessage);
        }

        [Fact]
        public async Task CheckingRule_PicsNotStartingAtOne_ReturnsNotPassed()
        {
            // Arrange
            var matches = new List<IMatch>();

            for (var i = 2; i <= 5; i++)
            {
                var match = new Mock<IMatch>();
                var matchGroup = new Mock<IMatchGroup>();
                matchGroup.Setup(f => f.Value).Returns($"{i}");
                matchGroup.Setup(f => f.Name).Returns(WordMatcher.NumberGroupName);
                match.Setup(f => f.Groups).Returns(new List<IMatchGroup> { matchGroup.Object });

                matches.Add(match.Object);
            }

            _wordMatcherMock.Setup(f => f.MatchWords(It.IsAny<IWordDocument>(), It.IsAny<string>())).Returns(matches);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
            Assert.StartsWith("2", actualResult.ErrorMessage);
        }

        [Fact]
        public async Task CheckingRule_PicsSorted_ReturnsPassed()
        {
            // Arrange
            var matches = new List<IMatch>();

            for (var i = 1; i <= 5; i++)
            {
                var match = new Mock<IMatch>();
                var matchGroup = new Mock<IMatchGroup>();
                matchGroup.Setup(f => f.Value).Returns($"{i}");
                matchGroup.Setup(f => f.Name).Returns(WordMatcher.NumberGroupName);
                match.Setup(f => f.Groups).Returns(new List<IMatchGroup> { matchGroup.Object });

                matches.Add(match.Object);
            }

            _wordMatcherMock.Setup(f => f.MatchWords(It.IsAny<IWordDocument>(), It.IsAny<string>())).Returns(matches);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.True(actualResult.RulePassed);
        }
    }
}