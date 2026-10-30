using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001F8 RID: 504
	public static class EnumerableExtensions
	{
		// Token: 0x06001028 RID: 4136 RVA: 0x0004E794 File Offset: 0x0004C994
		public static void SaveToFile<T>(this IEnumerable<T> items, string fileName, Func<T, string> mapping)
		{
			if (string.IsNullOrWhiteSpace(fileName))
			{
				throw new ArgumentNullException("The filename must not be empty");
			}
			File.WriteAllLines(fileName, from i in items
			select mapping(i));
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x0004E7DC File Offset: 0x0004C9DC
		public static void CopyToClipboard<T>(this IEnumerable<T> items, Func<T, string> mapping)
		{
			Clipboard.SetText(string.Join(Environment.NewLine, from i in items
			select mapping(i)));
		}
	}
}
