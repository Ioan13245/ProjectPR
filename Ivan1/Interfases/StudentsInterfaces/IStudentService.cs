using Ivan1.Database;
using Ivan1.Filters.StudentFilters;
using Ivan1.Models;
using Microsoft.EntityFrameworkCore;


namespace Ivan1.Interfases.StudentsInterfaces
{
	public interface IStudentService
	{
		public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
	}
	public class StudentService : IStudentService
	{
		private readonly StudentDbContext _dbcontext;
		public StudentService(StudentDbContext dbcontext)
		{
			_dbcontext = dbcontext;
		}
		public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
		{
			var students = _dbcontext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);
			return students;
		}
	}
}
