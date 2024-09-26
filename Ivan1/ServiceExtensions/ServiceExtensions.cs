using Ivan1.Interfases.StudentsInterfaces;

namespace Ivan1.ServiceExtensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IStudentService, StudentService>();
			return services;
		}
	}
}
