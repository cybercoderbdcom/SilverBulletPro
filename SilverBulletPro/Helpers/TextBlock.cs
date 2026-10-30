using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace SilverBulletPro.Helpers
{
	// Token: 0x020001ED RID: 493
	public static class TextBlock
	{
		// Token: 0x0600100D RID: 4109 RVA: 0x0004DC1F File Offset: 0x0004BE1F
		public static void SetCharacterCasing(DependencyObject element, CharacterCasing value)
		{
			element.SetValue(TextBlock.CharacterCasingProperty, value);
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x0004DC32 File Offset: 0x0004BE32
		public static CharacterCasing GetCharacterCasing(DependencyObject element)
		{
			return (CharacterCasing)element.GetValue(TextBlock.CharacterCasingProperty);
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x0004DC44 File Offset: 0x0004BE44
		private static void OnCharacterCasingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			TextBlock textBlock = d as TextBlock;
			if (textBlock != null)
			{
				if (BindingOperations.GetBinding(textBlock, TextBlock.TextProxyProperty) == null)
				{
					BindingOperations.SetBinding(textBlock, TextBlock.TextProxyProperty, new Binding
					{
						Path = TextBlock.TextPropertyPath,
						RelativeSource = RelativeSource.Self,
						Mode = BindingMode.OneWay
					});
					return;
				}
			}
			else
			{
				Run run = d as Run;
				if (run != null && BindingOperations.GetBinding(run, TextBlock.TextProxyProperty) == null)
				{
					BindingOperations.SetBinding(run, TextBlock.TextRunProperty, new Binding
					{
						Path = TextBlock.TextPropertyPath,
						RelativeSource = RelativeSource.Self,
						Mode = BindingMode.OneWay
					});
				}
			}
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x0004DCDC File Offset: 0x0004BEDC
		private static void OnTextProxyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			d.SetCurrentValue(TextBlock.TextProperty, TextBlock.<OnTextProxyChanged>g__Format|7_0((string)e.NewValue, TextBlock.GetCharacterCasing(d)));
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x0004DD00 File Offset: 0x0004BF00
		private static void OnTextRunChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			d.SetCurrentValue(Run.TextProperty, TextBlock.<OnTextRunChanged>g__Format|8_0((string)e.NewValue, TextBlock.GetCharacterCasing(d)));
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x0004DDF0 File Offset: 0x0004BFF0
		[CompilerGenerated]
		internal static string <OnTextProxyChanged>g__Format|7_0(string text, CharacterCasing casing)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			switch (casing)
			{
			case CharacterCasing.Normal:
				return text;
			case CharacterCasing.Lower:
				return text.ToLower();
			case CharacterCasing.Upper:
				return text.ToUpper();
			default:
				throw new ArgumentOutOfRangeException("casing", casing, null);
			}
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x0004DE3C File Offset: 0x0004C03C
		[CompilerGenerated]
		internal static string <OnTextRunChanged>g__Format|8_0(string text, CharacterCasing casing)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			switch (casing)
			{
			case CharacterCasing.Normal:
				return text;
			case CharacterCasing.Lower:
				return text.ToLower();
			case CharacterCasing.Upper:
				return text.ToUpper();
			default:
				throw new ArgumentOutOfRangeException("casing", casing, null);
			}
		}

		// Token: 0x0400076D RID: 1901
		public static readonly DependencyProperty CharacterCasingProperty = DependencyProperty.RegisterAttached("CharacterCasing", typeof(CharacterCasing), typeof(TextBlock), new FrameworkPropertyMetadata(CharacterCasing.Normal, FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.NotDataBindable, new PropertyChangedCallback(TextBlock.OnCharacterCasingChanged)));

		// Token: 0x0400076E RID: 1902
		private static readonly DependencyProperty TextProxyProperty = DependencyProperty.RegisterAttached("TextProxy", typeof(string), typeof(TextBlock), new PropertyMetadata(null, new PropertyChangedCallback(TextBlock.OnTextProxyChanged)));

		// Token: 0x0400076F RID: 1903
		private static readonly DependencyProperty TextRunProperty = DependencyProperty.RegisterAttached("TextRun", typeof(string), typeof(Run), new PropertyMetadata(null, new PropertyChangedCallback(TextBlock.OnTextRunChanged)));

		// Token: 0x04000770 RID: 1904
		private static readonly PropertyPath TextPropertyPath = new PropertyPath("Text", Array.Empty<object>());
	}
}
