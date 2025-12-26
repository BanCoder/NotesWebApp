using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace DataAccess
{
	public static class Extensions
	{
		public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection") ?? configuration["ConnectionSettings:sqlConnection"]; 
			serviceCollection.AddScoped<INoteRepository, NoteRepository>(); 
			serviceCollection.AddDbContext<AppContext>(x =>
			{
				x.UseNpgsql(connectionString); 
			}); 
			return serviceCollection;
		}
	}
}
