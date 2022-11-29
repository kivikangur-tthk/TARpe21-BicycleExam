namespace KivikangurBicycleExam.Models
{
	public class Examinee
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string SSID { get; set; }
		public ICollection<Exam>? Exams { get; set; }

	}
}
