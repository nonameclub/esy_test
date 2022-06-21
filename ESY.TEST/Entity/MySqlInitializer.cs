using ESY.TEST.Models;
using ESY.TEST.Models.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace ESY.TEST.Entity
{
    public class MySqlInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

			string roleName = "administrator";
			string roleUser = "user";
			string password = "123456";

			//Create Role Admin if it does not exist
			if (!roleManager.RoleExists(roleName))
			{
				var roleresult = roleManager.Create(new IdentityRole(roleName));
				var roleresult2 = roleManager.Create(new IdentityRole(roleUser));
			}

			// Create Products
			var products = new List<ProductModel>
			{
				new ProductModel { Name = "HDD 1TB", Quantity = 55, Price = 74.09 },
				new ProductModel { Name = "RAM DDR4 16GB", Quantity = 47, Price = 80.32 },
				new ProductModel { Name = "HDD SSD 512GB", Quantity = 102, Price = 190.99 }
			};
			context.Products.AddRange(products);
			context.SaveChanges();

			//Create User=Admin with password=123456
			var user = new ApplicationUser();
			user.UserName = "admin@admin.com";
			var adminresult = userManager.Create(user, password);
			//Add User Admin to Role Admin
			if (adminresult.Succeeded)
			{
				var result = userManager.AddToRole(user.Id, roleName);
			}
			base.Seed(context);
		}
	}
}