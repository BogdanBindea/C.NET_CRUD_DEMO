using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIDemo.Models
{
    public class Teacher
    {
        [Column("teacher_id")]
        public int TeacherId { get; set; }
        [Column("last_name")]
        public string FirstName { get; set; } = string.Empty;
        [Column("first_name")]
        public string LastName { get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
