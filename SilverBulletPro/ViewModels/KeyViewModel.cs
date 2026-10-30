using System;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Functions.Conditions;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Views.StackerBlocks;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001B9 RID: 441
	public class KeyViewModel : ViewModelBase
	{
		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000CBB RID: 3259 RVA: 0x000459DC File Offset: 0x00043BDC
		// (set) Token: 0x06000CBC RID: 3260 RVA: 0x000459E4 File Offset: 0x00043BE4
		public KeyFullId Id
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
				this.OnPropertyChanged("Id");
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000CBD RID: 3261 RVA: 0x000459F8 File Offset: 0x00043BF8
		// (set) Token: 0x06000CBE RID: 3262 RVA: 0x00045A00 File Offset: 0x00043C00
		public Key Key { get; set; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000CBF RID: 3263 RVA: 0x00045A09 File Offset: 0x00043C09
		// (set) Token: 0x06000CC0 RID: 3264 RVA: 0x00045A16 File Offset: 0x00043C16
		public string LeftTerm
		{
			get
			{
				return this.Key.LeftTerm;
			}
			set
			{
				this.Key.LeftTerm = value;
				this.OnPropertyChanged("LeftTerm");
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000CC1 RID: 3265 RVA: 0x00045A2F File Offset: 0x00043C2F
		// (set) Token: 0x06000CC2 RID: 3266 RVA: 0x00045A3C File Offset: 0x00043C3C
		public Comparer Comparer
		{
			get
			{
				return this.Key.Comparer;
			}
			set
			{
				this.Key.Comparer = value;
				this.OnPropertyChanged("Comparer");
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000CC3 RID: 3267 RVA: 0x00045A55 File Offset: 0x00043C55
		// (set) Token: 0x06000CC4 RID: 3268 RVA: 0x00045A62 File Offset: 0x00043C62
		public InputMode RightTermInputMode
		{
			get
			{
				return this.Key.RightTermInputMode;
			}
			set
			{
				this.Key.RightTermInputMode = value;
				this.OnPropertyChanged("RightTermInputMode");
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000CC5 RID: 3269 RVA: 0x00045A7B File Offset: 0x00043C7B
		// (set) Token: 0x06000CC6 RID: 3270 RVA: 0x00045A88 File Offset: 0x00043C88
		public string RightTerm
		{
			get
			{
				return this.Key.RightTerm;
			}
			set
			{
				this.Key.RightTerm = value;
				this.OnPropertyChanged("RightTerm");
			}
		}

		// Token: 0x06000CC7 RID: 3271 RVA: 0x00045AA1 File Offset: 0x00043CA1
		public KeyViewModel(Key key, int id, int parentId)
		{
			this.Key = key;
			this.Id = new KeyFullId
			{
				KeyId = id,
				ParentId = parentId
			};
			this.OnPropertyChanged("FullId");
			this.OnPropertyChanged("Id");
		}

		// Token: 0x04000655 RID: 1621
		private KeyFullId id;
	}
}
