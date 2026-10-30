using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using ICSharpCode.AvalonEdit;

namespace SilverBulletPro.FindReplace
{
	// Token: 0x020001D9 RID: 473
	public class IEditorConverter : IValueConverter
	{
		// Token: 0x06000ED0 RID: 3792 RVA: 0x0004B3E0 File Offset: 0x000495E0
		object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is TextEditor)
			{
				return new TextEditorAdapter(value as TextEditor);
			}
			if (value is System.Windows.Controls.TextBox)
			{
				return new TextBoxAdapter(value as System.Windows.Controls.TextBox);
			}
			if (value is System.Windows.Controls.RichTextBox)
			{
				return new RichTextBoxAdapter(value as System.Windows.Controls.RichTextBox);
			}
			if (value is WindowsFormsHost)
			{
				return new WFTextBoxAdapter((value as WindowsFormsHost).Child as TextBoxBase);
			}
			return null;
		}

		// Token: 0x06000ED1 RID: 3793 RVA: 0x0004B448 File Offset: 0x00049648
		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
