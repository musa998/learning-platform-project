using Microsoft.AspNet.Identity;
using StudentSystem.Data.UnitOfWork;
using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Web;

namespace StudentSystem.Web.Models
{
    public class CourseViewModel
    {
        [Key]
        public int CourseId { get; set; }

        [DisplayName("Курс")]
        public string CourseName { get; set; }

        public List<Course> Courses { get; set; }

        // public int StudentId { get; set; }

        public bool UserIsEnrolledCourse { get; set; }

        //Expression Funcion за по лесно превръщане от DataBase model -> ViewModel
        public static Expression<Func<Course, CourseViewModel>> FromCourseModel
        {
            get
            {
                return x => new CourseViewModel
                {
                    CourseId = x.CourseId,
                    CourseName = x.CourseName,
                    //  StudentId = x.SubjectID
                };
            }
        }
    }
}
