using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace NotesWebApp
{
	[ApiController]
	[Route("Note")]
	public class NoteController(INoteService noteService): ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> CreateAsync(string text)
		{
			await noteService.CreateAsync(text);
			return NoContent(); 
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetNoteAsync([FromRoute]int id)
		{
			var result = await noteService.GetByIdAsync(id);
			return Ok(result); 
		}
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] int id, string newText)
		{
			await noteService.UpdateAsync(id, newText);
			return NoContent();
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteAsync([FromRoute] int id)
		{
			await noteService.DeleteAsync(id);
			return NoContent();
		}
	}
}
