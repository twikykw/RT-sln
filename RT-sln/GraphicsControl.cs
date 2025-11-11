using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace RustTweaker
{
	// Token: 0x02000008 RID: 8
	public class GraphicsControl : UserControl
	{
		// Token: 0x06000048 RID: 72 RVA: 0x00007590 File Offset: 0x00005790
		public GraphicsControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000075A8 File Offset: 0x000057A8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000075E0 File Offset: 0x000057E0
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GraphicsControl));
			this.GraphicsControlContainer = new Panel();
			this.label1 = new Label();
			this.guna2PictureBox1 = new Guna2PictureBox();
			this.GraphicsControlContainer.SuspendLayout();
			((ISupportInitialize)this.guna2PictureBox1).BeginInit();
			base.SuspendLayout();
			this.GraphicsControlContainer.Controls.Add(this.guna2PictureBox1);
			this.GraphicsControlContainer.Controls.Add(this.label1);
			this.GraphicsControlContainer.Dock = DockStyle.Fill;
			this.GraphicsControlContainer.Location = new Point(0, 0);
			this.GraphicsControlContainer.Name = "GraphicsControlContainer";
			this.GraphicsControlContainer.Padding = new Padding(100, 32, 100, 32);
			this.GraphicsControlContainer.Size = new Size(683, 564);
			this.GraphicsControlContainer.TabIndex = 7;
			this.label1.BackColor = Color.Transparent;
			this.label1.Font = new Font("Segoe UI", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
			this.label1.ForeColor = Color.White;
			this.label1.Location = new Point(52, 295);
			this.label1.Name = "label1";
			this.label1.Size = new Size(578, 36);
			this.label1.TabIndex = 1;
			this.label1.Text = "Данная вкладка доступна в полной версии программы";
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
			this.guna2PictureBox1.TabIndex = 3;
			this.guna2PictureBox1.TabStop = false;
			this.guna2PictureBox1.UseTransparentBackground = true;
			base.AutoScaleDimensions = new SizeF(96f, 96f);
			base.AutoScaleMode = AutoScaleMode.Dpi;
			this.BackColor = Color.FromArgb(54, 54, 54);
			base.Controls.Add(this.GraphicsControlContainer);
			this.Font = new Font("Segoe UI", 12f);
			base.Margin = new Padding(20);
			base.Name = "GraphicsControl";
			base.Size = new Size(683, 564);
			this.GraphicsControlContainer.ResumeLayout(false);
			((ISupportInitialize)this.guna2PictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000047 RID: 71
		private IContainer components = null;

		// Token: 0x04000048 RID: 72
		private Panel GraphicsControlContainer;

		// Token: 0x04000049 RID: 73
		private Label label1;

		// Token: 0x0400004A RID: 74
		private Guna2PictureBox guna2PictureBox1;
	}
}
