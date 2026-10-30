using System;
using System.Collections.ObjectModel;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001AF RID: 431
	public class AddBlockDialogViewModel : ViewModelBase
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000C37 RID: 3127 RVA: 0x00043F0C File Offset: 0x0004210C
		// (set) Token: 0x06000C38 RID: 3128 RVA: 0x00043F14 File Offset: 0x00042114
		public ObservableCollection<UserControlBlock> Blocks
		{
			get
			{
				return this._blocks;
			}
			set
			{
				this._blocks = value;
				this.OnPropertyChanged("Blocks");
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000C39 RID: 3129 RVA: 0x00043F28 File Offset: 0x00042128
		// (set) Token: 0x06000C3A RID: 3130 RVA: 0x00043F30 File Offset: 0x00042130
		public ObservableCollection<BlockBase> RecentlyBlocks
		{
			get
			{
				return this._recentlyBlocks;
			}
			set
			{
				this._recentlyBlocks = value;
				this.OnPropertyChanged("RecentlyBlocks");
			}
		}

		// Token: 0x04000626 RID: 1574
		private ObservableCollection<UserControlBlock> _blocks;

		// Token: 0x04000627 RID: 1575
		private ObservableCollection<BlockBase> _recentlyBlocks;
	}
}
