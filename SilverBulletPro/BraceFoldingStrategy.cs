using System;
using System.Collections.Generic;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Folding;

namespace SilverBulletPro
{
	// Token: 0x02000019 RID: 25
	public class BraceFoldingStrategy
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00008E32 File Offset: 0x00007032
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00008E3A File Offset: 0x0000703A
		public char OpeningBrace { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00008E43 File Offset: 0x00007043
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00008E4B File Offset: 0x0000704B
		public char ClosingBrace { get; set; }

		// Token: 0x060000DA RID: 218 RVA: 0x00008E54 File Offset: 0x00007054
		public BraceFoldingStrategy()
		{
			this.OpeningBrace = '{';
			this.ClosingBrace = '}';
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00008E6C File Offset: 0x0000706C
		public void UpdateFoldings(FoldingManager manager, TextDocument document)
		{
			int num;
			IEnumerable<NewFolding> enumerable = this.CreateNewFoldings(document, out num);
			manager.UpdateFoldings(enumerable, num);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00008E8B File Offset: 0x0000708B
		public IEnumerable<NewFolding> CreateNewFoldings(TextDocument document, out int firstErrorOffset)
		{
			firstErrorOffset = -1;
			return this.CreateNewFoldings(document);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00008E98 File Offset: 0x00007098
		public IEnumerable<NewFolding> CreateNewFoldings(ITextSource document)
		{
			List<NewFolding> list = new List<NewFolding>();
			Stack<int> stack = new Stack<int>();
			int num = 0;
			char openingBrace = this.OpeningBrace;
			char closingBrace = this.ClosingBrace;
			for (int i = 0; i < document.TextLength; i++)
			{
				char charAt = document.GetCharAt(i);
				if (charAt == openingBrace)
				{
					stack.Push(i);
				}
				else if (charAt == closingBrace && stack.Count > 0)
				{
					int num2 = stack.Pop();
					if (num2 < num)
					{
						list.Add(new NewFolding(num2, i + 1));
					}
				}
				else if (charAt == '\n' || charAt == '\r')
				{
					num = i + 1;
				}
			}
			list.Sort((NewFolding a, NewFolding b) => a.StartOffset.CompareTo(b.StartOffset));
			return list;
		}
	}
}
