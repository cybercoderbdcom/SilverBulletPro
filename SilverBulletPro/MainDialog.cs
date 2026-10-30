using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using HandyControl.Controls;
using HandyControl.Tools;
using SilverBulletPro.Core.Extensions;

namespace SilverBulletPro
{
	// Token: 0x0200002E RID: 46
	public class MainDialog : GlowWindow, IComponentConnector
	{
		// Token: 0x0600019B RID: 411 RVA: 0x0000CE75 File Offset: 0x0000B075
		public MainDialog(MainDialog.InputDialog dialog)
		{
			this.InitializeComponent();
			this.InitializationsApplied = false;
			this.ApplyInitialization(dialog);
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000CE94 File Offset: 0x0000B094
		private void ApplyInitialization(MainDialog.InputDialog dialog)
		{
			this.dialog = dialog;
			base.Content = dialog.Dialog;
			base.SizeToContent = dialog.SizeToContent;
			string title;
			if (string.IsNullOrWhiteSpace(dialog.Title))
			{
				Page page = dialog.Dialog;
				title = ((page != null) ? page.Title : null);
			}
			else
			{
				title = dialog.Title;
			}
			base.Title = title;
			if (!string.IsNullOrWhiteSpace(dialog.Icon))
			{
				base.Icon = ImageSourceExtension.GetImage(dialog.Icon);
			}
			base.ResizeMode = dialog.ResizeMode;
			if (((dialog != null) ? dialog.Owner : null) == null)
			{
				base.Owner = WindowHelper.GetActiveWindow();
			}
			else
			{
				base.Owner = dialog.Owner;
			}
			if (dialog.InitialWidth != null)
			{
				base.Width = (double)dialog.InitialWidth.GetValueOrDefault();
			}
			if (dialog.InitialHeight != null)
			{
				base.Height = (double)dialog.InitialHeight.GetValueOrDefault();
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000CF88 File Offset: 0x0000B188
		private void BlurWindow_StateChanged(object sender, EventArgs e)
		{
			if (this.dialog.DisableMinimize && base.WindowState == WindowState.Minimized)
			{
				base.WindowState = WindowState.Normal;
			}
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000CFA7 File Offset: 0x0000B1A7
		private void BlurWindow_SourceInitialized(object sender, EventArgs e)
		{
			if (this.dialog.DisableMinimize)
			{
				base.CommandBindings.RemoveAt(0);
			}
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000CFC2 File Offset: 0x0000B1C2
		private void BlurWindow_Loaded(object sender, RoutedEventArgs e)
		{
			if (!this.InitializationsApplied)
			{
				this.InitializationsApplied = true;
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000CFD4 File Offset: 0x0000B1D4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/maindialog.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0000D004 File Offset: 0x0000B204
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((MainDialog)target).Loaded += this.BlurWindow_Loaded;
				((MainDialog)target).SourceInitialized += this.BlurWindow_SourceInitialized;
				((MainDialog)target).StateChanged += this.BlurWindow_StateChanged;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040000D6 RID: 214
		private MainDialog.InputDialog dialog;

		// Token: 0x040000D7 RID: 215
		private bool InitializationsApplied;

		// Token: 0x040000D8 RID: 216
		private bool _contentLoaded;

		// Token: 0x02000230 RID: 560
		public class InputDialog
		{
			// Token: 0x17000245 RID: 581
			// (get) Token: 0x060010D0 RID: 4304 RVA: 0x000500C2 File Offset: 0x0004E2C2
			// (set) Token: 0x060010D1 RID: 4305 RVA: 0x000500CA File Offset: 0x0004E2CA
			public Page Dialog { get; set; }

			// Token: 0x17000246 RID: 582
			// (get) Token: 0x060010D2 RID: 4306 RVA: 0x000500D3 File Offset: 0x0004E2D3
			// (set) Token: 0x060010D3 RID: 4307 RVA: 0x000500DB File Offset: 0x0004E2DB
			public string Title { get; set; }

			// Token: 0x17000247 RID: 583
			// (get) Token: 0x060010D4 RID: 4308 RVA: 0x000500E4 File Offset: 0x0004E2E4
			// (set) Token: 0x060010D5 RID: 4309 RVA: 0x000500EC File Offset: 0x0004E2EC
			public string Icon { get; set; }

			// Token: 0x17000248 RID: 584
			// (get) Token: 0x060010D6 RID: 4310 RVA: 0x000500F5 File Offset: 0x0004E2F5
			// (set) Token: 0x060010D7 RID: 4311 RVA: 0x000500FD File Offset: 0x0004E2FD
			public Window Owner { get; set; }

			// Token: 0x17000249 RID: 585
			// (get) Token: 0x060010D8 RID: 4312 RVA: 0x00050106 File Offset: 0x0004E306
			// (set) Token: 0x060010D9 RID: 4313 RVA: 0x0005010E File Offset: 0x0004E30E
			public bool DisableMinimize { get; set; }

			// Token: 0x1700024A RID: 586
			// (get) Token: 0x060010DA RID: 4314 RVA: 0x00050117 File Offset: 0x0004E317
			// (set) Token: 0x060010DB RID: 4315 RVA: 0x0005011F File Offset: 0x0004E31F
			public ResizeMode ResizeMode { get; set; }

			// Token: 0x1700024B RID: 587
			// (get) Token: 0x060010DC RID: 4316 RVA: 0x00050128 File Offset: 0x0004E328
			// (set) Token: 0x060010DD RID: 4317 RVA: 0x00050130 File Offset: 0x0004E330
			public int? InitialWidth { get; set; }

			// Token: 0x1700024C RID: 588
			// (get) Token: 0x060010DE RID: 4318 RVA: 0x00050139 File Offset: 0x0004E339
			// (set) Token: 0x060010DF RID: 4319 RVA: 0x00050141 File Offset: 0x0004E341
			public int? InitialHeight { get; set; }

			// Token: 0x1700024D RID: 589
			// (get) Token: 0x060010E0 RID: 4320 RVA: 0x0005014A File Offset: 0x0004E34A
			// (set) Token: 0x060010E1 RID: 4321 RVA: 0x00050152 File Offset: 0x0004E352
			public SizeToContent SizeToContent { get; set; } = SizeToContent.WidthAndHeight;
		}
	}
}
