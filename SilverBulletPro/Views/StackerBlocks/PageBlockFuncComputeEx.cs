using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000068 RID: 104
	public class PageBlockFuncComputeEx : Page, IComponentConnector
	{
		// Token: 0x060003F3 RID: 1011 RVA: 0x00016978 File Offset: 0x00014B78
		public PageBlockFuncComputeEx(BlockComputeEx block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00016990 File Offset: 0x00014B90
		private string[] GetItemsSource()
		{
			return (from m in typeof(Math).GetMethods(BindingFlags.Static | BindingFlags.Public)
			where !m.ReturnType.ToString().StartsWith("System.ValueTuple`")
			select m.Name).Distinct<string>().ToArray<string>();
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00016A00 File Offset: 0x00014C00
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/float/pageblockfunccomputeex.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00016A30 File Offset: 0x00014C30
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00016A3A File Offset: 0x00014C3A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040001FB RID: 507
		private bool _contentLoaded;
	}
}
