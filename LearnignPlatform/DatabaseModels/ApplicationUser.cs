using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.DatabaseModels
{// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ApplicationUser()
        {
           this.Courses = new HashSet<Course>();
        }

        public string StudentId { get; set; }

        private ICollection<Course> courses;

        public virtual  ICollection<Course> Courses
        {
            get { return courses; }
            set { courses = value; }
        }

        //public Course Course { get; set; }

        public bool IsEnrolledforCurrentCourse { get; set; }

        //private ICollection<Course> courses;

        //public virtual ICollection<Course> Courses
        //{
        //    get { return courses; }
        //    set { courses = value; }
        //}

    }
}
