using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using RustTweaker.Services;

namespace RustTweaker.Control
{
	// Token: 0x0200000F RID: 15
	public class LaunchOptions : UserControl
	{
		// Token: 0x06000066 RID: 102 RVA: 0x00008785 File Offset: 0x00006985
		public LaunchOptions(int mode)
		{
			this.InitializeComponent();
			this._mode = mode;
			this.graphicsShadowmode.Text = string.Format("-graphics.shadowmode {0}", this._mode);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000087C8 File Offset: 0x000069C8
		private void CopyInBuffer_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(string.Format("-graphics.shadowmode {0}", this._mode));
			NotificationService.ShowNotification("Параметр запуска успешно скопирован", 1000);
			try
			{
				Process.Start("steam://nav/games/details/252490");
			}
			catch (Exception ex)
			{
				NotificationService.ShowNotification("Ошибка при запуске клиента Steam - " + ex.Message, 1000);
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00008840 File Offset: 0x00006A40
		private void guna2PictureBox1_Click(object sender, EventArgs e)
		{
			GraphicsControl value = new GraphicsControl();
			this.guna2Panel1.Controls.Clear();
			this.guna2Panel1.Controls.Add(value);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00008878 File Offset: 0x00006A78
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000088B0 File Offset: 0x00006AB0
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(LaunchOptions));
			this.CopyAndOpenBtn = new Guna2Button();
			this.ShadowQualityText = new Label();
			this.guna2Panel1 = new Guna2Panel();
			this.guna2PictureBox1 = new Guna2PictureBox();
			this.label1 = new Label();
			this.guna2Panel2 = new Guna2Panel();
			this.graphicsShadowmode = new Label();
			this.guna2Panel1.SuspendLayout();
			((ISupportInitialize)this.guna2PictureBox1).BeginInit();
			this.guna2Panel2.SuspendLayout();
			base.SuspendLayout();
			this.CopyAndOpenBtn.BorderColor = Color.Transparent;
			this.CopyAndOpenBtn.BorderRadius = 3;
			this.CopyAndOpenBtn.Cursor = Cursors.Hand;
			this.CopyAndOpenBtn.DisabledState.BorderColor = Color.DarkGray;
			this.CopyAndOpenBtn.DisabledState.CustomBorderColor = Color.DarkGray;
			this.CopyAndOpenBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.CopyAndOpenBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.CopyAndOpenBtn.FillColor = Color.FromArgb(106, 106, 106);
			this.CopyAndOpenBtn.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
			this.CopyAndOpenBtn.ForeColor = Color.White;
			this.CopyAndOpenBtn.HoverState.FillColor = Color.FromArgb(253, 253, 48);
			this.CopyAndOpenBtn.HoverState.ForeColor = Color.FromArgb(64, 64, 64);
			this.CopyAndOpenBtn.Location = new Point(220, 341);
			this.CopyAndOpenBtn.Name = "CopyAndOpenBtn";
			this.CopyAndOpenBtn.Size = new Size(243, 54);
			this.CopyAndOpenBtn.TabIndex = 17;
			this.CopyAndOpenBtn.Text = "Скопировать и открыть Steam";
			this.CopyAndOpenBtn.Click += this.CopyInBuffer_Click;
			this.ShadowQualityText.AutoSize = true;
			this.ShadowQualityText.Font = new Font("Segoe UI", 11f);
			this.ShadowQualityText.ForeColor = Color.White;
			this.ShadowQualityText.Location = new Point(122, 47);
			this.ShadowQualityText.Name = "ShadowQualityText";
			this.ShadowQualityText.Size = new Size(439, 120);
			this.ShadowQualityText.TabIndex = 16;
			this.ShadowQualityText.Text = "Для правильного отображения теней необходимо добавить \r\nв параметры запуска данный параметр:\r\n\r\n\r\nНикакие другие параметры запуска мы настоятельно \r\nрекомендуем не использовать";
			this.ShadowQualityText.TextAlign = ContentAlignment.MiddleCenter;
			this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
			this.guna2Panel1.Controls.Add(this.CopyAndOpenBtn);
			this.guna2Panel1.Controls.Add(this.label1);
			this.guna2Panel1.Controls.Add(this.guna2Panel2);
			this.guna2Panel1.Dock = DockStyle.Fill;
			this.guna2Panel1.Location = new Point(0, 0);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Padding = new Padding(0, 150, 0, 150);
			this.guna2Panel1.Size = new Size(683, 564);
			this.guna2Panel1.TabIndex = 19;
			this.guna2PictureBox1.BackColor = Color.Transparent;
			this.guna2PictureBox1.Image = (Image)componentResourceManager.GetObject("guna2PictureBox1.Image");
			this.guna2PictureBox1.ImageRotate = 0f;
			this.guna2PictureBox1.Location = new Point(650, 12);
			this.guna2PictureBox1.Name = "guna2PictureBox1";
			this.guna2PictureBox1.Size = new Size(21, 20);
			this.guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			this.guna2PictureBox1.TabIndex = 22;
			this.guna2PictureBox1.TabStop = false;
			this.guna2PictureBox1.UseTransparentBackground = true;
			this.guna2PictureBox1.Click += this.guna2PictureBox1_Click;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Segoe UI Semibold", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
			this.label1.Location = new Point(231, 160);
			this.label1.Name = "label1";
			this.label1.Size = new Size(221, 25);
			this.label1.TabIndex = 20;
			this.label1.Text = "Настройки применены!";
			this.guna2Panel2.Controls.Add(this.graphicsShadowmode);
			this.guna2Panel2.Controls.Add(this.ShadowQualityText);
			this.guna2Panel2.Dock = DockStyle.Fill;
			this.guna2Panel2.Location = new Point(0, 150);
			this.guna2Panel2.Name = "guna2Panel2";
			this.guna2Panel2.Size = new Size(683, 264);
			this.guna2Panel2.TabIndex = 21;
			this.graphicsShadowmode.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
			this.graphicsShadowmode.ForeColor = Color.FromArgb(253, 253, 48);
			this.graphicsShadowmode.Location = new Point(212, 92);
			this.graphicsShadowmode.Name = "graphicsShadowmode";
			this.graphicsShadowmode.Size = new Size(259, 28);
			this.graphicsShadowmode.TabIndex = 19;
			this.graphicsShadowmode.Text = "label1";
			this.graphicsShadowmode.TextAlign = ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new SizeF(96f, 96f);
			base.AutoScaleMode = AutoScaleMode.Dpi;
			this.BackColor = Color.FromArgb(54, 54, 54);
			base.Controls.Add(this.guna2Panel1);
			this.Font = new Font("Segoe UI", 12f);
			this.ForeColor = Color.White;
			base.Name = "LaunchOptions";
			base.Size = new Size(683, 564);
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			((ISupportInitialize)this.guna2PictureBox1).EndInit();
			this.guna2Panel2.ResumeLayout(false);
			this.guna2Panel2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000059 RID: 89
		private readonly int _mode;

		// Token: 0x0400005A RID: 90
		private IContainer components = null;

		// Token: 0x0400005B RID: 91
		private Guna2Button CopyAndOpenBtn;

		// Token: 0x0400005C RID: 92
		private Label ShadowQualityText;

		// Token: 0x0400005D RID: 93
		private Guna2Panel guna2Panel1;

		// Token: 0x0400005E RID: 94
		private Label graphicsShadowmode;

		// Token: 0x0400005F RID: 95
		private Label label1;

		// Token: 0x04000060 RID: 96
		private Guna2Panel guna2Panel2;

		// Token: 0x04000061 RID: 97
		private Guna2PictureBox guna2PictureBox1;
	}
}
