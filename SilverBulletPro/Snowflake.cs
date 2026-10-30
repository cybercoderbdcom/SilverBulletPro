using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace SilverBulletPro
{
	// Token: 0x02000030 RID: 48
	public class Snowflake : UserControl, IComponentConnector
	{
		// Token: 0x060001AD RID: 429 RVA: 0x0000D435 File Offset: 0x0000B635
		public Snowflake()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000D444 File Offset: 0x0000B644
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/usercontrols/snowflake.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000D474 File Offset: 0x0000B674
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040000DE RID: 222
		private bool _contentLoaded;
	}
}
