﻿using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.Web.Models
{
    public class StudentViewModel
    {

        [Key]

        public int StudentID { get; set; }
        [DisplayName("Име")]
        public string FirstName { get; set; }
        [DisplayName("Презиме")]
        public string SecondName { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("№")]
        public int Number { get; set; }
        [DisplayName("Клас")]
        public string StudentClass { get; set; }
        public int StudentClassID { get; set; }

        //Expression Funcion за по лесно превръщане от DataBase model -> ViewModel
        public static Expression<Func<Student, StudentViewModel>> FromStudentModel
        {
            get
            {
                return x => new StudentViewModel
                {
                    StudentID = x.StudentID,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    Number = x.Number,
                };
            }
        }

    }
}
