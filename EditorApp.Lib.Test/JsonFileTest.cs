﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EditorApp.Lib.Csv;
using EditorApp.Lib.Json;
using Xunit;

namespace EditorApp.Lib.Test
{
    public class JsonFileTest
    {
        [Fact]
        public async Task Open_Test()
        {
            var expected = InitTestJson();

            var temp = new JsonFile();

            await temp.Open("test.json");

            var actual = (temp.Content as JsonContent)?.Content;

            Assert.Equal(expected, actual);
        }

        private JsonNode InitTestJson()
        {
            return new JsonNode()
            {
                Name = null,
                Contents = null,
                Children = new List<JsonNode>()
                {
                    new() { Name = "firstName", Contents = new List<object>() { "Иван" }, Children = null },
                    new() { Name = "lastName", Contents = new List<object>() { "Иванов" }, Children = null },
                    new()
                    {
                        Name = "address",
                        Contents = null,
                        Children = new List<JsonNode>()
                        {
                            new()
                            {
                                Name = "streetAddress",
                                Contents = new List<object>() { "Московское ш., 101, кв.101" },
                                Children = null
                            },
                            new()
                            {
                                Name = "city",
                                Contents = new List<object>() { "Ленинград" },
                                Children = null
                            },
                            new()
                            {
                                Name = "postalCode",
                                Contents = new List<object>() { 101101 },
                                Children = null
                            }
                        }
                    },
                    new()
                    {
                        Name = "phoneNumbers",
                        Contents = new List<object>() { "812 123-1234", "916 123-4567" },
                        Children = null
                    }
                }
            };
        }
    }
}
