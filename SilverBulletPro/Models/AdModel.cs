using System;
using System.Windows.Media;

namespace SilverBulletPro.Models
{
	// Token: 0x020001E8 RID: 488
	public class AdModel
	{
		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000F68 RID: 3944 RVA: 0x0004D1C7 File Offset: 0x0004B3C7
		// (set) Token: 0x06000F69 RID: 3945 RVA: 0x0004D1CF File Offset: 0x0004B3CF
		public string Logo { get; set; }

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000F6A RID: 3946 RVA: 0x0004D1D8 File Offset: 0x0004B3D8
		// (set) Token: 0x06000F6B RID: 3947 RVA: 0x0004D1E0 File Offset: 0x0004B3E0
		public string LogoMargin { get; set; } = "0,0,0,0";

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000F6C RID: 3948 RVA: 0x0004D1E9 File Offset: 0x0004B3E9
		// (set) Token: 0x06000F6D RID: 3949 RVA: 0x0004D1F1 File Offset: 0x0004B3F1
		public Stretch Stretch { get; set; } = Stretch.Fill;

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000F6E RID: 3950 RVA: 0x0004D1FA File Offset: 0x0004B3FA
		// (set) Token: 0x06000F6F RID: 3951 RVA: 0x0004D202 File Offset: 0x0004B402
		public string LogoBackColor { get; set; }

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000F70 RID: 3952 RVA: 0x0004D20B File Offset: 0x0004B40B
		// (set) Token: 0x06000F71 RID: 3953 RVA: 0x0004D213 File Offset: 0x0004B413
		public double Height { get; set; } = 285.0;

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000F72 RID: 3954 RVA: 0x0004D21C File Offset: 0x0004B41C
		// (set) Token: 0x06000F73 RID: 3955 RVA: 0x0004D224 File Offset: 0x0004B424
		public string BorderColor { get; set; }

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000F74 RID: 3956 RVA: 0x0004D22D File Offset: 0x0004B42D
		// (set) Token: 0x06000F75 RID: 3957 RVA: 0x0004D235 File Offset: 0x0004B435
		public string BackColor { get; set; }

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000F76 RID: 3958 RVA: 0x0004D23E File Offset: 0x0004B43E
		// (set) Token: 0x06000F77 RID: 3959 RVA: 0x0004D246 File Offset: 0x0004B446
		public string Tags { get; set; }

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000F78 RID: 3960 RVA: 0x0004D24F File Offset: 0x0004B44F
		// (set) Token: 0x06000F79 RID: 3961 RVA: 0x0004D257 File Offset: 0x0004B457
		public string Name { get; set; } = "";

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000F7A RID: 3962 RVA: 0x0004D260 File Offset: 0x0004B460
		// (set) Token: 0x06000F7B RID: 3963 RVA: 0x0004D28F File Offset: 0x0004B48F
		public string NameForeColor
		{
			get
			{
				if (string.IsNullOrWhiteSpace(this.nameForeColor))
				{
					return this.nameForeColor = Utils.GetMainForeColor();
				}
				return this.nameForeColor;
			}
			set
			{
				this.nameForeColor = value;
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000F7C RID: 3964 RVA: 0x0004D298 File Offset: 0x0004B498
		// (set) Token: 0x06000F7D RID: 3965 RVA: 0x0004D2A0 File Offset: 0x0004B4A0
		public string Description { get; set; } = "";

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000F7E RID: 3966 RVA: 0x0004D2AC File Offset: 0x0004B4AC
		// (set) Token: 0x06000F7F RID: 3967 RVA: 0x0004D2DB File Offset: 0x0004B4DB
		public string DescForeColor
		{
			get
			{
				if (string.IsNullOrWhiteSpace(this.descForeColor))
				{
					return this.descForeColor = Utils.GetMainForeColor();
				}
				return this.descForeColor;
			}
			set
			{
				this.descForeColor = value;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000F80 RID: 3968 RVA: 0x0004D2E4 File Offset: 0x0004B4E4
		// (set) Token: 0x06000F81 RID: 3969 RVA: 0x0004D2EC File Offset: 0x0004B4EC
		public string Text { get; set; } = "";

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000F82 RID: 3970 RVA: 0x0004D2F5 File Offset: 0x0004B4F5
		// (set) Token: 0x06000F83 RID: 3971 RVA: 0x0004D2FD File Offset: 0x0004B4FD
		public string Geometry { get; set; }

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000F84 RID: 3972 RVA: 0x0004D306 File Offset: 0x0004B506
		// (set) Token: 0x06000F85 RID: 3973 RVA: 0x0004D30E File Offset: 0x0004B50E
		public double GeometryWidth { get; set; } = 12.0;

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000F86 RID: 3974 RVA: 0x0004D317 File Offset: 0x0004B517
		// (set) Token: 0x06000F87 RID: 3975 RVA: 0x0004D31F File Offset: 0x0004B51F
		public double GeometryHeight { get; set; } = 12.0;

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000F88 RID: 3976 RVA: 0x0004D328 File Offset: 0x0004B528
		// (set) Token: 0x06000F89 RID: 3977 RVA: 0x0004D357 File Offset: 0x0004B557
		public string BtnForeColor
		{
			get
			{
				if (string.IsNullOrWhiteSpace(this.btnForeColor))
				{
					return this.btnForeColor = Utils.GetMainForeColor();
				}
				return this.btnForeColor;
			}
			set
			{
				this.btnForeColor = value;
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000F8A RID: 3978 RVA: 0x0004D360 File Offset: 0x0004B560
		// (set) Token: 0x06000F8B RID: 3979 RVA: 0x0004D368 File Offset: 0x0004B568
		public string BtnBackColor { get; set; }

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000F8C RID: 3980 RVA: 0x0004D371 File Offset: 0x0004B571
		// (set) Token: 0x06000F8D RID: 3981 RVA: 0x0004D379 File Offset: 0x0004B579
		public string Address { get; set; } = "";

		// Token: 0x04000728 RID: 1832
		private string nameForeColor = "";

		// Token: 0x0400072A RID: 1834
		private string descForeColor = "";

		// Token: 0x0400072F RID: 1839
		private string btnForeColor = "";
	}
}
