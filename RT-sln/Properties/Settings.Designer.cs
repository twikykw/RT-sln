using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RustTweaker.Properties
{
	// Token: 0x0200000C RID: 12
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.12.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00007C74 File Offset: 0x00005E74
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00007C8C File Offset: 0x00005E8C
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00007CAE File Offset: 0x00005EAE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SaveRustPath
		{
			get
			{
				return (string)this["SaveRustPath"];
			}
			set
			{
				this["SaveRustPath"] = value;
			}
		}

		// Token: 0x04000051 RID: 81
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
