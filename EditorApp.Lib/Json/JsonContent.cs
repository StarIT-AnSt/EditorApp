using System.Collections.Generic;
using System.Text.Json;

namespace EditorApp.Lib.Json
{
    public class JsonContent
    {
        private JsonNode _content;
        public JsonNode Content { get => _content; }

        public JsonContent()
        {
            _content = new JsonNode();
        }

        public void Parser(string str)
        {
            _content.Name = null;
            _content.Contents = null;
            _content.Children = null;
            
            var document = JsonDocument.Parse(str);
            var root = document.RootElement;
            switch (root.ValueKind)
            {
                case JsonValueKind.Object:
                    _content.Children = SetChildren(_content, root);
                    break;
                case JsonValueKind.Array:
                    _content.Contents = SetArrayContent(root);
                    break;
            }
        }

        private void SetContent(JsonNode node, JsonProperty element)
        {
            node.Name = element.Name;
            node.Contents = element.Value.ValueKind switch
            {
                JsonValueKind.Array => SetArrayContent(element.Value),
                JsonValueKind.Number => new List<object>(1) { element.Value.GetInt32() },
                JsonValueKind.String => new List<object>(1) { element.Value.GetString() },
                JsonValueKind.False => new List<object>(1) { element.Value.GetBoolean() },
                JsonValueKind.True => new List<object>(1) { element.Value.GetBoolean() },
                JsonValueKind.Undefined => null,
                JsonValueKind.Null => null,
                _ => null
            };
        }

        private List<object>? SetArrayContent(JsonElement element)
        {
            var list = new List<object?>();
            foreach (var i in element.EnumerateArray())
            {
                object? item = null;
                switch (i.ValueKind)
                {
                    case JsonValueKind.Object:
                        
                        break;
                    case JsonValueKind.Array:
                        item = SetArrayContent(element);
                        break;
                    case JsonValueKind.Number:
                        item = i.GetInt32();
                        break;
                    case JsonValueKind.String:
                        item = i.GetString();
                        break;
                    case JsonValueKind.False:
                    case JsonValueKind.True:
                        item = i.GetBoolean();
                        break;
                    case JsonValueKind.Undefined:
                    case JsonValueKind.Null:
                    default:
                        item = null;
                        break;
                }

                list.Add(item);
            }
            return list;
        }

        private List<JsonNode> SetChildren(JsonNode node, JsonElement element)
        {
            var children = new List<JsonNode>();

            var objects = element.EnumerateObject();
            foreach (var o in objects)
            {
                switch (o.Value.ValueKind)
                {
                    case JsonValueKind.Object:
                        node.Name = o.Name;
                        node.Children = SetChildren(node, o.Value);
                        break;
                    case JsonValueKind.Array:
                    case JsonValueKind.Undefined:
                    case JsonValueKind.String:
                    case JsonValueKind.Number:
                    case JsonValueKind.True:
                    case JsonValueKind.False:
                    case JsonValueKind.Null:
                    default:
                        SetContent(node, o);
                        break;
                }
            }
            
            return children;
        }

        public override string ToString()
        {
            //TODO заменить base.ToString()
            return base.ToString();
        }
    }
}