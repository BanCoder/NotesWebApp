using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess; 

namespace BusinessLogic
{
	internal class NoteService(INoteRepository noteRepository): INoteService
	{
		public async Task CreateAsync(string text, CancellationToken cancellationToken = default)
		{
			var note = new Note
			{
				Text = text
			}; 
			await noteRepository.CreateAsync(note, cancellationToken);
		}
		public async Task<string> GetByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			var note = await noteRepository.GetByIdAsync(id, cancellationToken); 
			if (note == null)
			{
				throw new Exception("Note is not found"); 
			}
			return note.Text;
		}
		public async Task UpdateAsync(int id, string newText, CancellationToken cancellationToken = default)
		{
			var note = await noteRepository.GetByIdAsync(id, cancellationToken);
			if (note == null)
			{
				throw new Exception("Note is not found");
			}
			note.Text = newText;
			await noteRepository.UpdateAsync(note, cancellationToken); 
		}
		public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
		{
			var note = await noteRepository.GetByIdAsync(id, cancellationToken);
			if (note == null)
			{
				throw new Exception("Note is not found");
			}
			await noteRepository.DeleteAsync(note, cancellationToken);
		}
	}
}
