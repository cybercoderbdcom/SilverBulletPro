using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Newtonsoft.Json;
using SilverBulletPro.Core;
using SilverBulletPro.Models;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x0200003C RID: 60
	public partial class UserControlBlock : Border, INotifyPropertyChanged
	{
		// Token: 0x060002B8 RID: 696 RVA: 0x00011EDE File Offset: 0x000100DE
		public UserControlBlock()
		{
			this.InitializeComponent();
			base.DataContext = this;
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060002B9 RID: 697 RVA: 0x00011EF4 File Offset: 0x000100F4
		// (remove) Token: 0x060002BA RID: 698 RVA: 0x00011F2C File Offset: 0x0001012C
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x060002BB RID: 699 RVA: 0x00011F61 File Offset: 0x00010161
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged == null)
			{
				return;
			}
			propertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002BC RID: 700 RVA: 0x00011F7A File Offset: 0x0001017A
		// (set) Token: 0x060002BD RID: 701 RVA: 0x00011F8C File Offset: 0x0001018C
		public Brush Foreground
		{
			get
			{
				return (Brush)base.GetValue(UserControlBlock.ForegroundProperty);
			}
			set
			{
				base.SetValue(UserControlBlock.ForegroundProperty, value);
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002BE RID: 702 RVA: 0x00011F9A File Offset: 0x0001019A
		// (set) Token: 0x060002BF RID: 703 RVA: 0x00011FAC File Offset: 0x000101AC
		public string Description
		{
			get
			{
				return (string)base.GetValue(UserControlBlock.DescriptionProperty);
			}
			set
			{
				base.SetValue(UserControlBlock.DescriptionProperty, value);
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x00011FBA File Offset: 0x000101BA
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x00011FCC File Offset: 0x000101CC
		public string FullInfo
		{
			get
			{
				return (string)base.GetValue(UserControlBlock.FullInfoProperty);
			}
			set
			{
				base.SetValue(UserControlBlock.FullInfoProperty, value);
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x00011FDA File Offset: 0x000101DA
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x00011FEC File Offset: 0x000101EC
		public Visibility DescriptionVisibility
		{
			get
			{
				return (Visibility)base.GetValue(UserControlBlock.DescriptionVisibilityProperty);
			}
			set
			{
				base.SetValue(UserControlBlock.DescriptionVisibilityProperty, value);
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00011FFF File Offset: 0x000101FF
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x00012011 File Offset: 0x00010211
		public Visibility FavoriteVisibility
		{
			get
			{
				return (Visibility)base.GetValue(UserControlBlock.FavoriteVisibilityProperty);
			}
			set
			{
				base.SetValue(UserControlBlock.FavoriteVisibilityProperty, value);
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00012024 File Offset: 0x00010224
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x00012036 File Offset: 0x00010236
		public string Text
		{
			get
			{
				return (string)base.GetValue(UserControlBlock.TextProperty);
			}
			set
			{
				base.SetValue(UserControlBlock.TextProperty, value);
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00012044 File Offset: 0x00010244
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x0001204C File Offset: 0x0001024C
		public bool Favorite
		{
			get
			{
				return this.favorite;
			}
			set
			{
				this.favorite = value;
				this.OnPropertyChanged("Favorite");
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00012060 File Offset: 0x00010260
		// (set) Token: 0x060002CB RID: 715 RVA: 0x00012072 File Offset: 0x00010272
		public double FontSize
		{
			get
			{
				return (double)base.GetValue(UserControlBlock.FontSizeProperty);
			}
			set
			{
				base.SetValue(UserControlBlock.FontSizeProperty, value);
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002CC RID: 716 RVA: 0x00012085 File Offset: 0x00010285
		// (set) Token: 0x060002CD RID: 717 RVA: 0x00012097 File Offset: 0x00010297
		public Thickness TextMargin
		{
			get
			{
				return (Thickness)base.GetValue(UserControlBlock.TextMarginProperty);
			}
			set
			{
				base.SetValue(UserControlBlock.TextMarginProperty, value);
			}
		}

		// Token: 0x060002CE RID: 718 RVA: 0x000120AA File Offset: 0x000102AA
		[AttachedPropertyBrowsableForType(typeof(TextBlock))]
		public static bool GetIsTextTrimmed(TextBlock target)
		{
			return (bool)target.GetValue(UserControlBlock.IsTextTrimmedProperty);
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002CF RID: 719 RVA: 0x000120BC File Offset: 0x000102BC
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x000120C4 File Offset: 0x000102C4
		public WrapPanel Subset { get; set; }

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060002D1 RID: 721 RVA: 0x000120CD File Offset: 0x000102CD
		// (remove) Token: 0x060002D2 RID: 722 RVA: 0x000120DB File Offset: 0x000102DB
		public event RoutedEventHandler Click
		{
			add
			{
				base.AddHandler(UserControlBlock.ClickEvent, value);
			}
			remove
			{
				base.RemoveHandler(UserControlBlock.ClickEvent, value);
			}
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000120EC File Offset: 0x000102EC
		private void RaiseClickEvent()
		{
			RoutedEventArgs e = new RoutedEventArgs(UserControlBlock.ClickEvent);
			base.RaiseEvent(e);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0001210B File Offset: 0x0001030B
		private void OnClick()
		{
			this.RaiseClickEvent();
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060002D5 RID: 725 RVA: 0x00012114 File Offset: 0x00010314
		// (remove) Token: 0x060002D6 RID: 726 RVA: 0x0001214C File Offset: 0x0001034C
		public event EventHandler<bool> FavoriteChanged;

		// Token: 0x060002D7 RID: 727 RVA: 0x00012181 File Offset: 0x00010381
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (this.favoriteClicked)
			{
				this.favoriteClicked = false;
				return;
			}
			this.OnClick();
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0001219C File Offset: 0x0001039C
		private void TextBlock_ToolTipOpening(object sender, ToolTipEventArgs e)
		{
			TextBlock textBlock = sender as TextBlock;
			if (textBlock.TextTrimming != TextTrimming.None)
			{
				e.Handled = !this.IsTextTrimmed(textBlock);
			}
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x000121C8 File Offset: 0x000103C8
		private bool IsTextTrimmed(TextBlock textBlock)
		{
			return this.CalculateIsTextTrimmed(textBlock);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x000121D4 File Offset: 0x000103D4
		private bool CalculateIsTextTrimmed(TextBlock textBlock)
		{
			if (!textBlock.IsArrangeValid)
			{
				return UserControlBlock.GetIsTextTrimmed(textBlock);
			}
			Typeface typeface = new Typeface(textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch);
			FormattedText formattedText = new FormattedText(textBlock.Text, Thread.CurrentThread.CurrentCulture, textBlock.FlowDirection, typeface, textBlock.FontSize, textBlock.Foreground);
			formattedText.MaxTextWidth = textBlock.ActualWidth;
			return formattedText.Height > textBlock.ActualHeight || formattedText.MinWidth > formattedText.MaxTextWidth;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00012261 File Offset: 0x00010461
		private void CheckBox_Click(object sender, RoutedEventArgs e)
		{
			this.favoriteClicked = true;
			this.SaveFavoriteBlock();
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00012270 File Offset: 0x00010470
		private void CheckBox_MouseLeave(object sender, MouseEventArgs e)
		{
			this.favoriteClicked = false;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0001227C File Offset: 0x0001047C
		public void SaveFavoriteBlock()
		{
			List<FavoriteBlock> list = IOManager.DeserializeObject<List<FavoriteBlock>>(File.ReadAllText(Constants.FavoriteBlocksFile)) ?? new List<FavoriteBlock>();
			FavoriteBlock item;
			if (this.Favorite)
			{
				list.Add(new FavoriteBlock
				{
					Name = base.Tag.ToString()
				});
			}
			else if ((item = list.FirstOrDefault((FavoriteBlock b) => b.Name == base.Tag.ToString())) != null)
			{
				list.Remove(item);
			}
			File.WriteAllText(Constants.FavoriteBlocksFile, IOManager.SerializeObject(list, 1, new JsonSerializerSettings()));
			EventHandler<bool> favoriteChanged = this.FavoriteChanged;
			if (favoriteChanged == null)
			{
				return;
			}
			favoriteChanged(this, this.Favorite);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x000123F8 File Offset: 0x000105F8
		// Note: this type is marked as 'beforefieldinit'.
		static UserControlBlock()
		{
			UserControlBlock.ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserControlBlock));
		}

		// Token: 0x0400015A RID: 346
		private bool favoriteClicked;

		// Token: 0x0400015C RID: 348
		public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register("Foreground", typeof(Brush), typeof(UserControlBlock));

		// Token: 0x0400015D RID: 349
		public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(UserControlBlock));

		// Token: 0x0400015E RID: 350
		public static readonly DependencyProperty FullInfoProperty = DependencyProperty.Register("FullInfo", typeof(string), typeof(UserControlBlock));

		// Token: 0x0400015F RID: 351
		public static readonly DependencyProperty DescriptionVisibilityProperty = DependencyProperty.Register("DescriptionVisibility", typeof(Visibility), typeof(UserControlBlock), new PropertyMetadata(Visibility.Collapsed));

		// Token: 0x04000160 RID: 352
		public static readonly DependencyProperty FavoriteVisibilityProperty = DependencyProperty.Register("FavoriteVisibility", typeof(Visibility), typeof(UserControlBlock), new PropertyMetadata(Visibility.Collapsed));

		// Token: 0x04000161 RID: 353
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(UserControlBlock));

		// Token: 0x04000162 RID: 354
		private bool favorite;

		// Token: 0x04000163 RID: 355
		public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register("FontSize", typeof(double), typeof(UserControlBlock));

		// Token: 0x04000164 RID: 356
		public static readonly DependencyProperty TextMarginProperty = DependencyProperty.Register("TextMargin", typeof(Thickness), typeof(UserControlBlock), new PropertyMetadata(new Thickness(0.0)));

		// Token: 0x04000165 RID: 357
		private static readonly DependencyPropertyKey IsTextTrimmedKey = DependencyProperty.RegisterAttachedReadOnly("IsTextTrimmed", typeof(bool), typeof(UserControlBlock), new PropertyMetadata(false));

		// Token: 0x04000166 RID: 358
		public static readonly DependencyProperty IsTextTrimmedProperty = UserControlBlock.IsTextTrimmedKey.DependencyProperty;
	}
}
