using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
	public class CategoryTransfer
	{
		public int Id { get; set; }
		public int Order { get; set; }
		public string Name { get; set; }
		public IEnumerable<CriterionTransfer> Criteria { get; set; }
		public IEnumerable<ObservationTransfer> Observations { get; set; }
	}
}