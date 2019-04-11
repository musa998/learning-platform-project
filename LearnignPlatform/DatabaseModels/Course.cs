
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudentSystem.DatabaseModels.Services;

namespace StudentSystem.DatabaseModels
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int CourseId{ get; set; }
        [Required]
        public string CourseName { get; set; }

        public Course()
        {
            this.Students = new HashSet<ApplicationUser>();
            this.Studentss = new HashSet<Student>();
        }

        private ICollection<Student> studentss;

        public virtual ICollection<Student> Studentss
        {
            get { return studentss; }
            set { studentss= value; }
        }

        private ICollection<ApplicationUser> students;

        public virtual ICollection<ApplicationUser> Students
        {
            get { return students; }
            set { students = value; }
        }

        public bool IsAStudentEnrolled { get; set; }

        //public ICollection<ApplicationUser> Teachers { get; set; }

        // public ICollection<ApplicationUser> Students { get; set; }

    }
}
