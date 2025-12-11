using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class Note
	{
		public int Id { get; set; }
		public string Text {  get; set; }
		public DateTime Created {  get; set; }
		public DateTime Updated { get; set; }
	}
}
