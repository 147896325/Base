using System;

namespace Messages.Game
{
	public class TicketMessage : IMessages
	{
		private string ticket;

		public TicketMessage (string _ticket)
		{
			ticket = _ticket;
		}

		public string Message()
		{
			return "AT" + ticket;
		}

	}
}

