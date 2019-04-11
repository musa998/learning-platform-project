
namespace StudentSystem.Data
{
    using StudentSystem.DatabaseModels;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IApplicationDbContext
    {
        IDbSet<Student> Students { get; set; }
        IDbSet<Course> Courses { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
        IDbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
