using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LiteDB;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.Runners;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Repositories;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001BE RID: 446
	public class RunnerManagerViewModel : ViewModelBase, IRunnerManager
	{
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000D2B RID: 3371 RVA: 0x00046B0E File Offset: 0x00044D0E
		// (set) Token: 0x06000D2C RID: 3372 RVA: 0x00046B16 File Offset: 0x00044D16
		public ObservableCollection<RunnerInstance> RunnersCollection { get; set; } = new ObservableCollection<RunnerInstance>();

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000D2D RID: 3373 RVA: 0x00046B1F File Offset: 0x00044D1F
		public IEnumerable<IRunner> Runners
		{
			get
			{
				return from i in this.RunnersCollection
				select i.ViewModel;
			}
		}

		// Token: 0x06000D2E RID: 3374 RVA: 0x00046B4B File Offset: 0x00044D4B
		public RunnerManagerViewModel()
		{
			this._repo = new LiteDBRepository<RunnerSessionData>(Constants.DataBaseFile, "runners");
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x00046B80 File Offset: 0x00044D80
		public RunnerInstance Get(int id)
		{
			return (from r in this.RunnersCollection
			where r.Id == id
			select r).First<RunnerInstance>();
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x00046BB8 File Offset: 0x00044DB8
		public IRunner Create()
		{
			RunnerInstance runnerInstance = new RunnerInstance(this.rand.Next());
			runnerInstance.ViewModel.ConfigChanged += this.OnRunnerSessionChanged;
			runnerInstance.ViewModel.WordlistChanged += this.OnRunnerSessionChanged;
			this.RunnersCollection.Add(runnerInstance);
			return runnerInstance.ViewModel;
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x00046C18 File Offset: 0x00044E18
		public IRunner Clone(RunnerInstance instance)
		{
			RunnerInstance runnerInstance = new RunnerInstance(this.rand.Next());
			runnerInstance.ViewModel.ConfigChanged += this.OnRunnerSessionChanged;
			runnerInstance.ViewModel.WordlistChanged += this.OnRunnerSessionChanged;
			this.RunnersCollection.Add(runnerInstance);
			RunnerOptionsViewModel runnerOptionsViewModel = new RunnerOptionsViewModel();
			ObjectExtension.ClonePropertiesTo(instance.ViewModel.Options, runnerOptionsViewModel, Array.Empty<string>());
			RunnerSessionData session = new RunnerSessionData
			{
				Options = runnerOptionsViewModel,
				Config = ((instance.ViewModel.Config != null) ? instance.ViewModel.ConfigName : "")
			};
			this.RestoreSession(session, runnerInstance.Id, runnerInstance.ViewModel);
			return instance.ViewModel;
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x00046CD8 File Offset: 0x00044ED8
		public void Remove(IRunner runner)
		{
			this.RunnersCollection.Remove(this.RunnersCollection.First((RunnerInstance r) => r.ViewModel == runner));
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x00046D15 File Offset: 0x00044F15
		public void Remove(int id)
		{
			this.RunnersCollection.Remove(this.Get(id));
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x00046D2A File Offset: 0x00044F2A
		public void RemoveAll()
		{
			this.RunnersCollection.Clear();
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x00046D37 File Offset: 0x00044F37
		public void OnRunnerSessionChanged(IRunnerMessaging obj)
		{
			this.SaveSession();
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x00046D40 File Offset: 0x00044F40
		public void SaveSession()
		{
			this._repo.RemoveAll();
			this._repo.Add(from r in this.RunnersCollection
			select r.ViewModel into r
			select new RunnerSessionData
			{
				Config = ((r.Config != null) ? r.ConfigName : ""),
				Options = r.Options
			});
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x00046DB4 File Offset: 0x00044FB4
		public bool RestoreSession()
		{
			RunnerSessionData[] array = this._repo.Get().ToArray<RunnerSessionData>();
			if (array.Length == 0)
			{
				return false;
			}
			RunnerSessionData[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RunnerSessionData r = array2[i];
				try
				{
					IRunner runner = this.Create();
					runner.Options = r.Options;
					ConfigViewModel configViewModel = GlobalData.ConfigManager.Configs.FirstOrDefault((ConfigViewModel c) => c.Name == r.Config);
					if (configViewModel == null)
					{
						throw new Exception("The Config " + r.Config + " was not found in the ConfigManager");
					}
					ConfigViewModel configViewModel2 = configViewModel;
					runner.SetConfig(configViewModel2.Config, false);
					DataPoolOptions[] dataPoolOptions = runner.Options.DataPoolOptions;
					if (dataPoolOptions == null || dataPoolOptions.Length == 0)
					{
						throw new Exception("The Wordlist not found");
					}
					runner.SetDataPoolOptions(runner.Options.DataPoolOptions);
					runner.StartingPoint = this.RetrieveRecord(configViewModel2.Config, string.Join('|', runner.Options.GetDataPoolPath()));
				}
				catch (Exception ex)
				{
					GlobalData.Logger.LogError(Components.RunnerManager, ex.Message, false, 0);
				}
			}
			return true;
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x00046EF4 File Offset: 0x000450F4
		public bool RestoreSession(RunnerSessionData session, int id, IRunner instance)
		{
			if (session == null || instance == null)
			{
				return false;
			}
			try
			{
				instance.Options = session.Options;
				ConfigViewModel configViewModel = GlobalData.ConfigManager.Configs.FirstOrDefault((ConfigViewModel c) => c.Name == session.Config);
				if (configViewModel == null)
				{
					throw new Exception("The Config " + session.Config + " was not found in the ConfigManager");
				}
				ConfigViewModel configViewModel2 = configViewModel;
				instance.SetConfig(configViewModel2.Config, false);
				DataPoolOptions[] dataPoolOptions = instance.Options.DataPoolOptions;
				if (dataPoolOptions == null || dataPoolOptions.Length == 0)
				{
					throw new Exception("The Wordlist not found");
				}
				instance.SetDataPoolOptions(instance.Options.DataPoolOptions);
				instance.StartingPoint = this.RetrieveRecord(configViewModel2.Config, string.Join('|', instance.Options.GetDataPoolPath()));
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.RunnerManager, ex.Message, false, 0);
			}
			return true;
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x00047000 File Offset: 0x00045200
		public long RetrieveRecord(Config config, string wordlistPath = null)
		{
			if (wordlistPath == null || config == null)
			{
				return 1L;
			}
			long result2;
			using (LiteDatabase liteDatabase = new LiteDatabase("filename=" + Constants.DataBaseFile + "; Connection=Shared;", null))
			{
				string[] array = new string[]
				{
					wordlistPath
				};
				if (wordlistPath.Contains("|"))
				{
					array = wordlistPath.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
				}
				Record record = null;
				if (array.Length == 1)
				{
					string wPath = array[0];
					record = liteDatabase.GetCollection<Record>("records", 10).FindOne((Record r) => r.ConfigName == config.Settings.Name && wPath == r.WordlistLocation);
				}
				else if (array.Length > 1)
				{
					long result = 1L;
					IEnumerable<Record> enumerable = liteDatabase.GetCollection<Record>("records", 10).FindAll();
					IEnumerable<Record> enumerable2 = (enumerable != null) ? (from r in enumerable
					where r.ConfigName == config.Settings.Name && array.Any((string p) => p == r.WordlistLocation)
					select r) : null;
					if (enumerable2 != null)
					{
						result = (from r in enumerable2
						select r.Checkpoint).Sum();
					}
					return result;
				}
				if (record != null)
				{
					result2 = record.Checkpoint;
				}
				else
				{
					result2 = 1L;
				}
			}
			return result2;
		}

		// Token: 0x06000D3A RID: 3386 RVA: 0x00047238 File Offset: 0x00045438
		public void SaveRecord(Config config, Wordlist wordlist, long progress)
		{
			if (config == null || wordlist == null)
			{
				return;
			}
			using (LiteDatabase liteDatabase = new LiteDatabase("filename=" + Constants.DataBaseFile + "; Connection=Shared;", null))
			{
				ILiteCollection<Record> collection = liteDatabase.GetCollection<Record>("records", 10);
				Record record = new Record(config.Settings.Name, wordlist.Path, progress);
				collection.DeleteMany((Record r) => r.ConfigName == config.Settings.Name && r.WordlistLocation == wordlist.Path);
				collection.Insert(record);
			}
		}

		// Token: 0x04000675 RID: 1653
		private LiteDBRepository<RunnerSessionData> _repo;

		// Token: 0x04000677 RID: 1655
		private Random rand = new Random();
	}
}
