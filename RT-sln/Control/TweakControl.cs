using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using RustTweaker.Services;

namespace RustTweaker.Control
{
	// Token: 0x02000011 RID: 17
	public class TweakControl : UserControl
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00009288 File Offset: 0x00007488
		// (set) Token: 0x0600006F RID: 111 RVA: 0x00009290 File Offset: 0x00007490
		public Action<string> OnHoverDescriptionChange { get; set; }

		// Token: 0x06000070 RID: 112 RVA: 0x00009299 File Offset: 0x00007499
		public TweakControl()
		{
			this.InitializeComponent();
			this.SetupAllCheckBoxEvents();
			this.InitializeTweakDefinitions();
			this.CombineOffCheckBoxInfo();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000092C8 File Offset: 0x000074C8
		private void InitializeTweakDefinitions()
		{
			this.tweakDefinitions = new Dictionary<Guna2CheckBox, List<ValueTuple<string, string>>>
			{
				{
					this.TweakCheckBox2,
					new List<ValueTuple<string, string>>
					{
						new ValueTuple<string, string>("effects.maxgibdist", "0")
					}
				},
				{
					this.TweakCheckBox3,
					new List<ValueTuple<string, string>>
					{
						new ValueTuple<string, string>("accessibility.treemarkercolor", "2")
					}
				},
				{
					this.TweakCheckBox4,
					new List<ValueTuple<string, string>>
					{
						new ValueTuple<string, string>("client.clampscreenshake", "True"),
						new ValueTuple<string, string>("client.allowcameratiltondpv", "False"),
						new ValueTuple<string, string>("client.headbob", "False"),
						new ValueTuple<string, string>("client.hurtpunch", "False")
					}
				},
				{
					this.TweakCheckBox5,
					new List<ValueTuple<string, string>>
					{
						new ValueTuple<string, string>("inventory.quickcraftdelay", "0")
					}
				},
				{
					this.TweakCheckBox6,
					new List<ValueTuple<string, string>>
					{
						new ValueTuple<string, string>("input.holdtime", "0.15")
					}
				},
				{
					this.TweakCheckBox7,
					new List<ValueTuple<string, string>>
					{
						new ValueTuple<string, string>("texture.memory_budget_factor", "1.3")
					}
				},
				{
					this.TweakCheckBox12,
					new List<ValueTuple<string, string>>
					{
						new ValueTuple<string, string>("legs.enablelegs", "False")
					}
				},
				{
					this.TweakCheckBox1,
					new List<ValueTuple<string, string>>
					{
						new ValueTuple<string, string>("client.headbob", "False"),
						new ValueTuple<string, string>("client.hurtpunch", "False"),
						new ValueTuple<string, string>("global.showblood", "False"),
						new ValueTuple<string, string>("global.censorrecordings", "False"),
						new ValueTuple<string, string>("shoutcaststreamer.allowinternetstreams", "False"),
						new ValueTuple<string, string>("player.cold_breath", "False"),
						new ValueTuple<string, string>("effects.hurtoverlay", "False"),
						new ValueTuple<string, string>("effects.hurtoverleyapplylighting", "False"),
						new ValueTuple<string, string>("effects.bloom", "False"),
						new ValueTuple<string, string>("effects.shafts", "False"),
						new ValueTuple<string, string>("effects.lensdirt", "False"),
						new ValueTuple<string, string>("graphics.branding", "False"),
						new ValueTuple<string, string>("gametip.showgametips", "False"),
						new ValueTuple<string, string>("graphicssettings.particleraycastbudget", "0"),
						new ValueTuple<string, string>("graphicssettings.billboardsfacecameraposition", "False"),
						new ValueTuple<string, string>("graphicssettings.pixellightcount", "0"),
						new ValueTuple<string, string>("reflection.planarreflections", "False"),
						new ValueTuple<string, string>("render.instanced_rendering", "0"),
						new ValueTuple<string, string>("ui.showbeltbarbinds", "False"),
						new ValueTuple<string, string>("water.quality", "0"),
						new ValueTuple<string, string>("client.hascompletedtutorial", "True"),
						new ValueTuple<string, string>("effects.vignet", "False"),
						new ValueTuple<string, string>("global.processmidiinput", "False")
					}
				}
			};
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00009648 File Offset: 0x00007848
		private void SetupAllCheckBoxEvents()
		{
			this.checkBoxDescriptions = new Dictionary<Guna2CheckBox, string>
			{
				{
					this.TweakCheckBox1,
					"Отключает все ненужные настройки, которые затрудняют геймплей, снижают производительность или просто удалены из игры, но остались в меню (ненужные блики, размытия, уведомления, анимации и т.д). Рекомендуем использовать данный твик всем без исключения."
				},
				{
					this.TweakCheckBox2,
					"Полностью отключает обломки при разрушении сооружений и объектов. Также отключает звук разрушения."
				},
				{
					this.TweakCheckBox3,
					"Меняет цвет отображения маркеров на деревьях на более контрастный."
				},
				{
					this.TweakCheckBox4,
					"Минимизирует тряску камеры при беге, стрельбе, взрывах и получении урона."
				},
				{
					this.TweakCheckBox5,
					"Отключает небольшое провисание интерфейса при попытке скрафтить предмет через меню быстрого крафта."
				},
				{
					this.TweakCheckBox6,
					"Немного ускоряет появление радиального меню при зажатии кнопки взаимодействия."
				},
				{
					this.TweakCheckBox7,
					"Исправляет проблему, при которой текстуры перестают прогружаться и выглядят как Unturned. Не используйте этот твик, если с текстурами все в порядке, включение может снизить FPS."
				},
				{
					this.TweakCheckBox12,
					"Отключает отображение ног персонажа от первого лица, помогая целиться вниз."
				}
			};
			foreach (KeyValuePair<Guna2CheckBox, string> keyValuePair in this.checkBoxDescriptions)
			{
				Guna2CheckBox key = keyValuePair.Key;
				string description = keyValuePair.Value;
				bool flag = key != null;
				if (flag)
				{
					key.MouseEnter += delegate(object s, EventArgs e)
					{
						Action<string> onHoverDescriptionChange = this.OnHoverDescriptionChange;
						if (onHoverDescriptionChange != null)
						{
							onHoverDescriptionChange(description);
						}
					};
				}
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00009778 File Offset: 0x00007978
		private void textInfoForOffCheckBox(Panel panel, string description)
		{
			panel.MouseEnter += delegate(object s, EventArgs e)
			{
				Action<string> onHoverDescriptionChange = this.OnHoverDescriptionChange;
				if (onHoverDescriptionChange != null)
				{
					onHoverDescriptionChange(description);
				}
			};
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000097B0 File Offset: 0x000079B0
		private void CombineOffCheckBoxInfo()
		{
			this.textInfoForOffCheckBox(this.guna2Panel2, "Для разблокировки необходимо приобрести полную версию программы");
			this.textInfoForOffCheckBox(this.guna2Panel4, "Для разблокировки необходимо приобрести полную версию программы");
			this.textInfoForOffCheckBox(this.guna2Panel5, "Для разблокировки необходимо приобрести полную версию программы");
			this.textInfoForOffCheckBox(this.guna2Panel6, "Для разблокировки необходимо приобрести полную версию программы");
			this.textInfoForOffCheckBox(this.guna2Panel7, "Для разблокировки необходимо приобрести полную версию программы");
			this.textInfoForOffCheckBox(this.guna2Panel8, "Для разблокировки необходимо приобрести полную версию программы");
			this.textInfoForOffCheckBox(this.guna2Panel9, "Для разблокировки необходимо приобрести полную версию программы");
			this.textInfoForOffCheckBox(this.guna2Panel10, "Для разблокировки необходимо приобрести полную версию программы");
			this.textInfoForOffCheckBox(this.guna2Panel11, "Для разблокировки необходимо приобрести полную версию программы");
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00009860 File Offset: 0x00007A60
		private void ApplyTweakButton_Click(object sender, EventArgs e)
		{
			bool flag = this.tweakDefinitions.Keys.Any((Guna2CheckBox cb) => cb.Checked);
			bool flag2 = !flag;
			if (flag2)
			{
				NotificationService.ShowNotification("Не выбрано ни одного параметра", 1000);
			}
			else
			{
				string text = Path.Combine(ConfigContol.SelectedGamePath, ConfigContol.clientPath);
				try
				{
					List<string> lines = File.ReadAllLines(text).ToList<string>();
					this.ApplyTweaksToFile(text, lines);
				}
				catch (Exception ex)
				{
					NotificationService.ShowNotification("Произошла ошибка при чтении/записи файла: " + ex.Message, 1000);
				}
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00009914 File Offset: 0x00007B14
		private void ApplyTweaksToFile(string filePath, List<string> lines)
		{
			bool flag = false;
			List<string> list = new List<string>();
			foreach (KeyValuePair<Guna2CheckBox, List<ValueTuple<string, string>>> keyValuePair in this.tweakDefinitions)
			{
				Guna2CheckBox key = keyValuePair.Key;
				List<ValueTuple<string, string>> value = keyValuePair.Value;
				bool @checked = key.Checked;
				if (@checked)
				{
					foreach (ValueTuple<string, string> valueTuple in value)
					{
						string item = valueTuple.Item1;
						string item2 = valueTuple.Item2;
						bool flag2 = false;
						for (int i = 0; i < lines.Count; i++)
						{
							string text = lines[i].Trim();
							bool flag3 = text.StartsWith(item, StringComparison.OrdinalIgnoreCase) && text.Length > item.Length && (text[item.Length] == ' ' || text[item.Length] == '\t' || text[item.Length] == '=');
							if (flag3)
							{
								lines[i] = item + " \"" + item2 + "\"";
								flag2 = true;
								flag = true;
								break;
							}
						}
						bool flag4 = !flag2;
						if (flag4)
						{
							string item3 = item + " \"" + item2 + "\"";
							bool flag5 = !list.Contains(item3);
							if (flag5)
							{
								list.Add(item3);
							}
							flag = true;
						}
					}
				}
			}
			bool flag6 = flag;
			if (flag6)
			{
				lines.AddRange(list);
				try
				{
					File.WriteAllLines(filePath, lines);
					NotificationService.ShowNotification("Параметры успешно применены", 1000);
				}
				catch (Exception ex)
				{
					NotificationService.ShowNotification("Произошла ошибка при записи файла: " + ex.Message, 1000);
				}
			}
			else
			{
				NotificationService.ShowNotification("Нет изменений для применения", 1000);
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00009B74 File Offset: 0x00007D74
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00009BAC File Offset: 0x00007DAC
		private void InitializeComponent()
		{
			this.TweakCheckBox1 = new Guna2CheckBox();
			this.ApplyTweakButton = new Guna2Button();
			this.TweakCheckBox2 = new Guna2CheckBox();
			this.TweakCheckBox6 = new Guna2CheckBox();
			this.TweakCheckBox9 = new Guna2CheckBox();
			this.TweakCheckBox10 = new Guna2CheckBox();
			this.TweakCheckBox15 = new Guna2CheckBox();
			this.TweakCheckBox17 = new Guna2CheckBox();
			this.TweakCheckBox16 = new Guna2CheckBox();
			this.guna2Panel1 = new Guna2Panel();
			this.guna2Panel3 = new Guna2Panel();
			this.TweakCheckBox8 = new Guna2CheckBox();
			this.TweakCheckBox14 = new Guna2CheckBox();
			this.TweakCheckBox13 = new Guna2CheckBox();
			this.TweakCheckBox11 = new Guna2CheckBox();
			this.TweakCheckBox7 = new Guna2CheckBox();
			this.TweakCheckBox12 = new Guna2CheckBox();
			this.TweakCheckBox4 = new Guna2CheckBox();
			this.TweakCheckBox3 = new Guna2CheckBox();
			this.guna2Panel8 = new Guna2Panel();
			this.guna2Panel9 = new Guna2Panel();
			this.guna2Panel10 = new Guna2Panel();
			this.guna2Panel11 = new Guna2Panel();
			this.PanelLeftColumn = new Guna2Panel();
			this.TweakCheckBox5 = new Guna2CheckBox();
			this.guna2Panel2 = new Guna2Panel();
			this.guna2Panel4 = new Guna2Panel();
			this.guna2Panel5 = new Guna2Panel();
			this.guna2Panel6 = new Guna2Panel();
			this.guna2Panel7 = new Guna2Panel();
			this.guna2Panel1.SuspendLayout();
			this.guna2Panel3.SuspendLayout();
			this.PanelLeftColumn.SuspendLayout();
			base.SuspendLayout();
			this.TweakCheckBox1.Animated = true;
			this.TweakCheckBox1.BackColor = Color.Transparent;
			this.TweakCheckBox1.CheckedState.BorderRadius = 0;
			this.TweakCheckBox1.CheckedState.BorderThickness = 0;
			this.TweakCheckBox1.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox1.CheckMarkColor = Color.Black;
			this.TweakCheckBox1.Cursor = Cursors.Hand;
			this.TweakCheckBox1.Font = new Font("Segoe UI Semibold", 11.25f, FontStyle.Bold);
			this.TweakCheckBox1.ForeColor = Color.White;
			this.TweakCheckBox1.Location = new Point(0, 0);
			this.TweakCheckBox1.Margin = new Padding(0);
			this.TweakCheckBox1.Name = "TweakCheckBox1";
			this.TweakCheckBox1.Size = new Size(311, 44);
			this.TweakCheckBox1.TabIndex = 0;
			this.TweakCheckBox1.TabStop = false;
			this.TweakCheckBox1.Text = "  Отключить все паразитные \r\n  параметры (рекомендуется)\r\n";
			this.TweakCheckBox1.TextAlign = ContentAlignment.BottomLeft;
			this.TweakCheckBox1.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox1.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox1.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox1.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox1.UseVisualStyleBackColor = false;
			this.ApplyTweakButton.BorderColor = Color.Transparent;
			this.ApplyTweakButton.BorderRadius = 3;
			this.ApplyTweakButton.Cursor = Cursors.Hand;
			this.ApplyTweakButton.DisabledState.BorderColor = Color.DarkGray;
			this.ApplyTweakButton.DisabledState.CustomBorderColor = Color.DarkGray;
			this.ApplyTweakButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.ApplyTweakButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.ApplyTweakButton.FillColor = Color.FromArgb(106, 106, 106);
			this.ApplyTweakButton.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
			this.ApplyTweakButton.ForeColor = Color.White;
			this.ApplyTweakButton.HoverState.FillColor = Color.FromArgb(253, 253, 48);
			this.ApplyTweakButton.HoverState.ForeColor = Color.FromArgb(64, 64, 64);
			this.ApplyTweakButton.Location = new Point(282, 492);
			this.ApplyTweakButton.Name = "ApplyTweakButton";
			this.ApplyTweakButton.Size = new Size(118, 42);
			this.ApplyTweakButton.TabIndex = 12;
			this.ApplyTweakButton.Text = "Применить";
			this.ApplyTweakButton.Click += this.ApplyTweakButton_Click;
			this.TweakCheckBox2.Animated = true;
			this.TweakCheckBox2.BackColor = Color.Transparent;
			this.TweakCheckBox2.CheckedState.BorderRadius = 0;
			this.TweakCheckBox2.CheckedState.BorderThickness = 0;
			this.TweakCheckBox2.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox2.CheckMarkColor = Color.Black;
			this.TweakCheckBox2.Cursor = Cursors.Hand;
			this.TweakCheckBox2.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox2.ForeColor = Color.White;
			this.TweakCheckBox2.Location = new Point(0, 84);
			this.TweakCheckBox2.Margin = new Padding(0);
			this.TweakCheckBox2.Name = "TweakCheckBox2";
			this.TweakCheckBox2.Size = new Size(311, 23);
			this.TweakCheckBox2.TabIndex = 13;
			this.TweakCheckBox2.TabStop = false;
			this.TweakCheckBox2.Text = "  Полностью отключить обломки";
			this.TweakCheckBox2.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox2.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox2.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox2.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox2.UseVisualStyleBackColor = false;
			this.TweakCheckBox6.Animated = true;
			this.TweakCheckBox6.AutoSize = true;
			this.TweakCheckBox6.BackColor = Color.Transparent;
			this.TweakCheckBox6.CheckedState.BorderRadius = 0;
			this.TweakCheckBox6.CheckedState.BorderThickness = 0;
			this.TweakCheckBox6.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox6.CheckMarkColor = Color.Black;
			this.TweakCheckBox6.Cursor = Cursors.Hand;
			this.TweakCheckBox6.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox6.ForeColor = Color.White;
			this.TweakCheckBox6.Location = new Point(0, 52);
			this.TweakCheckBox6.Margin = new Padding(0);
			this.TweakCheckBox6.Name = "TweakCheckBox6";
			this.TweakCheckBox6.Size = new Size(301, 24);
			this.TweakCheckBox6.TabIndex = 17;
			this.TweakCheckBox6.TabStop = false;
			this.TweakCheckBox6.Text = "  Снизить задержку радиального меню";
			this.TweakCheckBox6.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox6.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox6.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox6.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox6.UseVisualStyleBackColor = false;
			this.TweakCheckBox9.Animated = true;
			this.TweakCheckBox9.AutoSize = true;
			this.TweakCheckBox9.BackColor = Color.Transparent;
			this.TweakCheckBox9.CheckedState.BorderRadius = 0;
			this.TweakCheckBox9.CheckedState.BorderThickness = 0;
			this.TweakCheckBox9.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox9.CheckMarkColor = Color.Black;
			this.TweakCheckBox9.Cursor = Cursors.Hand;
			this.TweakCheckBox9.Enabled = false;
			this.TweakCheckBox9.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox9.ForeColor = Color.White;
			this.TweakCheckBox9.Location = new Point(0, 211);
			this.TweakCheckBox9.Margin = new Padding(0);
			this.TweakCheckBox9.Name = "TweakCheckBox9";
			this.TweakCheckBox9.Size = new Size(257, 44);
			this.TweakCheckBox9.TabIndex = 20;
			this.TweakCheckBox9.TabStop = false;
			this.TweakCheckBox9.Text = "  Добавить информацию о карте\r\n  в меню F8";
			this.TweakCheckBox9.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox9.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox9.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox9.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox9.UseVisualStyleBackColor = false;
			this.TweakCheckBox10.Animated = true;
			this.TweakCheckBox10.AutoSize = true;
			this.TweakCheckBox10.BackColor = Color.Transparent;
			this.TweakCheckBox10.CheckedState.BorderRadius = 0;
			this.TweakCheckBox10.CheckedState.BorderThickness = 0;
			this.TweakCheckBox10.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox10.CheckMarkColor = Color.Black;
			this.TweakCheckBox10.Cursor = Cursors.Hand;
			this.TweakCheckBox10.Enabled = false;
			this.TweakCheckBox10.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox10.ForeColor = Color.White;
			this.TweakCheckBox10.Location = new Point(0, 147);
			this.TweakCheckBox10.Margin = new Padding(0);
			this.TweakCheckBox10.Name = "TweakCheckBox10";
			this.TweakCheckBox10.Size = new Size(290, 24);
			this.TweakCheckBox10.TabIndex = 21;
			this.TweakCheckBox10.TabStop = false;
			this.TweakCheckBox10.Text = "  Ускорить поворот головы через ALT";
			this.TweakCheckBox10.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox10.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox10.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox10.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox10.UseVisualStyleBackColor = false;
			this.TweakCheckBox15.Animated = true;
			this.TweakCheckBox15.AutoSize = true;
			this.TweakCheckBox15.BackColor = Color.Transparent;
			this.TweakCheckBox15.CheckedState.BorderRadius = 0;
			this.TweakCheckBox15.CheckedState.BorderThickness = 0;
			this.TweakCheckBox15.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox15.CheckMarkColor = Color.Black;
			this.TweakCheckBox15.Cursor = Cursors.Hand;
			this.TweakCheckBox15.Enabled = false;
			this.TweakCheckBox15.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox15.ForeColor = Color.White;
			this.TweakCheckBox15.Location = new Point(0, 179);
			this.TweakCheckBox15.Margin = new Padding(0);
			this.TweakCheckBox15.Name = "TweakCheckBox15";
			this.TweakCheckBox15.Size = new Size(284, 24);
			this.TweakCheckBox15.TabIndex = 26;
			this.TweakCheckBox15.TabStop = false;
			this.TweakCheckBox15.Text = "  Отключить анимацию глаз игроков";
			this.TweakCheckBox15.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox15.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox15.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox15.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox15.UseVisualStyleBackColor = false;
			this.TweakCheckBox17.Animated = true;
			this.TweakCheckBox17.AutoSize = true;
			this.TweakCheckBox17.BackColor = Color.Transparent;
			this.TweakCheckBox17.CheckedState.BorderRadius = 0;
			this.TweakCheckBox17.CheckedState.BorderThickness = 0;
			this.TweakCheckBox17.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox17.CheckMarkColor = Color.Black;
			this.TweakCheckBox17.Cursor = Cursors.Hand;
			this.TweakCheckBox17.Enabled = false;
			this.TweakCheckBox17.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox17.ForeColor = Color.White;
			this.TweakCheckBox17.Location = new Point(0, 315);
			this.TweakCheckBox17.Margin = new Padding(0);
			this.TweakCheckBox17.Name = "TweakCheckBox17";
			this.TweakCheckBox17.Size = new Size(223, 24);
			this.TweakCheckBox17.TabIndex = 28;
			this.TweakCheckBox17.TabStop = false;
			this.TweakCheckBox17.Text = "  Отключить следы от шагов";
			this.TweakCheckBox17.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox17.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox17.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox17.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox17.UseVisualStyleBackColor = false;
			this.TweakCheckBox16.Animated = true;
			this.TweakCheckBox16.AutoSize = true;
			this.TweakCheckBox16.BackColor = Color.Transparent;
			this.TweakCheckBox16.CheckedState.BorderRadius = 0;
			this.TweakCheckBox16.CheckedState.BorderThickness = 0;
			this.TweakCheckBox16.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox16.CheckMarkColor = Color.Black;
			this.TweakCheckBox16.Cursor = Cursors.Hand;
			this.TweakCheckBox16.Enabled = false;
			this.TweakCheckBox16.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox16.ForeColor = Color.White;
			this.TweakCheckBox16.Location = new Point(0, 263);
			this.TweakCheckBox16.Margin = new Padding(0);
			this.TweakCheckBox16.Name = "TweakCheckBox16";
			this.TweakCheckBox16.Size = new Size(262, 44);
			this.TweakCheckBox16.TabIndex = 27;
			this.TweakCheckBox16.TabStop = false;
			this.TweakCheckBox16.Text = "  Отключить безопасный режим \r\n  механизма отсечения окклюзии";
			this.TweakCheckBox16.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox16.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox16.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox16.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox16.UseVisualStyleBackColor = false;
			this.guna2Panel1.Controls.Add(this.ApplyTweakButton);
			this.guna2Panel1.Controls.Add(this.guna2Panel3);
			this.guna2Panel1.Controls.Add(this.PanelLeftColumn);
			this.guna2Panel1.Dock = DockStyle.Fill;
			this.guna2Panel1.Location = new Point(0, 0);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Padding = new Padding(50, 28, 30, 28);
			this.guna2Panel1.Size = new Size(683, 564);
			this.guna2Panel1.TabIndex = 29;
			this.guna2Panel3.Controls.Add(this.TweakCheckBox8);
			this.guna2Panel3.Controls.Add(this.TweakCheckBox14);
			this.guna2Panel3.Controls.Add(this.TweakCheckBox13);
			this.guna2Panel3.Controls.Add(this.TweakCheckBox11);
			this.guna2Panel3.Controls.Add(this.TweakCheckBox7);
			this.guna2Panel3.Controls.Add(this.TweakCheckBox12);
			this.guna2Panel3.Controls.Add(this.TweakCheckBox4);
			this.guna2Panel3.Controls.Add(this.TweakCheckBox3);
			this.guna2Panel3.Controls.Add(this.guna2Panel8);
			this.guna2Panel3.Controls.Add(this.guna2Panel9);
			this.guna2Panel3.Controls.Add(this.guna2Panel10);
			this.guna2Panel3.Controls.Add(this.guna2Panel11);
			this.guna2Panel3.Dock = DockStyle.Left;
			this.guna2Panel3.Location = new Point(386, 28);
			this.guna2Panel3.Margin = new Padding(0);
			this.guna2Panel3.Name = "guna2Panel3";
			this.guna2Panel3.Size = new Size(278, 508);
			this.guna2Panel3.TabIndex = 29;
			this.TweakCheckBox8.Animated = true;
			this.TweakCheckBox8.AutoSize = true;
			this.TweakCheckBox8.BackColor = Color.Transparent;
			this.TweakCheckBox8.CheckedState.BorderRadius = 0;
			this.TweakCheckBox8.CheckedState.BorderThickness = 0;
			this.TweakCheckBox8.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox8.CheckMarkColor = Color.Black;
			this.TweakCheckBox8.Cursor = Cursors.Hand;
			this.TweakCheckBox8.Enabled = false;
			this.TweakCheckBox8.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox8.ForeColor = Color.White;
			this.TweakCheckBox8.Location = new Point(0, 263);
			this.TweakCheckBox8.Margin = new Padding(0);
			this.TweakCheckBox8.Name = "TweakCheckBox8";
			this.TweakCheckBox8.Size = new Size(242, 44);
			this.TweakCheckBox8.TabIndex = 19;
			this.TweakCheckBox8.TabStop = false;
			this.TweakCheckBox8.Text = "  Добавить админские жесты в\r\n  игровое меню";
			this.TweakCheckBox8.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox8.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox8.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox8.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox8.UseVisualStyleBackColor = false;
			this.TweakCheckBox14.Animated = true;
			this.TweakCheckBox14.AutoSize = true;
			this.TweakCheckBox14.BackColor = Color.Transparent;
			this.TweakCheckBox14.CheckedState.BorderRadius = 0;
			this.TweakCheckBox14.CheckedState.BorderThickness = 0;
			this.TweakCheckBox14.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox14.CheckMarkColor = Color.Black;
			this.TweakCheckBox14.Cursor = Cursors.Hand;
			this.TweakCheckBox14.Enabled = false;
			this.TweakCheckBox14.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox14.ForeColor = Color.White;
			this.TweakCheckBox14.Location = new Point(0, 211);
			this.TweakCheckBox14.Margin = new Padding(0);
			this.TweakCheckBox14.Name = "TweakCheckBox14";
			this.TweakCheckBox14.Size = new Size(249, 44);
			this.TweakCheckBox14.TabIndex = 25;
			this.TweakCheckBox14.TabStop = false;
			this.TweakCheckBox14.Text = "  Отключить красные ошибки в \r\n  левом верхнем углу";
			this.TweakCheckBox14.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox14.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox14.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox14.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox14.UseVisualStyleBackColor = false;
			this.TweakCheckBox13.Animated = true;
			this.TweakCheckBox13.BackColor = Color.Transparent;
			this.TweakCheckBox13.CheckedState.BorderRadius = 0;
			this.TweakCheckBox13.CheckedState.BorderThickness = 0;
			this.TweakCheckBox13.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox13.CheckMarkColor = Color.Black;
			this.TweakCheckBox13.Cursor = Cursors.Hand;
			this.TweakCheckBox13.Enabled = false;
			this.TweakCheckBox13.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox13.ForeColor = Color.White;
			this.TweakCheckBox13.Location = new Point(0, 180);
			this.TweakCheckBox13.Margin = new Padding(0);
			this.TweakCheckBox13.Name = "TweakCheckBox13";
			this.TweakCheckBox13.Size = new Size(278, 23);
			this.TweakCheckBox13.TabIndex = 24;
			this.TweakCheckBox13.TabStop = false;
			this.TweakCheckBox13.Text = "  Отключить деформацию ног";
			this.TweakCheckBox13.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox13.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox13.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox13.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox13.UseVisualStyleBackColor = false;
			this.TweakCheckBox11.Animated = true;
			this.TweakCheckBox11.AutoSize = true;
			this.TweakCheckBox11.BackColor = Color.Transparent;
			this.TweakCheckBox11.CheckedState.BorderRadius = 0;
			this.TweakCheckBox11.CheckedState.BorderThickness = 0;
			this.TweakCheckBox11.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox11.CheckMarkColor = Color.Black;
			this.TweakCheckBox11.Cursor = Cursors.Hand;
			this.TweakCheckBox11.Enabled = false;
			this.TweakCheckBox11.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox11.ForeColor = Color.White;
			this.TweakCheckBox11.Location = new Point(0, 147);
			this.TweakCheckBox11.Margin = new Padding(0);
			this.TweakCheckBox11.Name = "TweakCheckBox11";
			this.TweakCheckBox11.Size = new Size(207, 24);
			this.TweakCheckBox11.TabIndex = 22;
			this.TweakCheckBox11.TabStop = false;
			this.TweakCheckBox11.Text = "  Отключить стробоскопы";
			this.TweakCheckBox11.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox11.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox11.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox11.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox11.UseVisualStyleBackColor = false;
			this.TweakCheckBox7.Animated = true;
			this.TweakCheckBox7.AutoSize = true;
			this.TweakCheckBox7.BackColor = Color.Transparent;
			this.TweakCheckBox7.CheckedState.BorderRadius = 0;
			this.TweakCheckBox7.CheckedState.BorderThickness = 0;
			this.TweakCheckBox7.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox7.CheckMarkColor = Color.Black;
			this.TweakCheckBox7.Cursor = Cursors.Hand;
			this.TweakCheckBox7.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox7.ForeColor = Color.White;
			this.TweakCheckBox7.Location = new Point(0, 115);
			this.TweakCheckBox7.Margin = new Padding(0);
			this.TweakCheckBox7.Name = "TweakCheckBox7";
			this.TweakCheckBox7.Size = new Size(246, 24);
			this.TweakCheckBox7.TabIndex = 18;
			this.TweakCheckBox7.TabStop = false;
			this.TweakCheckBox7.Text = "  Исправить мыльные текстуры";
			this.TweakCheckBox7.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox7.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox7.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox7.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox7.UseVisualStyleBackColor = false;
			this.TweakCheckBox12.Animated = true;
			this.TweakCheckBox12.AutoSize = true;
			this.TweakCheckBox12.BackColor = Color.Transparent;
			this.TweakCheckBox12.CheckedState.BorderRadius = 0;
			this.TweakCheckBox12.CheckedState.BorderThickness = 0;
			this.TweakCheckBox12.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox12.CheckMarkColor = Color.Black;
			this.TweakCheckBox12.Cursor = Cursors.Hand;
			this.TweakCheckBox12.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox12.ForeColor = Color.White;
			this.TweakCheckBox12.Location = new Point(0, 83);
			this.TweakCheckBox12.Margin = new Padding(0);
			this.TweakCheckBox12.Name = "TweakCheckBox12";
			this.TweakCheckBox12.Size = new Size(238, 24);
			this.TweakCheckBox12.TabIndex = 23;
			this.TweakCheckBox12.TabStop = false;
			this.TweakCheckBox12.Text = "  Отключить отображение ног";
			this.TweakCheckBox12.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox12.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox12.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox12.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox12.UseVisualStyleBackColor = false;
			this.TweakCheckBox4.Animated = true;
			this.TweakCheckBox4.AutoSize = true;
			this.TweakCheckBox4.BackColor = Color.Transparent;
			this.TweakCheckBox4.CheckedState.BorderRadius = 0;
			this.TweakCheckBox4.CheckedState.BorderThickness = 0;
			this.TweakCheckBox4.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox4.CheckMarkColor = Color.Black;
			this.TweakCheckBox4.Cursor = Cursors.Hand;
			this.TweakCheckBox4.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox4.ForeColor = Color.White;
			this.TweakCheckBox4.Location = new Point(0, 52);
			this.TweakCheckBox4.Margin = new Padding(0);
			this.TweakCheckBox4.Name = "TweakCheckBox4";
			this.TweakCheckBox4.Size = new Size(222, 24);
			this.TweakCheckBox4.TabIndex = 15;
			this.TweakCheckBox4.TabStop = false;
			this.TweakCheckBox4.Text = "  Уменьшить тряску камеры";
			this.TweakCheckBox4.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox4.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox4.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox4.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox4.UseVisualStyleBackColor = false;
			this.TweakCheckBox3.Animated = true;
			this.TweakCheckBox3.AutoSize = true;
			this.TweakCheckBox3.BackColor = Color.Transparent;
			this.TweakCheckBox3.CheckedState.BorderRadius = 0;
			this.TweakCheckBox3.CheckedState.BorderThickness = 0;
			this.TweakCheckBox3.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox3.CheckMarkColor = Color.Black;
			this.TweakCheckBox3.Cursor = Cursors.Hand;
			this.TweakCheckBox3.Dock = DockStyle.Top;
			this.TweakCheckBox3.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox3.ForeColor = Color.White;
			this.TweakCheckBox3.Location = new Point(0, 0);
			this.TweakCheckBox3.Margin = new Padding(0);
			this.TweakCheckBox3.Name = "TweakCheckBox3";
			this.TweakCheckBox3.Size = new Size(278, 44);
			this.TweakCheckBox3.TabIndex = 14;
			this.TweakCheckBox3.TabStop = false;
			this.TweakCheckBox3.Text = "  Улучшить видимость крестиков \r\n  на деревьях ночью";
			this.TweakCheckBox3.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox3.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox3.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox3.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox3.UseVisualStyleBackColor = false;
			this.guna2Panel8.Location = new Point(0, 147);
			this.guna2Panel8.Name = "guna2Panel8";
			this.guna2Panel8.Size = new Size(207, 24);
			this.guna2Panel8.TabIndex = 26;
			this.guna2Panel9.Location = new Point(0, 180);
			this.guna2Panel9.Name = "guna2Panel9";
			this.guna2Panel9.Size = new Size(278, 23);
			this.guna2Panel9.TabIndex = 27;
			this.guna2Panel10.Location = new Point(0, 211);
			this.guna2Panel10.Name = "guna2Panel10";
			this.guna2Panel10.Size = new Size(249, 44);
			this.guna2Panel10.TabIndex = 28;
			this.guna2Panel11.Location = new Point(0, 263);
			this.guna2Panel11.Name = "guna2Panel11";
			this.guna2Panel11.Size = new Size(242, 44);
			this.guna2Panel11.TabIndex = 29;
			this.PanelLeftColumn.Controls.Add(this.TweakCheckBox17);
			this.PanelLeftColumn.Controls.Add(this.TweakCheckBox9);
			this.PanelLeftColumn.Controls.Add(this.TweakCheckBox16);
			this.PanelLeftColumn.Controls.Add(this.TweakCheckBox15);
			this.PanelLeftColumn.Controls.Add(this.TweakCheckBox10);
			this.PanelLeftColumn.Controls.Add(this.TweakCheckBox5);
			this.PanelLeftColumn.Controls.Add(this.TweakCheckBox2);
			this.PanelLeftColumn.Controls.Add(this.TweakCheckBox6);
			this.PanelLeftColumn.Controls.Add(this.TweakCheckBox1);
			this.PanelLeftColumn.Controls.Add(this.guna2Panel2);
			this.PanelLeftColumn.Controls.Add(this.guna2Panel4);
			this.PanelLeftColumn.Controls.Add(this.guna2Panel5);
			this.PanelLeftColumn.Controls.Add(this.guna2Panel6);
			this.PanelLeftColumn.Controls.Add(this.guna2Panel7);
			this.PanelLeftColumn.Dock = DockStyle.Left;
			this.PanelLeftColumn.Location = new Point(50, 28);
			this.PanelLeftColumn.Margin = new Padding(0);
			this.PanelLeftColumn.Name = "PanelLeftColumn";
			this.PanelLeftColumn.Size = new Size(336, 508);
			this.PanelLeftColumn.TabIndex = 30;
			this.TweakCheckBox5.Animated = true;
			this.TweakCheckBox5.AutoSize = true;
			this.TweakCheckBox5.BackColor = Color.Transparent;
			this.TweakCheckBox5.CheckedState.BorderRadius = 0;
			this.TweakCheckBox5.CheckedState.BorderThickness = 0;
			this.TweakCheckBox5.CheckedState.FillColor = Color.FromArgb(253, 253, 48);
			this.TweakCheckBox5.CheckMarkColor = Color.Black;
			this.TweakCheckBox5.Cursor = Cursors.Hand;
			this.TweakCheckBox5.Font = new Font("Segoe UI", 11f);
			this.TweakCheckBox5.ForeColor = Color.White;
			this.TweakCheckBox5.Location = new Point(0, 115);
			this.TweakCheckBox5.Margin = new Padding(0);
			this.TweakCheckBox5.Name = "TweakCheckBox5";
			this.TweakCheckBox5.Size = new Size(297, 24);
			this.TweakCheckBox5.TabIndex = 16;
			this.TweakCheckBox5.TabStop = false;
			this.TweakCheckBox5.Text = "  Убрать задержку в меню автокрафта ";
			this.TweakCheckBox5.UncheckedState.BorderColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox5.UncheckedState.BorderRadius = 0;
			this.TweakCheckBox5.UncheckedState.BorderThickness = 0;
			this.TweakCheckBox5.UncheckedState.FillColor = Color.FromArgb(42, 42, 42);
			this.TweakCheckBox5.UseVisualStyleBackColor = false;
			this.guna2Panel2.Location = new Point(0, 147);
			this.guna2Panel2.Name = "guna2Panel2";
			this.guna2Panel2.Size = new Size(290, 24);
			this.guna2Panel2.TabIndex = 29;
			this.guna2Panel4.Location = new Point(0, 179);
			this.guna2Panel4.Name = "guna2Panel4";
			this.guna2Panel4.Size = new Size(284, 24);
			this.guna2Panel4.TabIndex = 30;
			this.guna2Panel5.Location = new Point(0, 211);
			this.guna2Panel5.Name = "guna2Panel5";
			this.guna2Panel5.Size = new Size(257, 44);
			this.guna2Panel5.TabIndex = 31;
			this.guna2Panel6.Location = new Point(0, 263);
			this.guna2Panel6.Name = "guna2Panel6";
			this.guna2Panel6.Size = new Size(262, 44);
			this.guna2Panel6.TabIndex = 32;
			this.guna2Panel7.Location = new Point(0, 315);
			this.guna2Panel7.Name = "guna2Panel7";
			this.guna2Panel7.Size = new Size(223, 24);
			this.guna2Panel7.TabIndex = 33;
			base.AutoScaleDimensions = new SizeF(96f, 96f);
			base.AutoScaleMode = AutoScaleMode.Dpi;
			this.BackColor = Color.FromArgb(54, 54, 54);
			base.Controls.Add(this.guna2Panel1);
			this.Font = new Font("Segoe UI", 12f);
			this.ForeColor = Color.White;
			base.Margin = new Padding(4, 5, 4, 5);
			base.Name = "TweakControl";
			base.Size = new Size(683, 564);
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel3.ResumeLayout(false);
			this.guna2Panel3.PerformLayout();
			this.PanelLeftColumn.ResumeLayout(false);
			this.PanelLeftColumn.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000066 RID: 102
		private Dictionary<Guna2CheckBox, string> checkBoxDescriptions;

		// Token: 0x04000067 RID: 103
		[TupleElementNames(new string[]
		{
			"key",
			"value"
		})]
		private Dictionary<Guna2CheckBox, List<ValueTuple<string, string>>> tweakDefinitions;

		// Token: 0x04000068 RID: 104
		private IContainer components = null;

		// Token: 0x04000069 RID: 105
		private Guna2CheckBox TweakCheckBox1;

		// Token: 0x0400006A RID: 106
		private Guna2Button ApplyTweakButton;

		// Token: 0x0400006B RID: 107
		private Guna2CheckBox TweakCheckBox2;

		// Token: 0x0400006C RID: 108
		private Guna2CheckBox TweakCheckBox6;

		// Token: 0x0400006D RID: 109
		private Guna2CheckBox TweakCheckBox9;

		// Token: 0x0400006E RID: 110
		private Guna2CheckBox TweakCheckBox10;

		// Token: 0x0400006F RID: 111
		private Guna2CheckBox TweakCheckBox15;

		// Token: 0x04000070 RID: 112
		private Guna2CheckBox TweakCheckBox17;

		// Token: 0x04000071 RID: 113
		private Guna2CheckBox TweakCheckBox16;

		// Token: 0x04000072 RID: 114
		private Guna2Panel guna2Panel1;

		// Token: 0x04000073 RID: 115
		private Guna2CheckBox TweakCheckBox5;

		// Token: 0x04000074 RID: 116
		private Guna2Panel PanelLeftColumn;

		// Token: 0x04000075 RID: 117
		private Guna2Panel guna2Panel2;

		// Token: 0x04000076 RID: 118
		private Guna2Panel guna2Panel4;

		// Token: 0x04000077 RID: 119
		private Guna2Panel guna2Panel5;

		// Token: 0x04000078 RID: 120
		private Guna2Panel guna2Panel7;

		// Token: 0x04000079 RID: 121
		private Guna2Panel guna2Panel6;

		// Token: 0x0400007A RID: 122
		private Guna2Panel guna2Panel3;

		// Token: 0x0400007B RID: 123
		private Guna2CheckBox TweakCheckBox8;

		// Token: 0x0400007C RID: 124
		private Guna2CheckBox TweakCheckBox14;

		// Token: 0x0400007D RID: 125
		private Guna2CheckBox TweakCheckBox13;

		// Token: 0x0400007E RID: 126
		private Guna2CheckBox TweakCheckBox11;

		// Token: 0x0400007F RID: 127
		private Guna2CheckBox TweakCheckBox7;

		// Token: 0x04000080 RID: 128
		private Guna2CheckBox TweakCheckBox12;

		// Token: 0x04000081 RID: 129
		private Guna2CheckBox TweakCheckBox4;

		// Token: 0x04000082 RID: 130
		private Guna2CheckBox TweakCheckBox3;

		// Token: 0x04000083 RID: 131
		private Guna2Panel guna2Panel8;

		// Token: 0x04000084 RID: 132
		private Guna2Panel guna2Panel9;

		// Token: 0x04000085 RID: 133
		private Guna2Panel guna2Panel10;

		// Token: 0x04000086 RID: 134
		private Guna2Panel guna2Panel11;
	}
}
