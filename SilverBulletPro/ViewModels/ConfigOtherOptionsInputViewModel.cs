using System;
using System.Collections.ObjectModel;
using System.Linq;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001B3 RID: 435
	public class ConfigOtherOptionsInputViewModel : ViewModelBase
	{
		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000C6C RID: 3180 RVA: 0x00044E7E File Offset: 0x0004307E
		// (set) Token: 0x06000C6D RID: 3181 RVA: 0x00044E86 File Offset: 0x00043086
		public ObservableCollection<CustomInput> InputsList
		{
			get
			{
				return this.inputsList;
			}
			set
			{
				this.inputsList = value;
				this.OnPropertyChanged("InputsList");
			}
		}

		// Token: 0x06000C6E RID: 3182 RVA: 0x00044E9C File Offset: 0x0004309C
		public CustomInput GetInputById(int id)
		{
			return (from x in this.InputsList
			where x.Id == id
			select x).First<CustomInput>();
		}

		// Token: 0x06000C6F RID: 3183 RVA: 0x00044ED2 File Offset: 0x000430D2
		public void RemoveInputById(int id)
		{
			this.InputsList.Remove(this.GetInputById(id));
		}

		// Token: 0x0400063F RID: 1599
		private ObservableCollection<CustomInput> inputsList = new ObservableCollection<CustomInput>();
	}
}
