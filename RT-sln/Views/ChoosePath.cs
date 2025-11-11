using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace RustTweaker.Views
{
	// Token: 0x0200000D RID: 13
	public partial class ChoosePath : Form
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00007CDD File Offset: 0x00005EDD
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00007CE5 File Offset: 0x00005EE5
		public string SelectedPath { get; private set; }

		// Token: 0x0600005C RID: 92 RVA: 0x00007CF0 File Offset: 0x00005EF0
		public ChoosePath(List<string> foundPaths)
		{
			this.InitializeComponent();
			this.SetupListBoxColors();
			base.AcceptButton = this.OKbutton;
			base.CancelButton = this.CancelBtn;
			this.OKbutton.Click += this.OKbutton_Click;
			this.CancelBtn.Click += this.CancelBtn_Click;
			this.PopulateListBox(foundPaths);
			base.FormClosing += this.ChoosePath_FormClosing;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00007D80 File Offset: 0x00005F80
		private void PopulateListBox(List<string> foundPaths)
		{
			this.RustPathListBox.Items.Clear();
			foreach (string item in foundPaths)
			{
				this.RustPathListBox.Items.Add(item);
			}
			bool flag = this.RustPathListBox.Items.Count > 0;
			if (flag)
			{
				this.RustPathListBox.SelectedIndex = 0;
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00007E14 File Offset: 0x00006014
		private void OKbutton_Click(object sender, EventArgs e)
		{
			this.SelectedPath = (this.RustPathListBox.SelectedItem as string);
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00007E3D File Offset: 0x0000603D
		private void CancelBtn_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00007E50 File Offset: 0x00006050
		private void ChoosePath_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool flag = base.DialogResult == DialogResult.OK && this.SelectedPath == null;
			if (flag)
			{
				this.SelectedPath = (this.RustPathListBox.SelectedItem as string);
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00007E90 File Offset: 0x00006090
		private void SetupListBoxColors()
		{
			this.RustPathListBox.BackColor = Color.FromArgb(45, 45, 48);
			this.RustPathListBox.ForeColor = Color.White;
			this.RustPathListBox.DrawMode = DrawMode.OwnerDrawFixed;
			this.RustPathListBox.DrawItem += this.ListBox1_DrawItem;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00007EEC File Offset: 0x000060EC
		private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			Color color = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? Color.FromArgb(45, 45, 48) : listBox.BackColor;
			Color color2 = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? Color.FromArgb(253, 253, 48) : listBox.ForeColor;
			using (Brush brush = new SolidBrush(color))
			{
				using (Brush brush2 = new SolidBrush(color2))
				{
					e.Graphics.FillRectangle(brush, e.Bounds);
					bool flag = e.Index >= 0 && e.Index < listBox.Items.Count;
					if (flag)
					{
						string text = listBox.Items[e.Index].ToString();
						bool flag2 = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
						if (flag2)
						{
							string text2 = "✓";
							using (Font font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Bold))
							{
								SizeF sizeF = e.Graphics.MeasureString(text2, font);
								float y = (float)e.Bounds.Y + ((float)e.Bounds.Height - sizeF.Height) / 2f;
								e.Graphics.DrawString(text2, font, brush2, (float)(e.Bounds.X + 2), y);
							}
						}
						SizeF sizeF2 = e.Graphics.MeasureString(text, e.Font);
						float y2 = (float)e.Bounds.Y + ((float)e.Bounds.Height - sizeF2.Height) / 2f;
						e.Graphics.DrawString(text, e.Font, brush2, (float)(e.Bounds.X + 20), y2);
					}
				}
			}
		}
	}
}
