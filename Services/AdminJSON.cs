using SpankBank1.Helpers;
using SpankBank1.Models;
using System.Text.Json;

namespace SpankBank1.Services
{
    public class AdminJSON
    {
        public Admin GetStudentById(string adminId)
        {
            if (!int.TryParse(adminId, out int id))
            {
                return null; // Returns null if studentId is not a valid integer
            }

            var allStudents = AllStudent(); // Ensure this method correctly parses the JSON into a List<Student>
            return allStudents.FirstOrDefault(s => s.Id == id);
        }
        public AdminJSON(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileNames
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Students.json"); }
        }
        public List<Admin> AllStudent()
        {
            return JSONFileReader.ReadJson1(JsonFileNames);
        }
        public List<Admin> FilterStudent(string criteria)
        {
            List<Admin> admins = AllStudent();
            List<Admin> filteredEvents = new List<Admin>();
            foreach (var e in admins)
            {
                if (e.AdminName.StartsWith(criteria))
                {
                    filteredEvents.Add(e);
                }
            }
            return filteredEvents;
        }
        public IEnumerable<Admin> GetStudent()
        {
            using (var jsonFileReader = File.OpenText(JsonFileNames))
            {
                return JsonSerializer.Deserialize<Admin[]>(jsonFileReader.ReadToEnd(),

                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
        public void SaveStudents(IEnumerable<Admin> students)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(students, options);

            using (var jsonFileWriter = new StreamWriter(JsonFileNames))
            {
                jsonFileWriter.Write(jsonString);
            }
        }
    }
}
