﻿using AllegroRestApiTests;
using AllegroRestApiTests.Allegro.Api.Result;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;

namespace AllegroTests
{
    internal class GetCategoryByIdTests : BaseTest
    {
        [Test]
        public void Category_GetCategoryByCorrectId_IsPossible()
        {
            //arrange
            var categoryId = "5";

            //act
            var response = _client.GetCategory(_token, categoryId);
            var content = JsonConvert.DeserializeObject<Category>(response.Content);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("Dom i Ogród", content.Name);
        }

        [Test]
        public void Category_GetCategoryByIncorrectId_IsImpossible()
        {
            //arrange
            var categoryId = "abc";

            //act
            var response = _client.GetCategory(_token, categoryId);
            var content = JsonConvert.DeserializeObject<ErrorResult>(response.Content);

            //assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual($"Category '{categoryId}' not found", content.Errors[0].Message);
        }
    }
}