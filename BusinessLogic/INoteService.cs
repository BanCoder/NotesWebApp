using DataAccess;
namespace BusinessLogic
{
	public interface INoteService
	{
		Task CreateAsync(string title,string description, CancellationToken cancellationToken = default);
		Task<List<NoteDto>> GetAllAsync(string? search, string? sortOrder,CancellationToken cancellationToken = default);
		Task UpdateAsync(int id, string title, string description, CancellationToken cancellationToken = default);
		Task DeleteAsync(int id, CancellationToken cancellationToken = default);
	}
}
