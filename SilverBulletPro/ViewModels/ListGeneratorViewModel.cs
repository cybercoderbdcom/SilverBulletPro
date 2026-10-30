using System;
using System.Linq;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001BA RID: 442
	internal class ListGeneratorViewModel : ViewModelBase
	{
		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000CC8 RID: 3272 RVA: 0x00045ADF File Offset: 0x00043CDF
		// (set) Token: 0x06000CC9 RID: 3273 RVA: 0x00045AE7 File Offset: 0x00043CE7
		public bool OnlyLuhn
		{
			get
			{
				return this.onlyLuhn;
			}
			set
			{
				this.onlyLuhn = value;
				this.OnPropertyChanged("OnlyLuhn");
				this.OnPropertyChanged("OutputLines");
				this.OnPropertyChanged("OutputSize");
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000CCA RID: 3274 RVA: 0x00045B11 File Offset: 0x00043D11
		// (set) Token: 0x06000CCB RID: 3275 RVA: 0x00045B19 File Offset: 0x00043D19
		public bool AutoImport
		{
			get
			{
				return this.autoImport;
			}
			set
			{
				this.autoImport = value;
				this.OnPropertyChanged("AutoImport");
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000CCC RID: 3276 RVA: 0x00045B2D File Offset: 0x00043D2D
		// (set) Token: 0x06000CCD RID: 3277 RVA: 0x00045B35 File Offset: 0x00043D35
		public string Mask
		{
			get
			{
				return this.mask;
			}
			set
			{
				this.mask = value;
				this.OnPropertyChanged("Mask");
				this.OnPropertyChanged("OutputLines");
				this.OnPropertyChanged("OutputSize");
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000CCE RID: 3278 RVA: 0x00045B5F File Offset: 0x00043D5F
		// (set) Token: 0x06000CCF RID: 3279 RVA: 0x00045B67 File Offset: 0x00043D67
		public string AllowedCharacters
		{
			get
			{
				return this.allowedCharacters;
			}
			set
			{
				this.allowedCharacters = value;
				this.OnPropertyChanged("AllowedCharacters");
				this.OnPropertyChanged("OutputLines");
				this.OnPropertyChanged("OutputSize");
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000CD0 RID: 3280 RVA: 0x00045B94 File Offset: 0x00043D94
		public int OutputLines
		{
			get
			{
				string text = this.Mask.Split(':', StringSplitOptions.None)[0].Replace("*", "");
				int num = (from c in this.Mask.ToCharArray()
				where c == '*'
				select c).Count<char>();
				int num2 = (int)Math.Pow((double)this.AllowedCharacters.Length, (double)num);
				bool flag;
				if (!text.ToCharArray().Any((char c) => !char.IsDigit(c)))
				{
					flag = !this.AllowedCharacters.ToCharArray().Any((char c) => !char.IsDigit(c));
				}
				else
				{
					flag = false;
				}
				if (!flag || !this.OnlyLuhn)
				{
					return num2;
				}
				return num2 / 10;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x00045C7A File Offset: 0x00043E7A
		public string OutputSize
		{
			get
			{
				return ListGeneratorViewModel.SizeSuffix((long)(2 * this.Mask.Length * this.OutputLines), 0);
			}
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x00045C98 File Offset: 0x00043E98
		private static string SizeSuffix(long value, int decimalPlaces = 1)
		{
			if (decimalPlaces < 0)
			{
				throw new ArgumentOutOfRangeException("decimalPlaces");
			}
			if (value < 0L)
			{
				return "-" + ListGeneratorViewModel.SizeSuffix(-value, 1);
			}
			if (value == 0L)
			{
				return string.Format("{0:n" + decimalPlaces.ToString() + "} bytes", 0);
			}
			int num = (int)Math.Log((double)value, 1024.0);
			decimal num2 = value / (1L << num * 10);
			if (Math.Round(num2, decimalPlaces) >= 1000m)
			{
				num++;
				num2 /= 1024m;
			}
			return string.Format("{0:n" + decimalPlaces.ToString() + "} {1}", num2, ListGeneratorViewModel.SizeSuffixes[num]);
		}

		// Token: 0x04000657 RID: 1623
		private bool onlyLuhn;

		// Token: 0x04000658 RID: 1624
		private bool autoImport;

		// Token: 0x04000659 RID: 1625
		private string mask = "657438923467423847****:**";

		// Token: 0x0400065A RID: 1626
		private string allowedCharacters = "0123456789";

		// Token: 0x0400065B RID: 1627
		private static readonly string[] SizeSuffixes = new string[]
		{
			"bytes",
			"KB",
			"MB",
			"GB",
			"TB",
			"PB",
			"EB",
			"ZB",
			"YB"
		};
	}
}
