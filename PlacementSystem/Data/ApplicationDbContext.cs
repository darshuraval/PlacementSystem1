using Microsoft.EntityFrameworkCore;
using PlacementSystem.Models;

namespace PlacementSystem.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<TPOCoordinator> TPOCoordinators { get; set; }
		public DbSet<TPOHead> TPOHeads { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<JobApplication> JobApplications { get; set; }
		public DbSet<PlacementReport> PlacementReports { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Job>()
				.HasOne(j => j.Company)
				.WithMany()
				.HasForeignKey(j => j.CompanyId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<JobApplication>()
				.HasOne(ja => ja.Student)
				.WithMany()
				.HasForeignKey(ja => ja.StudentId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<JobApplication>()
				.HasOne(ja => ja.Job)
				.WithMany()
				.HasForeignKey(ja => ja.JobId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<PlacementReport>()
				.HasOne(pr => pr.Student)
				.WithMany()
				.HasForeignKey(pr => pr.StudentId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<PlacementReport>()
				.HasOne(pr => pr.Job)
				.WithMany()
				.HasForeignKey(pr => pr.JobId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
