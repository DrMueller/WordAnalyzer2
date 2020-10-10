using System.Threading.Tasks;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;

namespace Mmu.WordAnalyzer2.WordAccess.IntegrationTests.TestingAreas.Features
{
    [FeatureDescription(
        @"In order to use the WordDocument
as a programmer
I want to load the Word Document")]
    public partial class LoadWordDocumentFeature
    {
        public LoadWordDocumentFeature()
        {
            
        }

        [Scenario]
        public async Task No_Words()
        {
            await Runner.RunScenarioAsync(
                Given_Loading_WordDocument,
                And_given_the_WordDocument_is_empty,
                When_the_WordDocument_is_loaded,
                Then_the_WordDocument_contains_one_empty_line);
        }

        [Scenario]
        public async Task Five_Words()
        {
            await Runner.RunScenarioAsync(
                Given_Loading_WordDocument,
                And_given_the_WordDocument_has_five_Words,
                When_the_WordDocument_is_loaded,
                Then_the_WordDocument_contains_five_Words);
        }

    }
}