namespace RustTweaker.Views
{
	// Token: 0x0200000D RID: 13
	public partial class ChoosePath : global::System.Windows.Forms.Form
	{
		// Token: 0x06000063 RID: 99 RVA: 0x00008138 File Offset: 0x00006338
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00008170 File Offset: 0x00006370
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.BorderlessForm = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.ChooseFolderLabel = new global::System.Windows.Forms.Label();
			this.RustPathListBox = new global::System.Windows.Forms.ListBox();
			this.OKbutton = new global::Guna.UI2.WinForms.Guna2Button();
			this.CancelBtn = new global::Guna.UI2.WinForms.Guna2Button();
			base.SuspendLayout();
			this.BorderlessForm.AnimateWindow = true;
			this.BorderlessForm.AnimationInterval = 250;
			this.BorderlessForm.BorderRadius = 15;
			this.BorderlessForm.ContainerControl = this;
			this.BorderlessForm.DockIndicatorTransparencyValue = 0.6;
			this.BorderlessForm.HasFormShadow = false;
			this.BorderlessForm.ResizeForm = false;
			this.BorderlessForm.TransparentWhileDrag = true;
			this.ChooseFolderLabel.AutoSize = true;
			this.ChooseFolderLabel.Location = new global::System.Drawing.Point(18, 13);
			this.ChooseFolderLabel.Name = "ChooseFolderLabel";
			this.ChooseFolderLabel.Size = new global::System.Drawing.Size(522, 21);
			this.ChooseFolderLabel.TabIndex = 0;
			this.ChooseFolderLabel.Text = "Обнаружено несколько папок с игрой. Выберите необходимый клиент:";
			this.RustPathListBox.BackColor = global::System.Drawing.Color.FromArgb(54, 54, 54);
			this.RustPathListBox.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.RustPathListBox.ForeColor = global::System.Drawing.Color.White;
			this.RustPathListBox.ItemHeight = 21;
			this.RustPathListBox.Location = new global::System.Drawing.Point(18, 52);
			this.RustPathListBox.Name = "RustPathListBox";
			this.RustPathListBox.Size = new global::System.Drawing.Size(647, 252);
			this.RustPathListBox.TabIndex = 1;
			this.RustPathListBox.TabStop = false;
			this.OKbutton.BackColor = global::System.Drawing.Color.Transparent;
			this.OKbutton.BorderColor = global::System.Drawing.Color.Transparent;
			this.OKbutton.BorderRadius = 3;
			this.OKbutton.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.OKbutton.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.OKbutton.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.OKbutton.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.OKbutton.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.OKbutton.FillColor = global::System.Drawing.Color.FromArgb(106, 106, 106);
			this.OKbutton.Font = new global::System.Drawing.Font("Segoe UI Semibold", 11f, global::System.Drawing.FontStyle.Bold);
			this.OKbutton.ForeColor = global::System.Drawing.Color.White;
			this.OKbutton.HoverState.FillColor = global::System.Drawing.Color.FromArgb(253, 253, 48);
			this.OKbutton.HoverState.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.OKbutton.Location = new global::System.Drawing.Point(197, 320);
			this.OKbutton.Name = "OKbutton";
			this.OKbutton.Size = new global::System.Drawing.Size(118, 42);
			this.OKbutton.TabIndex = 14;
			this.OKbutton.Text = "OK";
			this.CancelBtn.BorderColor = global::System.Drawing.Color.Transparent;
			this.CancelBtn.BorderRadius = 3;
			this.CancelBtn.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.CancelBtn.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.CancelBtn.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.CancelBtn.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.CancelBtn.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.CancelBtn.FillColor = global::System.Drawing.Color.FromArgb(106, 106, 106);
			this.CancelBtn.Font = new global::System.Drawing.Font("Segoe UI Semibold", 11f, global::System.Drawing.FontStyle.Bold);
			this.CancelBtn.ForeColor = global::System.Drawing.Color.White;
			this.CancelBtn.HoverState.FillColor = global::System.Drawing.Color.FromArgb(253, 253, 48);
			this.CancelBtn.HoverState.ForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.CancelBtn.Location = new global::System.Drawing.Point(367, 320);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new global::System.Drawing.Size(118, 42);
			this.CancelBtn.TabIndex = 15;
			this.CancelBtn.Text = "Отмена";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = global::System.Drawing.Color.FromArgb(42, 42, 42);
			base.ClientSize = new global::System.Drawing.Size(683, 380);
			base.Controls.Add(this.CancelBtn);
			base.Controls.Add(this.OKbutton);
			base.Controls.Add(this.RustPathListBox);
			base.Controls.Add(this.ChooseFolderLabel);
			this.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.ForeColor = global::System.Drawing.Color.White;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Margin = new global::System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "ChoosePath";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ChoosePath";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000053 RID: 83
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000054 RID: 84
		private global::Guna.UI2.WinForms.Guna2BorderlessForm BorderlessForm;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.Label ChooseFolderLabel;

		// Token: 0x04000056 RID: 86
		private global::System.Windows.Forms.ListBox RustPathListBox;

		// Token: 0x04000057 RID: 87
		private global::Guna.UI2.WinForms.Guna2Button CancelBtn;

		// Token: 0x04000058 RID: 88
		private global::Guna.UI2.WinForms.Guna2Button OKbutton;
	}
}
