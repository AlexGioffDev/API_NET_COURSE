using System.ComponentModel.DataAnnotations;
namespace UniversityApiBackEnd.Models.DataModels
{
	public class Student : BaseEntity
	{
		[Required]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		public string LastName { get; set; } = string.Empty;

        [Required]
		public DateTime DOB { get; set;  }

		public ICollection<Course> Courses = new List<Course>();
	}
}

