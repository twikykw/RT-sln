using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace RustTweaker
{
	// Token: 0x02000009 RID: 9
	public partial class NotificationForm : Form
	{
		// Token: 0x0600004B RID: 75 RVA: 0x00007918 File Offset: 0x00005B18
		public NotificationForm(string message, int duration = 1000)
		{
			this.InitializeComponent();
			Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
			base.Location = new Point((workingArea.Width - base.Width) / 2, workingArea.Height - 100);
			this.label1.Text = message;
			this.timer = new Timer();
			this.timer.Interval = duration;
			this.timer.Tick += delegate(object s, EventArgs e)
			{
				this.timer.Stop();
				base.Close();
			};
			this.timer = this.timer;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000079B5 File Offset: 0x00005BB5
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			this.timer.Start();
		}

		// Token: 0x0400004B RID: 75
		private Timer timer;
	}
}
