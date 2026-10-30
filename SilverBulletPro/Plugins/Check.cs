using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using PluginFrameworkPro;
using PluginFrameworkPro.Attributes;
using SilverBulletPro.Core.Configuration;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.Plugins
{
	// Token: 0x020001E2 RID: 482
	public static class Check
	{
		// Token: 0x06000F50 RID: 3920 RVA: 0x0004CCB4 File Offset: 0x0004AEB4
		public static bool InputProperty(PropertyInfo property)
		{
			if (property.GetCustomAttributes().Count((Attribute a) => a is InputField) != 1)
			{
				return false;
			}
			InputField customAttribute = property.GetCustomAttribute<InputField>();
			if (!Check._requiredPropertyTypes.ContainsKey(customAttribute.GetType()))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Unknown attribute type ");
				defaultInterpolatedStringHandler.AppendFormatted<Type>(customAttribute.GetType());
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			Type type = Check._requiredPropertyTypes[customAttribute.GetType()];
			if (property.PropertyType != type)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 2);
				defaultInterpolatedStringHandler.AppendLiteral("The property ");
				defaultInterpolatedStringHandler.AppendFormatted(property.Name);
				defaultInterpolatedStringHandler.AppendLiteral(" must be of type ");
				defaultInterpolatedStringHandler.AppendFormatted<Type>(type);
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return true;
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x0004CDA0 File Offset: 0x0004AFA0
		public static bool Method(IPlugin plugin, MethodInfo method)
		{
			if (method.GetCustomAttributes().Count((Attribute a) => a is Button) != 1)
			{
				return false;
			}
			method.GetCustomAttribute<Button>();
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length > 1)
			{
				return false;
			}
			if (parameters.Length == 1)
			{
				if (!parameters.Any((ParameterInfo p) => p.ParameterType == typeof(IApplication)))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04000719 RID: 1817
		private static Dictionary<Type, Type> _requiredPropertyTypes = new Dictionary<Type, Type>
		{
			{
				typeof(InfoText),
				typeof(string)
			},
			{
				typeof(Text),
				typeof(string)
			},
			{
				typeof(Numeric),
				typeof(int)
			},
			{
				typeof(CheckBox),
				typeof(bool)
			},
			{
				typeof(TextMulti),
				typeof(string[])
			},
			{
				typeof(FilePicker),
				typeof(string)
			},
			{
				typeof(DropDown),
				typeof(string)
			},
			{
				typeof(WordlistPicker),
				typeof(Wordlist)
			},
			{
				typeof(ConfigPicker),
				typeof(ConfigViewModel)
			}
		};
	}
}
