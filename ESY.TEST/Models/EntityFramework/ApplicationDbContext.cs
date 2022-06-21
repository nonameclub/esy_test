using ESY.TEST.Entity;
using ESY.TEST.Models;
using ESY.TEST.Models.EntityFramework;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ESY.TEST.Models.EntityFramework
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		DbSet<RefreshToken> RefreshTokens { get; set; }
		public DbSet<ProductModel> Products { get; set; }
		public DbSet<ProductAuditModel> ProductAudit { get; set; }
		static ApplicationDbContext()
		{
			Database.SetInitializer(new MySqlInitializer());
		}

		public ApplicationDbContext()
			: base("DefaultConnection")
		{
		}
	}
}