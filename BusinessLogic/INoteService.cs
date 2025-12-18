namespace BusinessLogic
{
	public interface INoteService
	{
		Task CreateAsync(string title,string description, CancellationToken cancellationToken = default);
		Task<List<NoteDto>> GetAllAsync(CancellationToken cancellationToken = default);
		Task UpdateAsync(int id, string title, string description, CancellationToken cancellationToken = default);
		Task DeleteAsync(int id, CancellationToken cancellationToken = default);
	}
	public class NoteDto 
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Created { get; set; }
	}

}
