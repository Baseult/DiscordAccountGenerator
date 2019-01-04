using System;
using System.Windows.Forms;

namespace DAC_v4
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new DAC());
		}
	}
}