using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U.Utilities
{
	public class ImageHelper
	{
		public static bool IsImage(string fileName)
		{

			if (fileName == null) return false;
			string ext = System.IO.Path.GetExtension(fileName).ToLower();
			string[] imageExts = new string[] { ".gif", ".bmp", ".png", ".jpg", ".tif", ".tiff", ".jfif" };
			return imageExts.Contains(ext);
			

		}
	}
}
