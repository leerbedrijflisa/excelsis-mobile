using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
	public class ExamTransfer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Cohort { get; set; }
		public int Crebo { get; set; }
		public string Subject { get; set; }
		public string Status { get; set; }
		public IEnumerable<CategoryTransfer> Categories { get; set; }
	}
}