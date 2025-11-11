using System;

namespace RustTweaker.Services
{
	// Token: 0x0200000E RID: 14
	public static class NotificationService
	{
		// Token: 0x06000065 RID: 101 RVA: 0x00008768 File Offset: 0x00006968
		public static void ShowNotification(string text, int duration = 1000)
		{
			NotificationForm notificationForm = new NotificationForm(text, duration);
			notificationForm.Show();
		}
	}
}
