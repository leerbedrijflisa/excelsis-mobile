using SQLite.Net.Attributes;

namespace Lisa.Excelsis.Mobile
{
    [Table("Marks")]
    public class Markdb
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ObservationId { get; set; }
    }
}