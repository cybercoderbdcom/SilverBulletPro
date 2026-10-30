using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000082 RID: 130
	public class PageBlockFuncRandomUserAgent : Page, IComponentConnector
	{
		// Token: 0x0600045C RID: 1116 RVA: 0x00017844 File Offset: 0x00015A44
		public PageBlockFuncRandomUserAgent(BlockRandomUserAgent block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(UaPlatform)))
			{
				UaPlatform uaPlatform = (UaPlatform)obj;
				this.platFormBox.Items.Add(uaPlatform);
			}
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x000178CC File Offset: 0x00015ACC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/pageblockfuncrandomuseragent.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x000178FC File Offset: 0x00015AFC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00017906 File Offset: 0x00015B06
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.platFormBox = (ComboBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000229 RID: 553
		internal ComboBox platFormBox;

		// Token: 0x0400022A RID: 554
		private bool _contentLoaded;
	}
}
