using System;

namespace Issen
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var player = new Player(hp: 100, strength: 10);
			var enemy = new Enemy();
			Console.WriteLine ("test start");
			Console.WriteLine ("[Player] MaxHp: {0}, Hp: {1}, Strength: {2}", player.MaxHp, player.Hp, player.Strength);
			Console.WriteLine ("[Enemy] MaxHp: {0}, Hp: {1}, Strength: {2}", enemy.MaxHp, enemy.Hp, enemy.Strength);
			Console.WriteLine ("test end");
		}
	}
}
