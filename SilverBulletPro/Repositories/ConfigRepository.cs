using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Repositories;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.Repositories
{
	// Token: 0x020001DF RID: 479
	public class ConfigRepository : IRepository<ConfigViewModel, ValueTuple<string, string>>
	{
		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000F2E RID: 3886 RVA: 0x0004C071 File Offset: 0x0004A271
		// (set) Token: 0x06000F2F RID: 3887 RVA: 0x0004C079 File Offset: 0x0004A279
		public string BaseFolder { get; set; }

		// Token: 0x06000F30 RID: 3888 RVA: 0x0004C082 File Offset: 0x0004A282
		public ConfigRepository(string baseFolder)
		{
			this.BaseFolder = baseFolder;
		}

		// Token: 0x06000F31 RID: 3889 RVA: 0x0004C094 File Offset: 0x0004A294
		public void Add(ConfigViewModel entity)
		{
			string path = this.GetPath(entity);
			if (entity.Category != ConfigRepository.defaultCategory && !Directory.Exists(entity.Category))
			{
				Directory.CreateDirectory(Path.Combine(this.BaseFolder, entity.Category));
			}
			if (!File.Exists(path))
			{
				IOManager.SaveConfig(entity.Config, path);
				return;
			}
			throw new IOException("A config with the same name and category already exists");
		}

		// Token: 0x06000F32 RID: 3890 RVA: 0x0004C100 File Offset: 0x0004A300
		public IEnumerable<ConfigViewModel> Get()
		{
			List<ConfigViewModel> list = new List<ConfigViewModel>();
			foreach (string text in Directory.EnumerateFiles(Constants.ConfigFolder).Where(delegate(string file)
			{
				string extension = Path.GetExtension(file);
				return extension.Equals(".spk", StringComparison.OrdinalIgnoreCase) || extension.Equals(".svb", StringComparison.OrdinalIgnoreCase) || extension.Equals(".loli", StringComparison.OrdinalIgnoreCase) || extension.Equals(".lolix", StringComparison.OrdinalIgnoreCase) || extension.Equals(".anom", StringComparison.OrdinalIgnoreCase);
			}))
			{
				try
				{
					list.Add(new ConfigViewModel(Path.GetFileNameWithoutExtension(text), ConfigRepository.defaultCategory, IOManager.LoadConfig(text), false));
				}
				catch
				{
				}
			}
			foreach (string path in Directory.EnumerateDirectories(Constants.ConfigFolder))
			{
				foreach (string text2 in Directory.EnumerateFiles(path).Where(delegate(string file)
				{
					string extension = Path.GetExtension(file);
					return extension.Equals(".spk", StringComparison.OrdinalIgnoreCase) || extension.Equals(".svb", StringComparison.OrdinalIgnoreCase) || extension.Equals(".loli", StringComparison.OrdinalIgnoreCase) || extension.Equals(".lolix", StringComparison.OrdinalIgnoreCase) || extension.Equals(".anom", StringComparison.OrdinalIgnoreCase);
				}))
				{
					try
					{
						list.Add(new ConfigViewModel(Path.GetFileNameWithoutExtension(text2), Path.GetFileName(path), IOManager.LoadConfig(text2), false));
					}
					catch
					{
					}
				}
			}
			return list;
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x0004C270 File Offset: 0x0004A470
		public ConfigViewModel Get(ValueTuple<string, string> id)
		{
			string item = id.Item1;
			string item2 = id.Item2;
			string path = this.GetPath(item, item2);
			return new ConfigViewModel(item2, item, IOManager.LoadConfig(path), false);
		}

		// Token: 0x06000F34 RID: 3892 RVA: 0x0004C2A4 File Offset: 0x0004A4A4
		public void Remove(ConfigViewModel entity)
		{
			string path = this.GetPath(entity);
			if (File.Exists(path))
			{
				File.Delete(path);
				return;
			}
			throw new IOException("File not found");
		}

		// Token: 0x06000F35 RID: 3893 RVA: 0x0004C2D2 File Offset: 0x0004A4D2
		public void RemoveAll()
		{
			Directory.Delete(this.BaseFolder, true);
			Directory.CreateDirectory(this.BaseFolder);
		}

		// Token: 0x06000F36 RID: 3894 RVA: 0x0004C2EC File Offset: 0x0004A4EC
		public void Update(ConfigViewModel entity)
		{
			string path = this.GetPath(entity);
			if (File.Exists(path))
			{
				IOManager.SaveConfig(entity.Config, path);
				return;
			}
			throw new IOException("File not found");
		}

		// Token: 0x06000F37 RID: 3895 RVA: 0x0004C320 File Offset: 0x0004A520
		public void Add(IEnumerable<ConfigViewModel> entities)
		{
			foreach (ConfigViewModel entity in entities)
			{
				this.Add(entity);
			}
		}

		// Token: 0x06000F38 RID: 3896 RVA: 0x0004C368 File Offset: 0x0004A568
		public void Remove(IEnumerable<ConfigViewModel> entities)
		{
			foreach (ConfigViewModel entity in entities)
			{
				this.Remove(entity);
			}
		}

		// Token: 0x06000F39 RID: 3897 RVA: 0x0004C3B0 File Offset: 0x0004A5B0
		public void Update(IEnumerable<ConfigViewModel> entities)
		{
			foreach (ConfigViewModel entity in entities)
			{
				this.Update(entity);
			}
		}

		// Token: 0x06000F3A RID: 3898 RVA: 0x0004C3F8 File Offset: 0x0004A5F8
		private string GetPath(ConfigViewModel config)
		{
			return this.GetPath(config.Category, config.FileName);
		}

		// Token: 0x06000F3B RID: 3899 RVA: 0x0004C40C File Offset: 0x0004A60C
		private string GetPath(string category, string fileName)
		{
			string text = fileName + ".spk";
			if (category != ConfigRepository.defaultCategory)
			{
				return Path.Combine(this.BaseFolder, category, text);
			}
			return Path.Combine(this.BaseFolder, text);
		}

		// Token: 0x04000713 RID: 1811
		public static string defaultCategory = "Default";
	}
}
