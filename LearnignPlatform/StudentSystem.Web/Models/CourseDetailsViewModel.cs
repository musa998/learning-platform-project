namespace StudentSystem.Web.Models
{
    using StudentSystem.DatabaseModels;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class CourseDetailsViewModel
    {
        public Course Course { get; set; }

        public bool UserIsEnrolledCourse { get; set; }



        [Key]
        public int CourseId { get; set; }

        [DisplayName("Курс")]
        public string CourseName { get; set; }


        //Expression Funcion за по лесно превръщане от DataBase model -> ViewModel
        public static Expression<Func<Course, CourseViewModel>> FromCourseDetailsModel
        {
            get
            {
                return x => new CourseViewModel
                {
                    CourseId = x.CourseId,
                    CourseName = x.CourseName,
                };
            }
        }
    }
}