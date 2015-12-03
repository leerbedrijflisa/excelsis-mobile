using Newtonsoft.Json;

namespace Lisa.Excelsis.Mobile
{
    [JsonObject]
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cohort { get; set; }
        public int Crebo { get; set; }
        public string Subject { get; set; }
    }
}