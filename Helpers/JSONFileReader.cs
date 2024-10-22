using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpankBank1.Models;

namespace SpankBank1.Helpers
{
    public class JSONFileReader
    {
        public static Dictionary<int, Admin> ReadJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<Dictionary<int, Admin>>(jsonString);
        }
        public static List<Admin> ReadJson1(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonConvert.DeserializeObject<List<Admin>>(jsonString);
        }
    }
}
