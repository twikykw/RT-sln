using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.Win32;
using RustTweaker.Configuration;
using RustTweaker.Services;
using RustTweaker.Views;

namespace RustTweaker
{
	// Token: 0x02000005 RID: 5
	public class ConfigContol : UserControl
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002092 File Offset: 0x00000292
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000209A File Offset: 0x0000029A
		public Action<string> OnHoverDescriptionChange { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020A3 File Offset: 0x000002A3
		// (set) Token: 0x06000008 RID: 8 RVA: 0x000020AC File Offset: 0x000002AC
		public static string SelectedGamePath
		{
			get
			{
				return ConfigContol._selectedGamePath;
			}
			private set
			{
				bool flag = ConfigContol._selectedGamePath != value;
				if (flag)
				{
					ConfigContol._selectedGamePath = value;
					EventHandler onSelectedGamePathChanged = ConfigContol.OnSelectedGamePathChanged;
					if (onSelectedGamePathChanged != null)
					{
						onSelectedGamePathChanged(null, EventArgs.Empty);
					}
				}
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000009 RID: 9 RVA: 0x000020E8 File Offset: 0x000002E8
		// (remove) Token: 0x0600000A RID: 10 RVA: 0x0000211C File Offset: 0x0000031C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EventHandler OnSelectedGamePathChanged;

		// Token: 0x0600000B RID: 11 RVA: 0x00002150 File Offset: 0x00000350
		public ConfigContol()
		{
			this.InitializeComponent();
			this._settings = this._settingsService.Load();
			this.InitializeGameFolder();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000021A0 File Offset: 0x000003A0
		private void InitializeGameFolder()
		{
			bool isInitialized = ConfigContol._isInitialized;
			if (isInitialized)
			{
				this.UpdateUI();
				bool flag = !string.IsNullOrEmpty(ConfigContol.SelectedGamePath);
				if (flag)
				{
					this.CheckConfigFiles();
				}
			}
			else
			{
				try
				{
					AppSettings settings = this._settings;
					string text = (settings != null) ? settings.SavedRustPath : null;
					bool flag2 = !string.IsNullOrEmpty(text) && this.IsValidRustDirectory(text);
					if (flag2)
					{
						ConfigContol.SelectedGamePath = text;
					}
					else
					{
						List<string> list = this.FindAllRustGameFolders();
						bool flag3 = list.Count == 1;
						if (flag3)
						{
							ConfigContol.SelectedGamePath = list[0];
							this.SaveCurrentPath();
						}
						else
						{
							bool flag4 = list.Count > 1;
							if (flag4)
							{
								string text2 = this.ShowFolderSelectionDialog(list);
								bool flag5 = !string.IsNullOrEmpty(text2) && this.IsValidRustDirectory(text2);
								if (flag5)
								{
									ConfigContol.SelectedGamePath = text2;
									this.SaveCurrentPath();
								}
								else
								{
									ConfigContol.SelectedGamePath = null;
								}
							}
							else
							{
								ConfigContol.SelectedGamePath = null;
							}
						}
					}
				}
				catch
				{
					ConfigContol.SelectedGamePath = null;
				}
				finally
				{
					ConfigContol._isInitialized = true;
					this.UpdateUI();
					bool flag6 = !string.IsNullOrEmpty(ConfigContol.SelectedGamePath);
					if (flag6)
					{
						this.CheckConfigFiles();
					}
				}
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000022FC File Offset: 0x000004FC
		private void SaveCurrentPath()
		{
			bool flag = this._settings == null;
			if (flag)
			{
				this._settings = new AppSettings();
			}
			this._settings.SavedRustPath = (ConfigContol.SelectedGamePath ?? "");
			this._settingsService.Save(this._settings);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002350 File Offset: 0x00000550
		private bool CheckConfigFiles()
		{
			bool flag = string.IsNullOrWhiteSpace(ConfigContol.SelectedGamePath) || !Directory.Exists(ConfigContol.SelectedGamePath);
			bool result;
			if (flag)
			{
				this.StatusLabelInfo.Text = "папка с игрой не найдена";
				this.StatusLabelInfo.ForeColor = Color.FromArgb(253, 48, 48);
				this.BlockTabs();
				result = false;
			}
			else
			{
				string path = Path.Combine(ConfigContol.SelectedGamePath, ConfigContol.clientPath);
				string path2 = Path.Combine(ConfigContol.SelectedGamePath, ConfigContol.keysPath);
				bool flag2 = File.Exists(path);
				bool flag3 = File.Exists(path2);
				bool flag4 = !flag2 && !flag3;
				if (flag4)
				{
					result = this.<CheckConfigFiles>g__Warn|19_0("файл client.cfg не найден");
				}
				else
				{
					bool flag5 = !flag2;
					if (flag5)
					{
						result = this.<CheckConfigFiles>g__Warn|19_0("файл client.cfg не найден");
					}
					else
					{
						bool flag6 = !flag3;
						if (flag6)
						{
							result = this.<CheckConfigFiles>g__Warn|19_0("файл keys.cfg не найден");
						}
						else
						{
							bool flag7 = !ConfigContol.IsFileReadableWritable(path);
							if (flag7)
							{
								result = this.<CheckConfigFiles>g__Warn|19_0("файл client.cfg заблокирован");
							}
							else
							{
								bool flag8 = !ConfigContol.IsFileReadableWritable(path2);
								if (flag8)
								{
									result = this.<CheckConfigFiles>g__Warn|19_0("файл keys.cfg заблокирован");
								}
								else
								{
									this.StatusLabelInfo.Text = "папка с игрой найдена";
									this.StatusLabelInfo.ForeColor = Color.FromArgb(62, 253, 48);
									this.UnblockTabs();
									result = true;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000024B8 File Offset: 0x000006B8
		private void BlockTabs()
		{
			MainForm.Instance.TweakLabel.Enabled = false;
			MainForm.Instance.OptimisationLabel.Enabled = false;
			MainForm.Instance.GraphicsLabel.Enabled = false;
			MainForm.Instance.BindsLabel.Enabled = false;
			MainForm.Instance.guna2Panel2.Enabled = true;
			MainForm.Instance.guna2Panel2.MouseClick += delegate(object s, MouseEventArgs e)
			{
				NotificationService.ShowNotification("Укажите путь до папки с игрой", 2000);
			};
			MainForm.Instance.guna2Panel3.Enabled = true;
			MainForm.Instance.guna2Panel3.MouseClick += delegate(object s, MouseEventArgs e)
			{
				NotificationService.ShowNotification("Укажите путь до папки с игрой", 2000);
			};
			MainForm.Instance.guna2Panel4.Enabled = true;
			MainForm.Instance.guna2Panel4.MouseClick += delegate(object s, MouseEventArgs e)
			{
				NotificationService.ShowNotification("Укажите путь до папки с игрой", 2000);
			};
			MainForm.Instance.guna2Panel5.Enabled = true;
			MainForm.Instance.guna2Panel5.MouseClick += delegate(object s, MouseEventArgs e)
			{
				NotificationService.ShowNotification("Укажите путь до папки с игрой", 2000);
			};
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000260C File Offset: 0x0000080C
		private void UnblockTabs()
		{
			MainForm.Instance.TweakLabel.Enabled = true;
			MainForm.Instance.OptimisationLabel.Enabled = true;
			MainForm.Instance.GraphicsLabel.Enabled = true;
			MainForm.Instance.BindsLabel.Enabled = true;
			MainForm.Instance.ToolsLabel.Enabled = true;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002670 File Offset: 0x00000870
		private void UpdateUI()
		{
			bool flag = !string.IsNullOrEmpty(ConfigContol.SelectedGamePath);
			if (flag)
			{
				bool flag2 = this.StatusLabelInfo.ForeColor != Color.Orange;
				if (flag2)
				{
					this.StatusLabelInfo.Text = "папка с игрой найдена";
					this.StatusLabelInfo.ForeColor = Color.FromArgb(62, 253, 48);
				}
				this.PathLabel.Text = ConfigContol.SelectedGamePath;
				this.PathLabel.AutoEllipsis = true;
			}
			else
			{
				this.StatusLabelInfo.Text = "папка с игрой не найдена";
				this.StatusLabelInfo.ForeColor = Color.FromArgb(253, 48, 48);
				this.PathLabel.Text = "";
				this.BlockTabs();
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000273C File Offset: 0x0000093C
		private bool IsValidRustDirectory(string path)
		{
			bool flag = string.IsNullOrWhiteSpace(path);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !Directory.Exists(path);
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = File.Exists(Path.Combine(path, "RustClient.exe"));
					bool flag4 = File.Exists(Path.Combine(path, "Rust.exe"));
					result = (flag3 || flag4);
				}
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002794 File Offset: 0x00000994
		private List<string> FindAllRustGameFolders()
		{
			List<string> list = new List<string>();
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam"))
				{
					bool flag = registryKey != null;
					if (flag)
					{
						object value = registryKey.GetValue("SteamPath");
						bool flag2 = value != null;
						if (flag2)
						{
							string path = value.ToString().Replace("/", "\\");
							string item = Path.Combine(path, "steamapps", "common", "Rust");
							hashSet.Add(item);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Ошибка при чтении реестра Steam: " + ex.Message);
			}
			this.AddPathsFromLibraryFolders(hashSet);
			this.AddCommonPaths(hashSet);
			foreach (string text in hashSet)
			{
				bool flag3 = this.IsValidRustDirectory(text) && !list.Contains(text, StringComparer.OrdinalIgnoreCase);
				if (flag3)
				{
					list.Add(text);
				}
			}
			return list;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000028F0 File Offset: 0x00000AF0
		private void AddPathsFromLibraryFolders(HashSet<string> paths)
		{
			string path = "C:\\Program Files (x86)\\Steam\\steamapps\\libraryfolders.vdf";
			bool flag = File.Exists(path);
			if (flag)
			{
				try
				{
					string[] array = File.ReadAllLines(path);
					foreach (string input in array)
					{
						Match match = Regex.Match(input, "\"path\"\\s*\"([^\"]+)\"");
						bool success = match.Success;
						if (success)
						{
							string path2 = match.Groups[1].Value.Replace("\\\\", "\\");
							string item = Path.Combine(path2, "steamapps", "common", "Rust");
							paths.Add(item);
						}
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine("Ошибка при чтении libraryfolders.vdf: " + ex.Message);
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000029CC File Offset: 0x00000BCC
		private void AddCommonPaths(HashSet<string> paths)
		{
			string[] array = new string[]
			{
				"Steam\\steamapps\\common\\Rust",
				"Steam\\steamapps\\common\\RustStaging",
				"SteamLibrary\\steamapps\\common\\Rust",
				"SteamLibrary\\steamapps\\common\\RustStaging",
				"Program Files (x86)\\Steam\\steamapps\\common\\Rust",
				"Program Files (x86)\\Steam\\steamapps\\common\\RustStaging",
				"Program Files (x86)\\SteamLibrary\\steamapps\\common\\Rust",
				"Program Files (x86)\\SteamLibrary\\steamapps\\common\\RustStaging",
				"Games\\Rust",
				"Games\\RustStaging",
				"Games\\SteamLibrary\\steamapps\\common\\Rust",
				"Games\\SteamLibrary\\steamapps\\common\\RustStaging",
				"Games\\Steam\\steamapps\\common\\Rust",
				"Games\\Steam\\steamapps\\common\\RustStaging",
				"Rust",
				"RustStaging"
			};
			foreach (DriveInfo driveInfo in from d in DriveInfo.GetDrives()
			where d.DriveType == DriveType.Fixed
			select d)
			{
				foreach (string path in array)
				{
					string item = Path.Combine(driveInfo.Name, path);
					paths.Add(item);
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002B00 File Offset: 0x00000D00
		private string ShowFolderSelectionDialog(List<string> foundPaths)
		{
			string result;
			using (ChoosePath choosePath = new ChoosePath(foundPaths))
			{
				bool flag = choosePath.ShowDialog(this) == DialogResult.OK;
				if (flag)
				{
					result = choosePath.SelectedPath;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002B50 File Offset: 0x00000D50
		public static bool IsFileReadableWritable(string path)
		{
			bool result;
			try
			{
				using (File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
				{
					result = true;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002B9C File Offset: 0x00000D9C
		private void ChangeButton_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				folderBrowserDialog.Description = "Выберите папку с Rust";
				bool flag = !string.IsNullOrEmpty(ConfigContol.SelectedGamePath) && Directory.Exists(ConfigContol.SelectedGamePath);
				if (flag)
				{
					folderBrowserDialog.SelectedPath = ConfigContol.SelectedGamePath;
				}
				bool flag2 = folderBrowserDialog.ShowDialog(this) == DialogResult.OK;
				if (flag2)
				{
					string selectedPath = folderBrowserDialog.SelectedPath;
					bool flag3 = !this.IsValidRustDirectory(selectedPath);
					if (flag3)
					{
						NotificationService.ShowNotification("В выбранной папке не найден Rust", 1000);
					}
					else
					{
						ConfigContol.SelectedGamePath = selectedPath;
						this.SaveCurrentPath();
						this.UpdateUI();
						this.CheckConfigFiles();
					}
				}
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002C5C File Offset: 0x00000E5C
		private void ExportSetting_Click(object sender, EventArgs e)
		{
			bool flag = string.IsNullOrEmpty(ConfigContol.SelectedGamePath);
			if (flag)
			{
				NotificationService.ShowNotification("Не указан путь до папки с игрой", 1000);
			}
			else
			{
				string text = Path.Combine(ConfigContol.SelectedGamePath, ConfigContol.clientPath);
				bool flag2 = !File.Exists(text);
				if (flag2)
				{
					NotificationService.ShowNotification("Файл " + ConfigContol.clientPath + " не найден в указанной папке игры", 1000);
				}
				else
				{
					string str = DateTime.Now.ToString("dd.MM.yyyy_HH.mm.ss");
					try
					{
						using (SaveFileDialog saveFileDialog = new SaveFileDialog())
						{
							saveFileDialog.Title = "Сохранить файл";
							saveFileDialog.FileName = "client_backup_" + str + ".cfg";
							saveFileDialog.Filter = "Текстовые файлы (*.cfg)|*.cfg";
							saveFileDialog.InitialDirectory = Path.Combine(ConfigContol.SelectedGamePath, "cfg");
							bool flag3 = saveFileDialog.ShowDialog() == DialogResult.OK;
							if (flag3)
							{
								File.Copy(text, saveFileDialog.FileName, true);
								NotificationService.ShowNotification("Настройки успешно сохранены", 1000);
							}
						}
					}
					catch (Exception ex)
					{
						NotificationService.ShowNotification("Ошибка" + ex.Message, 1000);
					}
				}
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002DBC File Offset: 0x00000FBC
		private void ImportSetting_Click(object sender, EventArgs e)
		{
			bool flag = string.IsNullOrEmpty(ConfigContol.SelectedGamePath);
			if (flag)
			{
				NotificationService.ShowNotification("Не указан путь до папки с игрой", 1000);
			}
			else
			{
				string text = Path.Combine(ConfigContol.SelectedGamePath, ConfigContol.clientPath);
				bool flag2 = !File.Exists(text);
				if (flag2)
				{
					NotificationService.ShowNotification("Файл " + ConfigContol.clientPath + " не найден в указанной папке игры", 1000);
				}
				else
				{
					bool flag3 = !ConfigContol.IsFileReadableWritable(text);
					if (flag3)
					{
						NotificationService.ShowNotification("Файл client.cfg заблокирован для записи", 1000);
					}
					else
					{
						try
						{
							using (OpenFileDialog openFileDialog = new OpenFileDialog())
							{
								openFileDialog.Title = "Выберите файл для восстановления настроек";
								openFileDialog.Filter = "Текстовые файлы (*.cfg)|*.cfg";
								openFileDialog.InitialDirectory = Path.Combine(ConfigContol.SelectedGamePath, "cfg");
								bool flag4 = openFileDialog.ShowDialog() == DialogResult.OK;
								if (flag4)
								{
									string fileName = openFileDialog.FileName;
									File.Copy(fileName, text, true);
									NotificationService.ShowNotification("Настройки восстановлены", 1000);
								}
							}
						}
						catch (Exception ex)
						{
							NotificationService.ShowNotification("Ошибка: " + ex.Message, 1000);
						}
					}
				}
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002F14 File Offset: 0x00001114
		private void ExportBinds_Click(object sender, EventArgs e)
		{
			bool flag = string.IsNullOrEmpty(ConfigContol.SelectedGamePath);
			if (flag)
			{
				NotificationService.ShowNotification("Не указан путь до папки с игрой", 1000);
			}
			else
			{
				string text = Path.Combine(ConfigContol.SelectedGamePath, ConfigContol.keysPath);
				bool flag2 = !File.Exists(text);
				if (flag2)
				{
					NotificationService.ShowNotification("Файл " + ConfigContol.keysPath + " не найден в указанной папке игры", 1000);
				}
				else
				{
					string str = DateTime.Now.ToString("dd.MM.yyyy_HH.mm.ss");
					try
					{
						using (SaveFileDialog saveFileDialog = new SaveFileDialog())
						{
							saveFileDialog.Title = "Сохранить файл";
							saveFileDialog.FileName = "keys_backup_" + str + ".cfg";
							saveFileDialog.Filter = "Текстовые файлы (*.cfg)|*.cfg";
							saveFileDialog.InitialDirectory = Path.Combine(ConfigContol.SelectedGamePath, "cfg");
							bool flag3 = saveFileDialog.ShowDialog() == DialogResult.OK;
							if (flag3)
							{
								File.Copy(text, saveFileDialog.FileName, true);
								NotificationService.ShowNotification("Бинды успешно сохранены", 1000);
							}
						}
					}
					catch (Exception ex)
					{
						NotificationService.ShowNotification("Ошибка: " + ex.Message, 1000);
					}
				}
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003074 File Offset: 0x00001274
		private void ImportBinds_Click(object sender, EventArgs e)
		{
			bool flag = string.IsNullOrEmpty(ConfigContol.SelectedGamePath);
			if (flag)
			{
				NotificationService.ShowNotification("Не указан путь до папки с игрой", 1000);
			}
			else
			{
				string text = Path.Combine(ConfigContol.SelectedGamePath, ConfigContol.keysPath);
				bool flag2 = !File.Exists(text);
				if (flag2)
				{
					NotificationService.ShowNotification("Файл " + ConfigContol.keysPath + " не найден в указанной папке игры", 1000);
				}
				else
				{
					bool flag3 = !ConfigContol.IsFileReadableWritable(text);
					if (flag3)
					{
						NotificationService.ShowNotification("Файл keys.cfg заблокирован для записи", 1000);
					}
					else
					{
						try
						{
							using (OpenFileDialog openFileDialog = new OpenFileDialog())
							{
								openFileDialog.Title = "Выберите файл для восстановления биндов";
								openFileDialog.Filter = "Текстовые файлы (*.cfg)|*.cfg";
								openFileDialog.InitialDirectory = Path.Combine(ConfigContol.SelectedGamePath, "cfg");
								bool flag4 = openFileDialog.ShowDialog() == DialogResult.OK;
								if (flag4)
								{
									string fileName = openFileDialog.FileName;
									File.Copy(fileName, text, true);
									NotificationService.ShowNotification("Бинды восстановлены", 1000);
								}
							}
						}
						catch (Exception ex)
						{
							NotificationService.ShowNotification("Ошибка: " + ex.Message, 1000);
						}
					}
				}
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000031CC File Offset: 0x000013CC
		private void pasteIcon_Click(object sender, EventArgs e)
		{
			string text = Clipboard.GetText() ?? string.Empty;
			string text2 = text.Trim().Trim(new char[]
			{
				'"'
			});
			bool flag = string.IsNullOrEmpty(text2);
			if (flag)
			{
				NotificationService.ShowNotification("Буфер обмена пуст", 1000);
			}
			else
			{
				string text3 = text2;
				try
				{
					bool flag2 = File.Exists(text3);
					if (flag2)
					{
						string directoryName = Path.GetDirectoryName(text3);
						string text4;
						if (directoryName == null)
						{
							text4 = null;
						}
						else
						{
							DirectoryInfo parent = Directory.GetParent(directoryName);
							text4 = ((parent != null) ? parent.FullName : null);
						}
						string text5 = text4;
						text3 = (text5 ?? text3);
					}
					else
					{
						bool flag3 = Directory.Exists(text3);
						if (flag3)
						{
							string fileName = Path.GetFileName(text3.TrimEnd(new char[]
							{
								Path.DirectorySeparatorChar,
								Path.AltDirectorySeparatorChar
							}));
							bool flag4 = string.Equals(fileName, "cfg", StringComparison.OrdinalIgnoreCase);
							if (flag4)
							{
								DirectoryInfo parent2 = Directory.GetParent(text3);
								string text6 = (parent2 != null) ? parent2.FullName : null;
								text3 = (text6 ?? text3);
							}
						}
						else
						{
							int num = text3.LastIndexOf("\\cfg", StringComparison.OrdinalIgnoreCase);
							bool flag5 = num > 0;
							if (flag5)
							{
								text3 = text3.Substring(0, num);
							}
						}
					}
				}
				catch
				{
					NotificationService.ShowNotification("Некорректный путь в буфере обмена", 1000);
					return;
				}
				bool flag6 = !Directory.Exists(text3) || !this.IsValidRustDirectory(text3);
				if (flag6)
				{
					NotificationService.ShowNotification("Неверный путь до папки Rust", 1000);
				}
				else
				{
					ConfigContol.SelectedGamePath = text3;
					this.UpdateUI();
					bool flag7 = !this.CheckConfigFiles();
					if (!flag7)
					{
						this.SaveCurrentPath();
						NotificationService.ShowNotification("Путь до папки с игрой изменен", 1000);
					}
				}
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003378 File Offset: 0x00001578
		private void copyIcon_Click(object sender, EventArgs e)
		{
			bool flag = string.IsNullOrEmpty(this.PathLabel.Text);
			if (flag)
			{
				NotificationService.ShowNotification("Нечего копировать", 1000);
			}
			else
			{
				Clipboard.SetText(ConfigContol.SelectedGamePath);
				NotificationService.ShowNotification("Путь до папки с игрой скопирован", 1000);
				this.UpdateUI();
				this.CheckConfigFiles();
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000033D6 File Offset: 0x000015D6
		private void pasteIcon_MouseEnter(object sender, EventArgs e)
		{
			this.pasteIcon.Size = new Size(17, 17);
			this.pasteIcon.MouseLeave += delegate(object s, EventArgs e)
			{
				this.pasteIcon.Size = new Size(16, 16);
			};
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003406 File Offset: 0x00001606
		private void copyIcon_MouseEnter(object sender, EventArgs e)
		{
			this.copyIcon.Size = new Size(17, 17);
			this.copyIcon.MouseLeave += delegate(object s, EventArgs e)
			{
				this.copyIcon.Size = new Size(16, 16);
			};
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003438 File Offset: 0x00001638
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003470 File Offset: 0x00001670
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ConfigContol));
			this.ImportBinds = new Guna2Button();
			this.ExportBinds = new Guna2Button();
			this.ImportSetting = new Guna2Button();
			this.ExportSetting = new Guna2Button();
			this.ActionsWithConfigLabel = new Label();
			this.ChangeButton = new Guna2Button();
			this.StatusLabel = new Label();
			this.ConfigMainContainer = new Panel();
			this.ConfigMainPanel = new Guna2Panel();
			this.guna2Panel1 = new Guna2Panel();
			this.PathLabel = new Label();
			this.pasteIcon = new Guna2PictureBox();
			this.copyIcon = new Guna2PictureBox();
			this.StatusLabelInfo = new Label();
			this.ToolTip = new Guna2HtmlToolTip();
			this.ConfigMainContainer.SuspendLayout();
			this.ConfigMainPanel.SuspendLayout();
			this.guna2Panel1.SuspendLayout();
			((ISupportInitialize)this.pasteIcon).BeginInit();
			((ISupportInitialize)this.copyIcon).BeginInit();
			base.SuspendLayout();
			this.ImportBinds.Animated = true;
			this.ImportBinds.BorderColor = Color.Transparent;
			this.ImportBinds.BorderRadius = 6;
			this.ImportBinds.Cursor = Cursors.Hand;
			this.ImportBinds.DisabledState.BorderColor = Color.DarkGray;
			this.ImportBinds.DisabledState.CustomBorderColor = Color.DarkGray;
			this.ImportBinds.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.ImportBinds.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.ImportBinds.FillColor = Color.FromArgb(106, 106, 106);
			this.ImportBinds.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold);
			this.ImportBinds.ForeColor = Color.White;
			this.ImportBinds.Location = new Point(0, 343);
			this.ImportBinds.Name = "ImportBinds";
			this.ImportBinds.Size = new Size(483, 51);
			this.ImportBinds.TabIndex = 16;
			this.ImportBinds.TabStop = false;
			this.ImportBinds.Text = "Импорт биндов";
			this.ImportBinds.Click += this.ImportBinds_Click;
			this.ExportBinds.Animated = true;
			this.ExportBinds.BorderColor = Color.Transparent;
			this.ExportBinds.BorderRadius = 6;
			this.ExportBinds.Cursor = Cursors.Hand;
			this.ExportBinds.DisabledState.BorderColor = Color.DarkGray;
			this.ExportBinds.DisabledState.CustomBorderColor = Color.DarkGray;
			this.ExportBinds.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.ExportBinds.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.ExportBinds.FillColor = Color.FromArgb(106, 106, 106);
			this.ExportBinds.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold);
			this.ExportBinds.ForeColor = Color.White;
			this.ExportBinds.Location = new Point(0, 286);
			this.ExportBinds.Name = "ExportBinds";
			this.ExportBinds.Size = new Size(483, 51);
			this.ExportBinds.TabIndex = 15;
			this.ExportBinds.TabStop = false;
			this.ExportBinds.Text = "Экспорт биндов";
			this.ExportBinds.Click += this.ExportBinds_Click;
			this.ImportSetting.Animated = true;
			this.ImportSetting.BorderColor = Color.Transparent;
			this.ImportSetting.BorderRadius = 6;
			this.ImportSetting.Cursor = Cursors.Hand;
			this.ImportSetting.DisabledState.BorderColor = Color.DarkGray;
			this.ImportSetting.DisabledState.CustomBorderColor = Color.DarkGray;
			this.ImportSetting.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.ImportSetting.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.ImportSetting.FillColor = Color.FromArgb(106, 106, 106);
			this.ImportSetting.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold);
			this.ImportSetting.ForeColor = Color.White;
			this.ImportSetting.Location = new Point(0, 229);
			this.ImportSetting.Name = "ImportSetting";
			this.ImportSetting.Size = new Size(483, 51);
			this.ImportSetting.TabIndex = 14;
			this.ImportSetting.TabStop = false;
			this.ImportSetting.Text = "Импорт настроек игры";
			this.ImportSetting.Click += this.ImportSetting_Click;
			this.ExportSetting.Animated = true;
			this.ExportSetting.BorderColor = Color.Transparent;
			this.ExportSetting.BorderRadius = 6;
			this.ExportSetting.Cursor = Cursors.Hand;
			this.ExportSetting.DisabledState.BorderColor = Color.DarkGray;
			this.ExportSetting.DisabledState.CustomBorderColor = Color.DarkGray;
			this.ExportSetting.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.ExportSetting.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.ExportSetting.FillColor = Color.FromArgb(106, 106, 106);
			this.ExportSetting.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold);
			this.ExportSetting.ForeColor = Color.White;
			this.ExportSetting.Location = new Point(0, 172);
			this.ExportSetting.Name = "ExportSetting";
			this.ExportSetting.Size = new Size(483, 51);
			this.ExportSetting.TabIndex = 13;
			this.ExportSetting.TabStop = false;
			this.ExportSetting.Text = "Экспорт настроек игры";
			this.ExportSetting.Click += this.ExportSetting_Click;
			this.ActionsWithConfigLabel.AutoSize = true;
			this.ActionsWithConfigLabel.Font = new Font("Segoe UI", 13f);
			this.ActionsWithConfigLabel.Location = new Point(0, 143);
			this.ActionsWithConfigLabel.Name = "ActionsWithConfigLabel";
			this.ActionsWithConfigLabel.Size = new Size(192, 25);
			this.ActionsWithConfigLabel.TabIndex = 12;
			this.ActionsWithConfigLabel.Text = "Действия с конфигом:";
			this.ChangeButton.Animated = true;
			this.ChangeButton.BorderColor = Color.Empty;
			this.ChangeButton.BorderRadius = 6;
			this.ChangeButton.Cursor = Cursors.Hand;
			this.ChangeButton.DisabledState.BorderColor = Color.DarkGray;
			this.ChangeButton.DisabledState.CustomBorderColor = Color.DarkGray;
			this.ChangeButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			this.ChangeButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			this.ChangeButton.FillColor = Color.FromArgb(106, 106, 106);
			this.ChangeButton.Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold);
			this.ChangeButton.ForeColor = Color.White;
			this.ChangeButton.HoverState.FillColor = Color.FromArgb(253, 253, 48);
			this.ChangeButton.HoverState.ForeColor = Color.FromArgb(64, 64, 64);
			this.ChangeButton.Location = new Point(365, 29);
			this.ChangeButton.Margin = new Padding(0);
			this.ChangeButton.Name = "ChangeButton";
			this.ChangeButton.Size = new Size(118, 36);
			this.ChangeButton.TabIndex = 11;
			this.ChangeButton.TabStop = false;
			this.ChangeButton.Text = "Изменить";
			this.ChangeButton.Click += this.ChangeButton_Click;
			this.StatusLabel.AutoSize = true;
			this.StatusLabel.Font = new Font("Segoe UI", 13f);
			this.StatusLabel.Location = new Point(0, 0);
			this.StatusLabel.Margin = new Padding(0);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new Size(67, 25);
			this.StatusLabel.TabIndex = 9;
			this.StatusLabel.Text = "Статус:";
			this.ConfigMainContainer.Controls.Add(this.ConfigMainPanel);
			this.ConfigMainContainer.Dock = DockStyle.Fill;
			this.ConfigMainContainer.Location = new Point(0, 0);
			this.ConfigMainContainer.Name = "ConfigMainContainer";
			this.ConfigMainContainer.Padding = new Padding(100, 27, 100, 32);
			this.ConfigMainContainer.Size = new Size(683, 564);
			this.ConfigMainContainer.TabIndex = 18;
			this.ConfigMainPanel.Controls.Add(this.guna2Panel1);
			this.ConfigMainPanel.Controls.Add(this.StatusLabelInfo);
			this.ConfigMainPanel.Controls.Add(this.StatusLabel);
			this.ConfigMainPanel.Controls.Add(this.ChangeButton);
			this.ConfigMainPanel.Controls.Add(this.ExportSetting);
			this.ConfigMainPanel.Controls.Add(this.ActionsWithConfigLabel);
			this.ConfigMainPanel.Controls.Add(this.ImportBinds);
			this.ConfigMainPanel.Controls.Add(this.ExportBinds);
			this.ConfigMainPanel.Controls.Add(this.ImportSetting);
			this.ConfigMainPanel.Dock = DockStyle.Top;
			this.ConfigMainPanel.Font = new Font("Segoe UI", 11f);
			this.ConfigMainPanel.Location = new Point(100, 27);
			this.ConfigMainPanel.Name = "ConfigMainPanel";
			this.ConfigMainPanel.Size = new Size(483, 497);
			this.ConfigMainPanel.TabIndex = 17;
			this.guna2Panel1.BorderRadius = 6;
			this.guna2Panel1.Controls.Add(this.PathLabel);
			this.guna2Panel1.Controls.Add(this.pasteIcon);
			this.guna2Panel1.Controls.Add(this.copyIcon);
			this.guna2Panel1.FillColor = Color.FromArgb(16, 16, 16);
			this.guna2Panel1.Location = new Point(1, 29);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new Size(362, 36);
			this.guna2Panel1.TabIndex = 22;
			this.PathLabel.BackColor = Color.Transparent;
			this.PathLabel.Location = new Point(2, 7);
			this.PathLabel.Name = "PathLabel";
			this.PathLabel.Size = new Size(310, 22);
			this.PathLabel.TabIndex = 18;
			this.PathLabel.TextAlign = ContentAlignment.MiddleLeft;
			this.pasteIcon.BackColor = Color.Transparent;
			this.pasteIcon.Cursor = Cursors.Hand;
			this.pasteIcon.Image = (Image)componentResourceManager.GetObject("pasteIcon.Image");
			this.pasteIcon.ImageRotate = 0f;
			this.pasteIcon.Location = new Point(314, 10);
			this.pasteIcon.Name = "pasteIcon";
			this.pasteIcon.Size = new Size(16, 16);
			this.pasteIcon.SizeMode = PictureBoxSizeMode.Zoom;
			this.pasteIcon.TabIndex = 21;
			this.pasteIcon.TabStop = false;
			this.ToolTip.SetToolTip(this.pasteIcon, "Вставить путь из буфера");
			this.pasteIcon.UseTransparentBackground = true;
			this.pasteIcon.Click += this.pasteIcon_Click;
			this.pasteIcon.MouseEnter += this.pasteIcon_MouseEnter;
			this.copyIcon.BackColor = Color.Transparent;
			this.copyIcon.Cursor = Cursors.Hand;
			this.copyIcon.Image = (Image)componentResourceManager.GetObject("copyIcon.Image");
			this.copyIcon.ImageRotate = 0f;
			this.copyIcon.Location = new Point(336, 10);
			this.copyIcon.Name = "copyIcon";
			this.copyIcon.Size = new Size(16, 16);
			this.copyIcon.SizeMode = PictureBoxSizeMode.Zoom;
			this.copyIcon.TabIndex = 20;
			this.copyIcon.TabStop = false;
			this.ToolTip.SetToolTip(this.copyIcon, "Скопировать путь до папки Rust");
			this.copyIcon.UseTransparentBackground = true;
			this.copyIcon.Click += this.copyIcon_Click;
			this.copyIcon.MouseEnter += this.copyIcon_MouseEnter;
			this.StatusLabelInfo.AutoSize = true;
			this.StatusLabelInfo.BackColor = Color.Transparent;
			this.StatusLabelInfo.Font = new Font("Segoe UI", 13f);
			this.StatusLabelInfo.Location = new Point(60, 0);
			this.StatusLabelInfo.Margin = new Padding(0);
			this.StatusLabelInfo.Name = "StatusLabelInfo";
			this.StatusLabelInfo.Size = new Size(119, 25);
			this.StatusLabelInfo.TabIndex = 17;
			this.StatusLabelInfo.Text = "неопределен";
			this.ToolTip.AllowLinksHandling = true;
			this.ToolTip.AutomaticDelay = 250;
			this.ToolTip.AutoPopDelay = 2500;
			this.ToolTip.InitialDelay = 250;
			this.ToolTip.MaximumSize = new Size(0, 0);
			this.ToolTip.ReshowDelay = 1500;
			base.AutoScaleDimensions = new SizeF(96f, 96f);
			base.AutoScaleMode = AutoScaleMode.Dpi;
			this.BackColor = Color.FromArgb(54, 54, 54);
			base.Controls.Add(this.ConfigMainContainer);
			this.Font = new Font("Segoe UI", 12f);
			this.ForeColor = Color.White;
			base.Margin = new Padding(4, 5, 4, 5);
			base.Name = "ConfigContol";
			base.Size = new Size(683, 564);
			this.ConfigMainContainer.ResumeLayout(false);
			this.ConfigMainPanel.ResumeLayout(false);
			this.ConfigMainPanel.PerformLayout();
			this.guna2Panel1.ResumeLayout(false);
			((ISupportInitialize)this.pasteIcon).EndInit();
			((ISupportInitialize)this.copyIcon).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000454C File Offset: 0x0000274C
		[CompilerGenerated]
		private bool <CheckConfigFiles>g__Warn|19_0(string msg)
		{
			this.StatusLabelInfo.Text = msg;
			this.StatusLabelInfo.ForeColor = Color.Orange;
			this.BlockTabs();
			return false;
		}

		// Token: 0x04000004 RID: 4
		private static string _selectedGamePath;

		// Token: 0x04000006 RID: 6
		private static bool _isInitialized = false;

		// Token: 0x04000007 RID: 7
		public static string clientPath = "cfg\\client.cfg";

		// Token: 0x04000008 RID: 8
		public static string keysPath = "cfg\\keys.cfg";

		// Token: 0x04000009 RID: 9
		private readonly AppSettingsService _settingsService = new AppSettingsService("RustTweaker", "appsettings.json");

		// Token: 0x0400000A RID: 10
		private AppSettings _settings;

		// Token: 0x0400000B RID: 11
		private IContainer components = null;

		// Token: 0x0400000C RID: 12
		private Guna2Button ImportBinds;

		// Token: 0x0400000D RID: 13
		private Guna2Button ExportBinds;

		// Token: 0x0400000E RID: 14
		private Guna2Button ImportSetting;

		// Token: 0x0400000F RID: 15
		private Guna2Button ExportSetting;

		// Token: 0x04000010 RID: 16
		private Label ActionsWithConfigLabel;

		// Token: 0x04000011 RID: 17
		private Guna2Button ChangeButton;

		// Token: 0x04000012 RID: 18
		private Label StatusLabel;

		// Token: 0x04000013 RID: 19
		private Panel ConfigMainContainer;

		// Token: 0x04000014 RID: 20
		private Guna2Panel ConfigMainPanel;

		// Token: 0x04000015 RID: 21
		private Label StatusLabelInfo;

		// Token: 0x04000016 RID: 22
		private Label PathLabel;

		// Token: 0x04000017 RID: 23
		private Guna2PictureBox copyIcon;

		// Token: 0x04000018 RID: 24
		private Guna2PictureBox pasteIcon;

		// Token: 0x04000019 RID: 25
		private Guna2HtmlToolTip ToolTip;

		// Token: 0x0400001A RID: 26
		private Guna2Panel guna2Panel1;
	}
}
