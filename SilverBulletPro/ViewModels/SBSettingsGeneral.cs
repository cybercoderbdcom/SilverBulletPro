using System;
using System.Collections.Generic;
using System.Reflection;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001C1 RID: 449
	public class SBSettingsGeneral : ViewModelBase
	{
		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000D4E RID: 3406 RVA: 0x00047501 File Offset: 0x00045701
		// (set) Token: 0x06000D4F RID: 3407 RVA: 0x00047509 File Offset: 0x00045709
		public bool DisplaySvbScriptOnLoad
		{
			get
			{
				return this.displaySvbScriptOnLoad;
			}
			set
			{
				this.displaySvbScriptOnLoad = value;
				this.OnPropertyChanged("DisplaySvbScriptOnLoad");
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000D50 RID: 3408 RVA: 0x0004751D File Offset: 0x0004571D
		// (set) Token: 0x06000D51 RID: 3409 RVA: 0x00047525 File Offset: 0x00045725
		public bool RecommendedBots
		{
			get
			{
				return this.recommendedBots;
			}
			set
			{
				this.recommendedBots = value;
				this.OnPropertyChanged("RecommendedBots");
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000D52 RID: 3410 RVA: 0x00047539 File Offset: 0x00045739
		// (set) Token: 0x06000D53 RID: 3411 RVA: 0x00047541 File Offset: 0x00045741
		public int StartingWidth
		{
			get
			{
				return this.startingWidth;
			}
			set
			{
				this.startingWidth = value;
				this.OnPropertyChanged("StartingWidth");
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000D54 RID: 3412 RVA: 0x00047555 File Offset: 0x00045755
		// (set) Token: 0x06000D55 RID: 3413 RVA: 0x0004755D File Offset: 0x0004575D
		public int StartingHeight
		{
			get
			{
				return this.startingHeight;
			}
			set
			{
				this.startingHeight = value;
				this.OnPropertyChanged("StartingHeight");
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000D56 RID: 3414 RVA: 0x00047571 File Offset: 0x00045771
		// (set) Token: 0x06000D57 RID: 3415 RVA: 0x00047579 File Offset: 0x00045779
		public bool ChangeRunnerInterface
		{
			get
			{
				return this.changeRunnerInterface;
			}
			set
			{
				this.changeRunnerInterface = value;
				this.OnPropertyChanged("ChangeRunnerInterface");
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000D58 RID: 3416 RVA: 0x0004758D File Offset: 0x0004578D
		// (set) Token: 0x06000D59 RID: 3417 RVA: 0x00047595 File Offset: 0x00045795
		public bool DisableQuitWarning
		{
			get
			{
				return this.disableQuitWarning;
			}
			set
			{
				this.disableQuitWarning = value;
				this.OnPropertyChanged("DisableQuitWarning");
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000D5A RID: 3418 RVA: 0x000475A9 File Offset: 0x000457A9
		// (set) Token: 0x06000D5B RID: 3419 RVA: 0x000475B1 File Offset: 0x000457B1
		public bool DisableNotSavedWarning
		{
			get
			{
				return this.disableNotSavedWarning;
			}
			set
			{
				this.disableNotSavedWarning = value;
				this.OnPropertyChanged("DisableNotSavedWarning");
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000D5C RID: 3420 RVA: 0x000475C5 File Offset: 0x000457C5
		// (set) Token: 0x06000D5D RID: 3421 RVA: 0x000475CD File Offset: 0x000457CD
		public string DefaultAuthor
		{
			get
			{
				return this.defaultAuthor;
			}
			set
			{
				this.defaultAuthor = value;
				this.OnPropertyChanged("DefaultAuthor");
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000D5E RID: 3422 RVA: 0x000475E1 File Offset: 0x000457E1
		// (set) Token: 0x06000D5F RID: 3423 RVA: 0x000475E9 File Offset: 0x000457E9
		public bool LiveConfigUpdates
		{
			get
			{
				return this.liveConfigUpdates;
			}
			set
			{
				this.liveConfigUpdates = value;
				this.OnPropertyChanged("LiveConfigUpdates");
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000D60 RID: 3424 RVA: 0x000475FD File Offset: 0x000457FD
		// (set) Token: 0x06000D61 RID: 3425 RVA: 0x00047605 File Offset: 0x00045805
		public bool DisableHTMLView
		{
			get
			{
				return this.disableHTMLView;
			}
			set
			{
				this.disableHTMLView = value;
				this.OnPropertyChanged("DisableHTMLView");
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000D62 RID: 3426 RVA: 0x00047619 File Offset: 0x00045819
		// (set) Token: 0x06000D63 RID: 3427 RVA: 0x00047621 File Offset: 0x00045821
		public bool LocalHTMLViewer
		{
			get
			{
				return this.localHTMLViewer;
			}
			set
			{
				this.localHTMLViewer = value;
				this.OnPropertyChanged("LocalHTMLViewer");
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000D64 RID: 3428 RVA: 0x00047635 File Offset: 0x00045835
		// (set) Token: 0x06000D65 RID: 3429 RVA: 0x0004763D File Offset: 0x0004583D
		public bool EnableCookiesInBrowser
		{
			get
			{
				return this.enableCookiesInBrowser;
			}
			set
			{
				this.enableCookiesInBrowser = value;
				this.OnPropertyChanged("EnableCookiesInBrowser");
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000D66 RID: 3430 RVA: 0x00047651 File Offset: 0x00045851
		// (set) Token: 0x06000D67 RID: 3431 RVA: 0x00047659 File Offset: 0x00045859
		public bool AlwaysOnTop
		{
			get
			{
				return this.alwaysOnTop;
			}
			set
			{
				this.alwaysOnTop = value;
				this.OnPropertyChanged("AlwaysOnTop");
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000D68 RID: 3432 RVA: 0x0004766D File Offset: 0x0004586D
		// (set) Token: 0x06000D69 RID: 3433 RVA: 0x00047675 File Offset: 0x00045875
		public bool MinimizeToSysTray
		{
			get
			{
				return this.minimizeToSysTray;
			}
			set
			{
				this.minimizeToSysTray = value;
				this.OnPropertyChanged("MinimizeToSysTray");
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000D6A RID: 3434 RVA: 0x00047689 File Offset: 0x00045889
		// (set) Token: 0x06000D6B RID: 3435 RVA: 0x00047691 File Offset: 0x00045891
		public bool AutoCreateRunner
		{
			get
			{
				return this.autoCreateRunner;
			}
			set
			{
				this.autoCreateRunner = value;
				this.OnPropertyChanged("AutoCreateRunner");
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000D6C RID: 3436 RVA: 0x000476A5 File Offset: 0x000458A5
		// (set) Token: 0x06000D6D RID: 3437 RVA: 0x000476AD File Offset: 0x000458AD
		public bool DisableDebuggerLog
		{
			get
			{
				return this.disableDebuggerLog;
			}
			set
			{
				this.disableDebuggerLog = value;
				this.OnPropertyChanged("DisableDebuggerLog");
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000D6E RID: 3438 RVA: 0x000476C1 File Offset: 0x000458C1
		// (set) Token: 0x06000D6F RID: 3439 RVA: 0x000476C9 File Offset: 0x000458C9
		public bool SendDebuggerLogToNotepadPlus
		{
			get
			{
				return this.sendDebuggerLogToNotepadPlus;
			}
			set
			{
				this.sendDebuggerLogToNotepadPlus = value;
				this.OnPropertyChanged("SendDebuggerLogToNotepadPlus");
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000D70 RID: 3440 RVA: 0x000476DD File Offset: 0x000458DD
		// (set) Token: 0x06000D71 RID: 3441 RVA: 0x000476E5 File Offset: 0x000458E5
		public bool PersistDebuggerLog
		{
			get
			{
				return this.persistDebuggerLog;
			}
			set
			{
				this.persistDebuggerLog = value;
				this.OnPropertyChanged("PersistDebuggerLog");
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000D72 RID: 3442 RVA: 0x000476F9 File Offset: 0x000458F9
		// (set) Token: 0x06000D73 RID: 3443 RVA: 0x00047701 File Offset: 0x00045901
		public bool DisableSyntaxHelper
		{
			get
			{
				return this.disableSyntaxHelper;
			}
			set
			{
				this.disableSyntaxHelper = value;
				this.OnPropertyChanged("DisableSyntaxHelper");
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000D74 RID: 3444 RVA: 0x00047715 File Offset: 0x00045915
		// (set) Token: 0x06000D75 RID: 3445 RVA: 0x0004771D File Offset: 0x0004591D
		public bool DisplayCapturesLast
		{
			get
			{
				return this.displayCapturesLast;
			}
			set
			{
				this.displayCapturesLast = value;
				this.OnPropertyChanged("DisplayCapturesLast");
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000D76 RID: 3446 RVA: 0x00047731 File Offset: 0x00045931
		// (set) Token: 0x06000D77 RID: 3447 RVA: 0x00047739 File Offset: 0x00045939
		public bool DisableCopyPasteBlocks
		{
			get
			{
				return this.disableCopyPasteBlocks;
			}
			set
			{
				this.disableCopyPasteBlocks = value;
				this.OnPropertyChanged("DisableCopyPasteBlocks");
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000D78 RID: 3448 RVA: 0x0004774D File Offset: 0x0004594D
		// (set) Token: 0x06000D79 RID: 3449 RVA: 0x00047755 File Offset: 0x00045955
		public bool EnableLogging
		{
			get
			{
				return this.enableLogging;
			}
			set
			{
				this.enableLogging = value;
				this.OnPropertyChanged("EnableLogging");
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000D7A RID: 3450 RVA: 0x00047769 File Offset: 0x00045969
		// (set) Token: 0x06000D7B RID: 3451 RVA: 0x00047771 File Offset: 0x00045971
		public bool LogToFile
		{
			get
			{
				return this.logToFile;
			}
			set
			{
				this.logToFile = value;
				this.OnPropertyChanged("LogToFile");
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000D7C RID: 3452 RVA: 0x00047785 File Offset: 0x00045985
		// (set) Token: 0x06000D7D RID: 3453 RVA: 0x0004778D File Offset: 0x0004598D
		public int LogBufferSize
		{
			get
			{
				return this.logBufferSize;
			}
			set
			{
				this.logBufferSize = value;
				this.OnPropertyChanged("LogBufferSize");
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000D7E RID: 3454 RVA: 0x000477A1 File Offset: 0x000459A1
		// (set) Token: 0x06000D7F RID: 3455 RVA: 0x000477A9 File Offset: 0x000459A9
		public bool BackupDB
		{
			get
			{
				return this.backupDB;
			}
			set
			{
				this.backupDB = value;
				this.OnPropertyChanged("BackupDB");
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000D80 RID: 3456 RVA: 0x000477BD File Offset: 0x000459BD
		// (set) Token: 0x06000D81 RID: 3457 RVA: 0x000477C5 File Offset: 0x000459C5
		public bool IgnoreWordlistOnHitDedupe
		{
			get
			{
				return this.ignoreWordlistOnHitsDedupe;
			}
			set
			{
				this.ignoreWordlistOnHitsDedupe = value;
				this.OnPropertyChanged("IgnoreWordlistOnHitDedupe");
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000D82 RID: 3458 RVA: 0x000477D9 File Offset: 0x000459D9
		// (set) Token: 0x06000D83 RID: 3459 RVA: 0x000477E1 File Offset: 0x000459E1
		public bool AutoSaveConfigOnStacker
		{
			get
			{
				return this.autoSaveConfigOnStacker;
			}
			set
			{
				this.autoSaveConfigOnStacker = value;
				this.OnPropertyChanged("AutoSaveConfigOnStacker");
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000D84 RID: 3460 RVA: 0x000477F5 File Offset: 0x000459F5
		// (set) Token: 0x06000D85 RID: 3461 RVA: 0x000477FD File Offset: 0x000459FD
		public bool AutoCompleteDefinedVariables
		{
			get
			{
				return this.autoCompleteDefinedVariables;
			}
			set
			{
				this.autoCompleteDefinedVariables = value;
				this.OnPropertyChanged("AutoCompleteDefinedVariables");
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000D86 RID: 3462 RVA: 0x00047811 File Offset: 0x00045A11
		// (set) Token: 0x06000D87 RID: 3463 RVA: 0x00047819 File Offset: 0x00045A19
		public bool ScriptCompletion
		{
			get
			{
				return this.scriptCompletion;
			}
			set
			{
				this.scriptCompletion = value;
				this.OnPropertyChanged("ScriptCompletion");
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000D88 RID: 3464 RVA: 0x0004782D File Offset: 0x00045A2D
		// (set) Token: 0x06000D89 RID: 3465 RVA: 0x00047835 File Offset: 0x00045A35
		public bool EnableConfigConversion
		{
			get
			{
				return this.enableConfigConversion;
			}
			set
			{
				this.enableConfigConversion = value;
				this.OnPropertyChanged("EnableConfigConversion");
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000D8A RID: 3466 RVA: 0x00047849 File Offset: 0x00045A49
		// (set) Token: 0x06000D8B RID: 3467 RVA: 0x00047851 File Offset: 0x00045A51
		public bool DisableAnimationMode
		{
			get
			{
				return this.disableAnimationMode;
			}
			set
			{
				this.disableAnimationMode = value;
				this.OnPropertyChanged("DisableAnimationMode");
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000D8C RID: 3468 RVA: 0x00047865 File Offset: 0x00045A65
		// (set) Token: 0x06000D8D RID: 3469 RVA: 0x0004786D File Offset: 0x00045A6D
		public ConfigManagerViewMode ConfigManagerViewMode
		{
			get
			{
				return this.configManagerViewMode;
			}
			set
			{
				this.configManagerViewMode = value;
				this.OnPropertyChanged("ConfigManagerViewMode");
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000D8E RID: 3470 RVA: 0x00047881 File Offset: 0x00045A81
		// (set) Token: 0x06000D8F RID: 3471 RVA: 0x00047889 File Offset: 0x00045A89
		public ConfigFilterType ConfigFilterType
		{
			get
			{
				return this.filterType;
			}
			set
			{
				this.filterType = value;
				this.OnPropertyChanged("ConfigFilterType");
			}
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x000478A0 File Offset: 0x00045AA0
		public void Reset()
		{
			SBSettingsGeneral obj = new SBSettingsGeneral();
			foreach (PropertyInfo propertyInfo in ((IEnumerable<PropertyInfo>)new List<PropertyInfo>(typeof(SBSettingsGeneral).GetProperties())))
			{
				if (!(propertyInfo.Name == "PersistDebuggerLog") && !(propertyInfo.Name == "ConfigManagerViewMode"))
				{
					propertyInfo.SetValue(this, propertyInfo.GetValue(obj, null));
				}
			}
		}

		// Token: 0x04000680 RID: 1664
		private bool displaySvbScriptOnLoad;

		// Token: 0x04000681 RID: 1665
		private bool recommendedBots = true;

		// Token: 0x04000682 RID: 1666
		private int startingWidth = 800;

		// Token: 0x04000683 RID: 1667
		private int startingHeight = 620;

		// Token: 0x04000684 RID: 1668
		private bool changeRunnerInterface;

		// Token: 0x04000685 RID: 1669
		private bool disableQuitWarning;

		// Token: 0x04000686 RID: 1670
		private bool disableNotSavedWarning;

		// Token: 0x04000687 RID: 1671
		private string defaultAuthor = "Anonymous";

		// Token: 0x04000688 RID: 1672
		private bool liveConfigUpdates;

		// Token: 0x04000689 RID: 1673
		private bool disableHTMLView;

		// Token: 0x0400068A RID: 1674
		private bool localHTMLViewer;

		// Token: 0x0400068B RID: 1675
		private bool enableCookiesInBrowser;

		// Token: 0x0400068C RID: 1676
		private bool alwaysOnTop;

		// Token: 0x0400068D RID: 1677
		private bool minimizeToSysTray;

		// Token: 0x0400068E RID: 1678
		private bool autoCreateRunner;

		// Token: 0x0400068F RID: 1679
		private bool persistDebuggerLog;

		// Token: 0x04000690 RID: 1680
		private bool disableDebuggerLog;

		// Token: 0x04000691 RID: 1681
		private bool sendDebuggerLogToNotepadPlus;

		// Token: 0x04000692 RID: 1682
		private bool disableSyntaxHelper;

		// Token: 0x04000693 RID: 1683
		private bool displayCapturesLast;

		// Token: 0x04000694 RID: 1684
		private bool disableCopyPasteBlocks;

		// Token: 0x04000695 RID: 1685
		private bool enableLogging;

		// Token: 0x04000696 RID: 1686
		private bool logToFile;

		// Token: 0x04000697 RID: 1687
		private int logBufferSize = 10000;

		// Token: 0x04000698 RID: 1688
		private bool backupDB = true;

		// Token: 0x04000699 RID: 1689
		private bool ignoreWordlistOnHitsDedupe;

		// Token: 0x0400069A RID: 1690
		private bool autoSaveConfigOnStacker;

		// Token: 0x0400069B RID: 1691
		private bool autoCompleteDefinedVariables;

		// Token: 0x0400069C RID: 1692
		private bool scriptCompletion;

		// Token: 0x0400069D RID: 1693
		private bool enableConfigConversion = true;

		// Token: 0x0400069E RID: 1694
		private bool disableAnimationMode;

		// Token: 0x0400069F RID: 1695
		private ConfigManagerViewMode configManagerViewMode;

		// Token: 0x040006A0 RID: 1696
		private ConfigFilterType filterType = ConfigFilterType.Name;
	}
}
