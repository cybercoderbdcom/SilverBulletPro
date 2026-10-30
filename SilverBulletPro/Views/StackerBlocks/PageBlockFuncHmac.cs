using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Functions.Crypto;
using SilverBulletPro.Models;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000056 RID: 86
	public class PageBlockFuncHmac : Page, IComponentConnector
	{
		// Token: 0x060003A4 RID: 932 RVA: 0x00015A38 File Offset: 0x00013C38
		public PageBlockFuncHmac(BlockHmac block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(HashFunc)))
			{
				HashFunc hashFunc = (HashFunc)obj;
				Type typeFromHandle = typeof(Crypto);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
				defaultInterpolatedStringHandler.AppendLiteral("HMAC");
				defaultInterpolatedStringHandler.AppendFormatted<HashFunc>(hashFunc);
				if (ReflectionExtension.HasStaticMethod(typeFromHandle, defaultInterpolatedStringHandler.ToStringAndClear()))
				{
					this.hashFuncBox.Items.Add(new HashFuncModel
					{
						HashFunc = hashFunc
					});
				}
			}
			this.hashFuncBox.SelectedItem = this.hashFuncBox.Items.Cast<HashFuncModel>().FirstOrDefault((HashFuncModel f) => f.HashFunc == this.vm.HashFunc);
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00015B30 File Offset: 0x00013D30
		private void HashFuncBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.vm.HashFunc = ((HashFuncModel)this.hashFuncBox.SelectedItem).HashFunc;
			}
			catch
			{
			}
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00015B74 File Offset: 0x00013D74
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfunchmac.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00015BA4 File Offset: 0x00013DA4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00015BB0 File Offset: 0x00013DB0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.outputVar = (VarCapOutputBox)target;
				return;
			case 2:
				this.inputControl = (TextInputBox)target;
				return;
			case 3:
				this.keyControl = (TextInputBox)target;
				return;
			case 4:
				this.hashFuncBox = (ComboBox)target;
				this.hashFuncBox.SelectionChanged += this.HashFuncBox_SelectionChanged;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040001C6 RID: 454
		private BlockHmac vm;

		// Token: 0x040001C7 RID: 455
		internal VarCapOutputBox outputVar;

		// Token: 0x040001C8 RID: 456
		internal TextInputBox inputControl;

		// Token: 0x040001C9 RID: 457
		internal TextInputBox keyControl;

		// Token: 0x040001CA RID: 458
		internal ComboBox hashFuncBox;

		// Token: 0x040001CB RID: 459
		private bool _contentLoaded;
	}
}
