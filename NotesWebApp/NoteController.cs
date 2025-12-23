using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace NotesWebApp
{
	[ApiController]
	[Route("Note")]
	public class NoteController(INoteService noteService): ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> CreateAsync(string title, string description)
		{
			await noteService.CreateAsync(title, description);
			return NoContent(); 
		}
		[HttpGet]
		public async Task<IActionResult> GetAllNotes([FromQuery] string? search, [FromQuery] string? sortOrder = "desc")
		{
			var result = await noteService.GetAllAsync(search, sortOrder);
			return Ok(result);
		}
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] int id, string title, string description)
		{
			await noteService.UpdateAsync(id, title, description);
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
