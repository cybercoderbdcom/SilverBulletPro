using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.ViewModels
{
	// Token: 0x020001B6 RID: 438
	public class TestDataRulesDialogViewModel : ViewModelBase
	{
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000C7D RID: 3197 RVA: 0x00044F94 File Offset: 0x00043194
		// (set) Token: 0x06000C7E RID: 3198 RVA: 0x00044F9C File Offset: 0x0004319C
		public string WordlistType { get; set; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000C7F RID: 3199 RVA: 0x00044FA5 File Offset: 0x000431A5
		// (set) Token: 0x06000C80 RID: 3200 RVA: 0x00044FAD File Offset: 0x000431AD
		public ObservableCollection<SliceViewModel> SlicesCollection
		{
			get
			{
				return this.slicesCollection;
			}
			set
			{
				this.slicesCollection = value;
				this.OnPropertyChanged("SlicesCollection");
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000C81 RID: 3201 RVA: 0x00044FC1 File Offset: 0x000431C1
		// (set) Token: 0x06000C82 RID: 3202 RVA: 0x00044FC9 File Offset: 0x000431C9
		public ObservableCollection<ResultViewModel> ResultsCollection
		{
			get
			{
				return this.resultsCollection;
			}
			set
			{
				this.resultsCollection = value;
				this.OnPropertyChanged("ResultsCollection");
			}
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x00044FE0 File Offset: 0x000431E0
		public TestDataRulesDialogViewModel(string testData, string wordlistType, IEnumerable<DataRule> rules)
		{
			this.WordlistType = wordlistType;
			string testWordlistTypeForRules = GlobalData.ConfigManager.CurrentConfig.Config.Settings.TestWordlistTypeForRules;
			IEnumerable<SliceViewModel> enumerable = from v in new CData(testData, GlobalData.Settings.Environment.GetWordlistType(testWordlistTypeForRules)).GetVariables(false)
			select new SliceViewModel(v.Name, v.ToString());
			this.SlicesCollection = new ObservableCollection<SliceViewModel>(enumerable);
			List<ResultViewModel> list = new List<ResultViewModel>();
			using (IEnumerator<DataRule> enumerator = rules.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DataRule rule = enumerator.Current;
					SliceViewModel sliceViewModel = enumerable.FirstOrDefault((SliceViewModel v) => v.Name == rule.SliceName);
					if (sliceViewModel == null)
					{
						list.Add(new ResultViewModel("Invalid slice name: " + rule.SliceName, false));
					}
					else
					{
						list.Add(new ResultViewModel(TestDataRulesDialogViewModel.GetRuleText(rule), rule.IsSatisfied(sliceViewModel.Value)));
					}
				}
			}
			this.ResultsCollection = new ObservableCollection<ResultViewModel>(list);
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x00045134 File Offset: 0x00043334
		private static string GetRuleText(DataRule rule)
		{
			RegexDataRule regexDataRule = rule as RegexDataRule;
			if (regexDataRule != null)
			{
				return string.Concat(new string[]
				{
					regexDataRule.SliceName,
					" must",
					regexDataRule.Invert ? " not" : "",
					" match regex ",
					regexDataRule.RegexToMatch
				});
			}
			SimpleDataRule simpleDataRule = rule as SimpleDataRule;
			if (simpleDataRule != null)
			{
				return string.Format("{0} must{1} respect: {2} {3}", new object[]
				{
					simpleDataRule.SliceName,
					simpleDataRule.Invert ? " not" : "",
					simpleDataRule.Comparison,
					simpleDataRule.StringToCompare
				});
			}
			throw new NotImplementedException();
		}

		// Token: 0x04000645 RID: 1605
		private ObservableCollection<SliceViewModel> slicesCollection = new ObservableCollection<SliceViewModel>();

		// Token: 0x04000646 RID: 1606
		private ObservableCollection<ResultViewModel> resultsCollection = new ObservableCollection<ResultViewModel>();
	}
}
