using AllegroRestApiTests;
using AllegroRestApiTests.Allegro.Api.Result;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace AllegroTests
{
    public class GetIDsOfAllegroCategoriesTests : BaseTest
    {
        [Test]
        public void CategoriesList_NumberOfCategories_IsCorrect()
        {
            //arrange&act
            var response = _client.GetCategoryIds("", _token);
            var content = JsonConvert.DeserializeObject<CategoryResult>(response.Content);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var numberOfCategories = content.Categories.Count;
            numberOfCategories.Should().Be(13);
        }

        [Test]
        public void CategoriesList_CheckIfCategoriesNamesAndIds_AreCorrect()
        {
            //arrange&act
            var response = _client.GetCategoryIds("", _token);
            var content = JsonConvert.DeserializeObject<CategoryResult>(response.Content);
            var predefinedCategoryNames = ModelTestUtil.GetCategoriesDictionary();

            Dictionary<string, string> categoryIdToNamesMappingFromResponse =
                content.Categories.ToDictionary(content => content.Id, content => content.Name);

            //asert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            categoryIdToNamesMappingFromResponse.Equals(predefinedCategoryNames);
        }

        [Test]
        public void CategoryList_GetCategoryByParent_IsPossible()
        {
            //arrange&act
            var response = _client.GetCategoryIds("38d588fd-7e9c-4c42-a4ae-6831775eca45", _token);
            var content = JsonConvert.DeserializeObject<CategoryResult>(response.Content);

            var predefinedCategoryNames = ModelTestUtil.GetCategoriesForParentDictionary();
            Dictionary<string, string> categoryIdToNamesMappingFromResponse =
                content.Categories.ToDictionary(content => content.Id, content => content.Name);

            //asert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            categoryIdToNamesMappingFromResponse.Equals(predefinedCategoryNames);
        }

        [Test]
        public void Header_IsCorrect()
        {
            //arrange&act
            var response = _client.GetCategoryIds("", _token);
            var content = JsonConvert.DeserializeObject<CategoryResult>(response.Content);
            var header = response.Headers
                .Where(x => x.Name == "Content-Type")
                .Select(x => x.Value)
                .FirstOrDefault();

            //assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(header, "application/vnd.allegro.public.v1+json; charset=UTF-8");
        }

        [Test]
        public void CategoryList_GetCategoryWithIncorrectId_IsImpossible()
        {
            //arrange&act
            var response = _client.GetCategory(_token, "/8888");
            var content = JsonConvert.DeserializeObject<ErrorResult>(response.Content);
            var message = content.Errors[0].Message;

            //assert
            message.Should().BeEquivalentTo("Category '8888' not found");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public void CategoryList_GetCategoryWithIncorrectUrl_IsImpossible()
        {
            //arrange&act
            var response = _client.GetCategory(_token, "testUrl");
            var content = JsonConvert.DeserializeObject<ErrorResult>(response.Content);
            var message = content.Errors[0].Message;

            //assert
            message.Should().BeEquivalentTo("Not Found");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public void CategoryList_GetCategoryWithIncorrectContentHeader_IsImpossible()
        {
            //arrange&act
            var response = _client.GetWrongHeadersError(_token);
            var content = JsonConvert.DeserializeObject<ErrorResult>(response.Content);
            var message = content.Errors[0].Message;

            //assert
            message.Should().BeEquivalentTo("Could not find acceptable representation");
            Assert.AreEqual(HttpStatusCode.NotAcceptable, response.StatusCode);
        }
    }
}