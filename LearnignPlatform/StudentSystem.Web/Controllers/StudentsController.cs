using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentSystem.Data;
using StudentSystem.Web.Models;
using StudentSystem.DatabaseModels;

namespace StudentSystem.Web.Controllers
{
    /*Контролер, който позволява на админа да въвежда нови ученици,като определя от кой клас са*/
    public class StudentsController : BaseController
    {

        public ActionResult Index()
        {
            var students = this.data.Students.All().Select(StudentViewModel.FromStudentModel).ToList();
            return View(students);

        }


        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student foundStudentDM = this.data.Students.Find(id);
            if (foundStudentDM == null)
            {
                return HttpNotFound();
            }
            StudentViewModel foundStudentVM = new StudentViewModel()
            {
                StudentID = foundStudentDM.StudentID,
                FirstName = foundStudentDM.FirstName,
                SecondName = foundStudentDM.SecondName,
                LastName = foundStudentDM.LastName,
                Number = foundStudentDM.Number,
            };
            return View(foundStudentVM);


        }

        public ActionResult Create()
        {
            //var studentClassesList = StudentClassesSelectList();
            //ViewBag.StudentClasses = studentClassesList;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,SecondName,LastName,Number,StudentClassID")] StudentViewModel studentViewModel)
        {


            if (!ModelState.IsValid)
            {
                // ако нещо не е наред, връщаме за да се попълни/коригира
                return View(studentViewModel);
            }
          //  StudentClass studentClassToAssign = this.data.StudentClasses.Find(studentViewModel.StudentClassID);

            Student newStudent = new Student()
            {

                FirstName = studentViewModel.FirstName,
                SecondName = studentViewModel.SecondName,
                LastName = studentViewModel.LastName,
                Number = studentViewModel.Number,
            };
            int newStudentClassId = studentViewModel.StudentClassID;
            //Проверка дали съществува ученик от такъв клас с този номер

            this.data.Students.Add(newStudent);
            this.data.SaveChanges();
            // отиваме на индекса за учениците след успешно създаден ученик
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentToEdit = this.data.Students.Find(id);
            if (studentToEdit == null)
            {
                return HttpNotFound();
            }
            StudentViewModel studentViewModel = new StudentViewModel()
                {
                    StudentID = studentToEdit.StudentID,
                    FirstName = studentToEdit.FirstName,
                    SecondName = studentToEdit.SecondName,
                    LastName = studentToEdit.LastName,
                    Number = studentToEdit.Number,
                };
            return View(studentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,SecondName,LastName,Number,StudentClassID")] StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(studentViewModel);
            }
            var studentToEdit = this.data.Students.Find(studentViewModel.StudentID);
            if (studentToEdit == null)
            {
                return HttpNotFound("Student Not Found !");
            }

            studentToEdit.FirstName = studentViewModel.FirstName;
            studentToEdit.SecondName = studentViewModel.SecondName;
            studentToEdit.LastName = studentViewModel.LastName;
            studentToEdit.Number = studentViewModel.Number;

                this.data.Students.Update(studentToEdit);
                this.data.SaveChanges();
                // отиваме на индекса за учениците след успешно създаден ученик
                return RedirectToAction("Index");
        }





        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentViewModel studentViewModel = null;
            if (studentViewModel == null)
            {
                return HttpNotFound();
            }
            return View(studentViewModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            return RedirectToAction("Index");
        }


    }
}
