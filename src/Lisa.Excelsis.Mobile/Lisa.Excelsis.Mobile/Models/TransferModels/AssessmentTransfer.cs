using System;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
	public class AssessmentTransfer
	{
		public int Id{ get; set; }
		public StudentTransfer Student { get; set; }
		public DateTime Assessed { get; set; }
		public ExamTransfer Exam { get; set; }
		public IEnumerable<AssessorTransfer> Assessors { get; set; }
		public IEnumerable<CategoryTransfer> Categories { get; set; }
	}
}