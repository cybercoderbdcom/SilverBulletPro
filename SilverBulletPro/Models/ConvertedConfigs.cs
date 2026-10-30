using System;
using SilverBulletPro.Core;

namespace SilverBulletPro.Models
{
	// Token: 0x020001EC RID: 492
	public class ConvertedConfigs
	{
		// Token: 0x06001006 RID: 4102 RVA: 0x0004DBBF File Offset: 0x0004BDBF
		public ConvertedConfigs(Config config, string fileName)
		{
			this.Config = config;
			this.FileName = fileName;
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06001007 RID: 4103 RVA: 0x0004DBD5 File Offset: 0x0004BDD5
		// (set) Token: 0x06001008 RID: 4104 RVA: 0x0004DBDD File Offset: 0x0004BDDD
		public string FileName { get; private set; }

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06001009 RID: 4105 RVA: 0x0004DBE6 File Offset: 0x0004BDE6
		public string Name
		{
			get
			{
				if (this.Config != null)
				{
					return this.Config.Settings.Name;
				}
				return "";
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x0600100A RID: 4106 RVA: 0x0004DC06 File Offset: 0x0004BE06
		// (set) Token: 0x0600100B RID: 4107 RVA: 0x0004DC0E File Offset: 0x0004BE0E
		public Config Config { get; private set; }

		// Token: 0x0600100C RID: 4108 RVA: 0x0004DC17 File Offset: 0x0004BE17
		public override string ToString()
		{
			return this.Name;
		}
	}
}
