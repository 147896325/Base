using System;

namespace Messages.Login
{
	public class LogonMessage : IMessages
	{
		//aks.send(sLogin + '\n' + Utils.Crypt.cryptPassword(sPassword,aks.connexionKey));
		private string key, login, password;

		public LogonMessage (String _login, String _password, String _hcKey)
		{
			key = _hcKey;
			login = _login;
			password = cryptPassword(_password,key);
		}

		public string Message()
		{
			return login + '\n' + password;
		}

		private String cryptPassword(String sPassword,String connexionKey)
		{
			String hash = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
			String loc4 = "#1";
			for (int i = 0; i < sPassword.Length; i++) {
				int loc6 = (int) sPassword [i];
				int loc7 = (int) connexionKey [i];
				int loc8 = (int) Math.Floor ((double)(loc6 / 16));
				int loc9 = loc6 % 16;
				loc4 = loc4 + hash[ (loc8 + loc7 % hash.Length ) % hash.Length ] + hash[(loc9 + loc7 % hash.Length) % hash.Length];
			}
			return loc4;
		}
	}
}

