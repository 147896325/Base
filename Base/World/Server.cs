using System;

namespace Base.World
{
	public class Server
	{
		public bool _isLogin;
		public string _HCKey;
		public string _ip;
		public int _port;

		public string _ticket;
		public int _key;

		public Server (string ip,int port)
		{
			_ip = ip;
			_port = port;
		}
	}
}

