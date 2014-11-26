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
				if(battle.NextAttackerOf(player))
				{
					Console.WriteLine("カードを選択してください");
					Console.WriteLine("選択可能カード: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]");
					var card = int.Parse(Console.ReadLine());
					battle.DecideAttackCard(card);
				}
				battle.ForwardTurn();
				battle.LogLatestTurn();
			}
			Console.WriteLine("{0} win!", battle.Winner().Name());
			Console.WriteLine("battle end");
		}
	}
}
