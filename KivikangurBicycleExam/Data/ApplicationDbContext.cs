using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KivikangurBicycleExam.Models;

namespace KivikangurBicycleExam.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
						: base(options)
		{
		}
		public DbSet<KivikangurBicycleExam.Models.Exam> Exam { get; set; }
		public DbSet<KivikangurBicycleExam.Models.Examinee> Examinee { get; set; }
	}
}