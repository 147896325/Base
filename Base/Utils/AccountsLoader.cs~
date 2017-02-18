using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace Base.Utils
{
	public class AccountsLoader
	{
		private string accountsFile;

		public List<World.Account> _acc;

		public AccountsLoader (string file = "accounts.xml")
		{
			accountsFile = file;
			_acc = new List<World.Account> ();

			//Now fetching the accounts.

			using (XmlReader reader = XmlReader.Create(accountsFile))
			{
				// Parse the file and display each of the nodes.
				while (reader.Read())
				{
					if(reader.NodeType == XmlNodeType.Element && reader.Name == "Account")
					{
						_acc.Add(new World.Account(reader.GetAttribute("login"),reader.GetAttribute("password"),Convert.ToInt32(reader.GetAttribute("server"))));

					}
				}
					
			}
		}
	}
}