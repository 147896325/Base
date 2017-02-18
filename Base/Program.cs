using System;
using System.Threading;

namespace Base
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Utils.AccountsLoader acLoader = new Base.Utils.AccountsLoader ();
			Console.WriteLine (
				"                      ______                  __ ___   ___  \n" +
				"                     |  ____|                /_ |__ \\ / _ \\ \n" +
				"                     | |__ __ _ _ __ _ __ ___ | |  ) | (_) |\n" +
				"                     |  __/ _` | '__| '_ ` _ \\| | / / \\__, |\n" +
				"                     | | | (_| | |  | | | | | | |/ /_   / / \n" +
				"                     |_|  \\__,_|_|  |_| |_| |_|_|____| /_/  \n\n");
			Console.WriteLine("" +
				"|==============================================================================|");
			Console.WriteLine (
				"                                                Bot 1.29.1 par int80h            ");
			Console.WriteLine("" +
				"|==============================================================================|");
			foreach (var account in acLoader._acc) {
				new Thread(() => 
					{
						Thread.CurrentThread.IsBackground = true; 
						Bot _bot = new Bot (account);
					}).Start();
			}


			Console.ReadLine ();
		}
	}
}
