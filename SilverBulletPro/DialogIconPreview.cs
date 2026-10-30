using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using SilverBulletPro.Extensions;

namespace SilverBulletPro
{
	// Token: 0x02000024 RID: 36
	public class DialogIconPreview : Page, IComponentConnector
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000142 RID: 322 RVA: 0x0000AB73 File Offset: 0x00008D73
		// (set) Token: 0x06000143 RID: 323 RVA: 0x0000AB7B File Offset: 0x00008D7B
		public object Caller { get; set; }

		// Token: 0x06000144 RID: 324 RVA: 0x0000AB84 File Offset: 0x00008D84
		public DialogIconPreview(object caller, MemoryStream ms)
		{
			this.InitializeComponent();
			this.Caller = caller;
			this.icon.ImageSource = ms.ToImage();
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000ABAC File Offset: 0x00008DAC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/dialogiconpreview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0000ABDC File Offset: 0x00008DDC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.icon = (ImageBrush)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040000A5 RID: 165
		internal ImageBrush icon;

		// Token: 0x040000A6 RID: 166
		private bool _contentLoaded;
	}
}
