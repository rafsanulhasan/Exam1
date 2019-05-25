using Exam1.Library.Data.Entities;

using Microsoft.EntityFrameworkCore;

namespace Exam1.Library.Data
{
	public class SchoolContext
		: DbContext
	{
		private string _connectionString;
		private string _migrationAssemblyName;

		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<StudentCourses> StudentCourses { get; set; }
		public DbSet<Topic> Topics { get; set; }

		public SchoolContext(string connectionString, string migrationAssemblyName)
		{
			_connectionString = connectionString;
			_migrationAssemblyName = migrationAssemblyName;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseSqlServer(
					_connectionString,
					b => b.MigrationsAssembly(_migrationAssemblyName)
				);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<StudentCourses>()
				.HasKey(sc => new { sc.StudentId, sc.CourseId });

			modelBuilder
				.Entity<StudentCourses>()
				.HasOne(sc => sc.Student)
				.WithMany(s => s.StudentCourses)
				.HasForeignKey(sc => sc.StudentId);

			modelBuilder
				.Entity<StudentCourses>()
				.HasOne(sc => sc.Course)
				.WithMany(c => c.StudentCourses)
				.HasForeignKey(sc => sc.CourseId);

			modelBuilder
				.Entity<Topic>()
				.HasOne(sc => sc.Course)
				.WithMany(s => s.Topics)
				.HasForeignKey(sc => sc.CourseId);
		}
	}
}
