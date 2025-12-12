using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
