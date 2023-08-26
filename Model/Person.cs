using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace dotnet_vite_vuejs.Model
{
	public class Persons
	{
		[Key]
		public int PersonId { get; set; }
		[Required]
		[StringLength(50)]
		public string? LastName { get; set; }
		[Required]
		public string? FirstName { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
        [Required]
        public string? City { get; set; }
    }
	//public class ProductContext : DbContext
	//{
	//	public DbSet<Persons> Persons { set; get; }
	//	private string connectionString = @"Server=cmsblog123.mysql.database.azure.com;Database=cms;Uid=binhnguyen;Pwd=M@roen4ee;";

	//	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//	{
	//		base.OnConfiguring(optionsBuilder);
	//		optionsBuilder.UseMySQL(connectionString);
	//	}
	//}

}

