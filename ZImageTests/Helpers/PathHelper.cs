using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZImageTests.Helpers
{
	public static class PathHelper
	{
		public static string GetDir(string dirName)
		{
			var currDir = Directory.GetCurrentDirectory();
			dirName = dirName.Replace("\\", "").Replace("/", "");
			
			while (Directory.GetDirectories(currDir).All(d => d.Split('\\', '/').Last().ToLower() != dirName.ToLower()))
			{
				currDir = GetParent(currDir);
				if(currDir == null) 
					return string.Empty;
			}
			return Path.Combine(currDir, dirName);
		}

		public static string GetParent(string dirName) => string.Join('\\', dirName.Split("\\", '/').SkipLast(1));
	}
}
