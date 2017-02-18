using System;

namespace Messages.Game
{
	public class TicketResponse : IMessages
	{
		private short _key;
		public static char[] HEX_CHARS = {'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};

		public TicketResponse (string sExtraData)
		{
			_key = Convert.ToInt16 (sExtraData.Substring(0,1));
		}
		public string Message()
		{
			return "Ak" + HEX_CHARS [_key];
		}
	}
}

