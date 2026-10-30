using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using PluginFrameworkPro;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Plugins
{
	// Token: 0x020001E4 RID: 484
	public static class Loader
	{
		// Token: 0x06000F55 RID: 3925 RVA: 0x0004CF28 File Offset: 0x0004B128
		[return: TupleElementNames(new string[]
		{
			"PluginControl",
			"BlockPlugin"
		})]
		public static ValueTuple<IEnumerable<PluginControl>, IEnumerable<IBlockPlugin>> LoadPlugins(string folder)
		{
			List<PluginControl> list = new List<PluginControl>();
			List<IBlockPlugin> list2 = new List<IBlockPlugin>();
			foreach (string text in Directory.GetFiles(folder, "*.dll"))
			{
				Assembly assembly = Assembly.LoadFrom(text);
				string text2 = Path.Combine(Constants.PluginsFolder, Path.GetFileNameWithoutExtension(text));
				if (Directory.Exists(text2))
				{
					Loader.Hook(new string[]
					{
						text2
					});
				}
				Loader.LoadDependencies(assembly.GetReferencedAssemblies());
				foreach (Type type in assembly.GetTypes())
				{
					if (type.GetInterface("IPlugin") == typeof(IPlugin))
					{
						list.Add(new PluginControl(type, GlobalData.App, type.GetTypeInfo().IsSubclassOf(typeof(ViewModelBase))));
					}
					else if (type.GetInterface("IBlockPlugin") == typeof(IBlockPlugin) && type.GetTypeInfo().IsSubclassOf(typeof(BlockBase)))
					{
						list2.Add(Activator.CreateInstance(type) as IBlockPlugin);
					}
				}
			}
			return new ValueTuple<IEnumerable<PluginControl>, IEnumerable<IBlockPlugin>>(list, list2);
		}

		// Token: 0x06000F56 RID: 3926 RVA: 0x0004D068 File Offset: 0x0004B268
		public static void LoadDependencies(IEnumerable<AssemblyName> assemblies)
		{
			using (IEnumerator<AssemblyName> enumerator = assemblies.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					AssemblyName asm = enumerator.Current;
					if (!AppDomain.CurrentDomain.GetAssemblies().Any((Assembly a) => a.GetName().FullName == asm.FullName))
					{
						try
						{
							AppDomain.CurrentDomain.Load(asm);
							Loader.LoadDependencies(Assembly.Load(asm).GetReferencedAssemblies());
						}
						catch
						{
						}
					}
				}
			}
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x0004D108 File Offset: 0x0004B308
		public static void Hook(params string[] folders)
		{
			AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, [Nullable(1)] ResolveEventArgs args)
			{
				Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((Assembly a) => a.FullName == args.Name);
				if (assembly != null)
				{
					return assembly;
				}
				AssemblyName n = new AssemblyName(args.Name);
				if (n.Name.EndsWith(".xmlserializers", StringComparison.OrdinalIgnoreCase))
				{
					return null;
				}
				if (n.Name.EndsWith(".resources", StringComparison.OrdinalIgnoreCase))
				{
					return null;
				}
				string[] folders2 = folders;
				Func<string, bool> <>9__3;
				for (int i = 0; i < folders2.Length; i++)
				{
					string dir = folders2[i];
					IEnumerable<string> source = new string[]
					{
						"*.dll",
						"*.exe"
					}.SelectMany((string g) => Directory.EnumerateFiles(dir, g));
					Func<string, bool> predicate;
					if ((predicate = <>9__3) == null)
					{
						predicate = (<>9__3 = delegate(string f)
						{
							bool result;
							try
							{
								result = n.Name.Equals(AssemblyName.GetAssemblyName(f).Name, StringComparison.OrdinalIgnoreCase);
							}
							catch (BadImageFormatException)
							{
								result = false;
							}
							catch (Exception innerException)
							{
								throw new ApplicationException("Error loading assembly " + f, innerException);
							}
							return result;
						});
					}
					string text = source.FirstOrDefault(predicate);
					if (text != null)
					{
						return Assembly.LoadFrom(text);
					}
				}
				throw new ApplicationException("Assembly " + args.Name + " not found");
			};
		}
	}
}
