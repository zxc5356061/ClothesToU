﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.UseCases.EditProfile
{
    public class EditProfileRequest
	{
		public string CurrentUserAccount { get; set; }
		public string Account { get; set; }
		public string Name { get; set; }
		public string Mobile { get; set; }
		public string Address { get; set; }
	}
}