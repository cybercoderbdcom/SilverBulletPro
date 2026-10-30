using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001B8 RID: 440
	public class KeychainViewModel : ViewModelBase
	{
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000C9F RID: 3231 RVA: 0x00045689 File Offset: 0x00043889
		// (set) Token: 0x06000CA0 RID: 3232 RVA: 0x00045691 File Offset: 0x00043891
		public int Id
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

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000CA1 RID: 3233 RVA: 0x000456A5 File Offset: 0x000438A5
		// (set) Token: 0x06000CA2 RID: 3234 RVA: 0x000456AD File Offset: 0x000438AD
		public KeyChain Keychain { get; set; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x000456B6 File Offset: 0x000438B6
		// (set) Token: 0x06000CA4 RID: 3236 RVA: 0x000456BE File Offset: 0x000438BE
		public ObservableCollection<KeyViewModel> KeyList { get; set; } = new ObservableCollection<KeyViewModel>();

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x000456C7 File Offset: 0x000438C7
		// (set) Token: 0x06000CA6 RID: 3238 RVA: 0x000456D4 File Offset: 0x000438D4
		public KeyChain.KeychainType Type
		{
			get
			{
				return this.Keychain.Type;
			}
			set
			{
				this.Keychain.Type = value;
				this.OnPropertyChanged("Type");
				this.OnPropertyChanged("KeychainColor");
				this.OnPropertyChanged("CustomVisibility");
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000CA7 RID: 3239 RVA: 0x00045703 File Offset: 0x00043903
		// (set) Token: 0x06000CA8 RID: 3240 RVA: 0x0004570B File Offset: 0x0004390B
		public bool TypeInitialized { get; set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x00045714 File Offset: 0x00043914
		// (set) Token: 0x06000CAA RID: 3242 RVA: 0x00045721 File Offset: 0x00043921
		public KeyChain.KeychainMode Mode
		{
			get
			{
				return this.Keychain.Mode;
			}
			set
			{
				this.Keychain.Mode = value;
				this.OnPropertyChanged("Mode");
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000CAB RID: 3243 RVA: 0x0004573A File Offset: 0x0004393A
		// (set) Token: 0x06000CAC RID: 3244 RVA: 0x00045742 File Offset: 0x00043942
		public bool ModeInitialized { get; set; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000CAD RID: 3245 RVA: 0x0004574B File Offset: 0x0004394B
		// (set) Token: 0x06000CAE RID: 3246 RVA: 0x00045753 File Offset: 0x00043953
		public bool ExecPriorityInitialized { get; set; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x0004575C File Offset: 0x0004395C
		// (set) Token: 0x06000CB0 RID: 3248 RVA: 0x00045769 File Offset: 0x00043969
		public KeyChain.ExecPriority ExecPriority
		{
			get
			{
				return this.Keychain.ExecutionPriority;
			}
			set
			{
				this.Keychain.ExecutionPriority = value;
				this.OnPropertyChanged("ExecPriority");
				this.OnPropertyChanged("ExecPriority");
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x0004578D File Offset: 0x0004398D
		// (set) Token: 0x06000CB2 RID: 3250 RVA: 0x0004579A File Offset: 0x0004399A
		public string CustomType
		{
			get
			{
				return this.Keychain.CustomType;
			}
			set
			{
				this.Keychain.CustomType = value;
				this.OnPropertyChanged("CustomType");
				this.OnPropertyChanged("KeychainColor");
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000CB3 RID: 3251 RVA: 0x000457BE File Offset: 0x000439BE
		public Visibility CustomVisibility
		{
			get
			{
				if (this.Type != 4)
				{
					return Visibility.Collapsed;
				}
				return Visibility.Visible;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000CB4 RID: 3252 RVA: 0x000457CC File Offset: 0x000439CC
		// (set) Token: 0x06000CB5 RID: 3253 RVA: 0x000457D4 File Offset: 0x000439D4
		public bool CustomTypeInitialized { get; set; }

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000CB6 RID: 3254 RVA: 0x000457E0 File Offset: 0x000439E0
		public SolidColorBrush KeychainColor
		{
			get
			{
				Color color = Colors.Black;
				switch (this.Type)
				{
				case 0:
					color = (Color)ColorConverter.ConvertFromString("#006600");
					break;
				case 1:
					color = (Color)ColorConverter.ConvertFromString("#cc0000");
					break;
				case 2:
					color = (Color)ColorConverter.ConvertFromString("#660066");
					break;
				case 3:
					color = (Color)ColorConverter.ConvertFromString("#cc9900");
					break;
				case 4:
					color = GlobalData.Settings.Environment.GetCustomKeychain(this.CustomType).Color.ToMediaColor();
					break;
				}
				return new SolidColorBrush(color);
			}
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x00045884 File Offset: 0x00043A84
		public KeyViewModel GetKeyById(int id)
		{
			return (from x in this.KeyList
			where x.Id.KeyId == id
			select x).First<KeyViewModel>();
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x000458BA File Offset: 0x00043ABA
		public void RemoveKeyById(int id)
		{
			this.Keychain.Keys.Remove(this.GetKeyById(id).Key);
			this.KeyList.Remove(this.GetKeyById(id));
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x000458EC File Offset: 0x00043AEC
		public void AddKey()
		{
			Key key = new Key();
			this.Keychain.Keys.Add(key);
			this.KeyList.Add(new KeyViewModel(key, this.rand.Next(), this.Id));
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x00045934 File Offset: 0x00043B34
		public KeychainViewModel(KeyChain keychain, int id)
		{
			this.Keychain = keychain;
			this.Id = id;
			this.TypeInitialized = false;
			this.ModeInitialized = false;
			this.CustomTypeInitialized = false;
			foreach (Key key in keychain.Keys)
			{
				this.KeyList.Add(new KeyViewModel(key, this.rand.Next(), this.Id));
			}
		}

		// Token: 0x0400064D RID: 1613
		private Random rand = new Random(3);

		// Token: 0x0400064E RID: 1614
		private int id;
	}
}
