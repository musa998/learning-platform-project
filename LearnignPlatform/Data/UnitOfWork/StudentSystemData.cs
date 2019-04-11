﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StudentSystem.Data.Repositories;
using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.UnitOfWork
{
   public class StudentSystemData  : IStudentSystemData            //Nasledi IstudentSystemData ii definirai repositoryta
    {
       private readonly IApplicationDbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        private IUserStore<ApplicationUser> userStore;

        public StudentSystemData(IApplicationDbContext context)
        {
            this.dbContext = context;
            this.repositories = new Dictionary<Type, object>();
        }
        public StudentSystemData():this(new ApplicationDbContext())
        {

        }
       // Дефиниране на repository за всяка таблица от базата данни
        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Student> Students
        {
            get { return this.GetRepository<Student>(); }
        }

        public IRepository<Course> Courses
        {
            get { return this.GetRepository<Course>(); }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }


        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(Repository<T>);
                this.repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }


    }
}
