using System;
using SilverBulletPro.Core.Runners;
using SilverBulletPro.Views.Main.Runner;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001BF RID: 447
	public class RunnerInstance
	{
		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000D3B RID: 3387 RVA: 0x000473CC File Offset: 0x000455CC
		// (set) Token: 0x06000D3C RID: 3388 RVA: 0x000473D4 File Offset: 0x000455D4
		public Runner View { get; internal set; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000D3D RID: 3389 RVA: 0x000473DD File Offset: 0x000455DD
		// (set) Token: 0x06000D3E RID: 3390 RVA: 0x000473E5 File Offset: 0x000455E5
		public RunnerViewModel ViewModel { get; internal set; }

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000D3F RID: 3391 RVA: 0x000473EE File Offset: 0x000455EE
		// (set) Token: 0x06000D40 RID: 3392 RVA: 0x000473F6 File Offset: 0x000455F6
		public int Id { get; set; }

		// Token: 0x06000D41 RID: 3393 RVA: 0x000473FF File Offset: 0x000455FF
		public RunnerInstance(int id)
		{
			this.Id = id;
			this.ViewModel = new RunnerViewModel(GlobalData.Settings.Environment, GlobalData.Settings.CoreSettings, null);
			this.View = new Runner(this.ViewModel);
		}
	}
}
