using System;

namespace Issen
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var player = new Player();
			var enemy = new Enemy();
			var battle = new Battle(first: player, second: enemy);
			Console.WriteLine("battle start");
			Console.WriteLine(player.CurrentStatus());
			Console.WriteLine(enemy.CurrentStatus());
			while(!battle.IsEnded())
			{
				Console.WriteLine("---------");
				battle.ForwardTurn();
				battle.LogLatestTurn();
			}
			Console.WriteLine("battle end");
		}
	}
}
