using System;
using System.Collections.ObjectModel;
using System.Linq;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001B0 RID: 432
	public class BlockKeycheckViewModel : ViewModelBase
	{
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000C3B RID: 3131 RVA: 0x00043F44 File Offset: 0x00042144
		// (set) Token: 0x06000C3C RID: 3132 RVA: 0x00043F4C File Offset: 0x0004214C
		public BlockKeycheck Block { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000C3D RID: 3133 RVA: 0x00043F55 File Offset: 0x00042155
		// (set) Token: 0x06000C3E RID: 3134 RVA: 0x00043F5D File Offset: 0x0004215D
		public ObservableCollection<KeychainViewModel> KeychainList { get; set; }

		// Token: 0x06000C3F RID: 3135 RVA: 0x00043F68 File Offset: 0x00042168
		public KeychainViewModel GetKeychainById(int id)
		{
			return (from x in this.KeychainList
			where x.Id == id
			select x).First<KeychainViewModel>();
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x00043F9E File Offset: 0x0004219E
		public void RemoveKeychainById(int id)
		{
			this.KeychainList.Remove(this.GetKeychainById(id));
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x00043FB3 File Offset: 0x000421B3
		public void AddKeychain()
		{
			this.KeychainList.Add(new KeychainViewModel(new KeyChain(), this.rand.Next()));
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x00043FD8 File Offset: 0x000421D8
		public BlockKeycheckViewModel(BlockKeycheck block)
		{
			this.Block = block;
			this.KeychainList = new ObservableCollection<KeychainViewModel>();
			foreach (KeyChain keychain in block.KeyChains)
			{
				this.KeychainList.Add(new KeychainViewModel(keychain, this.rand.Next()));
			}
		}

		// Token: 0x04000628 RID: 1576
		private Random rand = new Random(2);
	}
}
