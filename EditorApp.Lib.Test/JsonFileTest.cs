using System.Collections.Generic;
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

            var actual = (temp.content as JsonContent)?.Content;
            
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
                    new JsonNode()
                    {
                        Name = "firstName",
                        Contents = new List<object>() {"Иван"},
                        Children = null
                    },
                    new JsonNode()
                    {
                        Name = "lastName",
                        Contents = new List<object>() {"Иванов"},
                        Children = null
                    },
                    new JsonNode()
                    {
                        Name = "address",
                        Contents = null,
                        Children = new List<JsonNode>()
                        {
                            new JsonNode()
                            {
                                Name = "streetAddress",
                                Contents = new List<object>() {"Московское ш., 101, кв.101"},
                                Children = null
                            },
                            new JsonNode()
                            {
                                Name = "city",
                                Contents = new List<object>() {"Ленинград"},
                                Children = null
                            },
                            new JsonNode()
                            {
                                Name = "postalCode",
                                Contents = new List<object>() {101101},
                                Children = null
                            }
                        }
                    },
                    new JsonNode()
                    {
                        Name = "phoneNumbers",
                        Contents = new List<object>() {"812 123-1234", "916 123-4567"},
                        Children = null
                    }
                }
            };
        }
    }
}