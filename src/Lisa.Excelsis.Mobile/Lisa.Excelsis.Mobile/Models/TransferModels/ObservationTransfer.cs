using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
	public class ObservationTransfer
	{
		public int Id { get; set; }
		public string Result { get; set; }
		public IEnumerable<string> Marks { get; set; }

	}
}