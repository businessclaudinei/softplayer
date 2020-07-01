using System.Threading;
using System.Threading.Tasks;
using Accounting.Interest.CrossCutting.Configuration.CustomModels;
using Accounting.Interest.Infrastructure.Data.Query.Queries.ShowMeTheCode;
using NUnit.Framework;

namespace Accounting.Interest.Infrastructure.Data.Query.Test.Unit.Queries.v1.ShowMeTheCode
{
    [TestFixture]
    public sealed class ShowMeTheCodeQueryHandlerTest
    {
        private ShowMeTheCodeQueryHandler _defaultContext;

        [SetUp]
        public void SetUp()
        {
            _defaultContext = new ShowMeTheCodeQueryHandler();
        }

        [Test]
        public async Task Should_GetInterestRate_ForValidRequest()
        {
            var response = await _defaultContext.Handle(new ShowMeTheCodeQuery(), CancellationToken.None);

            Assert.NotNull(response);
            Assert.That(response.GitHubRepositoryUrl, Does.Match(CustomSettings.Settings.UrlRegex));
        }

        [TestCase("http://xptocom")]
        [TestCase("http:/xpto.com")]
        [TestCase("htt://xpto.com")]
        [TestCase("http//xpto.com")]
        public void ValidateEnteredUris(string url)
        {
            Assert.That(url, Does.Not.Match(CustomSettings.Settings.UrlRegex));
        }
    }
}
