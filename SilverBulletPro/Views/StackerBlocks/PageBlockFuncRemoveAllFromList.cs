using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Functions.Conditions;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x0200007B RID: 123
	public class PageBlockFuncRemoveAllFromList : Page, IComponentConnector
	{
		// Token: 0x06000440 RID: 1088 RVA: 0x000174C8 File Offset: 0x000156C8
		public PageBlockFuncRemoveAllFromList(BlockRemoveAllFromList block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(Comparer)))
			{
				Comparer comparer = (Comparer)obj;
				string a = string.Empty;
				if ((a = EnumExtension.GetDescription(comparer)).Any((char c) => char.IsLetter(c)) || !(a != "==") || !(a != "!="))
				{
					this.comparisonBox.Items.Add(comparer);
				}
			}
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x000175A0 File Offset: 0x000157A0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfuncremoveallfromlist.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x000175D0 File Offset: 0x000157D0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x000175DA File Offset: 0x000157DA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.comparisonBox = (ComboBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000220 RID: 544
		internal ComboBox comparisonBox;

		// Token: 0x04000221 RID: 545
		private bool _contentLoaded;
	}
}
