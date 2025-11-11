using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace RustTweaker
{
	// Token: 0x02000006 RID: 6
	public class ToolsControl : UserControl
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000045B2 File Offset: 0x000027B2
		// (set) Token: 0x06000028 RID: 40 RVA: 0x000045BA File Offset: 0x000027BA
		public Action<string> OnHoverDescriptionChange { get; set; }

		// Token: 0x06000029 RID: 41 RVA: 0x000045C3 File Offset: 0x000027C3
		public ToolsControl()
		{
			this.InitializeComponent();
			this.HoverCombine();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000045E4 File Offset: 0x000027E4
		private void HoverLinkLabel(Guna2Button button, string description)
		{
			button.MouseEnter += delegate(object s, EventArgs e)
			{
				Action<string> onHoverDescriptionChange = this.OnHoverDescriptionChange;
				if (onHoverDescriptionChange != null)
				{
					onHoverDescriptionChange(description);
				}
			};
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000461C File Offset: 0x0000281C
		private void HoverCombine()
		{
			this.HoverLinkLabel(this.LinkButton1, "Полезная база данных по всем предметам, сооружениям и существам в игре. Позволяет быстро найти информацию о луте, стоимости разрушения, стоимости крафта, починки и разрушения предметов.");
			this.HoverLinkLabel(this.LinkButton2, "Википедия от разработчиков. Содержит много полезной информации для администраторов серверов и контентмейкеров.");
			this.HoverLinkLabel(this.LinkButton3, "Новости об игре, девблоги и комьюнити апдейты. Основной блог Facepunch");
			this.HoverLinkLabel(this.LinkButton4, "Удобный калькулятор рейда, позволяет просчитать необходимое количество взрывчатки на определенную базу, а также количество сырых ресурсов, нужное для крафта взрывчатки.");
			this.HoverLinkLabel(this.LinkButton5, "Самый удобный калькулятор для скрещивания семян. Умеет сам сканировать инвентарь игрока и подбирать оптимальные гены, исходя из имеющихся ростков.");
			this.HoverLinkLabel(this.LinkButton6, "Простой и удобный конструктор для электрических и индустриальных схем. Позволяет не только делиться схемами с друзьями, но и проверять их прямо в браузере.");
			this.HoverLinkLabel(this.LinkButton7, "Сайт для просмотра информации о серверах и игроках. Можно быстро найти IP любого сервера, проверить, как на нем держится онлайн, какие игроки в сети и какая карта установлена");
			this.HoverLinkLabel(this.LinkButton8, "Удобная и красивая карта любого сервера. Сервера, выделенные синим цветом, позволяют видеть себя на карте, а кнопка Mortality позволяет посмотреть локации, на которых чаще всего погибают игроки.");
			this.HoverLinkLabel(this.LinkButton9, "Инструмент для 3D визуализации монументов. Отображает точки спавна ящиков и бочек, NPC, а также зоны радиации");
			this.HoverLinkLabel(this.LinkButton10, "Простой инструмент, позволяющий быстро узнать стоимость предметов в инвентаре по своему SteamID. В последнее время работает с перебоями.");
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000046DE File Offset: 0x000028DE
		private void LinkButton1_Click(object sender, EventArgs e)
		{
			Process.Start("https://wiki.rustclash.com/");
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000046EC File Offset: 0x000028EC
		private void LinkButton2_Click(object sender, EventArgs e)
		{
			Process.Start("https://wiki.facepunch.com/rust/");
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000046FA File Offset: 0x000028FA
		private void LinkButton3_Click(object sender, EventArgs e)
		{
			Process.Start("https://rust.facepunch.com/news/");
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00004708 File Offset: 0x00002908
		private void LinkButton4_Click(object sender, EventArgs e)
		{
			Process.Start("https://rusttips.com/rust-raid-calculator/");
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00004716 File Offset: 0x00002916
		private void LinkButton5_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.rustbreeder.com/");
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00004724 File Offset: 0x00002924
		private void LinkButton6_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.rustrician.io/");
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00004732 File Offset: 0x00002932
		private void LinkButton7_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.battlemetrics.com/servers/rust");
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004740 File Offset: 0x00002940
		private void LinkButton8_Click(object sender, EventArgs e)
		{
			Process.Start("http://playrust.io/");
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000474E File Offset: 0x0000294E
		private void LinkButton9_Click(object sender, EventArgs e)
		{
			Process.Start("https://rustmaps.com/monuments");
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000475C File Offset: 0x0000295C
		private void LinkButton10_Click(object sender, EventArgs e)
		{
			Process.Start("https://steam.tools/itemvalue/");
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000476C File Offset: 0x0000296C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000047A4 File Offset: 0x000029A4
		private void InitializeComponent()
		{
			this.LinkButton1 = new Guna2Button();
			this.LinkButton2 = new Guna2Button();
			this.LinkButton3 = new Guna2Button();
			this.LinkButton4 = new Guna2Button();
			this.LinkButton5 = new Guna2Button();
			this.LinkButton10 = new Guna2Button();
			this.LinkButton9 = new Guna2Button();
			this.LinkButton8 = new Guna2Button();
			this.LinkButton7 = new Guna2Button();
			this.LinkButton6 = new Guna2Button();
			this.guna2Panel1 = new Guna2Panel();
			this.guna2Panel1.SuspendLayout();
			base.SuspendLayout();
			this.LinkButton1.Animated = true;
			this.LinkButton1.BackColor = Color.Transparent;
			this.LinkButton1.BorderColor = Color.Transparent;
			this.LinkButton1.BorderRadius = 6;
			this.LinkButton1.Cursor = Cursors.Hand;
			this.LinkButton1.DisabledState.BorderColor = Color.DarkGray;
			this.LinkButton1.DisabledState.CustomBorderColor = Color.DarkGray;
			this.LinkButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.LinkButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.LinkButton1.FillColor = Color.FromArgb(106, 106, 106);
			this.LinkButton1.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
			this.LinkButton1.ForeColor = Color.White;
			this.LinkButton1.HoverState.FillColor = Color.FromArgb(253, 253, 48);
			this.LinkButton1.HoverState.ForeColor = Color.FromArgb(64, 64, 64);
			this.LinkButton1.ImageAlign = HorizontalAlignment.Left;
			this.LinkButton1.ImageSize = new Size(30, 30);
			this.LinkButton1.Location = new Point(60, 0);
			this.LinkButton1.Name = "LinkButton1";
			this.LinkButton1.Size = new Size(263, 42);
			this.LinkButton1.TabIndex = 15;
			this.LinkButton1.Text = "Фанатская вики";
			this.LinkButton1.Click += this.LinkButton1_Click;
			this.LinkButton2.Animated = true;
			this.LinkButton2.BackColor = Color.Transparent;
			this.LinkButton2.BorderColor = Color.Transparent;
			this.LinkButton2.BorderRadius = 6;
			this.LinkButton2.Cursor = Cursors.Hand;
			this.LinkButton2.DisabledState.BorderColor = Color.DarkGray;
			this.LinkButton2.DisabledState.CustomBorderColor = Color.DarkGray;
			this.LinkButton2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.LinkButton2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.LinkButton2.FillColor = Color.FromArgb(106, 106, 106);
			this.LinkButton2.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
			this.LinkButton2.ForeColor = Color.White;
			this.LinkButton2.HoverState.FillColor = Color.FromArgb(253, 253, 48);
			this.LinkButton2.HoverState.ForeColor = Color.FromArgb(64, 64, 64);
			this.LinkButton2.ImageAlign = HorizontalAlignment.Left;
			this.LinkButton2.ImageSize = new Size(30, 30);
			this.LinkButton2.Location = new Point(60, 77);
			this.LinkButton2.Name = "LinkButton2";
			this.LinkButton2.Size = new Size(263, 42);
			this.LinkButton2.TabIndex = 16;
			this.LinkButton2.Text = "Официальная вики";
			this.LinkButton2.Click += this.LinkButton2_Click;
			this.LinkButton3.Animated = true;
			this.LinkButton3.BackColor = Color.Transparent;
			this.LinkButton3.BorderColor = Color.Transparent;
			this.LinkButton3.BorderRadius = 6;
			this.LinkButton3.Cursor = Cursors.Hand;
			this.LinkButton3.DisabledState.BorderColor = Color.DarkGray;
			this.LinkButton3.DisabledState.CustomBorderColor = Color.DarkGray;
			this.LinkButton3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.LinkButton3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.LinkButton3.FillColor = Color.FromArgb(106, 106, 106);
			this.LinkButton3.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
			this.LinkButton3.ForeColor = Color.White;
			this.LinkButton3.HoverState.FillColor = Color.FromArgb(253, 253, 48);
			this.LinkButton3.HoverState.ForeColor = Color.FromArgb(64, 64, 64);
			this.LinkButton3.ImageAlign = HorizontalAlignment.Left;
			this.LinkButton3.ImageSize = new Size(30, 30);
			this.LinkButton3.Location = new Point(60, 154);
			this.LinkButton3.Name = "LinkButton3";
			this.LinkButton3.Size = new Size(263, 42);
			this.LinkButton3.TabIndex = 17;
			this.LinkButton3.Text = "Официальный блог";
			this.LinkButton3.Click += this.LinkButton3_Click;
			this.LinkButton4.Animated = true;
			this.LinkButton4.BackColor = Color.Transparent;
			this.LinkButton4.BorderColor = Color.Transparent;
			this.LinkButton4.BorderRadius = 6;
			this.LinkButton4.Cursor = Cursors.Hand;
			this.LinkButton4.DisabledState.BorderColor = Color.DarkGray;
			this.LinkButton4.DisabledState.CustomBorderColor = Color.DarkGray;
			this.LinkButton4.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.LinkButton4.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.LinkButton4.FillColor = Color.FromArgb(106, 106, 106);
			this.LinkButton4.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
			this.LinkButton4.ForeColor = Color.White;
			this.LinkButton4.HoverState.FillColor = Color.FromArgb(253, 253, 48);
			this.LinkButton4.HoverState.ForeColor = Color.FromArgb(64, 64, 64);
			this.LinkButton4.ImageAlign = HorizontalAlignment.Left;
			this.LinkButton4.ImageSize = new Size(25, 30);
			this.LinkButton4.Location = new Point(60, 231);
			this.LinkButton4.Name = "LinkButton4";
			this.LinkButton4.Size = new Size(263, 42);
			this.LinkButton4.TabIndex = 18;
			this.LinkButton4.Text = "Калькулятор рейдов";
			this.LinkButton4.Click += this.LinkButton4_Click;
			this.LinkButton5.Animated = true;
			this.LinkButton5.BackColor = Color.Transparent;
			this.LinkButton5.BorderColor = Color.Transparent;
			this.LinkButton5.BorderRadius = 6;
			this.LinkButton5.Cursor = Cursors.Hand;
			this.LinkButton5.DisabledState.BorderColor = Color.DarkGray;
			this.LinkButton5.DisabledState.CustomBorderColor = Color.DarkGray;
			this.LinkButton5.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.LinkButton5.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.LinkButton5.FillColor = Color.FromArgb(106, 106, 106);
			this.LinkButton5.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
			this.LinkButton5.ForeColor = Color.White;
			this.LinkButton5.HoverState.FillColor = Color.FromArgb(253, 253, 48);
			this.LinkButton5.HoverState.ForeColor = Color.FromArgb(64, 64, 64);
			this.LinkButton5.ImageAlign = HorizontalAlignment.Left;
			this.LinkButton5.ImageSize = new Size(30, 30);
			this.LinkButton5.Location = new Point(60, 308);
			this.LinkButton5.Name = "LinkButton5";
			this.LinkButton5.Size = new Size(263, 42);
			this.LinkButton5.TabIndex = 19;
			this.LinkButton5.Text = "Калькулятор скрещивания";
			this.LinkButton5.Click += this.LinkButton5_Click;
			this.LinkButton10.Animated = true;
			this.LinkButton10.BackColor = Color.Transparent;
			this.LinkButton10.BorderColor = Color.Transparent;
			this.LinkButton10.BorderRadius = 6;
			this.LinkButton10.Cursor = Cursors.Hand;
			this.LinkButton10.DisabledState.BorderColor = Color.DarkGray;
			this.LinkButton10.DisabledState.CustomBorderColor = Color.DarkGray;
			this.LinkButton10.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.LinkButton10.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.LinkButton10.FillColor = Color.FromArgb(106, 106, 106);
			this.LinkButton10.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
			this.LinkButton10.ForeColor = Color.White;
			this.LinkButton10.HoverState.FillColor = Color.FromArgb(253, 253, 48);
			this.LinkButton10.HoverState.ForeColor = Color.FromArgb(64, 64, 64);
			this.LinkButton10.ImageAlign = HorizontalAlignment.Left;
			this.LinkButton10.ImageSize = new Size(30, 30);
			this.LinkButton10.Location = new Point(360, 308);
			this.LinkButton10.Name = "LinkButton10";
			this.LinkButton10.Size = new Size(263, 42);
			this.LinkButton10.TabIndex = 24;
			this.LinkButton10.Text = "Стоимость инвентаря";
			this.LinkButton10.Click += this.LinkButton10_Click;
			this.LinkButton9.Animated = true;
			this.LinkButton9.BackColor = Color.Transparent;
			this.LinkButton9.BorderColor = Color.Transparent;
			this.LinkButton9.BorderRadius = 6;
			this.LinkButton9.Cursor = Cursors.Hand;
			this.LinkButton9.DisabledState.BorderColor = Color.DarkGray;
			this.LinkButton9.DisabledState.CustomBorderColor = Color.DarkGray;
			this.LinkButton9.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.LinkButton9.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.LinkButton9.FillColor = Color.FromArgb(106, 106, 106);
			this.LinkButton9.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
			this.LinkButton9.ForeColor = Color.White;
			this.LinkButton9.HoverState.FillColor = Color.FromArgb(253, 253, 48);
			this.LinkButton9.HoverState.ForeColor = Color.FromArgb(64, 64, 64);
			this.LinkButton9.ImageAlign = HorizontalAlignment.Left;
			this.LinkButton9.ImageSize = new Size(30, 30);
			this.LinkButton9.Location = new Point(360, 231);
			this.LinkButton9.Name = "LinkButton9";
			this.LinkButton9.Size = new Size(263, 42);
			this.LinkButton9.TabIndex = 23;
			this.LinkButton9.Text = "3D монументы";
			this.LinkButton9.Click += this.LinkButton9_Click;
			this.LinkButton8.Animated = true;
			this.LinkButton8.BackColor = Color.Transparent;
			this.LinkButton8.BorderColor = Color.Transparent;
			this.LinkButton8.BorderRadius = 6;
			this.LinkButton8.Cursor = Cursors.Hand;
			this.LinkButton8.DisabledState.BorderColor = Color.DarkGray;
			this.LinkButton8.DisabledState.CustomBorderColor = Color.DarkGray;
			this.LinkButton8.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.LinkButton8.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.LinkButton8.FillColor = Color.FromArgb(106, 106, 106);
			this.LinkButton8.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
			this.LinkButton8.ForeColor = Color.White;
			this.LinkButton8.HoverState.FillColor = Color.FromArgb(253, 253, 48);
			this.LinkButton8.HoverState.ForeColor = Color.FromArgb(64, 64, 64);
			this.LinkButton8.ImageAlign = HorizontalAlignment.Left;
			this.LinkButton8.ImageSize = new Size(30, 30);
			this.LinkButton8.Location = new Point(360, 154);
			this.LinkButton8.Name = "LinkButton8";
			this.LinkButton8.Size = new Size(263, 42);
			this.LinkButton8.TabIndex = 22;
			this.LinkButton8.Text = "Интерактивная карта";
			this.LinkButton8.Click += this.LinkButton8_Click;
			this.LinkButton7.Animated = true;
			this.LinkButton7.BackColor = Color.Transparent;
			this.LinkButton7.BorderColor = Color.Transparent;
			this.LinkButton7.BorderRadius = 6;
			this.LinkButton7.Cursor = Cursors.Hand;
			this.LinkButton7.DisabledState.BorderColor = Color.DarkGray;
			this.LinkButton7.DisabledState.CustomBorderColor = Color.DarkGray;
			this.LinkButton7.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.LinkButton7.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.LinkButton7.FillColor = Color.FromArgb(106, 106, 106);
			this.LinkButton7.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
			this.LinkButton7.ForeColor = Color.White;
			this.LinkButton7.HoverState.FillColor = Color.FromArgb(253, 253, 48);
			this.LinkButton7.HoverState.ForeColor = Color.FromArgb(64, 64, 64);
			this.LinkButton7.ImageAlign = HorizontalAlignment.Left;
			this.LinkButton7.ImageSize = new Size(30, 30);
			this.LinkButton7.Location = new Point(360, 77);
			this.LinkButton7.Name = "LinkButton7";
			this.LinkButton7.Size = new Size(263, 42);
			this.LinkButton7.TabIndex = 21;
			this.LinkButton7.Text = "Статистика серверов";
			this.LinkButton7.Click += this.LinkButton7_Click;
			this.LinkButton6.Animated = true;
			this.LinkButton6.BackColor = Color.Transparent;
			this.LinkButton6.BorderColor = Color.Transparent;
			this.LinkButton6.BorderRadius = 6;
			this.LinkButton6.Cursor = Cursors.Hand;
			this.LinkButton6.DisabledState.BorderColor = Color.DarkGray;
			this.LinkButton6.DisabledState.CustomBorderColor = Color.DarkGray;
			this.LinkButton6.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.LinkButton6.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.LinkButton6.FillColor = Color.FromArgb(106, 106, 106);
			this.LinkButton6.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
			this.LinkButton6.ForeColor = Color.White;
			this.LinkButton6.HoverState.FillColor = Color.FromArgb(253, 253, 48);
			this.LinkButton6.HoverState.ForeColor = Color.FromArgb(64, 64, 64);
			this.LinkButton6.ImageAlign = HorizontalAlignment.Left;
			this.LinkButton6.ImageSize = new Size(30, 30);
			this.LinkButton6.Location = new Point(360, 0);
			this.LinkButton6.Name = "LinkButton6";
			this.LinkButton6.Size = new Size(263, 42);
			this.LinkButton6.TabIndex = 20;
			this.LinkButton6.Text = "Конструктор электросхем";
			this.LinkButton6.Click += this.LinkButton6_Click;
			this.guna2Panel1.Controls.Add(this.LinkButton10);
			this.guna2Panel1.Controls.Add(this.LinkButton9);
			this.guna2Panel1.Controls.Add(this.LinkButton8);
			this.guna2Panel1.Controls.Add(this.LinkButton7);
			this.guna2Panel1.Controls.Add(this.LinkButton6);
			this.guna2Panel1.Controls.Add(this.LinkButton5);
			this.guna2Panel1.Controls.Add(this.LinkButton4);
			this.guna2Panel1.Controls.Add(this.LinkButton3);
			this.guna2Panel1.Controls.Add(this.LinkButton2);
			this.guna2Panel1.Controls.Add(this.LinkButton1);
			this.guna2Panel1.Dock = DockStyle.Fill;
			this.guna2Panel1.Location = new Point(0, 33);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new Size(683, 531);
			this.guna2Panel1.TabIndex = 25;
			base.AutoScaleDimensions = new SizeF(96f, 96f);
			base.AutoScaleMode = AutoScaleMode.Dpi;
			this.BackColor = Color.FromArgb(54, 54, 54);
			base.Controls.Add(this.guna2Panel1);
			this.Font = new Font("Segoe UI", 12f);
			this.ForeColor = Color.White;
			base.Margin = new Padding(4, 5, 4, 5);
			base.Name = "ToolsControl";
			base.Padding = new Padding(0, 33, 0, 0);
			base.Size = new Size(683, 564);
			this.guna2Panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400001C RID: 28
		private IContainer components = null;

		// Token: 0x0400001D RID: 29
		private Guna2Button LinkButton1;

		// Token: 0x0400001E RID: 30
		private Guna2Button LinkButton2;

		// Token: 0x0400001F RID: 31
		private Guna2Button LinkButton3;

		// Token: 0x04000020 RID: 32
		private Guna2Button LinkButton4;

		// Token: 0x04000021 RID: 33
		private Guna2Button LinkButton5;

		// Token: 0x04000022 RID: 34
		private Guna2Button LinkButton10;

		// Token: 0x04000023 RID: 35
		private Guna2Button LinkButton9;

		// Token: 0x04000024 RID: 36
		private Guna2Button LinkButton8;

		// Token: 0x04000025 RID: 37
		private Guna2Button LinkButton7;

		// Token: 0x04000026 RID: 38
		private Guna2Button LinkButton6;

		// Token: 0x04000027 RID: 39
		private Guna2Panel guna2Panel1;
	}
}
