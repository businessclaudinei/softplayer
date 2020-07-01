using Accounting.Interest.Infrastructure.Data.Query.Queries.ShowMeTheCode;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Interest.Infrastructure.Data.Query.Tests.Unit.Queries.v1.ShowMeTheCode
{
    [TestFixture]
    public sealed class ShowMeTheCodeQueryHandlerTest
    {
        private ShowMeTheCodeQueryHandler _defaultContext;
        private string urlRegex;

        [SetUp]
        public void SetUp()
        {
            urlRegex = @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$";
            _defaultContext = new ShowMeTheCodeQueryHandler();
        }

        [Test]
        public async Task Should_GetInterestRate_ForValidRequest()
        {
            var response = await _defaultContext.Handle(new ShowMeTheCodeQuery(), CancellationToken.None);

            Assert.NotNull(response);
            Assert.That(response.GitHubRepositoryUrl, Does.Match(urlRegex));
        }

        [TestCase("http://xptocom")]
        [TestCase("http:/xpto.com")]
        [TestCase("htt://xpto.com")]
        [TestCase("http//xpto.com")]
        public void ValidateEnteredUris(string url)
        {
            Assert.That(url, Does.Not.Match(urlRegex));
        }
    }
}
