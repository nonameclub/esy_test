using ESY.TEST.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESY.TEST.Models
{
	[Table("product_audit")]
	public class ProductAuditModel
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[Display(Name = "User name")]
		public string User
		{
			get;
			set;
		}

		[Required]
		[Display(Name = "Action")]
		public string Action
		{
			get;
			set;
		}

		[Required]
		[Display(Name = "Data")]
		public DateTime Date
		{
			get;
			set;
		}
	}
}