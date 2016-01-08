using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    [Table("Assessors")]
    public class Assessor
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}