using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIDemo.Models
{
    public class Course
    {
        [Column("course_id")]
        public int CourseId { get; set; }

        [Column("course_name")]
        public string Name { get; set; }

        public Teacher Teacher { get; set; }


        [Column("teacher_id")]
        public int TeacherId { get; set; }
    }
}
