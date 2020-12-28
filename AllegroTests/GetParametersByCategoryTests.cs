using AllegroRestApiTests;
using AllegroRestApiTests.Allegro.Api.Result;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;

namespace AllegroTests
{
    public class GetParametersByCategoryTests : BaseTest
    {
        [Test]
        public void CategoryParameters_GetParametersNamesAndIds_IsPossible()
        {
            //arrange
            var resource = "42540aec-367a-4e5e-b411-17c09b08e41f";

            //act
            var response = _client.GetCategoryParameters(_token, resource);
            var content = JsonConvert.DeserializeObject<CategoryParametersResult>(response.Content);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            content.Parameters[0].Id.Should().NotBeNullOrEmpty();
            content.Parameters[0].Name.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void CategoryParameters_GetNumberOfParameters_IsPossible()
        {
            //arrange
            var resource = "42540aec-367a-4e5e-b411-17c09b08e41f";

            //act
            var response = _client.GetCategoryParameters(_token, resource);
            var content = JsonConvert.DeserializeObject<CategoryParametersResult>(response.Content);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            content.Parameters.Count.Should().Be(3);
        }

        [Test]
        public void CategoryParameters_GetPatametersWithoutCategoryId_IsIpossible()
        {
            //arrange&act
            var response = _client.GetCategoryParameters(_token, "");
            var content = JsonConvert.DeserializeObject<ErrorResult>(response.Content);

            //assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("Not found", content.Errors[0].Message);
        }
    }
}