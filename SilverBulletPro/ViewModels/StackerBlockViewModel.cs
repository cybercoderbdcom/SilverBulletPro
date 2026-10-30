using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001CB RID: 459
	public class StackerBlockViewModel : ViewModelBase
	{
		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000DDF RID: 3551 RVA: 0x00047FD2 File Offset: 0x000461D2
		// (set) Token: 0x06000DE0 RID: 3552 RVA: 0x00047FDA File Offset: 0x000461DA
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

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000DE1 RID: 3553 RVA: 0x00047FEE File Offset: 0x000461EE
		// (set) Token: 0x06000DE2 RID: 3554 RVA: 0x00047FF6 File Offset: 0x000461F6
		public bool Selected
		{
			get
			{
				return this.selected;
			}
			set
			{
				this.selected = value;
				this.OnPropertyChanged("Selected");
				this.OnPropertyChanged("BorderColor");
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000DE3 RID: 3555 RVA: 0x00048015 File Offset: 0x00046215
		public SolidColorBrush BorderColor
		{
			get
			{
				return new SolidColorBrush(this.Selected ? Colors.White : Colors.Black);
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000DE4 RID: 3556 RVA: 0x00048030 File Offset: 0x00046230
		public SolidColorBrush Color
		{
			get
			{
				return new SolidColorBrush(this.Block.Disabled ? Colors.Gray : this.GetBlockBackColor());
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x00048051 File Offset: 0x00046251
		public SolidColorBrush Foreground
		{
			get
			{
				return new SolidColorBrush(this.GetBlockForeColor());
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000DE6 RID: 3558 RVA: 0x0004805E File Offset: 0x0004625E
		// (set) Token: 0x06000DE7 RID: 3559 RVA: 0x00048066 File Offset: 0x00046266
		public int Height
		{
			get
			{
				return this.height;
			}
			set
			{
				this.height = value;
				this.OnPropertyChanged("Height");
				this.OnPropertyChanged("FontSize");
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000DE8 RID: 3560 RVA: 0x00048085 File Offset: 0x00046285
		public int FontSize
		{
			get
			{
				return this.Height / 3;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000DE9 RID: 3561 RVA: 0x0004808F File Offset: 0x0004628F
		// (set) Token: 0x06000DEA RID: 3562 RVA: 0x00048097 File Offset: 0x00046297
		public Page Page
		{
			get
			{
				return this.page;
			}
			set
			{
				this.page = value;
				this.OnPropertyChanged("Page");
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000DEB RID: 3563 RVA: 0x000480AB File Offset: 0x000462AB
		// (set) Token: 0x06000DEC RID: 3564 RVA: 0x000480B3 File Offset: 0x000462B3
		public BlockBase Block
		{
			get
			{
				return this.block;
			}
			set
			{
				this.block = value;
				this.OnPropertyChanged("Block");
			}
		}

		// Token: 0x06000DED RID: 3565 RVA: 0x000480C8 File Offset: 0x000462C8
		public void DisableOrEnable()
		{
			if (this.block.GetType() == typeof(BlockScriptCode))
			{
				return;
			}
			this.Block.Disabled = !this.Block.Disabled;
			this.OnPropertyChanged("Color");
		}

		// Token: 0x06000DEE RID: 3566 RVA: 0x00048116 File Offset: 0x00046316
		public void DisableBlock()
		{
			if (this.block.GetType() == typeof(BlockScriptCode))
			{
				return;
			}
			this.Block.Disabled = true;
			this.OnPropertyChanged("Color");
		}

		// Token: 0x06000DEF RID: 3567 RVA: 0x0004814C File Offset: 0x0004634C
		public void EnableBlock()
		{
			if (this.block.GetType() == typeof(BlockScriptCode))
			{
				return;
			}
			this.Block.Disabled = false;
			this.OnPropertyChanged("Color");
		}

		// Token: 0x06000DF0 RID: 3568 RVA: 0x00048182 File Offset: 0x00046382
		public void UpdateHeight(int height)
		{
			this.Height = height;
			this.OnPropertyChanged("Height");
			this.OnPropertyChanged("FontSize");
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x000481A4 File Offset: 0x000463A4
		public StackerBlockViewModel(BlockBase block, Random rand)
		{
			this.Id = rand.Next();
			this.Block = block;
			this.OnPropertyChanged("Label");
			this.OnPropertyChanged("Color");
			SilverBlock silverBlock;
			if ((silverBlock = GlobalData.BlockMappings.FirstOrDefault((SilverBlock m) => m.Block == block.GetType())) != null)
			{
				this.Page = (Activator.CreateInstance(silverBlock.Page, new object[]
				{
					block
				}) as Page);
				return;
			}
			throw new Exception("Tried to initialize a page for the block type " + block.GetType().Name + " but it wasn't found in the mappings");
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x00048256 File Offset: 0x00046456
		public Color GetBlockBackColor()
		{
			return GlobalData.BlockMappings.First((SilverBlock m) => m.Block == this.block.GetType()).Backrgound.ToMediaColor();
		}

		// Token: 0x06000DF3 RID: 3571 RVA: 0x00048278 File Offset: 0x00046478
		public Color GetBlockForeColor()
		{
			return GlobalData.BlockMappings.First((SilverBlock m) => m.Block == this.block.GetType()).Foreground.ToMediaColor();
		}

		// Token: 0x040006C4 RID: 1732
		private int id;

		// Token: 0x040006C5 RID: 1733
		private bool selected;

		// Token: 0x040006C6 RID: 1734
		private int height;

		// Token: 0x040006C7 RID: 1735
		private Page page;

		// Token: 0x040006C8 RID: 1736
		private BlockBase block;
	}
}
