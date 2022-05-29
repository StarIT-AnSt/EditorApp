using System.Collections.Generic;
using System.Text.Json;

namespace EditorApp.Lib.Json
{
    public class JsonContent
    {
        private JsonNode _content;
        public JsonContent()
        {
            _content = new JsonNode();
        }

        public void Parser(string str)
        {
            var document = JsonDocument.Parse(str);
            var root = document.RootElement;
            switch (root.ValueKind)
            {
                case JsonValueKind.Object:
                    var objects = root.EnumerateObject();
                    foreach (var o in objects)
                    {
                        switch (o.Value.ValueKind)
                        {
                            case JsonValueKind.Object:
                                break;
                            case JsonValueKind.Array:
                                break;
                            case JsonValueKind.Number:
                                _content.Name = o.Name;
                                _content.Contents = new List<object>(1);
                                _content.Contents.Add(o.Value.GetInt32());
                                break;
                            case JsonValueKind.String:
                                break;
                            case JsonValueKind.False:
                                break;
                            case JsonValueKind.True:
                                break;
                            case JsonValueKind.Null:
                                break;
                            case JsonValueKind.Undefined:
                            default:
                                break;
                        }
                    }
                    break;
                case JsonValueKind.Array:
                    
                    break;
            }
            
            _content.Name = null;
            _content.Contents = null;
            _content.Children = new List<JsonNode>();
            
        }

        public override string ToString()
        {
            //TODO заменить base.ToString()
            return base.ToString();
        }
    }
}