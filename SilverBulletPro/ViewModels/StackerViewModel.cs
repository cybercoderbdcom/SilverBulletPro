using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight.Command;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.LS;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;
using SilverBulletPro.Requests;
using SilverBulletPro.Views.StackerBlocks;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001CD RID: 461
	public class StackerViewModel : ViewModelBase
	{
		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000DF6 RID: 3574 RVA: 0x000482CA File Offset: 0x000464CA
		// (set) Token: 0x06000DF7 RID: 3575 RVA: 0x000482D2 File Offset: 0x000464D2
		public StackerView View { get; set; }

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000DF8 RID: 3576 RVA: 0x000482DB File Offset: 0x000464DB
		// (set) Token: 0x06000DF9 RID: 3577 RVA: 0x000482E3 File Offset: 0x000464E3
		public BotData BotData { get; set; }

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000DFA RID: 3578 RVA: 0x000482EC File Offset: 0x000464EC
		// (set) Token: 0x06000DFB RID: 3579 RVA: 0x000482F4 File Offset: 0x000464F4
		public SvbScript LS { get; set; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000DFC RID: 3580 RVA: 0x000482FD File Offset: 0x000464FD
		// (set) Token: 0x06000DFD RID: 3581 RVA: 0x00048305 File Offset: 0x00046505
		public bool ControlsEnabled
		{
			get
			{
				return this.controlsEnabled;
			}
			set
			{
				this.controlsEnabled = value;
				this.OnPropertyChanged("ControlsEnabled");
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000DFE RID: 3582 RVA: 0x00048319 File Offset: 0x00046519
		// (set) Token: 0x06000DFF RID: 3583 RVA: 0x00048321 File Offset: 0x00046521
		public ObservableCollection<SilverBlock> Blocks
		{
			get
			{
				return this.blocks;
			}
			set
			{
				this.blocks = value;
				this.OnPropertyChanged("Blocks");
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000E00 RID: 3584 RVA: 0x00048335 File Offset: 0x00046535
		// (set) Token: 0x06000E01 RID: 3585 RVA: 0x0004833D File Offset: 0x0004653D
		public bool Breakpoint
		{
			get
			{
				return this.breakpoint;
			}
			set
			{
				this.breakpoint = value;
				this.OnPropertyChanged("Breakpoint");
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000E02 RID: 3586 RVA: 0x00048351 File Offset: 0x00046551
		// (set) Token: 0x06000E03 RID: 3587 RVA: 0x00048359 File Offset: 0x00046559
		public ObservableCollection<SvbScript.Breakpoint> Breakpoints
		{
			get
			{
				return this.breakpoints;
			}
			set
			{
				this.breakpoints = value;
				this.OnPropertyChanged("Breakpoints");
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000E04 RID: 3588 RVA: 0x0004836D File Offset: 0x0004656D
		// (set) Token: 0x06000E05 RID: 3589 RVA: 0x00048375 File Offset: 0x00046575
		public ConfigViewModel ConfigViewModel { get; set; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000E06 RID: 3590 RVA: 0x0004837E File Offset: 0x0004657E
		// (set) Token: 0x06000E07 RID: 3591 RVA: 0x00048386 File Offset: 0x00046586
		public ObservableCollection<StackerBlockViewModel> Stack { get; set; } = new ObservableCollection<StackerBlockViewModel>();

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000E08 RID: 3592 RVA: 0x0004838F File Offset: 0x0004658F
		public List<StackerBlockViewModel> SelectedBlocks
		{
			get
			{
				return (from b in this.Stack
				where b.Selected
				select b).ToList<StackerBlockViewModel>();
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000E09 RID: 3593 RVA: 0x000483C0 File Offset: 0x000465C0
		// (set) Token: 0x06000E0A RID: 3594 RVA: 0x000483C8 File Offset: 0x000465C8
		public StackerBlockViewModel CurrentBlock { get; set; }

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000E0B RID: 3595 RVA: 0x000483D1 File Offset: 0x000465D1
		public int CurrentBlockIndex
		{
			get
			{
				return this.Stack.IndexOf(this.CurrentBlock);
			}
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x000483E4 File Offset: 0x000465E4
		public void DeselectAll()
		{
			foreach (StackerBlockViewModel stackerBlockViewModel in this.Stack)
			{
				stackerBlockViewModel.Selected = false;
			}
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x00048430 File Offset: 0x00046630
		public void SelectAll()
		{
			foreach (StackerBlockViewModel stackerBlockViewModel in this.Stack)
			{
				stackerBlockViewModel.Selected = true;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000E0E RID: 3598 RVA: 0x0004847C File Offset: 0x0004667C
		// (set) Token: 0x06000E0F RID: 3599 RVA: 0x00048484 File Offset: 0x00046684
		public Stack<StackerViewModel.UndoRedoBlock> UndoBlocks { get; set; } = new Stack<StackerViewModel.UndoRedoBlock>();

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000E10 RID: 3600 RVA: 0x0004848D File Offset: 0x0004668D
		// (set) Token: 0x06000E11 RID: 3601 RVA: 0x00048495 File Offset: 0x00046695
		public Stack<StackerViewModel.UndoRedoBlock> RedoBlocks { get; set; } = new Stack<StackerViewModel.UndoRedoBlock>();

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000E12 RID: 3602 RVA: 0x0004849E File Offset: 0x0004669E
		// (set) Token: 0x06000E13 RID: 3603 RVA: 0x000484A6 File Offset: 0x000466A6
		public string BlockLabel
		{
			get
			{
				return this.blockLabel;
			}
			set
			{
				this.blockLabel = value;
				this.OnPropertyChanged("BlockLabel");
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000E14 RID: 3604 RVA: 0x000484BA File Offset: 0x000466BA
		public ICommand RemoveBlockCommand
		{
			get
			{
				return new RelayCommand(new Action(this.RemoveBlock), () => this.SelectedBlocks.Count > 0);
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000E15 RID: 3605 RVA: 0x000484D9 File Offset: 0x000466D9
		public ICommand MoveBlockDownCommand
		{
			get
			{
				return new RelayCommand(delegate()
				{
					this.MoveBlockDown(null);
				}, () => this.SelectedBlocks.Count > 0 && this.Stack.Count > 1);
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000E16 RID: 3606 RVA: 0x000484F8 File Offset: 0x000466F8
		public ICommand MoveBlockUpCommand
		{
			get
			{
				return new RelayCommand(delegate()
				{
					this.MoveBlockUp(null);
				}, () => this.SelectedBlocks.Count > 0 && this.Stack.Count > 1);
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000E17 RID: 3607 RVA: 0x00048517 File Offset: 0x00046717
		public ICommand CloneBlockCommand
		{
			get
			{
				return new RelayCommand(new Action(this.CloneBlock), () => this.SelectedBlocks.Count > 0);
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000E18 RID: 3608 RVA: 0x00048536 File Offset: 0x00046736
		public ICommand CopyBlocksCommand
		{
			get
			{
				return new RelayCommand(new Action(this.CopyBlocks), () => this.SelectedBlocks.Count > 0 && !GlobalData.SBSettings.General.DisableCopyPasteBlocks);
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000E19 RID: 3609 RVA: 0x00048555 File Offset: 0x00046755
		public ICommand PasteBlocksCommand
		{
			get
			{
				return new RelayCommand(delegate()
				{
					this.PasteBlocks("");
				}, delegate()
				{
					bool result;
					try
					{
						string text = Clipboard.GetText();
						result = (!string.IsNullOrWhiteSpace(text) && Clipboard.GetText().Contains("{\"$type\":\"SilverBulletPro.Core.Block") && text.Contains("SilverBulletPro.Core") && text.Contains("}") && !GlobalData.SBSettings.General.DisableCopyPasteBlocks);
					}
					catch
					{
						result = false;
					}
					return result;
				});
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000E1A RID: 3610 RVA: 0x00048587 File Offset: 0x00046787
		public ICommand SelectAllBlocksCommand
		{
			get
			{
				return new RelayCommand(new Action(this.SelectAll), () => this.Stack.Count > 0);
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000E1B RID: 3611 RVA: 0x000485A6 File Offset: 0x000467A6
		public ICommand DeleteAllBlocksCommand
		{
			get
			{
				return new RelayCommand(delegate()
				{
					if (Alert.Choice("Do you want to delete all blocks?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
					{
						this.ClearBlocks(true);
						GlobalData.MainWindow.ConfigsSecionPage.StackerPage.BlockInfo.Content = null;
						this.BlockLabel = string.Empty;
					}
				}, () => this.Stack.Count > 1);
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000E1C RID: 3612 RVA: 0x000485C5 File Offset: 0x000467C5
		public ICommand DisableOrEnableBlockCommand
		{
			get
			{
				return new RelayCommand(new Action(this.DisableOrEnableBlock), () => this.SelectedBlocks.Count > 0);
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000E1D RID: 3613 RVA: 0x000485E4 File Offset: 0x000467E4
		public ICommand EnableAllBlocksCommand
		{
			get
			{
				return new RelayCommand(new Action(this.EnableAllBlocks), delegate()
				{
					if (this.Stack.Count > 0)
					{
						return this.Stack.Any((StackerBlockViewModel s) => s.Block.Disabled);
					}
					return false;
				});
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000E1E RID: 3614 RVA: 0x00048603 File Offset: 0x00046803
		public ICommand DisableAllBlocksCommand
		{
			get
			{
				return new RelayCommand(new Action(this.DisableAllBlocks), delegate()
				{
					if (this.Stack.Count > 0)
					{
						return this.Stack.Any((StackerBlockViewModel s) => !s.Block.Disabled);
					}
					return false;
				});
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000E1F RID: 3615 RVA: 0x00048622 File Offset: 0x00046822
		public ICommand UndoBlockCommand
		{
			get
			{
				return new RelayCommand(new Action(this.UndoBlock), () => this.UndoBlocks.Count > 0);
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000E20 RID: 3616 RVA: 0x00048641 File Offset: 0x00046841
		public ICommand RedoBlockCommand
		{
			get
			{
				return new RelayCommand(new Action(this.RedoBlock), () => this.RedoBlocks.Count > 0);
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000E21 RID: 3617 RVA: 0x00048660 File Offset: 0x00046860
		public ICommand ClearUndoRedoBlocksCommand
		{
			get
			{
				return new RelayCommand(new Action(this.ClearUndoRedo), () => this.UndoBlocks.Count > 0 || this.RedoBlocks.Count > 0);
			}
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x0004867F File Offset: 0x0004687F
		public List<BlockBase> GetList()
		{
			this.ConvertKeychains();
			this.ConvertPlugins();
			return (from x in this.Stack
			select x.Block).ToList<BlockBase>();
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x000486BC File Offset: 0x000468BC
		public void ConvertKeychains()
		{
			foreach (StackerBlockViewModel stackerBlockViewModel in this.Stack)
			{
				BlockBase block = stackerBlockViewModel.Block;
				Page page = stackerBlockViewModel.Page;
				if (page.GetType() == typeof(PageBlockKeycheck))
				{
					PageBlockKeycheck pageBlockKeycheck = (PageBlockKeycheck)page;
					((BlockKeycheck)block).KeyChains = (from k in pageBlockKeycheck.vm.KeychainList
					select k.Keychain).ToList<KeyChain>();
				}
			}
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x0004876C File Offset: 0x0004696C
		public void ConvertPlugins()
		{
			foreach (StackerBlockViewModel stackerBlockViewModel in from sb in this.Stack
			where sb.Block.IsPlugin()
			select sb)
			{
				(stackerBlockViewModel.Page as BlockPluginPage).SetPropertyValues();
			}
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x000487E4 File Offset: 0x000469E4
		public StackerBlockViewModel GetBlockById(int id)
		{
			return (from x in this.Stack
			where x.Id == id
			select x).First<StackerBlockViewModel>();
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x0004881C File Offset: 0x00046A1C
		public StackerBlockViewModel AddBlock(BlockBase block, int index = -1)
		{
			if (index < 0 || index > this.Stack.Count)
			{
				index = this.Stack.Count;
			}
			StackerBlockViewModel result;
			this.Stack.Insert(index, result = new StackerBlockViewModel(block, this.rand));
			this.UpdateHeights();
			this.UpdateBreakpoints();
			return result;
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x0004886F File Offset: 0x00046A6F
		public StackerBlockViewModel AddBlock(StackerBlockViewModel stacker, int index = -1)
		{
			if (index < 0 || index > this.Stack.Count)
			{
				index = this.Stack.Count;
			}
			this.Stack.Insert(index, stacker);
			this.UpdateHeights();
			this.UpdateBreakpoints();
			return stacker;
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x000488AC File Offset: 0x00046AAC
		public void RemoveBlock()
		{
			for (int i = this.SelectedBlocks.Count - 1; i >= 0; i--)
			{
				StackerBlockViewModel block = this.SelectedBlocks[i];
				this.UndoBlocks.Push(new StackerViewModel.UndoRedoBlock(block, this.Stack.IndexOf(block), StackerViewModel.UndoRedoState.Removed));
				this.Stack.Remove(block);
				SvbScript.Breakpoint item;
				if ((item = this.Breakpoints.FirstOrDefault((SvbScript.Breakpoint b) => b.Block == block.Block)) != null)
				{
					this.Breakpoints.Remove(item);
				}
				else
				{
					this.UpdateBreakpoints();
				}
			}
			this.CurrentBlock = null;
			try
			{
				GlobalData.MainWindow.ConfigsSecionPage.StackerPage.BlockInfo.Content = null;
			}
			catch
			{
			}
			this.BlockLabel = string.Empty;
			this.UpdateHeights();
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x000489A4 File Offset: 0x00046BA4
		public void ClearBlocks(bool addToUndo = false)
		{
			if (addToUndo)
			{
				for (int i = this.Stack.Count - 1; i >= 0; i--)
				{
					try
					{
						StackerBlockViewModel stackerBlockViewModel = this.Stack[i];
						this.UndoBlocks.Push(new StackerViewModel.UndoRedoBlock(stackerBlockViewModel, this.Stack.IndexOf(stackerBlockViewModel), StackerViewModel.UndoRedoState.Removed));
						this.Stack.Remove(stackerBlockViewModel);
					}
					catch
					{
					}
				}
				this.Breakpoints.Clear();
			}
			else
			{
				this.Stack.Clear();
				this.Breakpoints.Clear();
			}
			this.CurrentBlock = null;
			try
			{
				GlobalData.MainWindow.ConfigsSecionPage.StackerPage.BlockInfo.Content = null;
			}
			catch
			{
			}
			this.BlockLabel = string.Empty;
			this.UpdateHeights();
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x00048A80 File Offset: 0x00046C80
		public void UpdateHeights()
		{
			for (int i = 0; i < this.Stack.Count; i++)
			{
				this.Stack[i].UpdateHeight(this.Clamp(600 / this.Stack.Count, 30, 60));
			}
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x00048AD0 File Offset: 0x00046CD0
		public void MoveBlockUp(StackerBlockViewModel blockVM = null)
		{
			if (blockVM != null)
			{
				int num = this.Stack.IndexOf(blockVM);
				if (num != 0)
				{
					this.Stack.Move(num, num - 1);
				}
				this.UndoBlocks.Push(new StackerViewModel.UndoRedoBlock(blockVM, this.Stack.IndexOf(blockVM), StackerViewModel.UndoRedoState.MovedUp));
				this.MoveBreakpointUp(blockVM.Block, num);
				return;
			}
			for (int i = 0; i < this.SelectedBlocks.Count; i++)
			{
				StackerBlockViewModel stackerBlockViewModel = this.SelectedBlocks[i];
				int num2 = this.Stack.IndexOf(stackerBlockViewModel);
				if (num2 != 0)
				{
					this.Stack.Move(num2, num2 - 1);
				}
				this.UndoBlocks.Push(new StackerViewModel.UndoRedoBlock(stackerBlockViewModel, this.Stack.IndexOf(stackerBlockViewModel), StackerViewModel.UndoRedoState.MovedUp));
				if (!this.MoveBreakpointUp(stackerBlockViewModel.Block, num2))
				{
					this.UpdateBreakpoints();
				}
			}
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x00048BA4 File Offset: 0x00046DA4
		private bool MoveBreakpointUp(BlockBase currentBlock, int oldIndex)
		{
			SvbScript.Breakpoint breakpoint = null;
			if (this.Breakpoints.Count > 0 && (breakpoint = this.Breakpoints.FirstOrDefault((SvbScript.Breakpoint b) => b.Index == oldIndex && b.Block == currentBlock)) != null)
			{
				int num = this.Breakpoints.IndexOf(breakpoint);
				if (oldIndex > 0)
				{
					if (!this.Breakpoints.Remove(breakpoint))
					{
						this.Breakpoints.RemoveAt(num);
					}
					breakpoint.Index = oldIndex - 1;
					this.Breakpoints.Insert((num > 0) ? (num - 1) : num, breakpoint);
				}
			}
			return breakpoint != null;
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x00048C48 File Offset: 0x00046E48
		public void MoveBlockDown(StackerBlockViewModel blockVM = null)
		{
			if (blockVM != null)
			{
				int num = this.Stack.IndexOf(blockVM);
				if (num != this.Stack.Count - 1)
				{
					this.Stack.Move(num, num + 1);
				}
				this.UndoBlocks.Push(new StackerViewModel.UndoRedoBlock(blockVM, this.Stack.IndexOf(blockVM), StackerViewModel.UndoRedoState.MovedDown));
				this.MoveBreakpointDown(blockVM.Block, num);
				return;
			}
			foreach (StackerBlockViewModel stackerBlockViewModel in this.SelectedBlocks.AsEnumerable<StackerBlockViewModel>().Reverse<StackerBlockViewModel>())
			{
				int num2 = this.Stack.IndexOf(stackerBlockViewModel);
				if (num2 != this.Stack.Count - 1)
				{
					this.Stack.Move(num2, num2 + 1);
				}
				this.UndoBlocks.Push(new StackerViewModel.UndoRedoBlock(stackerBlockViewModel, this.Stack.IndexOf(stackerBlockViewModel), StackerViewModel.UndoRedoState.MovedDown));
				if (!this.MoveBreakpointDown(stackerBlockViewModel.Block, num2) && this.Breakpoints.Count > 0)
				{
					this.UpdateBreakpoints();
				}
			}
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x00048D64 File Offset: 0x00046F64
		private bool MoveBreakpointDown(BlockBase currentBlock, int oldIndex)
		{
			SvbScript.Breakpoint breakpoint = null;
			if (this.Breakpoints.Count > 0 && (breakpoint = this.Breakpoints.FirstOrDefault((SvbScript.Breakpoint b) => b.Index == oldIndex && b.Block == currentBlock)) != null)
			{
				int num = this.Breakpoints.IndexOf(breakpoint);
				if (oldIndex == this.Stack.Count - 1)
				{
					return true;
				}
				if (!this.Breakpoints.Remove(breakpoint))
				{
					this.Breakpoints.RemoveAt(num);
				}
				breakpoint.Index = oldIndex + 1;
				this.Breakpoints.Insert((this.Breakpoints.Count > 0) ? (num + 1) : num, breakpoint);
			}
			return breakpoint != null;
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00048E24 File Offset: 0x00047024
		private void UpdateBreakpoints()
		{
			for (int i = 0; i < this.Breakpoints.Count; i++)
			{
				SvbScript.Breakpoint breakpoint = this.Breakpoints[i];
				int index = this.Breakpoints.IndexOf(breakpoint);
				StackerBlockViewModel stackerBlockViewModel = this.Stack.FirstOrDefault((StackerBlockViewModel s) => s.Block == breakpoint.Block);
				if (stackerBlockViewModel == null)
				{
					return;
				}
				if (!this.Breakpoints.Remove(breakpoint))
				{
					this.Breakpoints.RemoveAt(index);
				}
				breakpoint.Block = stackerBlockViewModel.Block;
				breakpoint.Index = this.Stack.IndexOf(stackerBlockViewModel);
				this.Breakpoints.Insert(index, breakpoint);
			}
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x00048EEC File Offset: 0x000470EC
		public void CloneBlock()
		{
			this.ConvertKeychains();
			foreach (StackerBlockViewModel stackerBlockViewModel in this.SelectedBlocks)
			{
				this.AddBlock(IOManager.CloneBlock(stackerBlockViewModel.Block), this.Stack.IndexOf(stackerBlockViewModel) + 1);
				this.UndoBlocks.Push(new StackerViewModel.UndoRedoBlock(stackerBlockViewModel, this.Stack.IndexOf(stackerBlockViewModel) + 1, StackerViewModel.UndoRedoState.Cloned));
			}
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x00048F80 File Offset: 0x00047180
		public void CopyBlocks()
		{
			try
			{
				Clipboard.SetText(IOManager.SerializeBlocks((from s in this.SelectedBlocks
				select s.Block).ToList<BlockBase>()));
			}
			catch
			{
				GlobalData.Logger.LogError(Components.Stacker, "Exception while copying blocks", false, 0);
			}
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x00048FF0 File Offset: 0x000471F0
		public void PasteBlocks(string blocks = "")
		{
			try
			{
				int num = 0;
				foreach (BlockBase block in IOManager.DeserializeBlocks(string.IsNullOrEmpty(blocks) ? Clipboard.GetText() : blocks))
				{
					this.ConvertKeychains();
					int index;
					StackerBlockViewModel vm;
					if (this.SelectedBlocks.Count == 0)
					{
						index = this.Stack.Count;
						vm = this.AddBlock(block, index);
					}
					else
					{
						index = this.Stack.IndexOf(this.SelectedBlocks.Last<StackerBlockViewModel>()) + 1 + num;
						vm = this.AddBlock(block, index);
						num++;
					}
					this.UndoBlocks.Push(new StackerViewModel.UndoRedoBlock(vm, index, StackerViewModel.UndoRedoState.Cloned));
				}
			}
			catch
			{
				GlobalData.Logger.LogError(Components.Stacker, "Exception while pasting blocks", false, 0);
			}
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x000490E0 File Offset: 0x000472E0
		public void DisableOrEnableBlock()
		{
			foreach (StackerBlockViewModel stackerBlockViewModel in this.SelectedBlocks)
			{
				stackerBlockViewModel.DisableOrEnable();
				this.UndoBlocks.Push(new StackerViewModel.UndoRedoBlock(stackerBlockViewModel, this.Stack.IndexOf(stackerBlockViewModel), stackerBlockViewModel.Block.Disabled ? StackerViewModel.UndoRedoState.Disabled : StackerViewModel.UndoRedoState.Enabled));
			}
		}

		// Token: 0x06000E34 RID: 3636 RVA: 0x00049160 File Offset: 0x00047360
		public void DisableAllBlocks()
		{
			foreach (StackerBlockViewModel stackerBlockViewModel in this.Stack)
			{
				stackerBlockViewModel.DisableBlock();
				this.UndoBlocks.Push(new StackerViewModel.UndoRedoBlock(stackerBlockViewModel, this.Stack.IndexOf(stackerBlockViewModel), stackerBlockViewModel.Block.Disabled ? StackerViewModel.UndoRedoState.Disabled : StackerViewModel.UndoRedoState.Enabled));
			}
		}

		// Token: 0x06000E35 RID: 3637 RVA: 0x000491DC File Offset: 0x000473DC
		public void EnableAllBlocks()
		{
			foreach (StackerBlockViewModel stackerBlockViewModel in this.Stack)
			{
				stackerBlockViewModel.EnableBlock();
				this.UndoBlocks.Push(new StackerViewModel.UndoRedoBlock(stackerBlockViewModel, this.Stack.IndexOf(stackerBlockViewModel), stackerBlockViewModel.Block.Disabled ? StackerViewModel.UndoRedoState.Disabled : StackerViewModel.UndoRedoState.Enabled));
			}
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x00049258 File Offset: 0x00047458
		public void UndoBlock()
		{
			Stack<StackerViewModel.UndoRedoBlock> undoBlocks = this.UndoBlocks;
			if (undoBlocks != null && undoBlocks.Count <= 0)
			{
				GlobalData.Logger.LogError(Components.Stacker, "Nothing to undo", false, 0);
				return;
			}
			StackerViewModel.UndoRedoBlock undoRedoBlock = null;
			try
			{
				undoRedoBlock = this.UndoBlocks.Pop();
				string message = string.Empty;
				switch (undoRedoBlock.LastState)
				{
				case StackerViewModel.UndoRedoState.MovedUp:
				{
					this.MoveBlockDown(undoRedoBlock.Stacker);
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.MovedDown;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Moved up block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case StackerViewModel.UndoRedoState.MovedDown:
				{
					this.MoveBlockUp(undoRedoBlock.Stacker);
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.MovedUp;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Moved down block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case StackerViewModel.UndoRedoState.Cloned:
				{
					this.AddBlock(undoRedoBlock.Stacker, undoRedoBlock.Index);
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.Added;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Cloned block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case StackerViewModel.UndoRedoState.Removed:
				{
					this.AddBlock(undoRedoBlock.Stacker, undoRedoBlock.Index);
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.Added;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Readded block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case StackerViewModel.UndoRedoState.Added:
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
					if (!this.Stack.Remove(undoRedoBlock.Stacker))
					{
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Block (");
						defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
						defaultInterpolatedStringHandler.AppendLiteral(") could not be removed");
						throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.Removed;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Removed block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					this.CurrentBlock = null;
					GlobalData.MainWindow.ConfigsSecionPage.StackerPage.BlockInfo.Content = null;
					this.UpdateHeights();
					break;
				}
				case StackerViewModel.UndoRedoState.Disabled:
				{
					undoRedoBlock.Stacker.DisableOrEnable();
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.Enabled;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Enabled block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case StackerViewModel.UndoRedoState.Enabled:
				{
					undoRedoBlock.Stacker.DisableOrEnable();
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.Disabled;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Disabled block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				}
				this.RedoBlocks.Push(undoRedoBlock);
				GlobalData.MainWindow.ConfigsSecionPage.StackerPage.stackListView.SelectedIndex = -1;
				GlobalData.Logger.LogInfo(Components.Stacker, message, false, 0);
			}
			catch (Exception ex)
			{
				try
				{
					this.UndoBlocks.Push(undoRedoBlock);
				}
				catch
				{
				}
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x0004969C File Offset: 0x0004789C
		public void RedoBlock()
		{
			Stack<StackerViewModel.UndoRedoBlock> redoBlocks = this.RedoBlocks;
			if (redoBlocks != null && redoBlocks.Count <= 0)
			{
				GlobalData.Logger.LogError(Components.Stacker, "Nothing to redo", false, 0);
				return;
			}
			StackerViewModel.UndoRedoBlock undoRedoBlock = null;
			try
			{
				undoRedoBlock = this.RedoBlocks.Pop();
				string message = string.Empty;
				switch (undoRedoBlock.LastState)
				{
				case StackerViewModel.UndoRedoState.MovedUp:
				{
					this.MoveBlockDown(undoRedoBlock.Stacker);
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.MovedDown;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Moved up block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case StackerViewModel.UndoRedoState.MovedDown:
				{
					this.MoveBlockUp(undoRedoBlock.Stacker);
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.MovedUp;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Moved down block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case StackerViewModel.UndoRedoState.Cloned:
				{
					this.AddBlock(undoRedoBlock.Stacker, undoRedoBlock.Index);
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.Added;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Cloned block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case StackerViewModel.UndoRedoState.Removed:
				{
					this.AddBlock(undoRedoBlock.Stacker, undoRedoBlock.Index);
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.Added;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Readded block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case StackerViewModel.UndoRedoState.Added:
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
					if (!this.Stack.Remove(undoRedoBlock.Stacker))
					{
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Block (");
						defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
						defaultInterpolatedStringHandler.AppendLiteral(") could not be removed");
						throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.Removed;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Removed block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					this.CurrentBlock = null;
					GlobalData.MainWindow.ConfigsSecionPage.StackerPage.BlockInfo.Content = null;
					this.UpdateHeights();
					break;
				}
				case StackerViewModel.UndoRedoState.Disabled:
				{
					undoRedoBlock.Stacker.DisableOrEnable();
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.Enabled;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Enabled block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case StackerViewModel.UndoRedoState.Enabled:
				{
					undoRedoBlock.Stacker.DisableOrEnable();
					undoRedoBlock.LastState = StackerViewModel.UndoRedoState.Disabled;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Disabled block of type ");
					defaultInterpolatedStringHandler.AppendFormatted<Type>(undoRedoBlock.Stacker.Block.GetType());
					defaultInterpolatedStringHandler.AppendLiteral(" in position ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(undoRedoBlock.Index);
					message = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				}
				this.UndoBlocks.Push(undoRedoBlock);
				GlobalData.MainWindow.ConfigsSecionPage.StackerPage.stackListView.SelectedIndex = -1;
				GlobalData.Logger.LogInfo(Components.Stacker, message, false, 0);
			}
			catch (Exception ex)
			{
				try
				{
					this.RedoBlocks.Push(undoRedoBlock);
				}
				catch
				{
				}
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x00049AE0 File Offset: 0x00047CE0
		public void ClearUndoRedo()
		{
			if (Alert.Choice("Do you want to delete undo/redo?", "Clear Undo/Redo", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes)
			{
				return;
			}
			try
			{
				this.UndoBlocks.Clear();
			}
			catch
			{
			}
			try
			{
				this.RedoBlocks.Clear();
			}
			catch
			{
			}
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x00049B44 File Offset: 0x00047D44
		public int Clamp(int a, int min, int max)
		{
			if (a < min)
			{
				return min;
			}
			if (a > max)
			{
				return max;
			}
			return a;
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000E3A RID: 3642 RVA: 0x00049B53 File Offset: 0x00047D53
		// (set) Token: 0x06000E3B RID: 3643 RVA: 0x00049B5B File Offset: 0x00047D5B
		public ProxyType ProxyType
		{
			get
			{
				return this.proxyType;
			}
			set
			{
				this.proxyType = value;
				this.OnPropertyChanged("ProxyType");
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000E3C RID: 3644 RVA: 0x00049B6F File Offset: 0x00047D6F
		// (set) Token: 0x06000E3D RID: 3645 RVA: 0x00049B77 File Offset: 0x00047D77
		public string TestData
		{
			get
			{
				return this.testData;
			}
			set
			{
				this.testData = value;
				this.OnPropertyChanged("TestData");
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000E3E RID: 3646 RVA: 0x00049B8B File Offset: 0x00047D8B
		// (set) Token: 0x06000E3F RID: 3647 RVA: 0x00049B93 File Offset: 0x00047D93
		public string TestDataType
		{
			get
			{
				return this.testDataType;
			}
			set
			{
				this.testDataType = value;
				this.OnPropertyChanged("TestDataType");
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000E40 RID: 3648 RVA: 0x00049BA7 File Offset: 0x00047DA7
		// (set) Token: 0x06000E41 RID: 3649 RVA: 0x00049BAF File Offset: 0x00047DAF
		public string TestProxy
		{
			get
			{
				return this.testProxy;
			}
			set
			{
				this.testProxy = value;
				this.OnPropertyChanged("TestProxy");
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000E42 RID: 3650 RVA: 0x00049BC3 File Offset: 0x00047DC3
		// (set) Token: 0x06000E43 RID: 3651 RVA: 0x00049BCB File Offset: 0x00047DCB
		public bool UseProxy
		{
			get
			{
				return this.useProxy;
			}
			set
			{
				this.useProxy = value;
				this.OnPropertyChanged("UseProxy");
				this.OnPropertyChanged("UseProxyString");
				this.OnPropertyChanged("UseProxyColor");
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000E44 RID: 3652 RVA: 0x00049BF5 File Offset: 0x00047DF5
		public string UseProxyString
		{
			get
			{
				if (!this.UseProxy)
				{
					return "OFF";
				}
				return "ON";
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000E45 RID: 3653 RVA: 0x00049C0A File Offset: 0x00047E0A
		public SolidColorBrush UseProxyColor
		{
			get
			{
				if (!this.UseProxy)
				{
					return Utils.GetBrush("ForegroundBad");
				}
				return Utils.GetBrush("ForegroundGood");
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000E46 RID: 3654 RVA: 0x00049C29 File Offset: 0x00047E29
		// (set) Token: 0x06000E47 RID: 3655 RVA: 0x00049C31 File Offset: 0x00047E31
		public bool SBS
		{
			get
			{
				return this.sbs;
			}
			set
			{
				this.sbs = value;
				this.OnPropertyChanged("SBS");
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000E48 RID: 3656 RVA: 0x00049C45 File Offset: 0x00047E45
		// (set) Token: 0x06000E49 RID: 3657 RVA: 0x00049C4D File Offset: 0x00047E4D
		public bool SBSClear
		{
			get
			{
				return this.sbsClear;
			}
			set
			{
				this.sbsClear = value;
				this.OnPropertyChanged("SBSClear");
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000E4A RID: 3658 RVA: 0x00049C61 File Offset: 0x00047E61
		// (set) Token: 0x06000E4B RID: 3659 RVA: 0x00049C69 File Offset: 0x00047E69
		public bool SBSEnabled
		{
			get
			{
				return this.sbsEnabled;
			}
			set
			{
				this.sbsEnabled = value;
				this.OnPropertyChanged("SBSEnabled");
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000E4C RID: 3660 RVA: 0x00049C7D File Offset: 0x00047E7D
		// (set) Token: 0x06000E4D RID: 3661 RVA: 0x00049C85 File Offset: 0x00047E85
		public string SearchString
		{
			get
			{
				return this.searchString;
			}
			set
			{
				this.searchString = value;
				this.OnPropertyChanged("SearchString");
				this.OnPropertyChanged("SearchProgress");
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000E4E RID: 3662 RVA: 0x00049CA4 File Offset: 0x00047EA4
		// (set) Token: 0x06000E4F RID: 3663 RVA: 0x00049CAC File Offset: 0x00047EAC
		public List<int> Indexes
		{
			get
			{
				return this.indexes;
			}
			set
			{
				this.indexes = value;
				this.OnPropertyChanged("TotalSearchMatches");
				this.OnPropertyChanged("CurrentSearchMatch");
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000E50 RID: 3664 RVA: 0x00049CCB File Offset: 0x00047ECB
		public int TotalSearchMatches
		{
			get
			{
				return this.Indexes.Count;
			}
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x00049CD8 File Offset: 0x00047ED8
		public void UpdateTotalSearchMatches()
		{
			this.OnPropertyChanged("TotalSearchMatches");
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000E52 RID: 3666 RVA: 0x00049CE5 File Offset: 0x00047EE5
		// (set) Token: 0x06000E53 RID: 3667 RVA: 0x00049CED File Offset: 0x00047EED
		public int CurrentSearchMatch
		{
			get
			{
				return this.currentSearchMatch;
			}
			set
			{
				this.currentSearchMatch = value;
				this.OnPropertyChanged("CurrentSearchMatch");
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000E54 RID: 3668 RVA: 0x00049D01 File Offset: 0x00047F01
		// (set) Token: 0x06000E55 RID: 3669 RVA: 0x00049D09 File Offset: 0x00047F09
		public BinaryReader Reader
		{
			get
			{
				return this.binaryReader;
			}
			set
			{
				this.binaryReader = value;
				this.OnPropertyChanged("Reader");
			}
		}

		// Token: 0x06000E56 RID: 3670 RVA: 0x00049D20 File Offset: 0x00047F20
		public StackerViewModel(ConfigViewModel config)
		{
			this.ConfigViewModel = config;
		}

		// Token: 0x06000E57 RID: 3671 RVA: 0x00049DCC File Offset: 0x00047FCC
		[return: TupleElementNames(new string[]
		{
			"Text",
			"Description"
		})]
		public IEnumerable<ValueTuple<string, string>> GetAutoCompleteList(string text)
		{
			List<ValueTuple<string, string>> list = new List<ValueTuple<string, string>>(BlockParser.BlockMappings.Count);
			foreach (KeyValuePair<string, Type> keyValuePair in BlockParser.BlockMappings)
			{
				list.Add(new ValueTuple<string, string>(keyValuePair.Key + " (Block)", ((BlockBase)Activator.CreateInstance(keyValuePair.Value)).Info.Description));
			}
			list.Add(new ValueTuple<string, string>("BEGIN SCRIPT Jint", "JavaScript Interpreter"));
			list.Add(new ValueTuple<string, string>("BEGIN SCRIPT CSharp", "Interpreter"));
			list.Add(new ValueTuple<string, string>("BEGIN SCRIPT IronPython", "Python Interpreter"));
			list.Add(new ValueTuple<string, string>("BEGIN SCRIPT NodeJs", "Interpreter"));
			list.Add(new ValueTuple<string, string>("END SCRIPT -> VARS \"\"", "Interpreter"));
			list.Add(new ValueTuple<string, string>("VAR", ""));
			list.Add(new ValueTuple<string, string>("VARS", ""));
			list.Add(new ValueTuple<string, string>("CAP", ""));
			list.Add(new ValueTuple<string, string>("GVAR", ""));
			list.Add(new ValueTuple<string, string>("->", ""));
			list.Add(new ValueTuple<string, string>("HEADER", ""));
			list.Add(new ValueTuple<string, string>("COOKIE", ""));
			list.Add(new ValueTuple<string, string>("KEYCHAIN", ""));
			list.Add(new ValueTuple<string, string>("KEY", ""));
			list.Add(new ValueTuple<string, string>("VALUE", ""));
			list.Add(new ValueTuple<string, string>("NKEY", ""));
			list.Add(new ValueTuple<string, string>("MKEY", ""));
			list.Add(new ValueTuple<string, string>("NMKEY", ""));
			list.Add(new ValueTuple<string, string>("RKEY", ""));
			list.Add(new ValueTuple<string, string>("LR", ""));
			list.Add(new ValueTuple<string, string>("CSS", ""));
			list.Add(new ValueTuple<string, string>("JSON", ""));
			list.Add(new ValueTuple<string, string>("REGEX", ""));
			list.Add(new ValueTuple<string, string>("XPATH", ""));
			list.Add(new ValueTuple<string, string>("MESSAGE", ""));
			list.Add(new ValueTuple<string, string>("CONTENT", ""));
			list.Add(new ValueTuple<string, string>("SECPROTO", ""));
			foreach (object obj in Enum.GetValues(typeof(CommandParser.CommandName)))
			{
				list.Add(new ValueTuple<string, string>(((CommandParser.CommandName)obj).ToString() + " (Command)", ""));
			}
			list.Add(new ValueTuple<string, string>("BEGIN", ""));
			list.Add(new ValueTuple<string, string>("END", ""));
			list.Add(new ValueTuple<string, string>("IF", "\"STRING1\" CONDITION \"STRING2\""));
			list.Add(new ValueTuple<string, string>("ELIF", "\"STRING1\" CONDITION \"STRING2\""));
			list.Add(new ValueTuple<string, string>("ELSE", ""));
			list.Add(new ValueTuple<string, string>("ENDIF", ""));
			list.Add(new ValueTuple<string, string>("WHILE", "\"STRING1\" CONDITION \"STRING2\""));
			list.Add(new ValueTuple<string, string>("ENDWHILE", ""));
			list.Add(new ValueTuple<string, string>("JUMP", ""));
			list.Add(new ValueTuple<string, string>("<", "A is less than B."));
			list.Add(new ValueTuple<string, string>("<=", "A is less than or equal B."));
			list.Add(new ValueTuple<string, string>(">", "A is greater than B."));
			list.Add(new ValueTuple<string, string>(">=", "A is greater than or equal B."));
			list.Add(new ValueTuple<string, string>("==", "A is equal to B."));
			list.Add(new ValueTuple<string, string>("==", "A is equal to B."));
			list.Add(new ValueTuple<string, string>("!=", "A is not equal to B."));
			list.Add(new ValueTuple<string, string>("Contains", "A contains B."));
			list.Add(new ValueTuple<string, string>("DoesNotContain", "A does not contain B."));
			list.Add(new ValueTuple<string, string>("Exists", "Whether any variable can be replaced inside the string."));
			list.Add(new ValueTuple<string, string>("DoesNotExist", "Whether no variable can be replaced inside the string."));
			list.Add(new ValueTuple<string, string>("MatchesRegex", "A matches regex pattern B."));
			list.Add(new ValueTuple<string, string>("DoesNotMatchRegexs", "A does not match regex pattern B."));
			list.Add(new ValueTuple<string, string>("XPathExists", ""));
			list.Add(new ValueTuple<string, string>("XPathDoesNotExist", ""));
			list.Add(new ValueTuple<string, string>("<NAME[0]>", "List (access one element by index)"));
			list.Add(new ValueTuple<string, string>("<NAME[*]>", "List (access all element using * as index)"));
			list.Add(new ValueTuple<string, string>("<NAME(key)>", "Dictionary (access by key using ())"));
			list.Add(new ValueTuple<string, string>("<NAME{value}>", "Dictionary (access by value using {})"));
			list.Add(new ValueTuple<string, string>("<NAME(*)>", "Dictionary (access all keys using *)"));
			list.Add(new ValueTuple<string, string>("<NAME{*}>", "Dictionary (access all values using *)"));
			list.Add(new ValueTuple<string, string>("##", "Every line that starts with two #s is considered a comment"));
			return list;
		}

		// Token: 0x040006CD RID: 1741
		private Random rand = new Random();

		// Token: 0x040006D1 RID: 1745
		private bool controlsEnabled = true;

		// Token: 0x040006D2 RID: 1746
		private ObservableCollection<SilverBlock> blocks = new ObservableCollection<SilverBlock>();

		// Token: 0x040006D3 RID: 1747
		private bool breakpoint;

		// Token: 0x040006D4 RID: 1748
		private ObservableCollection<SvbScript.Breakpoint> breakpoints = new ObservableCollection<SvbScript.Breakpoint>();

		// Token: 0x040006DA RID: 1754
		private string blockLabel = "";

		// Token: 0x040006DB RID: 1755
		private ProxyType proxyType;

		// Token: 0x040006DC RID: 1756
		private string testData = "";

		// Token: 0x040006DD RID: 1757
		private string testDataType = "";

		// Token: 0x040006DE RID: 1758
		private string testProxy = "";

		// Token: 0x040006DF RID: 1759
		private bool useProxy;

		// Token: 0x040006E0 RID: 1760
		private bool sbs;

		// Token: 0x040006E1 RID: 1761
		private bool sbsClear;

		// Token: 0x040006E2 RID: 1762
		private bool sbsEnabled = true;

		// Token: 0x040006E3 RID: 1763
		private string searchString = "";

		// Token: 0x040006E4 RID: 1764
		private List<int> indexes = new List<int>();

		// Token: 0x040006E5 RID: 1765
		private int currentSearchMatch;

		// Token: 0x040006E6 RID: 1766
		private BinaryReader binaryReader;

		// Token: 0x020002CE RID: 718
		public class UndoRedoBlock
		{
			// Token: 0x17000250 RID: 592
			// (get) Token: 0x060012DA RID: 4826 RVA: 0x000559DC File Offset: 0x00053BDC
			// (set) Token: 0x060012DB RID: 4827 RVA: 0x000559E4 File Offset: 0x00053BE4
			public StackerBlockViewModel Stacker { get; private set; }

			// Token: 0x17000251 RID: 593
			// (get) Token: 0x060012DC RID: 4828 RVA: 0x000559ED File Offset: 0x00053BED
			// (set) Token: 0x060012DD RID: 4829 RVA: 0x000559F5 File Offset: 0x00053BF5
			public int Index { get; private set; }

			// Token: 0x17000252 RID: 594
			// (get) Token: 0x060012DE RID: 4830 RVA: 0x000559FE File Offset: 0x00053BFE
			// (set) Token: 0x060012DF RID: 4831 RVA: 0x00055A06 File Offset: 0x00053C06
			public StackerViewModel.UndoRedoState LastState { get; set; }

			// Token: 0x060012E0 RID: 4832 RVA: 0x00055A0F File Offset: 0x00053C0F
			public UndoRedoBlock(StackerBlockViewModel vm, int index, StackerViewModel.UndoRedoState state)
			{
				this.Stacker = vm;
				this.Index = index;
				this.LastState = state;
			}
		}

		// Token: 0x020002CF RID: 719
		public enum UndoRedoState
		{
			// Token: 0x0400097C RID: 2428
			MovedUp,
			// Token: 0x0400097D RID: 2429
			MovedDown,
			// Token: 0x0400097E RID: 2430
			Cloned,
			// Token: 0x0400097F RID: 2431
			Removed,
			// Token: 0x04000980 RID: 2432
			Added,
			// Token: 0x04000981 RID: 2433
			Disabled,
			// Token: 0x04000982 RID: 2434
			Enabled
		}
	}
}
