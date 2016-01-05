using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    public class Assessor
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}