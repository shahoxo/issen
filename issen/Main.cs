using System;

namespace Issen
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var player = new Player(hp: 100, strength: 10);
			Console.WriteLine ("test start");
			Console.WriteLine ("MaxHp: {0}, Hp: {1}, Strength: {2}", player.MaxHp, player.Hp, player.Strength);
			Console.WriteLine ("test end");
		}
	}
}
