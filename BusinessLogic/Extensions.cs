using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public static class Extensions
	{
		public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<INoteService, NoteService>(); 
			return serviceCollection; 
		}
	}
}
