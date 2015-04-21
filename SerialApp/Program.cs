using System;
using SerialApp.Properties;

namespace SerialApp
{
	public class Program
	{
		public static void Main()
		{
			using (var sm = new SerialManager(Settings.Default.Port))
			{
				Console.WriteLine("Type commands (AT, ATZ, ATI, ATDnumber, ATH, ATA), empty line to exit:");
				string line;
				do
				{
					line = Console.ReadLine();
					sm.Send(line);
				} while (!string.IsNullOrWhiteSpace(line));
			}
		}
	}
}