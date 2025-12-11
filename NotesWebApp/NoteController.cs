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
	}
}
