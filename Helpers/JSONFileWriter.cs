using Microsoft.Extensions.Logging;
using SpankBank1.Models;

namespace SpankBank1.Helpers
{
    public class JSONFileWriter
    {
        public static void WriteToJson(Dictionary<int, Admin> admins, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(admins, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
    }
}
