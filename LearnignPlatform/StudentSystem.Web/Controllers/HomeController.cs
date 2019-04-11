using StudentSystem.DatabaseModels;
using StudentSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace StudentSystem.Web.Controllers
{
   
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var subjectList = this.data.Courses.All().Select(CourseViewModel.FromCourseModel).ToList();
            return View(subjectList);
        }

        public ActionResult Lqlq()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Help()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        public ActionResult Insert()
        {
            return View();

        }
        public ActionResult loginform()
        {
            //SelectList selectStudentClassList = new SelectList(studentClassList, "StudentClassID", "ClassName", 0);
            var courseList = this.data.Courses.All().Select(CourseViewModel.FromCourseModel).ToList();
            SelectList selectCourseList = new SelectList(courseList, "CourseId", "CourseName", 0);
            ///ViewData["Data1"] = selectStudentClassList;
            ViewData["Data2"] = selectCourseList;
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}