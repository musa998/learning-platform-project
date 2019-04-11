using StudentSystem.Data.Services;
using StudentSystem.DatabaseModels;
using StudentSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.Controllers
{
    public class CourseController : BaseController
    {
        private UserService service;

        public CourseController()
        {
            this.service = new UserService();
        }

    

        public ActionResult Index()
        {
            var courses = this.data.Courses.All().Select(CourseViewModel.FromCourseModel).ToList();
            return View(courses);
        }
        public ActionResult Index2()
        {
            var courses = this.data.Courses.All().Select(CourseViewModel.FromCourseModel).ToList();
            return View(courses);
        }

        public ActionResult Details(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course foundCoursetDM = this.data.Courses.Find(id);
           

            if (foundCoursetDM == null)
            {
                return HttpNotFound();
            }
            var user = CurrentUser;
            foreach (var course in user.Courses)
            {
                if (foundCoursetDM.CourseId == course.CourseId)
                {
                    user.IsEnrolledforCurrentCourse = true;
                }
            }
            CourseViewModel foundSubjectVM = new CourseViewModel()
            {
                CourseId = foundCoursetDM.CourseId,
                CourseName = foundCoursetDM.CourseName,
                UserIsEnrolledCourse = user.IsEnrolledforCurrentCourse
            };
            //todo
            return View(foundSubjectVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseName")] CourseViewModel courseViewModel)
        {


            if (!ModelState.IsValid)
            {
                // ако нещо не е наред, връщаме за да се попълни/коригира
                return View(courseViewModel);
            }
            Course newCourse = new Course()
            {
                CourseName = courseViewModel.CourseName
            };
            if (this.data.Courses.All().Any(s => s.CourseName == newCourse.CourseName))
            {
                return RedirectToAction("Index");
            }
            else
            {

                this.data.Courses.Add(newCourse);
                this.data.SaveChanges();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course courseDM = this.data.Courses.Find(id);
            if (courseDM == null)
            {
                return HttpNotFound();
            }

            CourseViewModel courseVM = new CourseViewModel()
            {
                CourseId = courseDM.CourseId,
                CourseName = courseDM.CourseName
            };

            return View(courseVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName")] CourseViewModel courseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(courseViewModel);
            }

            // намираме модела в базата за да го редактираме
            Course courseToUpdate = this.data.Courses.Find(courseViewModel.CourseId);
            if (courseToUpdate == null)
            {
                return HttpNotFound();
            }
            courseToUpdate.CourseName = courseViewModel.CourseName;
            if (this.data.Courses.All().Any(s => s.CourseName == courseToUpdate.CourseName))
            {
                return RedirectToAction("Index");
            }
            else
            {
                this.data.Courses.Update(courseToUpdate);
                this.data.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course courseToDelete = this.data.Courses.Find(id);
            if (courseToDelete == null)
            {
                return HttpNotFound();
            }

            CourseViewModel courseToDeleteVM = new CourseViewModel()
            {
                CourseId = courseToDelete.CourseId,
                CourseName = courseToDelete.CourseName
            };

            return View(courseToDeleteVM);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var courseToDelete = this.data.Courses.Find(id);
            if (courseToDelete == null)
            {
                return HttpNotFound();
            }

            this.data.Courses.Delete(courseToDelete);
            this.data.SaveChanges();

            return RedirectToAction("Index");
        }
        //[HttpPost]
        //[Route("enroll")]
        public ActionResult Enroll(int id)
        {
            var user = CurrentUser;
            var course = this.data.Courses.Find(id);
            user.Courses.Add(course);
            //user
            this.data.Users.Update(user);
            this.data.SaveChanges();

            //this.service.EnrollStudentInCourse(id, user);
            return this.RedirectToAction("Index");
        }
    }
}