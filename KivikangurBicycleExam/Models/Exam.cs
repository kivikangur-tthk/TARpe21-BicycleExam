using System.ComponentModel;

namespace KivikangurBicycleExam.Models
{
	public class Exam
	{
		// Id=1, Name=Toomas, TR=15, 1 ,1 ,1 ,1
		public int Id { get; set; }

		public Examinee Examinee { get; set; }
		public int ExamineeId { get; set; }
		public int? TheoryResult { get; set; } 
		public int? ParkingLotResult { get; set; }
		public int? SlalomResult { get; set; }
		public int? CircleResult { get; set; }
	}
}
