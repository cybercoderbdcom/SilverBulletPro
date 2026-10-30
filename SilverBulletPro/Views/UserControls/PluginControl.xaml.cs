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
using SilverBulletPro.Core.Configuration;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Plugins;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x02000039 RID: 57
	public partial class PluginControl : UserControl
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000295 RID: 661 RVA: 0x00011714 File Offset: 0x0000F914
		// (set) Token: 0x06000296 RID: 662 RVA: 0x0001171C File Offset: 0x0000F91C
		public IPlugin Plugin { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000297 RID: 663 RVA: 0x00011725 File Offset: 0x0000F925
		// (set) Token: 0x06000298 RID: 664 RVA: 0x0001172D File Offset: 0x0000F92D
		public ObservableCollection<UserControl> Controls { get; set; } = new ObservableCollection<UserControl>();

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00011736 File Offset: 0x0000F936
		// (set) Token: 0x0600029A RID: 666 RVA: 0x0001173E File Offset: 0x0000F93E
		private List<PropertyInfo> ValidProperties { get; set; } = new List<PropertyInfo>();

		// Token: 0x0600029B RID: 667 RVA: 0x00011748 File Offset: 0x0000F948
		public PluginControl(Type type, IApplication app, bool supportsPropertyChanged = false)
		{
			this.InitializeComponent();
			base.DataContext = this;
			object[] args = new object[0];
			if (type.GetConstructors().Any((ConstructorInfo c) => c.GetParameters().Any((ParameterInfo p) => p.ParameterType == typeof(IApplication))))
			{
				args = new object[]
				{
					app
				};
			}
			this.Plugin = (Activator.CreateInstance(type, args) as IPlugin);
			foreach (PropertyInfo propertyInfo in from p in type.GetProperties()
			where Check.InputProperty(p)
			select p)
			{
				this.ValidProperties.Add(propertyInfo);
				this.Controls.Add(Build.InputField(this.Plugin, propertyInfo, supportsPropertyChanged ? (this.Plugin as ViewModelBase) : null, null));
			}
			foreach (MethodInfo method in from m in type.GetMethods()
			where Check.Method(this.Plugin, m)
			select m)
			{
				this.Controls.Add(Build.Button(method, this));
			}
			try
			{
				InfoText customAttribute = type.GetCustomAttribute<InfoText>();
				if (customAttribute != null)
				{
					this.Controls.Add(new UserControlInfoText(customAttribute.Label, customAttribute, supportsPropertyChanged ? (this.Plugin as ViewModelBase) : null, null)
					{
						ToolTip = (string.IsNullOrEmpty(customAttribute.Tooltip) ? null : customAttribute.Tooltip)
					});
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00011924 File Offset: 0x0000FB24
		public void RunMethod(string methodName)
		{
			using (List<PropertyInfo>.Enumerator enumerator = this.ValidProperties.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PropertyInfo property = enumerator.Current;
					if (PluginControl.<>o__13.<>p__0 == null)
					{
						PluginControl.<>o__13.<>p__0 = CallSite<Action<CallSite, PropertyInfo, IPlugin, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetValue", null, typeof(PluginControl), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					PluginControl.<>o__13.<>p__0.Target(PluginControl.<>o__13.<>p__0, property, this.Plugin, (from c in this.Controls
					where c is UserControlContainer
					select c as UserControlContainer).First((UserControlContainer c) => c.PropertyName == property.Name).GetValue());
				}
			}
			MethodInfo method = this.Plugin.GetType().GetMethod(methodName);
			ParameterInfo[] parameters = method.GetParameters();
			object[] parameters2 = new object[0];
			if (parameters.Length == 1 && parameters.First<ParameterInfo>().ParameterType == typeof(IApplication))
			{
				parameters2 = new object[]
				{
					GlobalData.App
				};
			}
			method.Invoke(this.Plugin, parameters2);
		}
	}
}
