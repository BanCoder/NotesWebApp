using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
	public class AppContext(DbContextOptions<AppContext> options): DbContext(options)
	{
		public DbSet<Note> Notes { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Note>().HasKey(x => x.Id);
			modelBuilder.Entity<Note>().Property(x => x.Title).HasMaxLength(50); 
			modelBuilder.Entity<Note>().Property(x => x.Description).HasMaxLength(150);
			base.OnModelCreating(modelBuilder);
		}
	}
}
