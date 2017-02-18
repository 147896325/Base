using System;
using System.Collections;
using System.Collections.Generic;

namespace Messages.Game
{
	public class CharacterSelectionMessage
	{
		private int _index;
		private Dictionary<int,character> _char;

		public CharacterSelectionMessage (int index, string sExtraData)
		{
			_char = new Dictionary<int, character> ();

			var _loc6_ = sExtraData.Split ('|');
			var _loc7_ = Convert.ToInt32 (_loc6_ [0]);
			var _loc8_ = Convert.ToInt32 (_loc6_ [1]);
			var _loc10_ = 2;
			while (_loc10_ < _loc6_.Length) {
				var _loc11_ = _loc6_ [_loc10_].Split (';');
				character _c;
				_c.id = Convert.ToInt32(_loc11_ [0]);
				_c.pseudo = _loc11_ [1];
				_char.Add (_loc10_ - 2, _c);
				/*
				_loc12_.level = _loc11_ [2];
				_loc12_.gfxID = _loc11_ [3];
				_loc12_.color1 = _loc11_ [4];
				_loc12_.color2 = _loc11_ [5];
				_loc12_.color3 = _loc11_ [6];
				_loc12_.accessories = _loc11_ [7];
				_loc12_.merchant = _loc11_ [8];
				_loc12_.serverID = _loc11_ [9];
				_loc12_.isDead = _loc11_ [10];
				_loc12_.deathCount = _loc11_ [11];
				_loc12_.lvlMax = _loc11_ [12];
				var _loc15_ = this.api.kernel.CharactersManager.createCharacter (_loc13_, _loc14_, _loc12_);
				_loc15_.sortID = Number (_loc13_);
				_loc5_.push (_loc15_);
				_loc9_.push (Number (_loc13_));
				*/
				_loc10_ = _loc10_ + 1;
			}
		}

		public string Message()
		{
			return "AS" + _char[_index].id;
		}
	}

	public struct character
	{
		public int id;
		public string pseudo;
	}
}

