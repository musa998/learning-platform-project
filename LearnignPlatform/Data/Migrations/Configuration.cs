namespace StudentSystem.Data.Migrations
{
    using StudentSystem.DatabaseModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled =true;
            AutomaticMigrationDataLossAllowed = true;
        }
     /* При първоначално стартиране на системата се изпълнява първоначално запълване на базата с данни (т.нар seed),
        включващo регистриране и профил на поне един администратор*/
        protected override void Seed(StudentSystem.Data.ApplicationDbContext context)
        {

            if(!context.Courses.Any(c=>c.CourseName== "Информатика"))
            {

                var sub = new Course { CourseName = "Информатика" };
                context.Courses.Add(sub);
                
                if (!context.Users.Any(u => u.UserName == "admin@mail.com"))
                {
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    var admin = new ApplicationUser
                    {
                        UserName = "admin@mail.com",
                        Email = "admin@mail.com",
                        PhoneNumber="1111111111"
                    };

                   
                    manager.Create(admin, "admin123");
                   
                }
                if (!context.Users.Any(u => u.UserName == "teacher@abv.bg"))
                {
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    

                    var teacher = new ApplicationUser
                    {
                        UserName = "teacher@abv.bg",
                        Email = "teacher@abv.bg",
                        PhoneNumber = "222222222",
                        
                    };
                    //teacher.StudentClasses.Add(cls);
                    //teacher.Subjects.Add(sub);
                    manager.Create(teacher, "123asd");

                }
                
            }
        }
    }
}
