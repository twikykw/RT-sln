namespace RustTweaker
{
	// Token: 0x02000009 RID: 9
	public partial class NotificationForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600004D RID: 77 RVA: 0x000079CC File Offset: 0x00005BCC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00007A04 File Offset: 0x00005C04
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.guna2BorderlessForm1.BorderRadius = 20;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			this.guna2BorderlessForm1.DragForm = false;
			this.guna2BorderlessForm1.HasFormShadow = false;
			this.guna2BorderlessForm1.ResizeForm = false;
			this.guna2BorderlessForm1.TransparentWhileDrag = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(247, 92);
			this.label1.TabIndex = 0;
			this.label1.Text = "label";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = global::System.Drawing.Color.FromArgb(42, 42, 42);
			base.ClientSize = new global::System.Drawing.Size(271, 110);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "NotificationForm";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NotificationForm";
			base.TopMost = true;
			base.ResumeLayout(false);
		}

		// Token: 0x0400004C RID: 76
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400004D RID: 77
		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.Label label1;
	}
}
