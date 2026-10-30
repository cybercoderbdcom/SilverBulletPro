using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.CSharp.RuntimeBinder;
using PluginFrameworkPro;
using PluginFrameworkPro.Attributes;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Plugins;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000047 RID: 71
	public partial class BlockPluginPage : Page
	{
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600033F RID: 831 RVA: 0x00013D4B File Offset: 0x00011F4B
		// (set) Token: 0x06000340 RID: 832 RVA: 0x00013D53 File Offset: 0x00011F53
		public IBlockPlugin BlockPlugin { get; set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000341 RID: 833 RVA: 0x00013D5C File Offset: 0x00011F5C
		public BlockBase Block
		{
			get
			{
				return this.BlockPlugin as BlockBase;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000342 RID: 834 RVA: 0x00013D69 File Offset: 0x00011F69
		// (set) Token: 0x06000343 RID: 835 RVA: 0x00013D71 File Offset: 0x00011F71
		public ObservableCollection<UserControl> Controls { get; set; } = new ObservableCollection<UserControl>();

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000344 RID: 836 RVA: 0x00013D7A File Offset: 0x00011F7A
		// (set) Token: 0x06000345 RID: 837 RVA: 0x00013D82 File Offset: 0x00011F82
		private List<PropertyInfo> ValidProperties { get; set; } = new List<PropertyInfo>();

		// Token: 0x06000346 RID: 838 RVA: 0x00013D8C File Offset: 0x00011F8C
		public BlockPluginPage(IBlockPlugin blockPlugin)
		{
			this.InitializeComponent();
			base.DataContext = this;
			this.BlockPlugin = blockPlugin;
			MethodInfo[] methods = blockPlugin.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public);
			IEnumerable<EventObject> enumerable;
			if (methods == null)
			{
				enumerable = null;
			}
			else
			{
				IEnumerable<MethodInfo> enumerable2 = from m in methods
				where m.GetCustomAttribute<HandleEvent>() != null
				select m;
				if (enumerable2 == null)
				{
					enumerable = null;
				}
				else
				{
					enumerable = from m in enumerable2
					select new EventObject(m, m.GetCustomAttribute<HandleEvent>());
				}
			}
			IEnumerable<EventObject> enumerable3 = enumerable;
			using (IEnumerator<PropertyInfo> enumerator = (from p in this.BlockPlugin.GetType().GetProperties()
			where Check.InputProperty(p)
			select p).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PropertyInfo p = enumerator.Current;
					this.ValidProperties.Add(p);
					Collection<UserControl> controls = this.Controls;
					object blockPlugin2 = this.BlockPlugin;
					PropertyInfo p2 = p;
					ViewModelBase viewModel = null;
					EventObject[] events;
					if (enumerable3 == null)
					{
						events = null;
					}
					else
					{
						IEnumerable<EventObject> enumerable4 = from e in enumerable3
						where ((HandleEvent)e.EventAttrib).PropName == p.Name
						select e;
						events = ((enumerable4 != null) ? enumerable4.ToArray<EventObject>() : null);
					}
					controls.Add(Build.InputField(blockPlugin2, p2, viewModel, events));
				}
			}
			try
			{
				InfoText customAttribute = blockPlugin.GetType().GetCustomAttribute<InfoText>();
				if (customAttribute != null)
				{
					this.Controls.Add(new UserControlInfoText(customAttribute.Label, customAttribute, null, null)
					{
						ToolTip = (string.IsNullOrEmpty(customAttribute.Tooltip) ? null : customAttribute.Tooltip)
					});
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00013F48 File Offset: 0x00012148
		public void SetPropertyValues()
		{
			using (List<PropertyInfo>.Enumerator enumerator = this.ValidProperties.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PropertyInfo property = enumerator.Current;
					object value = (from c in this.Controls
					where c is UserControlContainer
					select c as UserControlContainer).First((UserControlContainer c) => c.PropertyName == property.Name).GetValue();
					if (ReflectionExtension.IsNumeric(property.PropertyType))
					{
						if (BlockPluginPage.<>o__15.<>p__1 == null)
						{
							BlockPluginPage.<>o__15.<>p__1 = CallSite<Action<CallSite, PropertyInfo, IBlockPlugin, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetValue", null, typeof(BlockPluginPage), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Action<CallSite, PropertyInfo, IBlockPlugin, object> target = BlockPluginPage.<>o__15.<>p__1.Target;
						CallSite <>p__ = BlockPluginPage.<>o__15.<>p__1;
						PropertyInfo property2 = property;
						IBlockPlugin blockPlugin = this.BlockPlugin;
						if (BlockPluginPage.<>o__15.<>p__0 == null)
						{
							BlockPluginPage.<>o__15.<>p__0 = CallSite<Func<CallSite, Type, object, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ChangeType", null, typeof(BlockPluginPage), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
							}));
						}
						target(<>p__, property2, blockPlugin, BlockPluginPage.<>o__15.<>p__0.Target(BlockPluginPage.<>o__15.<>p__0, typeof(Convert), value, property.PropertyType));
					}
					else
					{
						if (BlockPluginPage.<>o__15.<>p__2 == null)
						{
							BlockPluginPage.<>o__15.<>p__2 = CallSite<Action<CallSite, PropertyInfo, IBlockPlugin, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetValue", null, typeof(BlockPluginPage), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						BlockPluginPage.<>o__15.<>p__2.Target(BlockPluginPage.<>o__15.<>p__2, property, this.BlockPlugin, value);
					}
				}
			}
		}
	}
}
