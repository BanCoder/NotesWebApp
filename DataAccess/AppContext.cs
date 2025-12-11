using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
	public class AppContext(DbContextOptions<AppContext> options): DbContext(options)
	{
		public DbSet<Note> Notes { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Note>().HasKey(x => x.Id);
			modelBuilder.Entity<Note>().Property(x => x.Text).HasMaxLength(150);
			base.OnModelCreating(modelBuilder);
		}
	}
}
