using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.UseCases.EditProfile
{
    public class EditProfileRequest
	{
		public int Id { get; set; }
		public string Account { get; set; }
		public string Name { get; set; }
		public bool IsConfirmed { get; set; }
		public string ConfirmCode { get; set; }
		public string Mobile { get; set; }
		public string Address { get; set; }
	}
}