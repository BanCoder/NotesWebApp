using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public interface INoteService
	{
		Task CreateAsync(string text, CancellationToken cancellationToken = default);
		Task<string> GetByIdAsync(int id, CancellationToken cancellationToken = default);
		Task UpdateAsync(int id, string newText, CancellationToken cancellationToken = default);
		Task DeleteAsync(int id, CancellationToken cancellationToken = default);
	}
}
