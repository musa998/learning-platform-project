using StudentSystem.Data.UnitOfWork;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using Microsoft.AspNet.Identity;

using StudentSystem.DatabaseModels;
namespace StudentSystem.Web.Controllers
{
    /* Този контролер съдържа инстанцирането на DB-context-a идващ от StudentSystemData,
       както и методи които да използваме на различни места в приложението*/
    public class BaseController : Controller
    {
        protected IStudentSystemData data;
        public BaseController ()
	{
        this.data = new StudentSystemData();
	}
      
        //Метод който връща List със selectItem за всеки предмет, по който преподава даден учител
        protected List<SelectListItem> TeacherSubjectsList(string id)
        {
            var teacherSubjects = this.data.Users.Find(id).Courses.ToList();
            var teacherSubjectsList = this.data.Courses.All().ToList().Select(x => new SelectListItem
            {
                Text = x.CourseName,
                Value = x.CourseId.ToString(),
                Selected = teacherSubjects.Any(c => c.CourseId == x.CourseId)
            }).ToList();
            return teacherSubjectsList;
        }
        //Метод който връща текущия логнат потребител
        private ApplicationUser GetCurrentUser()
        {
            string userId = this.User.Identity.GetUserId();
            var user = this.data.Users.All().FirstOrDefault(u => u.Id == userId);
            return user;
        }
        protected Student CurrentStudent
        {
            get
            {
                string userId = this.User.Identity.GetUserId();

                var user = this.data.Students.All().FirstOrDefault(u => u.Id == userId);
                return user;
            }
        }

        //Проперти за текущия логнат потребител
        protected ApplicationUser CurrentUser
        {
            get
            {
                string userId = this.User.Identity.GetUserId();
                var user = this.data.Users.All().FirstOrDefault(u => u.Id == userId);
                return user;
            }
        }
    }
}