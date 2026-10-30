using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Models;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001C5 RID: 453
	public class SBSettingsSources : ViewModelBase
	{
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000D9D RID: 3485 RVA: 0x00047A82 File Offset: 0x00045C82
		// (set) Token: 0x06000D9E RID: 3486 RVA: 0x00047A8A File Offset: 0x00045C8A
		public ObservableCollection<Source> Sources { get; set; } = new ObservableCollection<Source>();

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000D9F RID: 3487 RVA: 0x00047A93 File Offset: 0x00045C93
		// (set) Token: 0x06000DA0 RID: 3488 RVA: 0x00047A9B File Offset: 0x00045C9B
		public bool ShowRemoteCustomConfigs
		{
			get
			{
				return this.showRemoteCustomConfigs;
			}
			set
			{
				this.showRemoteCustomConfigs = value;
				this.OnPropertyChanged("ShowRemoteCustomConfigs");
			}
		}

		// Token: 0x06000DA1 RID: 3489 RVA: 0x00047AAF File Offset: 0x00045CAF
		public void RemoveSourceById(int id)
		{
			this.Sources.Remove(this.GetSourceById(id));
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x00047AC4 File Offset: 0x00045CC4
		public Source GetSourceById(int id)
		{
			return this.Sources.FirstOrDefault((Source s) => s.Id == id);
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x00047AF8 File Offset: 0x00045CF8
		public void Reset()
		{
			SBSettingsSources obj = new SBSettingsSources();
			foreach (PropertyInfo propertyInfo in ((IEnumerable<PropertyInfo>)new List<PropertyInfo>(typeof(SBSettingsSources).GetProperties())))
			{
				propertyInfo.SetValue(this, propertyInfo.GetValue(obj, null));
			}
		}

		// Token: 0x040006A9 RID: 1705
		private bool showRemoteCustomConfigs;
	}
}
