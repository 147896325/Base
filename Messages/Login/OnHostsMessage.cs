using System;

namespace Messages.Login
{
	public class OnHostsMessage : IMessages
	{
		public bool canAccess;

		public OnHostsMessage (String sExtraData, int serverID)
		{
			canAccess = true;
			String[] _loc5_ = sExtraData.Split('|');
			int _loc6_ = 0;
			while (_loc6_ < _loc5_.Length) 
			{
				String[] _loc7_ = _loc5_ [_loc6_].ToString ().Split (';');
				int id = Convert.ToInt32(_loc7_ [0]);
				int state = Convert.ToInt32(_loc7_ [1]);
				int completion = Convert.ToInt32(_loc7_ [2]);
				bool canLog = _loc7_ [3] == "1";

				if(id==serverID && state!=1)
				{
					canAccess = false;
				}
				_loc6_++;
					
			}
		}
		public string Message()
		{
			return "Ax";
		}
	}
}

