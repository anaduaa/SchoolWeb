using System.ComponentModel.DataAnnotations;

namespace WebApplication15.Models
{
    public class Courses 
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        

    }
}
