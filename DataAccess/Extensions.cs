using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
	public static class Extensions
	{
		public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<INoteRepository, NoteRepository>(); 
			serviceCollection.AddDbContext<AppContext>(x =>
			{
				x.UseNpgsql("Server=localhost;Port=5432;Database=NoteDb; User Id=postgres; Password=postgres"); 
			}); 
			return serviceCollection;
		}
	}
}
