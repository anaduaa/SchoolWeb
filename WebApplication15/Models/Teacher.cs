using System.Collections.Generic;

namespace WebApplication15.Models
{
    public class Teacher
    {
        public int id { get; set; }
       
        public int Teacherid { get; set; }
        public MyUser teacheruser { get; set; }//needs sth
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public int Salary { get; set; }
        public string PhoneNum { get; set; }
        public string Gender { get; set; }
        public string specialize { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }

       // public WebApplication15User user { get; set; }
    }
}
