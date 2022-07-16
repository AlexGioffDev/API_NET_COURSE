using Microsoft.EntityFrameworkCore;
using UniversityApiBackEnd.Models.DataModels;

namespace UniversityApiBackEnd.DataAccess
{
	public class UniversityDBContext : DbContext
	{
		public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
		{

		}

		// TODO ADD Tables of our DataBase
		public DbSet<User>? Users { get; set; }

        public DbSet<Course>? Courses { get; set; }
        public DbSet<Chapter>? Chapters{ get; set; }
        public DbSet<Category>? Categories { get; set; }
		public DbSet<Student>? Students { get; set; }
		
    }
}

