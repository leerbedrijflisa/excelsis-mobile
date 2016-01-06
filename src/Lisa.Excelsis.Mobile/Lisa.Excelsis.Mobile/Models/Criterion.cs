using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    public class Criterion
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Weight { get; set; }
    }
}