namespace StudentSystem.DatabaseModels
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Students")]
    public class Student : IdentityUser
    {
        [Key]
        public int StudentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Number { get; set; }
        public Student()
        {
            this.Courses = new HashSet<Course>();
            //this.UserId = User.Id;
        }
        //Relations
        ////[Key]
        //[ ForeignKey("StudentClass")]
        //public int StudentClassID { get; set; }

        [NotMapped]
        public virtual ApplicationUser User { get; set; }

        [NotMapped]
        public string UserId { get; set; }


        private ICollection<Course> courses;

        public virtual ICollection<Course> Courses
        {
            get { return courses; }
            set { courses = value; }
        }

        // public virtual StudentCourses StudentCourses { get; set; }

    }
}
