using System;
using SocketLibrary;
using System.Collections.Generic;

namespace Base
{
	public class Bot
	{
		private CustomAsync socket;
		private World.Server loginServer;

		private World.Server gameServer;

		private World.Account account;

		public Bot (World.Account _acc)
		{
			loginServer = new World.Server ("80.239.173.166",443);
			account = _acc;

			socket = new CustomAsync (
				new System.Net.IPEndPoint(
					System.Net.IPAddress.Parse(loginServer._ip),
					loginServer._port
				)
			);
			socket.OnReceive += S_OnReceive;
		}

		public void connectToGameServer(bool bSuccess, bool bUseIp, String sExtraData)
		{
			if (bSuccess) {
				if (bUseIp) {
					String _loc8_ = sExtraData.Substring (0, 8);
					String _loc9_ = sExtraData.Substring (8, 3);
					String _loc7_ = sExtraData.Substring (11);
					List<int> _loc10_ = new List<int> ();
					int _loc11_ = 0;
					while (_loc11_ < 8) {
						var _loc12_ = Convert.ToInt32 (_loc8_ [(_loc11_)]) - 48;
						var _loc13_ = Convert.ToInt32 (_loc8_ [_loc11_ + 1]) - 48;
						_loc10_.Add ((_loc12_ & 15) << 4 | _loc13_ & 15);
						_loc11_ = _loc11_ + 2;
					}
					string _loc5_ = string.Join (".", _loc10_);
					var _loc6_ = (Utils.Compressor.decode64 (_loc9_ [0]) & 63) << 12 
						|(Utils.Compressor.decode64 (_loc9_ [1]) & 63) << 6 
						| Utils.Compressor.decode64 (_loc9_ [2]) & 63;

					string ticket = _loc7_;
					string gameserver_ip = _loc5_;
					int gameserver_port = _loc6_;
					bool ignoreMigration = false;
					bool ignoreCreateCharacter = false;

					gameServer = new World.Server (gameserver_ip,gameserver_port);
					gameServer._ticket = ticket;

					socket.close ();
					socket = new CustomAsync (new System.Net.IPEndPoint (
						System.Net.IPAddress.Parse (gameServer._ip),
						gameServer._port));
					socket.OnReceive += S_OnReceive;
				}
				else {
					switch (sExtraData [0]) {
					case 'd':
						//this.api.kernel.showMessage(undefined,this.api.lang.getText("CANT_CHOOSE_CHARACTER_SERVER_DOWN"),"ERROR_BOX");
						Utils.Log.Alert ("CANT_CHOOSE_CHARACTER_SERVER_DOWN");
						//forceLogout ();
						break;
					case 'f':
						//var _loc17_ = this.api.lang.getText("CANT_CHOOSE_CHARACTER_SERVER_FULL");
						Utils.Log.Alert ("CANT_CHOOSE_CHARACTER_SERVER_FULL");
						/*if(sExtraData.substr(1).length > 0)
						{
							var _loc18_ = sExtraData.substr(1).split("|");
							_loc17_ = _loc17_ + "<br/><br/>";
							_loc17_ = _loc17_ + (this.api.lang.getText("SERVERS_ACCESSIBLES") + " : <br/>");
							var _loc19_ = 0;
							while(_loc19_ < _loc18_.length)
							{
								var _loc20_ = new dofus.datacenter.Server(_loc18_[_loc19_]);
								_loc17_ = _loc17_ + _loc20_.label;
								_loc17_ = _loc17_ + (_loc19_ != _loc18_.length - 1?", ":".");
								_loc19_ = _loc19_ + 1;
							}
						}
	*/
						//this.api.kernel.showMessage(undefined,_loc17_,"ERROR_BOX");
						break;
					case 'F':
						//this.api.kernel.showMessage(undefined,this.api.lang.getText("SERVER_FULL"),"ERROR_BOX");
						Utils.Log.Alert ("SERVER_FULL");
						break;
					case 's':
						//var _loc21_ = this.api.lang.getServerInfos(Number(sExtraData.substr(1))).n;
						//this.api.kernel.showMessage(undefined,this.api.lang.getText("CANT_CHOOSE_CHARACTER_SHOP_OTHER_SERVER",[_loc21_]),"ERROR_BOX");
						break;
					case 'r':
						//this.api.kernel.showMessage(undefined,this.api.lang.getText("CANT_SELECT_THIS_SERVER"),"ERROR_BOX");
						break;
					default:
						break;
					}
				}
			}
				
		}
			

		public void send(string data)
		{
			if(data.Length > 0)
			{
				if(data[data.Length - 1] != '\n')
				{
					data = data + "\n";
				}
				socket.Send (data);
				Utils.Log.SendLog (data);
			}
		}

		private void S_OnReceive (object sender, SocketEventArgs e)
		{
			String packet = String.Empty;
			String data = System.Text.Encoding.UTF8.GetString (e.Data);
			for (int i = 0; i < data.Length; i++) {
				if (data [i] == 0 && packet.Length > 0) {
					Utils.Log.RecvLog (packet);
					parsing (packet);
					packet = String.Empty;
				} else {
					if (data [i] != '\n' && data [i] != '\0')
						packet = packet + Convert.ToChar (data [i]);
				}
			}
		}

		private void parsing(string packet)
		{
			char sType = packet [0];
			char sAction = packet [1];
			String extraData = String.Empty;
			bool bError = false;

			if(packet.Length >= 3)
			{
				extraData = packet.Substring (3);
				bError = (packet [2] == 'E');

			}

			switch (sType) {
			case 'H':
				switch (sAction) {
				case 'C':
					loginServer._HCKey = packet.Substring (2);
					send (new Messages.Login.VersionMessage ().Message ());
					send (new Messages.Login.LogonMessage (
						account._login,
						account._password, 
						loginServer._HCKey).Message ());
					send (new Messages.Login.QueuePositionMessage ().Message ());
					break;
				case 'G':
					send (new Messages.Game.TicketMessage (gameServer._ticket).Message());
					break;
				default:
					Utils.Log.Alert ("Packet inconnu " + sType + sAction + bError);
					break;
				}
				break;
			case 'A':
				switch (sAction) {
				case 'd':
					account._name = packet.Substring (2);
					break;
				case 'Q':
					account._secretQuestion = packet.Substring (2);
					break;
				case 'H':
					Messages.Login.OnHostsMessage hostMsg = new Messages.Login.OnHostsMessage (extraData, account._serverID);
					send (hostMsg.Message ());
					break;
				case 'x':
					send (new Messages.Login.OnServerListMessage (account._serverID,extraData).Message ());
					break;
				case 'X':
					connectToGameServer (!bError, true, extraData);
					break;
				case 'T':
					send (new Messages.Game.TicketResponse (extraData).Message ());
					send (new Messages.Game.RegionalVersionMessage ().Message ());
					break;
				case 'V':
					String end = "";
					if (account._serverID == 6002) {
						end = "en";
					} else {
						end = "fr";
					}
					send ("Ag" + end);
					send ("AL");
					send ("Af");
					break;
				case 'q':
					Utils.Log.Info ("Position dans la queue " + packet[2] + " / " + packet[2]);
					break;
				case 'L':
					send (new Messages.Game.CharacterSelectionMessage (0, extraData).Message());
					break;
				default:
					Utils.Log.Alert ("Packet inconnu " + sType + sAction + bError);
					break;
				}
				break;
			case 'B':
				break;
			default:
				Utils.Log.Alert ("Packet inconnu " + sType + sAction + bError);
				break;
			}
		}

	}
}

