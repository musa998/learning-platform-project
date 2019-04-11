using StudentSystem.DatabaseModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StudentSystem.Data.Migrations;
using System.Reflection.Emit;

namespace StudentSystem.Data
{
    /*DbContext-а който се инстанцира е необходимо да наследява IdentityDbContext,
      за да е възможно използването на системата за идентификация и оторизация, предоставена от 
     ASP.NET Identity и да имплементира интерфейса IApplicationDbContext,
     в който са дефинирани DbSet-обектите с които работи контекста*/
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("LearningPlatform", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Course> Courses { get; set; }


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}


