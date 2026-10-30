using System;
using System.Windows;
using Newtonsoft.Json;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.Models
{
	// Token: 0x020001EB RID: 491
	public class Source : ViewModelBase
	{
		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000FF5 RID: 4085 RVA: 0x0004DAA5 File Offset: 0x0004BCA5
		// (set) Token: 0x06000FF6 RID: 4086 RVA: 0x0004DAAD File Offset: 0x0004BCAD
		public int Id { get; set; }

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000FF7 RID: 4087 RVA: 0x0004DAB6 File Offset: 0x0004BCB6
		// (set) Token: 0x06000FF8 RID: 4088 RVA: 0x0004DABE File Offset: 0x0004BCBE
		public string ApiUrl
		{
			get
			{
				return this.apiUrl;
			}
			set
			{
				this.apiUrl = value;
				this.OnPropertyChanged("ApiUrl");
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000FF9 RID: 4089 RVA: 0x0004DAD2 File Offset: 0x0004BCD2
		// (set) Token: 0x06000FFA RID: 4090 RVA: 0x0004DADA File Offset: 0x0004BCDA
		public Source.AuthMode Auth
		{
			get
			{
				return this.auth;
			}
			set
			{
				this.auth = value;
				this.OnPropertyChanged("Auth");
				this.OnPropertyChanged("ApiKeyVisible");
				this.OnPropertyChanged("UserPassVisible");
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000FFB RID: 4091 RVA: 0x0004DB04 File Offset: 0x0004BD04
		// (set) Token: 0x06000FFC RID: 4092 RVA: 0x0004DB0C File Offset: 0x0004BD0C
		public string ApiKey
		{
			get
			{
				return this.apiKey;
			}
			set
			{
				this.apiKey = value;
				this.OnPropertyChanged("ApiKey");
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000FFD RID: 4093 RVA: 0x0004DB20 File Offset: 0x0004BD20
		// (set) Token: 0x06000FFE RID: 4094 RVA: 0x0004DB28 File Offset: 0x0004BD28
		public string Username
		{
			get
			{
				return this.username;
			}
			set
			{
				this.username = value;
				this.OnPropertyChanged("Username");
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000FFF RID: 4095 RVA: 0x0004DB3C File Offset: 0x0004BD3C
		// (set) Token: 0x06001000 RID: 4096 RVA: 0x0004DB44 File Offset: 0x0004BD44
		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				this.password = value;
				this.OnPropertyChanged("Password");
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06001001 RID: 4097 RVA: 0x0004DB58 File Offset: 0x0004BD58
		// (set) Token: 0x06001002 RID: 4098 RVA: 0x0004DB60 File Offset: 0x0004BD60
		[JsonIgnore]
		public bool AuthInitialized { get; set; }

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06001003 RID: 4099 RVA: 0x0004DB69 File Offset: 0x0004BD69
		[JsonIgnore]
		public Visibility ApiKeyVisible
		{
			get
			{
				if (this.Auth != Source.AuthMode.ApiKey)
				{
					return Visibility.Collapsed;
				}
				return Visibility.Visible;
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06001004 RID: 4100 RVA: 0x0004DB76 File Offset: 0x0004BD76
		[JsonIgnore]
		public Visibility UserPassVisible
		{
			get
			{
				if (this.Auth != Source.AuthMode.UserPass)
				{
					return Visibility.Collapsed;
				}
				return Visibility.Visible;
			}
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x0004DB84 File Offset: 0x0004BD84
		public Source(int id)
		{
			this.Id = id;
		}

		// Token: 0x04000765 RID: 1893
		private string apiUrl = "";

		// Token: 0x04000766 RID: 1894
		private Source.AuthMode auth;

		// Token: 0x04000767 RID: 1895
		private string apiKey = "";

		// Token: 0x04000768 RID: 1896
		private string username = "";

		// Token: 0x04000769 RID: 1897
		private string password = "";

		// Token: 0x020002E4 RID: 740
		public enum AuthMode
		{
			// Token: 0x040009B6 RID: 2486
			ApiKey,
			// Token: 0x040009B7 RID: 2487
			UserPass
		}
	}
}
