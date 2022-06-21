using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESY.TEST.Models
{
	[Table("products")]
	public class ProductModel
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[Display(Name = "Item name")]
		public string Name
		{
			get;
			set;
		}

		[Required]
		[Display(Name = "Item quantity")]
		public int Quantity
		{
			get;
			set;
		}

		[Required]
		[Display(Name = "Item price")]
		public double Price
		{
			get;
			set;
		}
	}
}