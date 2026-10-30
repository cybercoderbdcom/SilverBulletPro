using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;
using PluginFrameworkPro.Attributes;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Plugins
{
	// Token: 0x020001E1 RID: 481
	public static class Build
	{
		// Token: 0x06000F4D RID: 3917 RVA: 0x0004C7B4 File Offset: 0x0004A9B4
		public static UserControlContainer InputField(object plugin, PropertyInfo property, ViewModelBase viewModel = null, EventObject[] events = null)
		{
			InputField customAttribute = property.GetCustomAttribute<InputField>();
			object arg = Convert.ChangeType(property.GetValue(plugin), property.PropertyType);
			InfoText infoText = customAttribute as InfoText;
			IControl userControl;
			if (infoText == null)
			{
				Text text = customAttribute as Text;
				if (text == null)
				{
					Numeric numeric = customAttribute as Numeric;
					if (numeric == null)
					{
						CheckBox checkBox = customAttribute as CheckBox;
						if (checkBox == null)
						{
							TextMulti textMulti = customAttribute as TextMulti;
							if (textMulti == null)
							{
								FilePicker filePicker = customAttribute as FilePicker;
								if (filePicker == null)
								{
									DropDown dropDown = customAttribute as DropDown;
									if (dropDown == null)
									{
										WordlistPicker wordlistPicker = customAttribute as WordlistPicker;
										if (wordlistPicker == null)
										{
											ConfigPicker configPicker = customAttribute as ConfigPicker;
											if (configPicker == null)
											{
												throw new NotImplementedException();
											}
											userControl = new UserControlConfig(configPicker);
										}
										else
										{
											userControl = new UserControlWordlist(wordlistPicker);
										}
									}
									else
									{
										if (Build.<>o__0.<>p__6 == null)
										{
											Build.<>o__0.<>p__6 = CallSite<Func<CallSite, Type, object, DropDown, ViewModelBase, EventObject[], UserControlDropdown>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(Build), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
											}));
										}
										userControl = Build.<>o__0.<>p__6.Target(Build.<>o__0.<>p__6, typeof(UserControlDropdown), arg, dropDown, viewModel, events);
									}
								}
								else
								{
									if (Build.<>o__0.<>p__5 == null)
									{
										Build.<>o__0.<>p__5 = CallSite<Func<CallSite, Type, object, FilePicker, EventObject[], UserControlFilePicker>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(Build), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
										}));
									}
									userControl = Build.<>o__0.<>p__5.Target(Build.<>o__0.<>p__5, typeof(UserControlFilePicker), arg, filePicker, events);
								}
							}
							else
							{
								if (Build.<>o__0.<>p__4 == null)
								{
									Build.<>o__0.<>p__4 = CallSite<Func<CallSite, Type, object, TextMulti, ViewModelBase, EventObject[], UserControlTextMulti>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(Build), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
									}));
								}
								userControl = Build.<>o__0.<>p__4.Target(Build.<>o__0.<>p__4, typeof(UserControlTextMulti), arg, textMulti, viewModel, events);
							}
						}
						else
						{
							if (Build.<>o__0.<>p__3 == null)
							{
								Build.<>o__0.<>p__3 = CallSite<Func<CallSite, Type, object, CheckBox, ViewModelBase, EventObject[], UserControlCheckbox>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(Build), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
								}));
							}
							userControl = Build.<>o__0.<>p__3.Target(Build.<>o__0.<>p__3, typeof(UserControlCheckbox), arg, checkBox, viewModel, events);
						}
					}
					else
					{
						if (Build.<>o__0.<>p__2 == null)
						{
							Build.<>o__0.<>p__2 = CallSite<Func<CallSite, Type, object, Numeric, ViewModelBase, EventObject[], UserControlNumericPlug>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(Build), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
							}));
						}
						userControl = Build.<>o__0.<>p__2.Target(Build.<>o__0.<>p__2, typeof(UserControlNumericPlug), arg, numeric, viewModel, events);
					}
				}
				else
				{
					if (Build.<>o__0.<>p__1 == null)
					{
						Build.<>o__0.<>p__1 = CallSite<Func<CallSite, Type, object, Text, ViewModelBase, EventObject[], UserControlText>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(Build), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					userControl = Build.<>o__0.<>p__1.Target(Build.<>o__0.<>p__1, typeof(UserControlText), arg, text, viewModel, events);
				}
			}
			else
			{
				if (Build.<>o__0.<>p__0 == null)
				{
					Build.<>o__0.<>p__0 = CallSite<Func<CallSite, Type, object, InfoText, ViewModelBase, EventObject[], UserControlInfoText>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(Build), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				userControl = Build.<>o__0.<>p__0.Target(Build.<>o__0.<>p__0, typeof(UserControlInfoText), arg, infoText, viewModel, events);
			}
			return new UserControlContainer(property.Name, userControl, customAttribute);
		}

		// Token: 0x06000F4E RID: 3918 RVA: 0x0004CC0F File Offset: 0x0004AE0F
		public static ButtonContainer Button(MethodInfo method, PluginControl pluginControl)
		{
			return new ButtonContainer(method.GetCustomAttribute<Button>(), method.Name, pluginControl);
		}

		// Token: 0x06000F4F RID: 3919 RVA: 0x0004CC24 File Offset: 0x0004AE24
		internal static void SetEvents(EventObject[] events, Func<HandleEvent, object> funcTarget, string controlName = "")
		{
			if (events == null || events.Length == 0)
			{
				return;
			}
			for (int i = 0; i < events.Length; i++)
			{
				HandleEvent handleEvent = events[i].EventAttrib as HandleEvent;
				object obj = (funcTarget != null) ? funcTarget(handleEvent) : null;
				if (obj != null)
				{
					EventInfo @event = obj.GetType().GetEvent(handleEvent.EventName);
					if (@event == null)
					{
						GlobalData.Logger.Log(Components.Stacker, 2, "The " + handleEvent.EventName + " event was not found in control " + controlName, true, 0);
					}
					else
					{
						ReflectionExtension.AddEventHandler(@event, obj, events[i].Method);
					}
				}
			}
		}
	}
}
