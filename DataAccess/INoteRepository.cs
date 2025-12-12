using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public interface INoteRepository
	{
		Task CreateAsync(Note note, CancellationToken cancellationToken = default);
		Task<Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
		Task UpdateAsync(Note note, CancellationToken cancellationToken = default);
		Task DeleteAsync(Note note, CancellationToken cancellationToken = default);
	}
}
