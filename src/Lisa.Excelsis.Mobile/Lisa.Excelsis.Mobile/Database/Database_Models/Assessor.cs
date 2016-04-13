using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    [Table("Assessors")]
    public class Assessordb
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
