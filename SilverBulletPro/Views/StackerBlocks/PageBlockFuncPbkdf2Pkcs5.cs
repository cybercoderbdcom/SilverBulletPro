using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Functions.Crypto;
using SilverBulletPro.Models;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000059 RID: 89
	public class PageBlockFuncPbkdf2Pkcs5 : Page, IComponentConnector
	{
		// Token: 0x060003B2 RID: 946 RVA: 0x00015D78 File Offset: 0x00013F78
		public PageBlockFuncPbkdf2Pkcs5(BlockPbkdf2Pkcs5 block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
			using (IEnumerator enumerator = Enum.GetValues(typeof(HashFunc)).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					HashFunc func = (HashFunc)enumerator.Current;
					if (typeof(HashAlgorithmName).GetProperties().Any((PropertyInfo p) => p.Name == func.ToString()))
					{
						this.typeBox.Items.Add(new HashFuncModel
						{
							HashFunc = func
						});
					}
				}
			}
			this.typeBox.SelectedItem = this.typeBox.Items.Cast<HashFuncModel>().FirstOrDefault((HashFuncModel f) => f.HashFunc == this.vm.TypeFunc);
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00015E6C File Offset: 0x0001406C
		private void TypeFuncBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.vm.TypeFunc = ((HashFuncModel)this.typeBox.SelectedItem).HashFunc;
			}
			catch
			{
			}
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00015EB0 File Offset: 0x000140B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfuncpbkdf2pkcs5.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00015EE0 File Offset: 0x000140E0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00015EEC File Offset: 0x000140EC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.outputVar = (VarCapOutputBox)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.typeBox = (ComboBox)target;
			this.typeBox.SelectionChanged += this.TypeFuncBox_SelectionChanged;
		}

		// Token: 0x040001D1 RID: 465
		private BlockPbkdf2Pkcs5 vm;

		// Token: 0x040001D2 RID: 466
		internal VarCapOutputBox outputVar;

		// Token: 0x040001D3 RID: 467
		internal ComboBox typeBox;

		// Token: 0x040001D4 RID: 468
		private bool _contentLoaded;
	}
}
