using DataAccess.Model;
using DataAccess.Repository;

namespace BusinessLogic.Services
{
	public class NoteService(INoteRepository noteRepository): INoteService
	{
		
		public async Task CreateAsync(string title, string description, CancellationToken cancellationToken = default)
		{
			var note = new Note
			{
				Title = title,
				Description = description,
			}; 
			await noteRepository.CreateAsync(note, cancellationToken);
		}

		public async Task<List<NoteDto>> GetAllAsync(string? search, string? sortOrder, CancellationToken cancellationToken = default)
		{
			var notes = await noteRepository.GetAllAsync(cancellationToken);
			var filtered = notes.AsQueryable();

			if (!string.IsNullOrEmpty(search))
			{
				filtered = filtered.Where(n => n.Title.Contains(search, StringComparison.OrdinalIgnoreCase) || n.Description.Contains(search, StringComparison.OrdinalIgnoreCase));
			}
			filtered = sortOrder?.ToLower() == "asc" ? filtered.OrderBy(n => n.Created) : filtered.OrderByDescending(n => n.Created);
			return filtered.Select(n => new NoteDto
			{
				Id = n.Id,
				Title = n.Title,
				Description = n.Description,
				Created = n.Created
			}).ToList();
		}
		public async Task UpdateAsync(int id, string title, string description, CancellationToken cancellationToken = default)
		{
			var note = await noteRepository.GetByIdAsync(id,cancellationToken);
			if (note == null)
			{
				throw new Exception("Note is not found");
			}
			if (title != null)
			{
				note.Title = title;
			}
				
			if (description != null)
			{
				note.Description = description;
			}
			await noteRepository.UpdateAsync(note, cancellationToken); 
		}
		public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
		{
			var note = await noteRepository.GetByIdAsync(id,cancellationToken);
			if (note == null)
			{
				throw new Exception("Note is not found");
			}
			await noteRepository.DeleteAsync(note, cancellationToken);
		}
	}
}
