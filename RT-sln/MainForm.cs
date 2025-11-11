using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using RustTweaker.Control;

namespace RustTweaker
{
	// Token: 0x02000007 RID: 7
	public partial class MainForm : Form
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00005CF2 File Offset: 0x00003EF2
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00005CF9 File Offset: 0x00003EF9
		public static MainForm Instance { get; private set; }

		// Token: 0x0600003A RID: 58 RVA: 0x00005D04 File Offset: 0x00003F04
		public MainForm()
		{
			this.InitializeComponent();
			MainForm.Instance = this;
			this.LoadUserControls(new ConfigContol());
			this.InitializeCustomLabels();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00005D54 File Offset: 0x00003F54
		public void LoadUserControls(UserControl uc)
		{
			this.MainPanel.Controls.Clear();
			uc.Dock = DockStyle.Fill;
			TweakControl tweakControl = uc as TweakControl;
			bool flag = tweakControl != null;
			if (flag)
			{
				tweakControl.OnHoverDescriptionChange = delegate(string text)
				{
					bool flag6 = this.TextInfoLabel != null;
					if (flag6)
					{
						this.TextInfoLabel.Text = (text ?? "");
						this.TextInfoLabel.Visible = !string.IsNullOrEmpty(text);
					}
				};
			}
			else
			{
				bool flag2 = this.TextInfoLabel != null;
				if (flag2)
				{
					this.TextInfoLabel.Visible = false;
					this.TextInfoLabel.Text = "Поле информации";
				}
			}
			ConfigContol configContol = uc as ConfigContol;
			bool flag3 = configContol != null;
			if (flag3)
			{
				configContol.OnHoverDescriptionChange = delegate(string text)
				{
					bool flag6 = this.TextInfoLabel != null;
					if (flag6)
					{
						this.TextInfoLabel.Text = (text ?? "");
						this.TextInfoLabel.Visible = !string.IsNullOrEmpty(text);
					}
				};
			}
			ToolsControl toolsControl = uc as ToolsControl;
			bool flag4 = toolsControl != null;
			if (flag4)
			{
				toolsControl.OnHoverDescriptionChange = delegate(string text)
				{
					bool flag6 = this.TextInfoLabel != null;
					if (flag6)
					{
						this.TextInfoLabel.Text = (text ?? "");
						this.TextInfoLabel.Visible = !string.IsNullOrEmpty(text);
					}
				};
			}
			else
			{
				bool flag5 = this.TextInfoLabel != null;
				if (flag5)
				{
					this.TextInfoLabel.Visible = false;
					this.TextInfoLabel.Text = "Поле информации";
				}
			}
			this.MainPanel.Controls.Add(uc);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005E60 File Offset: 0x00004060
		private void InitializeCustomLabels()
		{
			this.allLabels.AddRange(new Label[]
			{
				this.ConfigLabel,
				this.TweakLabel,
				this.OptimisationLabel,
				this.GraphicsLabel,
				this.BindsLabel,
				this.ToolsLabel,
				this.versionLabel
			});
			foreach (Label label in this.allLabels)
			{
				label.ForeColor = Color.LightGray;
				label.TextAlign = ContentAlignment.MiddleCenter;
				label.Cursor = Cursors.Hand;
				label.MouseEnter += this.Label_MouseEnter;
				label.MouseLeave += this.Label_MouseLeave;
				label.Click += this.Label_Click;
			}
			this.SetActiveLabel(this.ConfigLabel);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00005F6C File Offset: 0x0000416C
		private void Label_MouseEnter(object sender, EventArgs e)
		{
			Label label = sender as Label;
			bool flag = label != null && label != this.activeLabel;
			if (flag)
			{
				label.ForeColor = Color.White;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005FA8 File Offset: 0x000041A8
		private void Label_MouseLeave(object sender, EventArgs e)
		{
			Label label = sender as Label;
			bool flag = label != null && label != this.activeLabel;
			if (flag)
			{
				label.ForeColor = Color.LightGray;
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005FE4 File Offset: 0x000041E4
		private void Label_Click(object sender, EventArgs e)
		{
			Label label = sender as Label;
			bool flag = label != null;
			if (flag)
			{
				this.SetActiveLabel(label);
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000600C File Offset: 0x0000420C
		private void SetActiveLabel(Label newActiveLabel)
		{
			bool flag = newActiveLabel == this.activeLabel;
			if (!flag)
			{
				bool flag2 = this.activeLabel != null;
				if (flag2)
				{
					this.activeLabel.ForeColor = Color.LightGray;
				}
				this.activeLabel = newActiveLabel;
				this.activeLabel.ForeColor = Color.FromArgb(253, 253, 48);
				this.HandleLabelSelection(this.activeLabel);
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000607C File Offset: 0x0000427C
		private void HandleLabelSelection(Label selectedLabel)
		{
			string name = selectedLabel.Name;
			string a = name;
			if (!(a == "ConfigLabel"))
			{
				if (!(a == "TweakLabel"))
				{
					if (!(a == "OptimisationLabel"))
					{
						if (!(a == "GraphicsLabel"))
						{
							if (!(a == "BindsLabel"))
							{
								if (a == "ToolsLabel")
								{
									this.LoadUserControls(new ToolsControl());
								}
							}
							else
							{
								this.LoadUserControls(new OptimisationControl());
							}
						}
						else
						{
							this.LoadUserControls(new GraphicsControl());
						}
					}
					else
					{
						this.LoadUserControls(new OptimisationControl());
					}
				}
				else
				{
					this.LoadUserControls(new TweakControl());
				}
			}
			else
			{
				this.LoadUserControls(new ConfigContol());
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00006137 File Offset: 0x00004337
		private void versionLabel_Click(object sender, EventArgs e)
		{
			Process.Start("https://rusttweaker.com/profile");
		}

		// Token: 0x04000028 RID: 40
		private Label activeLabel = null;

		// Token: 0x04000029 RID: 41
		public List<Label> allLabels = new List<Label>();
	}
}
