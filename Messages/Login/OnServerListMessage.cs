using System;
using System.Collections.Generic;

namespace Messages.Login
{
	public class OnServerListMessage : IMessages
	{
		private int _serverID;
		private bool _subscriber;

		private Dictionary<int,int> _servers;

		public OnServerListMessage (int serverID, string sData)
		{
			_servers = new Dictionary<int,int> ();
			_serverID = serverID;

			String[] loc5 = sData.Split ('|');
			int subscriberTimestamp = Convert.ToInt32(loc5 [0]);
			_subscriber = (bool)(subscriberTimestamp > 0);

			for(int i = 1 ; i < loc5.Length; i++)
			{
				var _loc10_ = loc5[i].Split(',');
				int _sID = Convert.ToInt32(_loc10_[0]);
				int _chara = Convert.ToInt32(_loc10_[1]);
				if(!_servers.ContainsKey(_sID))
				{
					_servers.Add (_sID, _chara);
				}
			}
				
		}

		public string Message()
		{
			if (_servers.ContainsKey (_serverID))
				return "AX" + _serverID;
			else
				return null;
		}
	}
}

