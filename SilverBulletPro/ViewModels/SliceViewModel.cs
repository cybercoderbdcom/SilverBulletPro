using System;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001B5 RID: 437
	public class SliceViewModel : ViewModelBase
	{
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000C78 RID: 3192 RVA: 0x00044F5C File Offset: 0x0004315C
		// (set) Token: 0x06000C79 RID: 3193 RVA: 0x00044F64 File Offset: 0x00043164
		public string Name { get; set; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000C7A RID: 3194 RVA: 0x00044F6D File Offset: 0x0004316D
		// (set) Token: 0x06000C7B RID: 3195 RVA: 0x00044F75 File Offset: 0x00043175
		public string Value { get; set; }

		// Token: 0x06000C7C RID: 3196 RVA: 0x00044F7E File Offset: 0x0004317E
		public SliceViewModel(string name, string value)
		{
			this.Name = name;
			this.Value = value;
		}
	}
}
