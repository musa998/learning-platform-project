using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Services
{
   public class UserService : Service
    {
        public Student GetCurrentStudent(string userName)
        {
            var user = this.Context.Users
                .FirstOrDefault(applicationUser => applicationUser.UserName == userName);
            Student student = this.Context.Students
                .FirstOrDefault(student1 => student1.Id == user.StudentId);
            return student;
        }
        public void EnrollStudentInCourse(int courseId, ApplicationUser student)
        {
            Course wantedCourse = this.Context.Courses.Find(courseId);
            ICollection<Course> courses = new List<Course>();
            courses.Add(wantedCourse);
            student.Courses = courses;
            this.Context.SaveChanges();
        }
        public List<Course> GetAllCourses()
        {
            List<Course> courses = this.Context.Courses.ToList();
            return courses;
        }
    }
}
