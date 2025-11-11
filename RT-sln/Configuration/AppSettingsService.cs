using System;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace RustTweaker.Configuration
{
	// Token: 0x02000013 RID: 19
	public sealed class AppSettingsService
	{
		// Token: 0x0600007C RID: 124 RVA: 0x0000C2D4 File Offset: 0x0000A4D4
		public AppSettingsService(string appFolderName = "RustTweaker", string fileName = "appsettings.json")
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			this._folderPath = Path.Combine(folderPath, appFolderName);
			this._filePath = Path.Combine(this._folderPath, fileName);
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600007D RID: 125 RVA: 0x0000C31B File Offset: 0x0000A51B
		public string SettingsFilePath
		{
			get
			{
				return this._filePath;
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000C324 File Offset: 0x0000A524
		public AppSettings Load()
		{
			object sync = this._sync;
			AppSettings result;
			lock (sync)
			{
				try
				{
					bool flag2 = !File.Exists(this._filePath);
					if (flag2)
					{
						result = new AppSettings();
					}
					else
					{
						string value = File.ReadAllText(this._filePath);
						result = (JsonConvert.DeserializeObject<AppSettings>(value) ?? new AppSettings());
					}
				}
				catch
				{
					result = new AppSettings();
				}
			}
			return result;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000C3B4 File Offset: 0x0000A5B4
		public void Save(AppSettings settings)
		{
			bool flag = settings == null;
			if (flag)
			{
				throw new ArgumentNullException("settings");
			}
			object sync = this._sync;
			lock (sync)
			{
				Directory.CreateDirectory(this._folderPath);
				string contents = JsonConvert.SerializeObject(settings, Formatting.Indented);
				File.WriteAllText(this._filePath, contents);
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000C428 File Offset: 0x0000A628
		public string GetSavedRustPath()
		{
			AppSettings appSettings = this.Load();
			return appSettings.SavedRustPath ?? "";
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000C450 File Offset: 0x0000A650
		[NullableContext(2)]
		public void SetSavedRustPath(string path)
		{
			AppSettings appSettings = this.Load();
			appSettings.SavedRustPath = (path ?? "");
			this.Save(appSettings);
		}

		// Token: 0x04000088 RID: 136
		private readonly string _folderPath;

		// Token: 0x04000089 RID: 137
		private readonly string _filePath;

		// Token: 0x0400008A RID: 138
		private readonly object _sync = new object();
	}
}
