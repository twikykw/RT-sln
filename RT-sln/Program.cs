using System;
using System.Windows.Forms;

namespace RustTweaker
{
	// Token: 0x0200000A RID: 10
	internal static class Program
	{
		// Token: 0x06000050 RID: 80 RVA: 0x00007BE5 File Offset: 0x00005DE5
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
