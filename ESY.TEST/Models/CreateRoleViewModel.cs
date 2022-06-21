﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESY.TEST.Models
{
	public class CreateRoleViewModel
	{
		[Required]
		[Display(Name = "Role name")]
		public string RoleName
		{
			get;
			set;
		}
	}
}