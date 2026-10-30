using System;
using System.Windows;
using System.Windows.Data;
using Microsoft.Xaml.Behaviors;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001F0 RID: 496
	public static class BehaviorsExtension
	{
		// Token: 0x06001019 RID: 4121 RVA: 0x0004E054 File Offset: 0x0004C254
		public static void SetTrigger(this UIElement control, string commandName, string eventName, object commandParameter = null)
		{
			InvokeCommandAction invokeCommandAction = new InvokeCommandAction
			{
				CommandParameter = commandParameter
			};
			Binding binding = new Binding
			{
				Path = new PropertyPath(commandName, Array.Empty<object>())
			};
			BindingOperations.SetBinding(invokeCommandAction, InvokeCommandAction.CommandProperty, binding);
			EventTrigger eventTrigger = new EventTrigger
			{
				EventName = eventName
			};
			eventTrigger.Actions.Add(invokeCommandAction);
			Interaction.GetTriggers(control).Add(eventTrigger);
		}
	}
}
