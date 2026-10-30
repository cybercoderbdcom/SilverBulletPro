using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Navigation;
using HandyControl.Controls;
using HandyControl.Data;
using MahApps.Metro.IconPacks;
using PluginFrameworkPro;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Extensions;
using SilverBulletPro.Models;
using SilverBulletPro.Views.Main.Configs;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.Dialogs
{
	// Token: 0x020001A9 RID: 425
	public partial class DialogAddBlock : Page
	{
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000BE0 RID: 3040 RVA: 0x00040608 File Offset: 0x0003E808
		// (set) Token: 0x06000BE1 RID: 3041 RVA: 0x00040610 File Offset: 0x0003E810
		public object Caller { get; set; }

		// Token: 0x06000BE2 RID: 3042 RVA: 0x0004061C File Offset: 0x0003E81C
		public DialogAddBlock(object caller)
		{
			this.InitializeComponent();
			this.Caller = caller;
			try
			{
				if (!File.Exists(Constants.FavoriteBlocksFile))
				{
					File.Create(Constants.FavoriteBlocksFile);
				}
				this.ReadFavoriteBlocksFile();
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
			Task.Run(delegate()
			{
				DialogAddBlock.<<-ctor>b__11_0>d <<-ctor>b__11_0>d;
				<<-ctor>b__11_0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<-ctor>b__11_0>d.<>4__this = this;
				<<-ctor>b__11_0>d.<>1__state = -1;
				<<-ctor>b__11_0>d.<>t__builder.Start<DialogAddBlock.<<-ctor>b__11_0>d>(ref <<-ctor>b__11_0>d);
				return <<-ctor>b__11_0>d.<>t__builder.Task;
			}).ContinueWith(delegate(Task t)
			{
				t.Dispose();
			});
			Task.Run(delegate()
			{
				DialogAddBlock.<<-ctor>b__11_2>d <<-ctor>b__11_2>d;
				<<-ctor>b__11_2>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<-ctor>b__11_2>d.<>4__this = this;
				<<-ctor>b__11_2>d.<>1__state = -1;
				<<-ctor>b__11_2>d.<>t__builder.Start<DialogAddBlock.<<-ctor>b__11_2>d>(ref <<-ctor>b__11_2>d);
				return <<-ctor>b__11_2>d.<>t__builder.Task;
			}).ContinueWith(delegate(Task t)
			{
				t.Dispose();
			});
			Task.Run(delegate()
			{
				DialogAddBlock.<<-ctor>b__11_4>d <<-ctor>b__11_4>d;
				<<-ctor>b__11_4>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<-ctor>b__11_4>d.<>4__this = this;
				<<-ctor>b__11_4>d.<>1__state = -1;
				<<-ctor>b__11_4>d.<>t__builder.Start<DialogAddBlock.<<-ctor>b__11_4>d>(ref <<-ctor>b__11_4>d);
				return <<-ctor>b__11_4>d.<>t__builder.Task;
			}).ContinueWith(delegate(Task t)
			{
				t.Dispose();
			});
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x0004071C File Offset: 0x0003E91C
		private void AddPlugins()
		{
			if (GlobalData.BlockPlugins.Count <= 0)
			{
				this.tabItemPlugins.IsEnabled = false;
				return;
			}
			this.tabItemPlugins.IsEnabled = true;
			this.pluginPanel = new WrapPanel();
			this.NavigationFramePlugin.Content = this.pluginPanel;
			IBlockPlugin[] array = (from p in GlobalData.BlockPlugins
			where p.GetType().GetCustomAttribute<ObsoleteAttribute>() == null
			select p into plugin
			let blockAttrib = plugin.GetType().GetCustomAttribute<Block>()
			where blockAttrib != null
			orderby blockAttrib.Priority
			select plugin).ToArray<IBlockPlugin>();
			for (int i = 0; i < array.Length; i++)
			{
				IBlockPlugin plugin = array[i];
				Block customAttribute = plugin.GetType().GetCustomAttribute<Block>();
				if (customAttribute == null || string.IsNullOrWhiteSpace((customAttribute != null) ? customAttribute.Category : null))
				{
					BlockInfo info = ((BlockBase)plugin).Info;
					UserControlBlock userControlBlock = new UserControlBlock
					{
						Margin = new Thickness(5.0, 5.0, 3.0, 4.0),
						Width = 170.0,
						Height = 55.0,
						FontSize = 13.0,
						Background = plugin.Background.ToBrush(),
						Foreground = plugin.Foreground.ToBrush(),
						Text = customAttribute.Name,
						Tag = plugin.GetType(),
						Description = info.Description,
						Favorite = (this.favoriteBlocks != null && this.favoriteBlocks.Any((FavoriteBlock fb) => fb.Name == plugin.ToString())),
						FavoriteVisibility = Visibility.Visible,
						TextMargin = ((customAttribute.Name.Length >= 22) ? new Thickness(14.0, 0.0, 4.0, 0.0) : new Thickness(0.0)),
						DescriptionVisibility = ((!string.IsNullOrWhiteSpace(info.Description)) ? Visibility.Visible : Visibility.Collapsed)
					};
					if (customAttribute.Name.Length >= 22)
					{
						userControlBlock.TitleTextBlock.Width = 147.0;
					}
					userControlBlock.Click += delegate(object sender, RoutedEventArgs e)
					{
						this.SendBack(Activator.CreateInstance((sender as UserControlBlock).Tag as Type) as BlockBase);
					};
					userControlBlock.FavoriteChanged += delegate(object sender, bool e)
					{
						try
						{
							UserControlBlock currentBlock = null;
							if (e)
							{
								IBlockPlugin blockPlugin = Activator.CreateInstance((sender as UserControlBlock).Tag as Type) as IBlockPlugin;
								UIElementCollection children = this.favoritesPanel.Children;
								IBlockPlugin plugin = blockPlugin;
								Block customAttribute2 = blockPlugin.GetType().GetCustomAttribute<Block>();
								children.Add(this.CreatePluginBlock(plugin, (customAttribute2 != null) ? customAttribute2.Name : null, false));
								if ((currentBlock = this.GetBlocksFromPanel(this.pluginPanel).FirstOrDefault((UserControlBlock bp) => bp.Tag.ToString() == ((UserControlBlock)sender).Tag.ToString())) != null)
								{
									currentBlock.Favorite = e;
								}
							}
							else
							{
								if (((UserControlBlock)sender).Parent == this.favoritesPanel)
								{
									this.favoritesPanel.Children.RemoveAt(this.favoritesPanel.Children.IndexOf((UserControlBlock)sender));
								}
								else
								{
									currentBlock = (UserControlBlock)sender;
									this.favoritesPanel.Children.Remove(this.favoritesPanel.Children.OfType<UserControlBlock>().FirstOrDefault((UserControlBlock b) => b.Tag.ToString() == ((UserControlBlock)sender).Tag.ToString()));
								}
								if (currentBlock != null)
								{
									currentBlock.Favorite = e;
									if (currentBlock.Parent == this.panelRecentBlocks && (currentBlock = this.GetBlocksFromPanel(this.defaultPanel).FirstOrDefault((UserControlBlock bp) => bp.Tag.ToString() == ((UserControlBlock)sender).Tag.ToString())) != null)
									{
										currentBlock.Favorite = e;
									}
								}
								else if ((currentBlock = this.GetBlocksFromPanel(this.pluginPanel).FirstOrDefault((UserControlBlock bp) => bp.Tag.ToString() == ((UserControlBlock)sender).Tag.ToString())) != null)
								{
									currentBlock.Favorite = e;
								}
							}
							if ((currentBlock = this.panelRecentBlocks.Children.OfType<UserControlBlock>().FirstOrDefault((UserControlBlock b) => b.Tag.ToString() == (currentBlock ?? (sender as UserControlBlock)).Tag.ToString())) != null)
							{
								currentBlock.Favorite = e;
							}
						}
						catch
						{
						}
						try
						{
							this.tabItemFavorites.IsEnabled = (this.favoritesPanel.Children.Count > 0);
							if (!this.tabItemFavorites.IsEnabled && this.tabControl.SelectedIndex == 2)
							{
								this.tabControl.SelectedIndex = -1;
							}
						}
						catch
						{
						}
					};
					this.pluginPanel.Children.Add(userControlBlock);
				}
				else
				{
					this.CreatePluginBlocks(plugin);
				}
			}
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x00040A44 File Offset: 0x0003EC44
		private void AddBlocks()
		{
			this.defaultPanel = new WrapPanel();
			this.NavigationFrame.Content = this.defaultPanel;
			Type[] array = (from <>h__TransparentIdentifier0 in (from s in GlobalData.BlockMappings
			where s.Block.GetCustomAttribute<ObsoleteAttribute>() == null
			select s into b
			select new
			{
				b = b,
				attrib = b.Block.GetCustomAttribute<Block>()
			}).Where(delegate(<>h__TransparentIdentifier0)
			{
				if (<>h__TransparentIdentifier0.attrib != null)
				{
					return !<>h__TransparentIdentifier0.b.Block.GetInterfaces().Any((Type bp) => bp == typeof(IBlockPlugin));
				}
				return false;
			})
			orderby <>h__TransparentIdentifier0.attrib.Priority
			select <>h__TransparentIdentifier0.b.Block).ToArray<Type>();
			for (int i = 0; i < array.Length; i++)
			{
				this.CreateBlocks(array[i]);
			}
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x00040B44 File Offset: 0x0003ED44
		private void AddFavorites()
		{
			this.favoritesPanel = new WrapPanel();
			this.NavigationFrameFavorites.Content = this.favoritesPanel;
			FavoriteBlock[] array = this.favoriteBlocks;
			if (array != null && array.Length == 0)
			{
				this.tabItemFavorites.IsEnabled = false;
				return;
			}
			this.tabItemFavorites.IsEnabled = true;
			for (int i = 0; i < this.favoriteBlocks.Length; i++)
			{
				FavoriteBlock fb = this.favoriteBlocks[i];
				if (fb.Name.StartsWith("SilverBulletPro.Plugin"))
				{
					IBlockPlugin blockPlugin = GlobalData.BlockPlugins.FirstOrDefault((IBlockPlugin b) => b.ToString() == fb.ToString());
					if (blockPlugin != null)
					{
						UIElementCollection children = this.favoritesPanel.Children;
						IBlockPlugin plugin = blockPlugin;
						Block customAttribute = blockPlugin.GetType().GetCustomAttribute<Block>();
						children.Add(this.CreatePluginBlock(plugin, (customAttribute != null) ? customAttribute.Name : null, false));
					}
				}
				else
				{
					SilverBlock silverBlock = GlobalData.BlockMappings.FirstOrDefault((SilverBlock b) => b.Block.ToString() == fb.ToString());
					Type type = (silverBlock != null) ? silverBlock.Block : null;
					if (type != null)
					{
						this.favoritesPanel.Children.Add(this.CreateBlock(type, false));
					}
				}
			}
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x00040C68 File Offset: 0x0003EE68
		private void CreateBlocks(Type block)
		{
			DialogAddBlock.<>c__DisplayClass15_0 CS$<>8__locals1 = new DialogAddBlock.<>c__DisplayClass15_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.block = block;
			CS$<>8__locals1.attrib = CS$<>8__locals1.block.GetCustomAttribute<Block>();
			if (string.IsNullOrWhiteSpace(CS$<>8__locals1.attrib.Category))
			{
				this.defaultPanel.Children.Add(this.CreateBlock(CS$<>8__locals1.block, false));
				return;
			}
			if (!CS$<>8__locals1.attrib.Category.Contains(">"))
			{
				CS$<>8__locals1.category = new string[]
				{
					CS$<>8__locals1.attrib.Category
				};
			}
			else
			{
				CS$<>8__locals1.category = (from c in CS$<>8__locals1.attrib.Category.Split('>', StringSplitOptions.RemoveEmptyEntries)
				select c.Trim()).ToArray<string>();
			}
			DialogAddBlock.<>c__DisplayClass15_1 CS$<>8__locals2;
			CS$<>8__locals2.b = 0;
			while (CS$<>8__locals2.b < CS$<>8__locals1.category.Length)
			{
				IEnumerable<UserControlBlock> source = this.defaultPanel.FindVisualChildren<UserControlBlock>();
				Func<UserControlBlock, bool> predicate;
				if ((predicate = CS$<>8__locals1.<>9__1) == null)
				{
					predicate = (CS$<>8__locals1.<>9__1 = ((UserControlBlock b) => b.Text == CS$<>8__locals1.category[0]));
				}
				DialogAddBlock.<>c__DisplayClass15_2 CS$<>8__locals3;
				CS$<>8__locals3.subBlock = source.FirstOrDefault(predicate);
				if (CS$<>8__locals3.subBlock == null)
				{
					CS$<>8__locals3.subBlock = this.CreateSubBlock(CS$<>8__locals1.category[0], StringExtension.TrySplit(CS$<>8__locals1.attrib.BackColor, ">", 0, StringSplitOptions.RemoveEmptyEntries, null).Trim().ToBrush(), StringExtension.TrySplit(CS$<>8__locals1.attrib.ForeColor, ">", 0, StringSplitOptions.RemoveEmptyEntries, null).Trim().ToBrush(), this.NavigationFrame);
					this.defaultPanel.Children.Add(CS$<>8__locals3.subBlock);
					CS$<>8__locals1.<CreateBlocks>g__CreateCategoryOrBlock|2(false, ref CS$<>8__locals2, ref CS$<>8__locals3);
				}
				else if (CS$<>8__locals2.b == 0)
				{
					if (CS$<>8__locals2.b == CS$<>8__locals1.category.Length - 1)
					{
						CS$<>8__locals3.subBlock.Subset.Children.Add(this.CreateBlock(CS$<>8__locals1.block, false));
						return;
					}
				}
				else
				{
					CS$<>8__locals1.<CreateBlocks>g__CreateCategoryOrBlock|2(true, ref CS$<>8__locals2, ref CS$<>8__locals3);
				}
				int b2 = CS$<>8__locals2.b;
				CS$<>8__locals2.b = b2 + 1;
			}
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x00040E80 File Offset: 0x0003F080
		private void CreatePluginBlocks(IBlockPlugin block)
		{
			DialogAddBlock.<>c__DisplayClass16_0 CS$<>8__locals1 = new DialogAddBlock.<>c__DisplayClass16_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.block = block;
			CS$<>8__locals1.attrib = CS$<>8__locals1.block.GetType().GetCustomAttribute<Block>();
			if (string.IsNullOrWhiteSpace(CS$<>8__locals1.attrib.Category))
			{
				this.pluginPanel.Children.Add(this.CreatePluginBlock(CS$<>8__locals1.block, CS$<>8__locals1.attrib.Name, false));
				return;
			}
			if (!CS$<>8__locals1.attrib.Category.Contains(">"))
			{
				CS$<>8__locals1.category = new string[]
				{
					CS$<>8__locals1.attrib.Category
				};
			}
			else
			{
				CS$<>8__locals1.category = (from c in CS$<>8__locals1.attrib.Category.Split('>', StringSplitOptions.RemoveEmptyEntries)
				select c.Trim()).ToArray<string>();
			}
			DialogAddBlock.<>c__DisplayClass16_1 CS$<>8__locals2;
			CS$<>8__locals2.j = 0;
			while (CS$<>8__locals2.j < CS$<>8__locals1.category.Length)
			{
				IEnumerable<UserControlBlock> source = this.pluginPanel.FindVisualChildren<UserControlBlock>();
				Func<UserControlBlock, bool> predicate;
				if ((predicate = CS$<>8__locals1.<>9__1) == null)
				{
					predicate = (CS$<>8__locals1.<>9__1 = ((UserControlBlock b) => b.Text == CS$<>8__locals1.category[0]));
				}
				DialogAddBlock.<>c__DisplayClass16_2 CS$<>8__locals3;
				CS$<>8__locals3.subBlock = source.FirstOrDefault(predicate);
				if (CS$<>8__locals3.subBlock == null)
				{
					CS$<>8__locals3.subBlock = this.CreateSubBlock(CS$<>8__locals1.category[0], StringExtension.TrySplit(CS$<>8__locals1.attrib.BackColor, ">", 0, StringSplitOptions.RemoveEmptyEntries, null).Trim().ToBrush(), StringExtension.TrySplit(CS$<>8__locals1.attrib.ForeColor, ">", 0, StringSplitOptions.RemoveEmptyEntries, null).Trim().ToBrush(), this.NavigationFramePlugin);
					this.pluginPanel.Children.Add(CS$<>8__locals3.subBlock);
					CS$<>8__locals1.<CreatePluginBlocks>g__CreateCategoryOrBlock|2(false, ref CS$<>8__locals2, ref CS$<>8__locals3);
				}
				else if (CS$<>8__locals2.j == 0)
				{
					if (CS$<>8__locals2.j == CS$<>8__locals1.category.Length - 1)
					{
						CS$<>8__locals3.subBlock.Subset.Children.Add(this.CreatePluginBlock(CS$<>8__locals1.block, CS$<>8__locals1.attrib.Name, false));
						return;
					}
				}
				else
				{
					CS$<>8__locals1.<CreatePluginBlocks>g__CreateCategoryOrBlock|2(false, ref CS$<>8__locals2, ref CS$<>8__locals3);
				}
				int j = CS$<>8__locals2.j;
				CS$<>8__locals2.j = j + 1;
			}
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x000410B4 File Offset: 0x0003F2B4
		private UserControlBlock CreateBlock(Type blockType, bool favorite = false)
		{
			Block customAttribute = blockType.GetCustomAttribute<Block>();
			SilverBlock silverBlock = GlobalData.BlockMappings.First((SilverBlock b) => b.Block == blockType);
			BlockBase blockInstance = (BlockBase)Activator.CreateInstance(silverBlock.Block);
			BlockInfo blockInfo = (silverBlock.Info == null) ? blockInstance.Info : silverBlock.Info;
			UserControlBlock userControlBlock = new UserControlBlock
			{
				Text = customAttribute.Name,
				Margin = new Thickness(5.0, 5.0, 3.0, 4.0),
				Width = 170.0,
				Height = 55.0,
				FontSize = 13.0,
				Foreground = silverBlock.Foreground.ToBrush(),
				Background = silverBlock.Backrgound.ToBrush(),
				Tag = blockInstance,
				Description = blockInfo.Description,
				FavoriteVisibility = Visibility.Visible,
				FullInfo = blockInfo.ToString(),
				Favorite = ((this.favoriteBlocks != null && this.favoriteBlocks.Any((FavoriteBlock fb) => fb.Name == blockInstance.ToString())) || favorite),
				TextMargin = ((customAttribute.Name.Length >= 22) ? new Thickness(14.0, 0.0, 4.0, 0.0) : new Thickness(0.0)),
				DescriptionVisibility = ((!string.IsNullOrWhiteSpace(blockInfo.Description)) ? Visibility.Visible : Visibility.Collapsed)
			};
			if (customAttribute.Name.Length >= 22)
			{
				userControlBlock.TitleTextBlock.Width = 147.0;
			}
			userControlBlock.Click += delegate(object sender, RoutedEventArgs e)
			{
				this.SendBack((sender as UserControlBlock).Tag as BlockBase);
			};
			userControlBlock.FavoriteChanged += delegate(object sender, bool e)
			{
				try
				{
					UserControlBlock currentBlock = null;
					if (e)
					{
						this.favoritesPanel.Children.Add(this.CreateBlock(((BlockBase)((UserControlBlock)sender).Tag).GetType(), e));
						if ((currentBlock = this.GetBlocksFromPanel(this.defaultPanel).FirstOrDefault((UserControlBlock bp) => bp.Tag.ToString() == ((UserControlBlock)sender).Tag.ToString())) != null)
						{
							currentBlock.Favorite = e;
						}
					}
					else
					{
						if (((UserControlBlock)sender).Parent == this.favoritesPanel)
						{
							this.favoritesPanel.Children.RemoveAt(this.favoritesPanel.Children.IndexOf((UserControlBlock)sender));
						}
						else
						{
							currentBlock = (UserControlBlock)sender;
							this.favoritesPanel.Children.Remove(this.favoritesPanel.Children.OfType<UserControlBlock>().FirstOrDefault((UserControlBlock b) => b.Tag.ToString() == ((UserControlBlock)sender).Tag.ToString()));
						}
						if (currentBlock != null)
						{
							currentBlock.Favorite = e;
							if (currentBlock.Parent == this.panelRecentBlocks && (currentBlock = this.GetBlocksFromPanel(this.defaultPanel).FirstOrDefault((UserControlBlock bp) => bp.Tag.ToString() == ((UserControlBlock)sender).Tag.ToString())) != null)
							{
								currentBlock.Favorite = e;
							}
						}
						else if ((currentBlock = this.GetBlocksFromPanel(this.defaultPanel).FirstOrDefault((UserControlBlock bp) => bp.Tag.ToString() == ((UserControlBlock)sender).Tag.ToString())) != null)
						{
							currentBlock.Favorite = e;
						}
					}
					if ((currentBlock = this.panelRecentBlocks.Children.OfType<UserControlBlock>().FirstOrDefault((UserControlBlock b) => b.Tag.ToString() == (currentBlock ?? (sender as UserControlBlock)).Tag.ToString())) != null)
					{
						currentBlock.Favorite = e;
					}
				}
				catch
				{
				}
				try
				{
					this.tabItemFavorites.IsEnabled = (this.favoritesPanel.Children.Count > 0);
					if (!this.tabItemFavorites.IsEnabled && this.tabControl.SelectedIndex == 2)
					{
						this.tabControl.SelectedIndex = -1;
					}
				}
				catch
				{
				}
			};
			return userControlBlock;
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x000412C4 File Offset: 0x0003F4C4
		private UserControlBlock CreateSubBlock(string name, Brush background, Brush foreground, Frame navigationFrame)
		{
			UserControlBlock userControlBlock = new UserControlBlock();
			userControlBlock.Text = name;
			userControlBlock.Margin = new Thickness(5.0, 7.0, 3.0, 2.0);
			userControlBlock.Width = 170.0;
			userControlBlock.Height = 47.0;
			userControlBlock.FontSize = 15.0;
			userControlBlock.Foreground = foreground;
			userControlBlock.Background = background;
			userControlBlock.Subset = new WrapPanel();
			userControlBlock.Click += delegate(object sender, RoutedEventArgs e)
			{
				navigationFrame.Content = (sender as UserControlBlock).Subset;
			};
			return userControlBlock;
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x00041374 File Offset: 0x0003F574
		private UserControlBlock CreatePluginBlock(IBlockPlugin plugin, string name = "", bool favorite = false)
		{
			BlockInfo info = ((BlockBase)plugin).Info;
			int length = (string.IsNullOrEmpty(name) ? plugin.Name : name).Length;
			UserControlBlock userControlBlock = new UserControlBlock
			{
				Margin = new Thickness(5.0, 5.0, 3.0, 4.0),
				Width = 170.0,
				Height = 55.0,
				FontSize = 13.0,
				Background = plugin.Background.ToBrush(),
				Foreground = plugin.Foreground.ToBrush(),
				Text = (string.IsNullOrEmpty(name) ? plugin.Name : name),
				Tag = plugin.GetType(),
				Description = info.Description,
				FavoriteVisibility = Visibility.Visible,
				FullInfo = info.ToString(),
				Favorite = ((this.favoriteBlocks != null && this.favoriteBlocks.Any((FavoriteBlock fb) => fb.Name == plugin.ToString())) || favorite),
				TextMargin = ((length >= 22) ? new Thickness(14.0, 0.0, 4.0, 0.0) : new Thickness(0.0)),
				DescriptionVisibility = ((!string.IsNullOrWhiteSpace(info.Description)) ? Visibility.Visible : Visibility.Collapsed)
			};
			if (length >= 23)
			{
				userControlBlock.TitleTextBlock.Width = 147.0;
			}
			userControlBlock.Click += delegate(object sender, RoutedEventArgs e)
			{
				this.SendBack(Activator.CreateInstance((sender as UserControlBlock).Tag as Type) as BlockBase);
			};
			userControlBlock.FavoriteChanged += delegate(object sender, bool e)
			{
				try
				{
					UserControlBlock currentBlock = null;
					if (e)
					{
						IBlockPlugin blockPlugin = Activator.CreateInstance((sender as UserControlBlock).Tag as Type) as IBlockPlugin;
						UIElementCollection children = this.favoritesPanel.Children;
						DialogAddBlock <>4__this = this;
						IBlockPlugin plugin2 = blockPlugin;
						Block customAttribute = blockPlugin.GetType().GetCustomAttribute<Block>();
						children.Add(<>4__this.CreatePluginBlock(plugin2, (customAttribute != null) ? customAttribute.Name : null, e));
						if ((currentBlock = this.GetBlocksFromPanel(this.pluginPanel).FirstOrDefault((UserControlBlock bp) => bp.Tag.ToString() == ((UserControlBlock)sender).Tag.ToString())) != null)
						{
							currentBlock.Favorite = e;
						}
					}
					else
					{
						if (((UserControlBlock)sender).Parent == this.favoritesPanel)
						{
							this.favoritesPanel.Children.RemoveAt(this.favoritesPanel.Children.IndexOf((UserControlBlock)sender));
						}
						else
						{
							currentBlock = (UserControlBlock)sender;
							this.favoritesPanel.Children.Remove(this.favoritesPanel.Children.OfType<UserControlBlock>().FirstOrDefault((UserControlBlock b) => b.Tag.ToString() == ((UserControlBlock)sender).Tag.ToString()));
						}
						if (currentBlock != null)
						{
							currentBlock.Favorite = e;
							if (currentBlock.Parent == this.panelRecentBlocks && (currentBlock = this.GetBlocksFromPanel(this.defaultPanel).FirstOrDefault((UserControlBlock bp) => bp.Tag.ToString() == ((UserControlBlock)sender).Tag.ToString())) != null)
							{
								currentBlock.Favorite = e;
							}
						}
						else if ((currentBlock = this.GetBlocksFromPanel(this.pluginPanel).FirstOrDefault((UserControlBlock bp) => bp.Tag.ToString() == ((UserControlBlock)sender).Tag.ToString())) != null)
						{
							currentBlock.Favorite = e;
						}
					}
					if ((currentBlock = this.panelRecentBlocks.Children.OfType<UserControlBlock>().FirstOrDefault((UserControlBlock b) => b.Tag.ToString() == (currentBlock ?? (sender as UserControlBlock)).Tag.ToString())) != null)
					{
						currentBlock.Favorite = e;
					}
				}
				catch
				{
				}
				try
				{
					this.tabItemFavorites.IsEnabled = (this.favoritesPanel.Children.Count > 0);
					if (!this.tabItemFavorites.IsEnabled && this.tabControl.SelectedIndex == 2)
					{
						this.tabControl.SelectedIndex = -1;
					}
				}
				catch
				{
				}
			};
			return userControlBlock;
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x0004155F File Offset: 0x0003F75F
		private IEnumerable<UserControlBlock> GetBlocksFromPanel(WrapPanel panel)
		{
			foreach (UserControlBlock userControlBlock in panel.Children.OfType<UserControlBlock>())
			{
				if (userControlBlock.Subset != null)
				{
					foreach (UserControlBlock userControlBlock2 in this.GetBlocksFromPanel(userControlBlock.Subset))
					{
						yield return userControlBlock2;
					}
					IEnumerator<UserControlBlock> enumerator2 = null;
				}
				else
				{
					yield return userControlBlock;
				}
			}
			IEnumerator<UserControlBlock> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x00041578 File Offset: 0x0003F778
		private void SendBack(BlockBase block)
		{
			if (this.Caller.GetType() == typeof(Stacker))
			{
				((Stacker)this.Caller).AddBlock(block);
				try
				{
					this.AddRecentBlock(block);
				}
				catch (Exception ex)
				{
					Alert.Exception(ex, "");
				}
			}
			((MainDialog)base.Parent).Close();
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x000415E8 File Offset: 0x0003F7E8
		private void AddRecentBlock(BlockBase block)
		{
			BlockBase blockBase = DialogAddBlock.recentBlocks.FirstOrDefault((BlockBase b) => ((b != null) ? b.GetType() : null) == block.GetType());
			if (DialogAddBlock.recentBlocks.Count > 2)
			{
				if (blockBase != null)
				{
					DialogAddBlock.recentBlocks.Remove(blockBase);
				}
				else
				{
					DialogAddBlock.recentBlocks.RemoveAt(DialogAddBlock.recentBlocks.Count - 1);
				}
			}
			else if (blockBase != null)
			{
				DialogAddBlock.recentBlocks.Remove(blockBase);
			}
			DialogAddBlock.recentBlocks.Insert(0, block);
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x00041670 File Offset: 0x0003F870
		private void Frame_Navigating(object sender, NavigatingCancelEventArgs e)
		{
			try
			{
				if (e.NavigationMode == NavigationMode.Forward)
				{
					e.Cancel = true;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x000416A4 File Offset: 0x0003F8A4
		private Assembly GetCoreLib()
		{
			return Assembly.Load(Assembly.GetEntryAssembly().GetReferencedAssemblies().FirstOrDefault((AssemblyName a) => a.Name == "SilverBulletPro.Core"));
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x000416DC File Offset: 0x0003F8DC
		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (this.tabControl.SelectedIndex == 0)
				{
					this.browseBack.SetBinding(ButtonBase.CommandTargetProperty, new Binding
					{
						ElementName = "NavigationFrame"
					});
					this.browseBack.SetBinding(UIElement.IsEnabledProperty, new Binding("CanGoBack")
					{
						ElementName = "NavigationFrame"
					});
				}
				else
				{
					this.browseBack.SetBinding(ButtonBase.CommandTargetProperty, new Binding
					{
						ElementName = "NavigationFramePlugin"
					});
					this.browseBack.SetBinding(UIElement.IsEnabledProperty, new Binding("CanGoBack")
					{
						ElementName = "NavigationFramePlugin"
					});
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x0004179C File Offset: 0x0003F99C
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (DialogAddBlock.recentBlocks.Count > 0)
			{
				this.gridRecentBlocks.Visibility = Visibility.Visible;
			}
			else
			{
				this.gridRecentBlocks.Visibility = Visibility.Collapsed;
			}
			foreach (BlockBase blockBase in DialogAddBlock.recentBlocks)
			{
				if (blockBase != null)
				{
					try
					{
						ContextMenu contextMenu = new ContextMenu();
						MenuItem menuItem = new MenuItem
						{
							Header = "Remove",
							Icon = new PackIconIonicons
							{
								Kind = 161
							},
							Tag = blockBase
						};
						menuItem.Click += delegate(object s, RoutedEventArgs e)
						{
							try
							{
								int index = DialogAddBlock.recentBlocks.IndexOf(((MenuItem)s).Tag as BlockBase);
								DialogAddBlock.recentBlocks.RemoveAt(index);
								this.panelRecentBlocks.Children.RemoveAt(index);
								if (this.panelRecentBlocks.Children.Count == 0)
								{
									this.gridRecentBlocks.Visibility = Visibility.Collapsed;
								}
							}
							catch
							{
							}
						};
						contextMenu.Items.Add(menuItem);
						IBlockPlugin blockPlugin = blockBase as IBlockPlugin;
						if (blockPlugin != null)
						{
							UserControlBlock userControlBlock = this.CreatePluginBlock(blockPlugin, blockPlugin.GetType().GetCustomAttribute<Block>().Name, false);
							userControlBlock.ContextMenu = contextMenu;
							this.panelRecentBlocks.Children.Add(userControlBlock);
						}
						else
						{
							UserControlBlock userControlBlock2 = this.CreateBlock(blockBase.GetType(), false);
							userControlBlock2.ContextMenu = contextMenu;
							this.panelRecentBlocks.Children.Add(userControlBlock2);
						}
					}
					catch
					{
					}
				}
			}
			try
			{
				((MainDialog)base.Parent).KeyDown += this.Page_KeyDown;
			}
			catch
			{
			}
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x0004191C File Offset: 0x0003FB1C
		private void SearchBar_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Key == Key.Return)
				{
					SearchBar searchBar = sender as SearchBar;
					if (string.IsNullOrEmpty(searchBar.Text))
					{
						if (this.tabControl.SelectedIndex == 0)
						{
							this.NavigationFrame.Content = this.defaultPanel;
							this.defaultSearchPanel.Children.Clear();
						}
						else
						{
							this.NavigationFramePlugin.Content = this.pluginPanel;
							this.pluginSearchPanel.Children.Clear();
						}
					}
					else if (this.tabControl.SelectedIndex == 0)
					{
						this.SearchBlockMapping(searchBar.Text);
					}
					else
					{
						this.SearchBlockPlugins(searchBar.Text);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x000419D8 File Offset: 0x0003FBD8
		private void SearchBar_SearchStarted(object sender, FunctionEventArgs<string> e)
		{
			try
			{
				SearchBar searchBar = sender as SearchBar;
				if (string.IsNullOrEmpty(searchBar.Text))
				{
					if (this.tabControl.SelectedIndex == 0)
					{
						this.NavigationFrame.Content = this.defaultPanel;
						WrapPanel wrapPanel = this.defaultSearchPanel;
						if (wrapPanel != null)
						{
							wrapPanel.Children.Clear();
						}
					}
					else
					{
						this.NavigationFramePlugin.Content = this.pluginPanel;
						WrapPanel wrapPanel2 = this.pluginSearchPanel;
						if (wrapPanel2 != null)
						{
							wrapPanel2.Children.Clear();
						}
					}
				}
				else if (this.tabControl.SelectedIndex == 0)
				{
					this.SearchBlockMapping(searchBar.Text);
				}
				else
				{
					this.SearchBlockPlugins(searchBar.Text);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x00041A94 File Offset: 0x0003FC94
		private void SearchBlockMapping(string searchText)
		{
			Type[] array = (from <>h__TransparentIdentifier0 in (from b in GlobalData.BlockMappings
			select new
			{
				b = b,
				attrib = b.Block.GetCustomAttribute<Block>()
			}).Where(delegate(<>h__TransparentIdentifier0)
			{
				if (<>h__TransparentIdentifier0.attrib != null)
				{
					if (!<>h__TransparentIdentifier0.b.Block.GetInterfaces().Any((Type bp) => bp == typeof(IBlockPlugin)))
					{
						return <>h__TransparentIdentifier0.attrib.Name.ToLower().Contains(searchText.ToLower()) || <>h__TransparentIdentifier0.b.Block.Name.ToLower().Contains(searchText.ToLower());
					}
				}
				return false;
			})
			select <>h__TransparentIdentifier0.b.Block).ToArray<Type>();
			if (this.defaultSearchPanel == null)
			{
				this.defaultSearchPanel = new WrapPanel();
			}
			this.defaultSearchPanel.Children.Clear();
			for (int i = 0; i < array.Length; i++)
			{
				this.defaultSearchPanel.Children.Add(this.CreateBlock(array[i], false));
			}
			this.NavigationFrame.Content = this.defaultSearchPanel;
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x00041B70 File Offset: 0x0003FD70
		private void SearchBlockPlugins(string searchText)
		{
			IBlockPlugin[] array = (from p in GlobalData.BlockPlugins
			let attrib = p.GetType().GetCustomAttribute<Block>()
			where attrib != null && (attrib.Name.ToLower().Contains(searchText.ToLower()) || p.Name.ToLower().Contains(searchText.ToLower()))
			select p).ToArray<IBlockPlugin>();
			if (this.pluginSearchPanel == null)
			{
				this.pluginSearchPanel = new WrapPanel();
			}
			this.pluginSearchPanel.Children.Clear();
			for (int i = 0; i < array.Length; i++)
			{
				this.pluginSearchPanel.Children.Add(this.CreatePluginBlock(array[i], array[i].GetType().GetCustomAttribute<Block>().Name, false));
			}
			this.NavigationFramePlugin.Content = this.pluginSearchPanel;
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x00041C60 File Offset: 0x0003FE60
		private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (!string.IsNullOrEmpty((sender as SearchBar).Text))
			{
				return;
			}
			if (this.tabControl.SelectedIndex == 0)
			{
				this.NavigationFrame.Content = this.defaultPanel;
				WrapPanel wrapPanel = this.defaultSearchPanel;
				if (wrapPanel == null)
				{
					return;
				}
				wrapPanel.Children.Clear();
				return;
			}
			else
			{
				this.NavigationFramePlugin.Content = this.pluginPanel;
				WrapPanel wrapPanel2 = this.pluginSearchPanel;
				if (wrapPanel2 == null)
				{
					return;
				}
				wrapPanel2.Children.Clear();
				return;
			}
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x00041CDC File Offset: 0x0003FEDC
		private void Page_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Key == Key.Escape)
				{
					((MainDialog)base.Parent).Close();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x00041D18 File Offset: 0x0003FF18
		private void ReadFavoriteBlocksFile()
		{
			this.favoriteBlocks = IOManager.DeserializeObject<FavoriteBlock[]>(File.ReadAllText(Constants.FavoriteBlocksFile)).Distinct<FavoriteBlock>().ToArray<FavoriteBlock>();
		}

		// Token: 0x040005ED RID: 1517
		private static List<BlockBase> recentBlocks = new List<BlockBase>();

		// Token: 0x040005EE RID: 1518
		private WrapPanel defaultPanel;

		// Token: 0x040005EF RID: 1519
		private WrapPanel pluginPanel;

		// Token: 0x040005F0 RID: 1520
		private WrapPanel favoritesPanel;

		// Token: 0x040005F1 RID: 1521
		private WrapPanel defaultSearchPanel;

		// Token: 0x040005F2 RID: 1522
		private WrapPanel pluginSearchPanel;

		// Token: 0x040005F3 RID: 1523
		private FavoriteBlock[] favoriteBlocks;
	}
}
