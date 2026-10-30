using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.Runners;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.ViewModels;

namespace SilverBulletPro
{
	// Token: 0x02000021 RID: 33
	public class DialogCustomInput : Page, IComponentConnector
	{
		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000123 RID: 291 RVA: 0x0000A343 File Offset: 0x00008543
		// (set) Token: 0x06000124 RID: 292 RVA: 0x0000A34B File Offset: 0x0000854B
		private object Caller { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000125 RID: 293 RVA: 0x0000A354 File Offset: 0x00008554
		// (set) Token: 0x06000126 RID: 294 RVA: 0x0000A35C File Offset: 0x0000855C
		private string VariableName { get; set; }

		// Token: 0x06000127 RID: 295 RVA: 0x0000A368 File Offset: 0x00008568
		public DialogCustomInput(object caller, CustomInput input)
		{
			this.InitializeComponent();
			this.Caller = caller;
			this.VariableName = input.VariableName;
			this.questionLabel.Content = input.Description;
			if (input.Description.Length >= 57)
			{
				this.questionLabel.ToolTip = input.Description;
			}
			this.answerTextbox.Focus();
			if (!string.IsNullOrEmpty(input.DefaultAnswer))
			{
				this.answerTextbox.Text = input.DefaultAnswer;
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000A3F0 File Offset: 0x000085F0
		private void acceptButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.Caller.GetType() == typeof(StackerViewModel))
			{
				((StackerViewModel)this.Caller).BotData.Variables.Set(new CVar(this.VariableName, this.answerTextbox.Text, false, false));
			}
			else if (this.Caller.GetType() == typeof(RunnerViewModel))
			{
				((RunnerViewModel)this.Caller).CustomInputs.Add(new KeyValuePair<string, string>(this.VariableName, this.answerTextbox.Text));
			}
			((MainDialog)base.Parent).Close();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000A4A4 File Offset: 0x000086A4
		private void answerTextbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.acceptButton_Click(sender, null);
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000A4B8 File Offset: 0x000086B8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/dialogcustominput.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000A4E8 File Offset: 0x000086E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.questionLabel = (Label)target;
				return;
			case 2:
				this.answerTextbox = (TextBox)target;
				this.answerTextbox.KeyDown += this.answerTextbox_KeyDown;
				return;
			case 3:
				this.acceptButton = (Button)target;
				this.acceptButton.Click += this.acceptButton_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000091 RID: 145
		internal Label questionLabel;

		// Token: 0x04000092 RID: 146
		internal TextBox answerTextbox;

		// Token: 0x04000093 RID: 147
		internal Button acceptButton;

		// Token: 0x04000094 RID: 148
		private bool _contentLoaded;
	}
}
