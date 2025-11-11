namespace RustTweaker
{
	// Token: 0x02000007 RID: 7
	public partial class MainForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000043 RID: 67 RVA: 0x00006148 File Offset: 0x00004348
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00006180 File Offset: 0x00004380
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::RustTweaker.MainForm));
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.TopPanel = new global::Guna.UI2.WinForms.Guna2Panel();
			this.guna2PictureBox1 = new global::Guna.UI2.WinForms.Guna2PictureBox();
			this.MinBox = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.CloseBox = new global::Guna.UI2.WinForms.Guna2ControlBox();
			this.ProgramName = new global::System.Windows.Forms.Label();
			this.DragControl = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.Container = new global::Guna.UI2.WinForms.Guna2Panel();
			this.MainPanel = new global::Guna.UI2.WinForms.Guna2Panel();
			this.MenuPanel = new global::Guna.UI2.WinForms.Guna2Panel();
			this.ToolsLabel = new global::System.Windows.Forms.Label();
			this.BindsLabel = new global::System.Windows.Forms.Label();
			this.GraphicsLabel = new global::System.Windows.Forms.Label();
			this.OptimisationLabel = new global::System.Windows.Forms.Label();
			this.TweakLabel = new global::System.Windows.Forms.Label();
			this.ConfigLabel = new global::System.Windows.Forms.Label();
			this.guna2Panel6 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.guna2Panel5 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.guna2Panel4 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.guna2Panel3 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.guna2Panel2 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.guna2Panel1 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.versionLabel = new global::System.Windows.Forms.Label();
			this.TextInfoLabel = new global::System.Windows.Forms.Label();
			this.guna2DragControl1 = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2DragControl2 = new global::Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.label1 = new global::System.Windows.Forms.Label();
			this.TopPanel.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.guna2PictureBox1).BeginInit();
			this.Container.SuspendLayout();
			this.MenuPanel.SuspendLayout();
			this.guna2Panel1.SuspendLayout();
			base.SuspendLayout();
			this.guna2BorderlessForm1.BorderRadius = 15;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			this.guna2BorderlessForm1.HasFormShadow = false;
			this.guna2BorderlessForm1.ResizeForm = false;
			this.guna2BorderlessForm1.TransparentWhileDrag = true;
			this.TopPanel.Controls.Add(this.guna2PictureBox1);
			this.TopPanel.Controls.Add(this.MinBox);
			this.TopPanel.Controls.Add(this.CloseBox);
			this.TopPanel.Controls.Add(this.ProgramName);
			this.TopPanel.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.TopPanel.FillColor = global::System.Drawing.Color.FromArgb(106, 106, 106);
			this.TopPanel.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.TopPanel.Location = new global::System.Drawing.Point(0, 0);
			this.TopPanel.Name = "TopPanel";
			this.TopPanel.Size = new global::System.Drawing.Size(960, 36);
			this.TopPanel.TabIndex = 0;
			this.guna2PictureBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2PictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("guna2PictureBox1.Image");
			this.guna2PictureBox1.ImageRotate = 0f;
			this.guna2PictureBox1.Location = new global::System.Drawing.Point(12, 5);
			this.guna2PictureBox1.Name = "guna2PictureBox1";
			this.guna2PictureBox1.Size = new global::System.Drawing.Size(30, 27);
			this.guna2PictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.guna2PictureBox1.TabIndex = 0;
			this.guna2PictureBox1.TabStop = false;
			this.guna2PictureBox1.UseTransparentBackground = true;
			this.MinBox.ControlBoxType = global::Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
			this.MinBox.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.MinBox.FillColor = global::System.Drawing.Color.FromArgb(106, 106, 106);
			this.MinBox.HoverState.IconColor = global::System.Drawing.Color.FromArgb(253, 253, 48);
			this.MinBox.IconColor = global::System.Drawing.Color.White;
			this.MinBox.Location = new global::System.Drawing.Point(870, 0);
			this.MinBox.Name = "MinBox";
			this.MinBox.Size = new global::System.Drawing.Size(45, 36);
			this.MinBox.TabIndex = 2;
			this.CloseBox.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.CloseBox.FillColor = global::System.Drawing.Color.FromArgb(106, 106, 106);
			this.CloseBox.HoverState.IconColor = global::System.Drawing.Color.FromArgb(253, 253, 48);
			this.CloseBox.IconColor = global::System.Drawing.Color.White;
			this.CloseBox.Location = new global::System.Drawing.Point(915, 0);
			this.CloseBox.Name = "CloseBox";
			this.CloseBox.Size = new global::System.Drawing.Size(45, 36);
			this.CloseBox.TabIndex = 1;
			this.ProgramName.AutoSize = true;
			this.ProgramName.BackColor = global::System.Drawing.Color.Transparent;
			this.ProgramName.Font = new global::System.Drawing.Font("Segoe UI", 10f);
			this.ProgramName.ForeColor = global::System.Drawing.Color.White;
			this.ProgramName.Location = new global::System.Drawing.Point(43, 9);
			this.ProgramName.Name = "ProgramName";
			this.ProgramName.Size = new global::System.Drawing.Size(138, 19);
			this.ProgramName.TabIndex = 0;
			this.ProgramName.Text = "RustTweaker [DEMO]";
			this.DragControl.DockIndicatorTransparencyValue = 0.6;
			this.DragControl.TargetControl = this.TopPanel;
			this.DragControl.TransparentWhileDrag = false;
			this.Container.BackColor = global::System.Drawing.Color.FromArgb(42, 42, 42);
			this.Container.Controls.Add(this.MainPanel);
			this.Container.Controls.Add(this.MenuPanel);
			this.Container.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.Container.Location = new global::System.Drawing.Point(0, 36);
			this.Container.Name = "Container";
			this.Container.Size = new global::System.Drawing.Size(960, 564);
			this.Container.TabIndex = 1;
			this.MainPanel.BackColor = global::System.Drawing.Color.FromArgb(54, 54, 54);
			this.MainPanel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.MainPanel.ForeColor = global::System.Drawing.Color.White;
			this.MainPanel.Location = new global::System.Drawing.Point(277, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new global::System.Drawing.Size(683, 564);
			this.MainPanel.TabIndex = 1;
			this.MenuPanel.Controls.Add(this.ToolsLabel);
			this.MenuPanel.Controls.Add(this.BindsLabel);
			this.MenuPanel.Controls.Add(this.GraphicsLabel);
			this.MenuPanel.Controls.Add(this.OptimisationLabel);
			this.MenuPanel.Controls.Add(this.TweakLabel);
			this.MenuPanel.Controls.Add(this.ConfigLabel);
			this.MenuPanel.Controls.Add(this.guna2Panel6);
			this.MenuPanel.Controls.Add(this.guna2Panel5);
			this.MenuPanel.Controls.Add(this.guna2Panel4);
			this.MenuPanel.Controls.Add(this.guna2Panel3);
			this.MenuPanel.Controls.Add(this.guna2Panel2);
			this.MenuPanel.Controls.Add(this.guna2Panel1);
			this.MenuPanel.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.MenuPanel.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.MenuPanel.Location = new global::System.Drawing.Point(0, 0);
			this.MenuPanel.Name = "MenuPanel";
			this.MenuPanel.Padding = new global::System.Windows.Forms.Padding(20, 26, 20, 37);
			this.MenuPanel.Size = new global::System.Drawing.Size(277, 564);
			this.MenuPanel.TabIndex = 0;
			this.ToolsLabel.AutoSize = true;
			this.ToolsLabel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.ToolsLabel.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.ToolsLabel.Font = new global::System.Drawing.Font("Segoe UI", 16f);
			this.ToolsLabel.ForeColor = global::System.Drawing.Color.Silver;
			this.ToolsLabel.Location = new global::System.Drawing.Point(20, 176);
			this.ToolsLabel.Name = "ToolsLabel";
			this.ToolsLabel.Size = new global::System.Drawing.Size(150, 30);
			this.ToolsLabel.TabIndex = 10;
			this.ToolsLabel.Text = "Инструменты";
			this.BindsLabel.AutoSize = true;
			this.BindsLabel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.BindsLabel.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.BindsLabel.Font = new global::System.Drawing.Font("Segoe UI", 16f);
			this.BindsLabel.ForeColor = global::System.Drawing.Color.Silver;
			this.BindsLabel.Location = new global::System.Drawing.Point(20, 146);
			this.BindsLabel.Name = "BindsLabel";
			this.BindsLabel.Size = new global::System.Drawing.Size(80, 30);
			this.BindsLabel.TabIndex = 4;
			this.BindsLabel.Text = "Бинды";
			this.GraphicsLabel.AutoSize = true;
			this.GraphicsLabel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.GraphicsLabel.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.GraphicsLabel.Font = new global::System.Drawing.Font("Segoe UI", 16f);
			this.GraphicsLabel.ForeColor = global::System.Drawing.Color.Silver;
			this.GraphicsLabel.Location = new global::System.Drawing.Point(20, 116);
			this.GraphicsLabel.Name = "GraphicsLabel";
			this.GraphicsLabel.Size = new global::System.Drawing.Size(97, 30);
			this.GraphicsLabel.TabIndex = 3;
			this.GraphicsLabel.Text = "Графика";
			this.GraphicsLabel.Click += new global::System.EventHandler(this.Label_Click);
			this.OptimisationLabel.AutoSize = true;
			this.OptimisationLabel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.OptimisationLabel.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.OptimisationLabel.Font = new global::System.Drawing.Font("Segoe UI", 16f);
			this.OptimisationLabel.ForeColor = global::System.Drawing.Color.Silver;
			this.OptimisationLabel.Location = new global::System.Drawing.Point(20, 86);
			this.OptimisationLabel.Name = "OptimisationLabel";
			this.OptimisationLabel.Size = new global::System.Drawing.Size(151, 30);
			this.OptimisationLabel.TabIndex = 2;
			this.OptimisationLabel.Text = "Оптимизация";
			this.OptimisationLabel.Click += new global::System.EventHandler(this.Label_Click);
			this.TweakLabel.AutoSize = true;
			this.TweakLabel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.TweakLabel.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.TweakLabel.Font = new global::System.Drawing.Font("Segoe UI", 16f);
			this.TweakLabel.ForeColor = global::System.Drawing.Color.Silver;
			this.TweakLabel.Location = new global::System.Drawing.Point(20, 56);
			this.TweakLabel.Name = "TweakLabel";
			this.TweakLabel.Size = new global::System.Drawing.Size(74, 30);
			this.TweakLabel.TabIndex = 1;
			this.TweakLabel.Text = "Твики";
			this.TweakLabel.Click += new global::System.EventHandler(this.Label_Click);
			this.ConfigLabel.AutoSize = true;
			this.ConfigLabel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.ConfigLabel.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.ConfigLabel.Font = new global::System.Drawing.Font("Segoe UI", 16f);
			this.ConfigLabel.ForeColor = global::System.Drawing.Color.Silver;
			this.ConfigLabel.Location = new global::System.Drawing.Point(20, 26);
			this.ConfigLabel.Name = "ConfigLabel";
			this.ConfigLabel.Size = new global::System.Drawing.Size(88, 30);
			this.ConfigLabel.TabIndex = 0;
			this.ConfigLabel.Text = "Конфиг";
			this.ConfigLabel.Click += new global::System.EventHandler(this.Label_Click);
			this.guna2Panel6.Enabled = false;
			this.guna2Panel6.Location = new global::System.Drawing.Point(26, 185);
			this.guna2Panel6.Name = "guna2Panel6";
			this.guna2Panel6.Size = new global::System.Drawing.Size(139, 22);
			this.guna2Panel6.TabIndex = 11;
			this.guna2Panel5.Enabled = false;
			this.guna2Panel5.Location = new global::System.Drawing.Point(25, 152);
			this.guna2Panel5.Name = "guna2Panel5";
			this.guna2Panel5.Size = new global::System.Drawing.Size(69, 23);
			this.guna2Panel5.TabIndex = 9;
			this.guna2Panel4.Enabled = false;
			this.guna2Panel4.Location = new global::System.Drawing.Point(25, 122);
			this.guna2Panel4.Name = "guna2Panel4";
			this.guna2Panel4.Size = new global::System.Drawing.Size(83, 24);
			this.guna2Panel4.TabIndex = 8;
			this.guna2Panel3.Enabled = false;
			this.guna2Panel3.Location = new global::System.Drawing.Point(25, 92);
			this.guna2Panel3.Name = "guna2Panel3";
			this.guna2Panel3.Size = new global::System.Drawing.Size(137, 21);
			this.guna2Panel3.TabIndex = 7;
			this.guna2Panel2.Enabled = false;
			this.guna2Panel2.Location = new global::System.Drawing.Point(25, 62);
			this.guna2Panel2.Name = "guna2Panel2";
			this.guna2Panel2.Size = new global::System.Drawing.Size(63, 21);
			this.guna2Panel2.TabIndex = 6;
			this.guna2Panel1.Controls.Add(this.versionLabel);
			this.guna2Panel1.Controls.Add(this.TextInfoLabel);
			this.guna2Panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.guna2Panel1.Location = new global::System.Drawing.Point(20, 26);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new global::System.Drawing.Size(237, 501);
			this.guna2Panel1.TabIndex = 5;
			this.versionLabel.AutoSize = true;
			this.versionLabel.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.versionLabel.Font = new global::System.Drawing.Font("Segoe UI", 16f);
			this.versionLabel.ForeColor = global::System.Drawing.Color.Silver;
			this.versionLabel.Location = new global::System.Drawing.Point(0, 473);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new global::System.Drawing.Size(205, 30);
			this.versionLabel.TabIndex = 12;
			this.versionLabel.Text = "Бесплатная версия";
			this.versionLabel.Click += new global::System.EventHandler(this.versionLabel_Click);
			this.TextInfoLabel.BackColor = global::System.Drawing.Color.Transparent;
			this.TextInfoLabel.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.TextInfoLabel.ForeColor = global::System.Drawing.Color.White;
			this.TextInfoLabel.Location = new global::System.Drawing.Point(5, 268);
			this.TextInfoLabel.Margin = new global::System.Windows.Forms.Padding(0);
			this.TextInfoLabel.Name = "TextInfoLabel";
			this.TextInfoLabel.Size = new global::System.Drawing.Size(227, 181);
			this.TextInfoLabel.TabIndex = 0;
			this.TextInfoLabel.Text = "Поле информации";
			this.TextInfoLabel.Visible = false;
			this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
			this.guna2DragControl1.TargetControl = this.ProgramName;
			this.guna2DragControl1.TransparentWhileDrag = false;
			this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6;
			this.guna2DragControl2.TargetControl = this.guna2PictureBox1;
			this.guna2DragControl2.TransparentWhileDrag = false;
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.FromArgb(54, 54, 54);
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(910, 575);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(39, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "v.1.0.0";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new global::System.Drawing.Size(960, 600);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.Container);
			base.Controls.Add(this.TopPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "MainForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RustTweaker";
			this.TopPanel.ResumeLayout(false);
			this.TopPanel.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.guna2PictureBox1).EndInit();
			this.Container.ResumeLayout(false);
			this.MenuPanel.ResumeLayout(false);
			this.MenuPanel.PerformLayout();
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400002B RID: 43
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400002C RID: 44
		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

		// Token: 0x0400002D RID: 45
		private global::Guna.UI2.WinForms.Guna2Panel TopPanel;

		// Token: 0x0400002E RID: 46
		private global::Guna.UI2.WinForms.Guna2ControlBox MinBox;

		// Token: 0x0400002F RID: 47
		private global::Guna.UI2.WinForms.Guna2ControlBox CloseBox;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.Label ProgramName;

		// Token: 0x04000031 RID: 49
		private global::Guna.UI2.WinForms.Guna2DragControl DragControl;

		// Token: 0x04000032 RID: 50
		private new global::Guna.UI2.WinForms.Guna2Panel Container;

		// Token: 0x04000033 RID: 51
		private global::Guna.UI2.WinForms.Guna2Panel MenuPanel;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.Label ConfigLabel;

		// Token: 0x04000035 RID: 53
		private global::Guna.UI2.WinForms.Guna2Panel MainPanel;

		// Token: 0x04000036 RID: 54
		public global::System.Windows.Forms.Label TextInfoLabel;

		// Token: 0x04000037 RID: 55
		private global::Guna.UI2.WinForms.Guna2Panel guna2Panel1;

		// Token: 0x04000038 RID: 56
		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;

		// Token: 0x04000039 RID: 57
		private global::Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;

		// Token: 0x0400003A RID: 58
		public global::System.Windows.Forms.Label TweakLabel;

		// Token: 0x0400003B RID: 59
		public global::System.Windows.Forms.Label BindsLabel;

		// Token: 0x0400003C RID: 60
		public global::System.Windows.Forms.Label GraphicsLabel;

		// Token: 0x0400003D RID: 61
		public global::System.Windows.Forms.Label OptimisationLabel;

		// Token: 0x0400003E RID: 62
		public global::Guna.UI2.WinForms.Guna2Panel guna2Panel2;

		// Token: 0x0400003F RID: 63
		public global::Guna.UI2.WinForms.Guna2Panel guna2Panel3;

		// Token: 0x04000040 RID: 64
		public global::Guna.UI2.WinForms.Guna2Panel guna2Panel4;

		// Token: 0x04000041 RID: 65
		public global::Guna.UI2.WinForms.Guna2Panel guna2Panel5;

		// Token: 0x04000042 RID: 66
		public global::System.Windows.Forms.Label ToolsLabel;

		// Token: 0x04000043 RID: 67
		public global::Guna.UI2.WinForms.Guna2Panel guna2Panel6;

		// Token: 0x04000044 RID: 68
		private global::Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;

		// Token: 0x04000045 RID: 69
		public global::System.Windows.Forms.Label versionLabel;

		// Token: 0x04000046 RID: 70
		public global::System.Windows.Forms.Label label1;
	}
}
