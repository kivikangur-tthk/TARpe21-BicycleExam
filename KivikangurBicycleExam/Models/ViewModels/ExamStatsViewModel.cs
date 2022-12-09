namespace KivikangurBicycleExam.Models.ViewModels
{
	public class ExamStatsViewModel
	{
		public ICollection<Exam> RegisteredExams { get; set; }
		public ICollection<Exam> IncompleteExams { get; set; }
		public ICollection<Exam> CompletedExams { get; set; }
	}
}
