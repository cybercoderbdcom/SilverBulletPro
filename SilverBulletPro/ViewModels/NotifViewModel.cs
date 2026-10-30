using System;
using System.Collections.ObjectModel;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Models;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001C9 RID: 457
	public class NotifViewModel : ViewModelBase
	{
		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x00047F72 File Offset: 0x00046172
		// (set) Token: 0x06000DDA RID: 3546 RVA: 0x00047F7A File Offset: 0x0004617A
		public ObservableCollection<NotifModel> NotifDataList
		{
			get
			{
				return this.notifDataList;
			}
			set
			{
				this.SetProperty<ObservableCollection<NotifModel>>(ref this.notifDataList, value, "NotifDataList");
			}
		}

		// Token: 0x040006C2 RID: 1730
		private ObservableCollection<NotifModel> notifDataList = new ObservableCollection<NotifModel>();
	}
}
