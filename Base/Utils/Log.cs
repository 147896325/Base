using System;
using System.Text;

namespace Base.Utils
{
	class Log
	{
		public static void Write (String msg, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine ("[" + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second + "]" + msg.Trim('\n'));
			Console.ResetColor ();
		}
		public static void Alert (String msg)
		{
			Write (msg, ConsoleColor.DarkRed);
		}
		public static void Succes (String msg)
		{
			Write (msg, ConsoleColor.DarkGreen);
		}
		public static void Info (String msg)
		{
			Write (msg, ConsoleColor.DarkYellow);
		}
		public static void RecvLog(String msg, bool verbose = false)
		{
			String byteValues = "";
			foreach (char c in msg) {
				byteValues += (int)c + " ";
			}
			String verb = "{Len: " + msg.Length + ", Byte[]: " + byteValues + " }";
			Write ("[RECV] " 
				+ ((verbose)?verb:"")
				+": " + msg, ConsoleColor.White);
		}
		public static void SendLog(String msg, bool verbose = false)
		{
			String byteValues = "";
			foreach (char c in msg) {
				byteValues += (int)c + " ";
			}
			String verb = "{Len: " + msg.Length + ", Byte[]: " + byteValues + " }";
			Write ("[SEND] " 
				+ ((verbose)?verb:"")
				+": " + msg, ConsoleColor.Cyan);
		}
	}
}
