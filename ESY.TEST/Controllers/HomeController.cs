using ESY.TEST.Models;
using ESY.TEST.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ESY.TEST.Controllers
{
	public class HomeController : Controller
	{
		static ApplicationDbContext _context = new ApplicationDbContext();
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Products()
        {
			ViewBag.Message = "Display Products.";
			
			return View(from products in _context.Products.ToList()
						select products);
		}

		[HttpPost]
		public ActionResult EditProduct(ProductModel product)
        {
			if (!this.User.IsInRole("administrator")) return RedirectToAction("Index");
			var model = _context.Products.Where(s => s.ID == product.ID).FirstOrDefault();
			model.Name = product.Name;
			model.Price = product.Price;
			model.Quantity = product.Quantity;

			var Audit = new ProductAuditModel();
			Audit.User = User.Identity.Name;
			Audit.Date = DateTime.Now;
			Audit.Action = "Edited Product with ID: " + product.ID.ToString();
			_context.ProductAudit.Add(Audit);

			_context.SaveChanges();
			return RedirectToAction("Products", "Home");
		}

		public ActionResult EditProduct(int ID)
        {
			if (!this.User.IsInRole("administrator")) return RedirectToAction("Index");

			var product = _context.Products.Where(s => s.ID == ID).FirstOrDefault();

			return View(product);
        }

		public ActionResult DeleteProduct(int ID)
        {
			if (!this.User.IsInRole("administrator")) return RedirectToAction("Index");

			var product = _context.Products.Where(s => s.ID == ID).FirstOrDefault();

			return View(product);
		}

		[HttpPost]
		public ActionResult DeleteProduct(ProductModel product)
		{
			if (!this.User.IsInRole("administrator")) return RedirectToAction("Index");

			var model = _context.Products.Where(s => s.ID == product.ID).FirstOrDefault();
			_context.Products.Remove(model);

			var Audit = new ProductAuditModel();
			Audit.User = User.Identity.Name;
			Audit.Date = DateTime.Now;
			Audit.Action = "Deleted Product with ID: " + product.ID.ToString();
			_context.ProductAudit.Add(Audit);
			_context.SaveChanges();

			return RedirectToAction("Products", "Home");
		}

		public ActionResult CreateProduct()
        {
			if (!this.User.IsInRole("administrator")) return RedirectToAction("Index");

			return View();
        }

		[HttpPost]
		public ActionResult CreateProduct(ProductModel product)
		{
			if (!this.User.IsInRole("administrator")) return RedirectToAction("Index");

			_context.Products.Add(product);
			_context.SaveChanges();

			var Audit = new ProductAuditModel();
			Audit.User = User.Identity.Name;
			Audit.Date = DateTime.Now;
			Audit.Action = "Creaated Product with ID: " + product.ID.ToString();
			_context.ProductAudit.Add(Audit);
			_context.SaveChanges();
			

			return RedirectToAction("Products", "Home");
		}

		[HttpGet]
		public async Task<ActionResult> Audit()
        {
			var audits = _context.ProductAudit.OrderByDescending(x => x.Date).ToList();
			return Json(audits, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}