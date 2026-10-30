using System;

namespace SilverBulletPro.Models
{
	// Token: 0x020001E9 RID: 489
	public class MarketModel
	{
		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000F8F RID: 3983 RVA: 0x0004D423 File Offset: 0x0004B623
		// (set) Token: 0x06000F90 RID: 3984 RVA: 0x0004D42B File Offset: 0x0004B62B
		public string Icon { get; set; }

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000F91 RID: 3985 RVA: 0x0004D434 File Offset: 0x0004B634
		// (set) Token: 0x06000F92 RID: 3986 RVA: 0x0004D43C File Offset: 0x0004B63C
		public string IconBorderColor { get; set; }

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000F93 RID: 3987 RVA: 0x0004D445 File Offset: 0x0004B645
		// (set) Token: 0x06000F94 RID: 3988 RVA: 0x0004D44D File Offset: 0x0004B64D
		public string Text { get; set; }

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000F95 RID: 3989 RVA: 0x0004D458 File Offset: 0x0004B658
		// (set) Token: 0x06000F96 RID: 3990 RVA: 0x0004D487 File Offset: 0x0004B687
		public string TextForeColor
		{
			get
			{
				if (string.IsNullOrWhiteSpace(this.textForeColor))
				{
					return this.textForeColor = Utils.GetMainForeColor();
				}
				return this.textForeColor;
			}
			set
			{
				this.textForeColor = value;
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000F97 RID: 3991 RVA: 0x0004D490 File Offset: 0x0004B690
		// (set) Token: 0x06000F98 RID: 3992 RVA: 0x0004D498 File Offset: 0x0004B698
		public string[] Content { get; set; }

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000F99 RID: 3993 RVA: 0x0004D4A1 File Offset: 0x0004B6A1
		// (set) Token: 0x06000F9A RID: 3994 RVA: 0x0004D4A9 File Offset: 0x0004B6A9
		public string Seller { get; set; }

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000F9B RID: 3995 RVA: 0x0004D4B4 File Offset: 0x0004B6B4
		// (set) Token: 0x06000F9C RID: 3996 RVA: 0x0004D4E3 File Offset: 0x0004B6E3
		public string SellerForeColor
		{
			get
			{
				if (string.IsNullOrWhiteSpace(this.sellerForeColor))
				{
					return this.sellerForeColor = Utils.GetMainForeColor();
				}
				return this.sellerForeColor;
			}
			set
			{
				this.sellerForeColor = value;
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000F9D RID: 3997 RVA: 0x0004D4EC File Offset: 0x0004B6EC
		// (set) Token: 0x06000F9E RID: 3998 RVA: 0x0004D4F4 File Offset: 0x0004B6F4
		public string SellerRank { get; set; }

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000F9F RID: 3999 RVA: 0x0004D4FD File Offset: 0x0004B6FD
		// (set) Token: 0x06000FA0 RID: 4000 RVA: 0x0004D505 File Offset: 0x0004B705
		public string SellerRankForeColor { get; set; } = "#fff";

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000FA1 RID: 4001 RVA: 0x0004D50E File Offset: 0x0004B70E
		// (set) Token: 0x06000FA2 RID: 4002 RVA: 0x0004D516 File Offset: 0x0004B716
		public string SellerRankBackColor { get; set; } = "#0C46A9";

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000FA3 RID: 4003 RVA: 0x0004D51F File Offset: 0x0004B71F
		// (set) Token: 0x06000FA4 RID: 4004 RVA: 0x0004D527 File Offset: 0x0004B727
		public string BackColor { get; set; }

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000FA5 RID: 4005 RVA: 0x0004D530 File Offset: 0x0004B730
		// (set) Token: 0x06000FA6 RID: 4006 RVA: 0x0004D538 File Offset: 0x0004B738
		public string BorderColor { get; set; } = "#0C46A9";

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000FA7 RID: 4007 RVA: 0x0004D541 File Offset: 0x0004B741
		// (set) Token: 0x06000FA8 RID: 4008 RVA: 0x0004D549 File Offset: 0x0004B749
		public string BorderThickness { get; set; } = "6,3,3,3";

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000FA9 RID: 4009 RVA: 0x0004D552 File Offset: 0x0004B752
		// (set) Token: 0x06000FAA RID: 4010 RVA: 0x0004D55A File Offset: 0x0004B75A
		public string Description { get; set; } = "";

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000FAB RID: 4011 RVA: 0x0004D564 File Offset: 0x0004B764
		// (set) Token: 0x06000FAC RID: 4012 RVA: 0x0004D593 File Offset: 0x0004B793
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

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000FAD RID: 4013 RVA: 0x0004D59C File Offset: 0x0004B79C
		// (set) Token: 0x06000FAE RID: 4014 RVA: 0x0004D5A4 File Offset: 0x0004B7A4
		public string CreationDate { get; set; }

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000FAF RID: 4015 RVA: 0x0004D5B0 File Offset: 0x0004B7B0
		// (set) Token: 0x06000FB0 RID: 4016 RVA: 0x0004D5DF File Offset: 0x0004B7DF
		public string CreationDateForeColor
		{
			get
			{
				if (string.IsNullOrWhiteSpace(this.creationDateForeColor))
				{
					return this.creationDateForeColor = Utils.GetMainForeColor();
				}
				return this.creationDateForeColor;
			}
			set
			{
				this.creationDateForeColor = value;
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000FB1 RID: 4017 RVA: 0x0004D5E8 File Offset: 0x0004B7E8
		// (set) Token: 0x06000FB2 RID: 4018 RVA: 0x0004D5F0 File Offset: 0x0004B7F0
		public string Category { get; set; } = "";

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000FB3 RID: 4019 RVA: 0x0004D5FC File Offset: 0x0004B7FC
		// (set) Token: 0x06000FB4 RID: 4020 RVA: 0x0004D62B File Offset: 0x0004B82B
		public string CategoryForeColor
		{
			get
			{
				if (string.IsNullOrWhiteSpace(this.categoryForeColor))
				{
					return this.categoryForeColor = Utils.GetMainForeColor();
				}
				return this.categoryForeColor;
			}
			set
			{
				this.categoryForeColor = value;
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000FB5 RID: 4021 RVA: 0x0004D634 File Offset: 0x0004B834
		// (set) Token: 0x06000FB6 RID: 4022 RVA: 0x0004D63C File Offset: 0x0004B83C
		public string Price { get; set; } = "0";

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000FB7 RID: 4023 RVA: 0x0004D645 File Offset: 0x0004B845
		// (set) Token: 0x06000FB8 RID: 4024 RVA: 0x0004D64D File Offset: 0x0004B84D
		public string Discount { get; set; } = "0";

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000FB9 RID: 4025 RVA: 0x0004D658 File Offset: 0x0004B858
		// (set) Token: 0x06000FBA RID: 4026 RVA: 0x0004D687 File Offset: 0x0004B887
		public string DiscountForeColor
		{
			get
			{
				if (string.IsNullOrWhiteSpace(this.discountForeColor))
				{
					return this.discountForeColor = Utils.GetMainForeColor();
				}
				return this.discountForeColor;
			}
			set
			{
				this.discountForeColor = value;
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000FBB RID: 4027 RVA: 0x0004D690 File Offset: 0x0004B890
		// (set) Token: 0x06000FBC RID: 4028 RVA: 0x0004D6BF File Offset: 0x0004B8BF
		public string PriceForeColor
		{
			get
			{
				if (string.IsNullOrWhiteSpace(this.priceForeColor))
				{
					return this.priceForeColor = Utils.GetMainForeColor();
				}
				return this.priceForeColor;
			}
			set
			{
				this.priceForeColor = value;
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000FBD RID: 4029 RVA: 0x0004D6C8 File Offset: 0x0004B8C8
		// (set) Token: 0x06000FBE RID: 4030 RVA: 0x0004D6D0 File Offset: 0x0004B8D0
		public string FooterBackColor { get; set; }

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000FBF RID: 4031 RVA: 0x0004D6D9 File Offset: 0x0004B8D9
		// (set) Token: 0x06000FC0 RID: 4032 RVA: 0x0004D6E1 File Offset: 0x0004B8E1
		public string Tags { get; set; }

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000FC1 RID: 4033 RVA: 0x0004D6EA File Offset: 0x0004B8EA
		// (set) Token: 0x06000FC2 RID: 4034 RVA: 0x0004D6F2 File Offset: 0x0004B8F2
		public string Buy { get; set; } = "";

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000FC3 RID: 4035 RVA: 0x0004D6FB File Offset: 0x0004B8FB
		// (set) Token: 0x06000FC4 RID: 4036 RVA: 0x0004D703 File Offset: 0x0004B903
		public string Report { get; set; } = "";

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000FC5 RID: 4037 RVA: 0x0004D70C File Offset: 0x0004B90C
		// (set) Token: 0x06000FC6 RID: 4038 RVA: 0x0004D714 File Offset: 0x0004B914
		public string MediaElement { get; set; }

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000FC7 RID: 4039 RVA: 0x0004D71D File Offset: 0x0004B91D
		// (set) Token: 0x06000FC8 RID: 4040 RVA: 0x0004D725 File Offset: 0x0004B925
		public string MediaElementBackColor { get; set; } = "#313131";

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000FC9 RID: 4041 RVA: 0x0004D72E File Offset: 0x0004B92E
		// (set) Token: 0x06000FCA RID: 4042 RVA: 0x0004D736 File Offset: 0x0004B936
		public string Telegram { get; set; } = "";

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000FCB RID: 4043 RVA: 0x0004D73F File Offset: 0x0004B93F
		// (set) Token: 0x06000FCC RID: 4044 RVA: 0x0004D747 File Offset: 0x0004B947
		public string TlgBackColor { get; set; } = "#2DA5E1";

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000FCD RID: 4045 RVA: 0x0004D750 File Offset: 0x0004B950
		// (set) Token: 0x06000FCE RID: 4046 RVA: 0x0004D77F File Offset: 0x0004B97F
		public string TlgForeColor
		{
			get
			{
				if (string.IsNullOrWhiteSpace(this.tlgForeColor))
				{
					return this.tlgForeColor = Utils.GetMainForeColor();
				}
				return this.tlgForeColor;
			}
			set
			{
				this.tlgForeColor = value;
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000FCF RID: 4047 RVA: 0x0004D788 File Offset: 0x0004B988
		// (set) Token: 0x06000FD0 RID: 4048 RVA: 0x0004D790 File Offset: 0x0004B990
		public string Discord { get; set; } = "";

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000FD1 RID: 4049 RVA: 0x0004D799 File Offset: 0x0004B999
		// (set) Token: 0x06000FD2 RID: 4050 RVA: 0x0004D7A1 File Offset: 0x0004B9A1
		public string DiscordBackColor { get; set; } = "#5562EA";

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000FD3 RID: 4051 RVA: 0x0004D7AC File Offset: 0x0004B9AC
		// (set) Token: 0x06000FD4 RID: 4052 RVA: 0x0004D7DB File Offset: 0x0004B9DB
		public string DiscordForeColor
		{
			get
			{
				if (string.IsNullOrWhiteSpace(this.discordForeColor))
				{
					return this.discordForeColor = Utils.GetMainForeColor();
				}
				return this.discordForeColor;
			}
			set
			{
				this.discordForeColor = value;
			}
		}

		// Token: 0x04000735 RID: 1845
		private string textForeColor = "";

		// Token: 0x04000738 RID: 1848
		private string sellerForeColor = "";

		// Token: 0x04000740 RID: 1856
		private string descForeColor = "";

		// Token: 0x04000742 RID: 1858
		private string creationDateForeColor = "";

		// Token: 0x04000744 RID: 1860
		private string categoryForeColor = "";

		// Token: 0x04000747 RID: 1863
		private string discountForeColor = "";

		// Token: 0x04000748 RID: 1864
		private string priceForeColor = "";

		// Token: 0x04000751 RID: 1873
		private string tlgForeColor = "";

		// Token: 0x04000754 RID: 1876
		private string discordForeColor = "";
	}
}
