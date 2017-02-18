using System;
using System.Collections.Generic;

namespace Base.Utils
{
	public static class Compressor
	{

		public static char[] ZKARRAY = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_".ToCharArray();
		public static String[] ZIPKEY = {"_a","_b","_c","_d","_e","_f","_g","_h","_i","_j","_k","_l","_m","_n","_o","_p","_q","_r","_s","_t","_u","_v","_w","_x","_y","_z","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","0","1","2","3","4","5","6","7","8","9","-","_"};

		public static int decode64 (int codedValue)
		{
			return hashCodes ()[codedValue];
		}
		public static char encode64(int value)
		{
			return ZKARRAY [value];
		}
		public static Dictionary<int,int> hashCodes()
		{
			int size = ZKARRAY.Length - 1;
			Dictionary<int,int> _hashCodes =  new Dictionary<int,int>();

			while(size >=0)
			{
				_hashCodes [ZKARRAY [size]] = size;
				size--;
			}

			return _hashCodes;
		}
	}
}