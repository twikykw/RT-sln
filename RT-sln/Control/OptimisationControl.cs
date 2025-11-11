using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace RustTweaker.Control
{
	// Token: 0x02000010 RID: 16
	public class OptimisationControl : UserControl
	{
		// Token: 0x0600006B RID: 107 RVA: 0x00008FBF File Offset: 0x000071BF
		public OptimisationControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00008FD8 File Offset: 0x000071D8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00009010 File Offset: 0x00007210
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(OptimisationControl));
			this.label1 = new Label();
			this.guna2PictureBox1 = new Guna2PictureBox();
			((ISupportInitialize)this.guna2PictureBox1).BeginInit();
			base.SuspendLayout();
			this.label1.BackColor = Color.Transparent;
			this.label1.Font = new Font("Segoe UI", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label1.ForeColor = Color.White;
			this.label1.Location = new Point(52, 295);
			this.label1.Name = "label1";
			this.label1.Size = new Size(578, 60);
			this.label1.TabIndex = 0;
			this.label1.Text = "Данная вкладка находится в разработке и разблокируется\r\nв следующих версиях программы";
			this.label1.TextAlign = ContentAlignment.MiddleCenter;
			this.guna2PictureBox1.BackColor = Color.Transparent;
			this.guna2PictureBox1.FillColor = Color.Transparent;
			this.guna2PictureBox1.Image = (Image)componentResourceManager.GetObject("guna2PictureBox1.Image");
			this.guna2PictureBox1.ImageRotate = 0f;
			this.guna2PictureBox1.InitialImage = (Image)componentResourceManager.GetObject("guna2PictureBox1.InitialImage");
			this.guna2PictureBox1.Location = new Point(300, 209);
			this.guna2PictureBox1.Name = "guna2PictureBox1";
			this.guna2PictureBox1.Size = new Size(83, 83);
			this.guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			this.guna2PictureBox1.TabIndex = 0;
			this.guna2PictureBox1.TabStop = false;
			this.guna2PictureBox1.UseTransparentBackground = true;
			base.AutoScaleDimensions = new SizeF(96f, 96f);
			base.AutoScaleMode = AutoScaleMode.Dpi;
			this.BackColor = Color.FromArgb(54, 54, 54);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.guna2PictureBox1);
			this.Font = new Font("Segoe UI", 12f);
			base.Name = "OptimisationControl";
			base.Size = new Size(683, 564);
			((ISupportInitialize)this.guna2PictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000062 RID: 98
		private IContainer components = null;

		// Token: 0x04000063 RID: 99
		private Label label1;

		// Token: 0x04000064 RID: 100
		private Guna2PictureBox guna2PictureBox1;
	}
}
