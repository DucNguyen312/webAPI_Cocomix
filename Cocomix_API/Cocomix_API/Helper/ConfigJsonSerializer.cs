using System.Text.Json.Serialization;
using System.Text.Json;

namespace Cocomix_API.Helper
{
    public class ConfigJsonSerializer
    {
        public void SerializeToJson(object obj) 
        {
            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true,
                MaxDepth = 5
            };

            JsonSerializer.Serialize(obj, jsonOptions);
        }
    }
}
