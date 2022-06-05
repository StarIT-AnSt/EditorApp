using System.Collections.Generic;

namespace EditorApp.Lib.Json
{
    public class JsonNode
         {
             public string? Name { get; set; }
             public List<object>? Contents { get; set; }
             public List<JsonNode>? Children { get; set; }
         }
}