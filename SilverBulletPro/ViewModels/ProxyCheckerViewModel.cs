using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Requests;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001BC RID: 444
	public class ProxyCheckerViewModel : ViewModelBase, IProxyChecker
	{
		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000CD8 RID: 3288 RVA: 0x00045E1A File Offset: 0x0004401A
		// (set) Token: 0x06000CD9 RID: 3289 RVA: 0x00045E22 File Offset: 0x00044022
		public ObservableCollection<CProxy> ProxiesCollection
		{
			get
			{
				return this._proxiesCollection;
			}
			private set
			{
				this._proxiesCollection = value;
				this.OnPropertyChanged("ProxiesCollection");
				this.UpdateProperties();
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000CDA RID: 3290 RVA: 0x00045E3C File Offset: 0x0004403C
		public IEnumerable<CProxy> Proxies
		{
			get
			{
				return this.ProxiesCollection;
			}
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x00045E44 File Offset: 0x00044044
		public ProxyCheckerViewModel()
		{
			this.ProxiesCollection = new ObservableCollection<CProxy>();
			this.RefreshList();
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000CDC RID: 3292 RVA: 0x00045EB4 File Offset: 0x000440B4
		// (set) Token: 0x06000CDD RID: 3293 RVA: 0x00045EBC File Offset: 0x000440BC
		public ProxyType Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
				this.OnPropertyChanged("Type");
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000CDF RID: 3295 RVA: 0x00045EE4 File Offset: 0x000440E4
		// (set) Token: 0x06000CDE RID: 3294 RVA: 0x00045ED0 File Offset: 0x000440D0
		public int Total
		{
			get
			{
				return this.total;
			}
			set
			{
				this.total = value;
				this.OnPropertyChanged("Total");
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x00045F00 File Offset: 0x00044100
		// (set) Token: 0x06000CE0 RID: 3296 RVA: 0x00045EEC File Offset: 0x000440EC
		public int Tested
		{
			get
			{
				return this.tested;
			}
			set
			{
				this.tested = value;
				this.OnPropertyChanged("Tested");
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x00045F1C File Offset: 0x0004411C
		// (set) Token: 0x06000CE2 RID: 3298 RVA: 0x00045F08 File Offset: 0x00044108
		public int Chain
		{
			get
			{
				return this.chain;
			}
			set
			{
				this.chain = value;
				this.OnPropertyChanged("Chain");
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x00045F38 File Offset: 0x00044138
		// (set) Token: 0x06000CE4 RID: 3300 RVA: 0x00045F24 File Offset: 0x00044124
		public int Working
		{
			get
			{
				return this.working;
			}
			set
			{
				this.working = value;
				this.OnPropertyChanged("Working");
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000CE7 RID: 3303 RVA: 0x00045F54 File Offset: 0x00044154
		// (set) Token: 0x06000CE6 RID: 3302 RVA: 0x00045F40 File Offset: 0x00044140
		public int NotWorking
		{
			get
			{
				return this.notWorking;
			}
			set
			{
				this.notWorking = value;
				this.OnPropertyChanged("NotWorking");
			}
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x00045F5C File Offset: 0x0004415C
		public void UpdateProperties()
		{
			object obj = this.totalLock;
			lock (obj)
			{
				this.Total = this.ProxiesCollection.Count;
			}
			obj = this.testedLock;
			lock (obj)
			{
				this.Tested = this.ProxiesCollection.Count((CProxy x) => x.Working != 2);
			}
			obj = this.chainLock;
			lock (obj)
			{
				this.Chain = this.ProxiesCollection.Count((CProxy x) => x.Type == 4);
			}
			obj = this.workingLock;
			lock (obj)
			{
				this.Working = this.ProxiesCollection.Count((CProxy x) => x.Working == 0);
			}
			obj = this.notWorkingLock;
			lock (obj)
			{
				this.NotWorking = this.ProxiesCollection.Count((CProxy x) => x.Working == 1);
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x0004610C File Offset: 0x0004430C
		public ProxyManagerStats Stats
		{
			get
			{
				return new ProxyManagerStats(this.Total, this.Tested, this.Working);
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000CEA RID: 3306 RVA: 0x00046125 File Offset: 0x00044325
		// (set) Token: 0x06000CEB RID: 3307 RVA: 0x0004612D File Offset: 0x0004432D
		public int BotsAmount
		{
			get
			{
				return this.botsAmount;
			}
			set
			{
				this.botsAmount = value;
				this.OnPropertyChanged("BotsAmount");
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000CEC RID: 3308 RVA: 0x00046141 File Offset: 0x00044341
		// (set) Token: 0x06000CED RID: 3309 RVA: 0x00046152 File Offset: 0x00044352
		public string TestSite
		{
			get
			{
				return GlobalData.Settings.ProxyManagerSettings.ActiveProxySiteUrl;
			}
			set
			{
				GlobalData.Settings.ProxyManagerSettings.ActiveProxySiteUrl = value;
				this.OnPropertyChanged("TestSite");
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000CEE RID: 3310 RVA: 0x0004616F File Offset: 0x0004436F
		// (set) Token: 0x06000CEF RID: 3311 RVA: 0x00046180 File Offset: 0x00044380
		public string SuccessKey
		{
			get
			{
				return GlobalData.Settings.ProxyManagerSettings.ActiveProxyKey;
			}
			set
			{
				GlobalData.Settings.ProxyManagerSettings.ActiveProxyKey = value;
				this.OnPropertyChanged("SuccessKey");
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000CF0 RID: 3312 RVA: 0x0004619D File Offset: 0x0004439D
		// (set) Token: 0x06000CF1 RID: 3313 RVA: 0x000461A5 File Offset: 0x000443A5
		public bool OnlyUntested
		{
			get
			{
				return this.onlyUntested;
			}
			set
			{
				this.onlyUntested = value;
				this.OnPropertyChanged("OnlyUntested");
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000CF2 RID: 3314 RVA: 0x000461B9 File Offset: 0x000443B9
		// (set) Token: 0x06000CF3 RID: 3315 RVA: 0x000461C1 File Offset: 0x000443C1
		public bool AddMultipleLists
		{
			get
			{
				return this.addMultipleLists;
			}
			set
			{
				this.addMultipleLists = value;
				this.OnPropertyChanged("AddMultipleLists");
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000CF4 RID: 3316 RVA: 0x000461D5 File Offset: 0x000443D5
		// (set) Token: 0x06000CF5 RID: 3317 RVA: 0x000461DD File Offset: 0x000443DD
		public int Timeout
		{
			get
			{
				return this.timeout;
			}
			set
			{
				this.timeout = value;
				this.OnPropertyChanged("Timeout");
			}
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x000461F4 File Offset: 0x000443F4
		public Task CheckAllAsync(IEnumerable<CProxy> proxies, CancellationToken cancellationToken, Action<CheckResult<ProxyResult>> onResult = null, IProgress<float> progress = null)
		{
			ProxyCheckerViewModel.<CheckAllAsync>d__61 <CheckAllAsync>d__;
			<CheckAllAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<CheckAllAsync>d__.<>4__this = this;
			<CheckAllAsync>d__.proxies = proxies;
			<CheckAllAsync>d__.cancellationToken = cancellationToken;
			<CheckAllAsync>d__.onResult = onResult;
			<CheckAllAsync>d__.progress = progress;
			<CheckAllAsync>d__.<>1__state = -1;
			<CheckAllAsync>d__.<>t__builder.Start<ProxyCheckerViewModel.<CheckAllAsync>d__61>(ref <CheckAllAsync>d__);
			return <CheckAllAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000CF7 RID: 3319 RVA: 0x00046258 File Offset: 0x00044458
		public Task<ProxyResult> CheckAsync(CProxy proxy, CancellationToken cancellationToken)
		{
			ProxyCheckerViewModel.<CheckAsync>d__62 <CheckAsync>d__;
			<CheckAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ProxyResult>.Create();
			<CheckAsync>d__.<>4__this = this;
			<CheckAsync>d__.proxy = proxy;
			<CheckAsync>d__.cancellationToken = cancellationToken;
			<CheckAsync>d__.<>1__state = -1;
			<CheckAsync>d__.<>t__builder.Start<ProxyCheckerViewModel.<CheckAsync>d__62>(ref <CheckAsync>d__);
			return <CheckAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000CF8 RID: 3320 RVA: 0x000462AC File Offset: 0x000444AC
		private Task<ProxyResult> CheckProxy(CProxy proxy)
		{
			ProxyCheckerViewModel.<CheckProxy>d__63 <CheckProxy>d__;
			<CheckProxy>d__.<>t__builder = AsyncTaskMethodBuilder<ProxyResult>.Create();
			<CheckProxy>d__.<>4__this = this;
			<CheckProxy>d__.proxy = proxy;
			<CheckProxy>d__.<>1__state = -1;
			<CheckProxy>d__.<>t__builder.Start<ProxyCheckerViewModel.<CheckProxy>d__63>(ref <CheckProxy>d__);
			return <CheckProxy>d__.<>t__builder.Task;
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x000462F8 File Offset: 0x000444F8
		private Task<bool> CheckWorking(CProxy proxy)
		{
			ProxyCheckerViewModel.<CheckWorking>d__64 <CheckWorking>d__;
			<CheckWorking>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<CheckWorking>d__.<>4__this = this;
			<CheckWorking>d__.proxy = proxy;
			<CheckWorking>d__.<>1__state = -1;
			<CheckWorking>d__.<>t__builder.Start<ProxyCheckerViewModel.<CheckWorking>d__64>(ref <CheckWorking>d__);
			return <CheckWorking>d__.<>t__builder.Task;
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x00046344 File Offset: 0x00044544
		private Task<string> CheckCountry(CProxy proxy)
		{
			ProxyCheckerViewModel.<CheckCountry>d__65 <CheckCountry>d__;
			<CheckCountry>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<CheckCountry>d__.<>4__this = this;
			<CheckCountry>d__.proxy = proxy;
			<CheckCountry>d__.<>1__state = -1;
			<CheckCountry>d__.<>t__builder.Start<ProxyCheckerViewModel.<CheckCountry>d__65>(ref <CheckCountry>d__);
			return <CheckCountry>d__.<>t__builder.Task;
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x00046390 File Offset: 0x00044590
		public static Task AsTask(CancellationToken cancellationToken)
		{
			TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
			cancellationToken.Register(delegate()
			{
				tcs.TrySetCanceled();
			}, false);
			return tcs.Task;
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x000463CE File Offset: 0x000445CE
		public void Add(CProxy proxy)
		{
			this.ProxiesCollection.Add(proxy);
		}

		// Token: 0x06000CFD RID: 3325 RVA: 0x000463DC File Offset: 0x000445DC
		public void AddRange(IEnumerable<CProxy> proxies)
		{
			foreach (CProxy item in proxies)
			{
				this.ProxiesCollection.Add(item);
			}
		}

		// Token: 0x06000CFE RID: 3326 RVA: 0x0004642C File Offset: 0x0004462C
		public void RefreshList()
		{
			this.ProxiesCollection = new ObservableCollection<CProxy>();
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x00046439 File Offset: 0x00044639
		public void Update(CProxy proxy)
		{
			this.ProxiesCollection[this.ProxiesCollection.IndexOf(proxy)] = proxy;
		}

		// Token: 0x06000D00 RID: 3328 RVA: 0x00046453 File Offset: 0x00044653
		public void Remove(CProxy proxy)
		{
			this.ProxiesCollection.Remove(proxy);
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x00046464 File Offset: 0x00044664
		public void Remove(IEnumerable<CProxy> proxies)
		{
			foreach (CProxy item in proxies.ToArray<CProxy>())
			{
				this.ProxiesCollection.Remove(item);
			}
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x00046497 File Offset: 0x00044697
		public void RemoveAll()
		{
			this.ProxiesCollection.Clear();
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x000464A4 File Offset: 0x000446A4
		public void RemoveNotWorking()
		{
			this.Remove(from p in this.Proxies
			where p.Working == 1
			select p);
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x000464D8 File Offset: 0x000446D8
		public void RemoveDuplicates()
		{
			IEnumerable<CProxy> proxies = (from p in this.Proxies
			group p by p.Proxy into g
			where g.Count<CProxy>() > 1
			select g).SelectMany((IGrouping<string, CProxy> g) => (from p in g
			orderby p.Proxy
			select p).Reverse<CProxy>().Skip(1));
			this.Remove(proxies);
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x0004655F File Offset: 0x0004475F
		public void RemoveUntested()
		{
			this.Remove(from p in this.Proxies
			where p.Working == 2
			select p);
		}

		// Token: 0x0400065D RID: 1629
		private ObservableCollection<CProxy> _proxiesCollection;

		// Token: 0x0400065E RID: 1630
		private ProxyType type;

		// Token: 0x0400065F RID: 1631
		public object totalLock = new object();

		// Token: 0x04000660 RID: 1632
		private int total;

		// Token: 0x04000661 RID: 1633
		public object testedLock = new object();

		// Token: 0x04000662 RID: 1634
		private int tested;

		// Token: 0x04000663 RID: 1635
		public object chainLock = new object();

		// Token: 0x04000664 RID: 1636
		private int chain;

		// Token: 0x04000665 RID: 1637
		public object workingLock = new object();

		// Token: 0x04000666 RID: 1638
		private int working;

		// Token: 0x04000667 RID: 1639
		public object notWorkingLock = new object();

		// Token: 0x04000668 RID: 1640
		private int notWorking;

		// Token: 0x04000669 RID: 1641
		private int botsAmount = 1;

		// Token: 0x0400066A RID: 1642
		private bool onlyUntested = true;

		// Token: 0x0400066B RID: 1643
		private bool addMultipleLists;

		// Token: 0x0400066C RID: 1644
		private int timeout = 2;
	}
}
