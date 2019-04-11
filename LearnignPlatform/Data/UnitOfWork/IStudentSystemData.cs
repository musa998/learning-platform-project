
namespace StudentSystem.Data.UnitOfWork
{
    using StudentSystem.DatabaseModels;
    using StudentSystem.Data.Repositories;
   //дефинирани са всички Repository обекти за обмен на данни, както и метод за запис на състоянието на DbContext-а
    public interface IStudentSystemData
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Student> Students { get; }
        IRepository<Course> Courses { get; }
        void SaveChanges();
    }
}
