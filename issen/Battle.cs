using System;
using System.Collections.Generic;
using System.Linq;
namespace Issen
{
	public class Battle
	{
		List<Turn> turns = new List<Turn>();
		public Battle(Minion first, Minion second)
		{
			FirstMinion = first;
			SecondMinion = second;
		}

		public Minion FirstMinion { get; private set; }
		public Minion SecondMinion { get; private set; }

		public void DecideAttackCard(int attackCard)
		{
			NextTurnAttacker().DecideCard(attackCard);
		}

		public Minion NextTurnAttacker()
		{
			return (!IsStarted() || turns.Last().Attacker == SecondMinion) ? FirstMinion : SecondMinion;
		}

		public Minion NextTurnDefender()
		{
			return (NextTurnAttacker() == FirstMinion) ? SecondMinion : FirstMinion;
		}

		public bool NextAttackerOf(Minion minion)
		{
			return NextTurnAttacker() == minion;
		}

		public void ForwardTurn()
		{
			NextTurnAttacker().Think(this);
			var turn = new Turn(attacker: NextTurnAttacker(), defender: NextTurnDefender());
			turn.Execute();
			turns.Add(turn);
		}

		public string LatestTurnResult()
		{
			if(!IsStarted()) return null;
			return turns.Last().Result();
		}

		public void LogLatestTurn()
		{
			Console.WriteLine("Turn {0}", turns.Count);
			Console.WriteLine(LatestTurnResult());
			Console.WriteLine(FirstMinion.CurrentStatus());
			Console.WriteLine(SecondMinion.CurrentStatus());
		}

		public bool IsStarted()
		{
			return turns.Count > 0;
		}

		public bool IsEnded()
		{
			return (FirstMinion.Hp <= 0 || SecondMinion.Hp <= 0) ? true : false;
		}

		public Minion Winner()
		{
			if(!IsEnded()) { return null; }
			if(FirstMinion.Hp == SecondMinion.Hp)
			{
				return null;
			}
			else if(FirstMinion.Hp > SecondMinion.Hp)
			{
				return FirstMinion;
			}
			else
			{
				return SecondMinion;
			}
		}

		public class Turn
		{
			bool isExecuted = false;
			public Turn(Minion attacker, Minion defender)
			{
				Attacker = attacker;
				Defender = defender;
			}

			public Minion Attacker { get; private set; }
			public Minion Defender { get; private set; }
			public Damage Damage { get; private set; }

			public Turn Execute()
			{
				// TODO: extract to damage calculator
				this.Damage = Damage.MinionToMinion(attacker: Attacker, defender: Defender);
				Defender.Hp -= this.Damage.Hp;
				isExecuted = true;
				return this;
			}

			public string Result()
			{
				if(!isExecuted) return null;
				return String.Format("{0} から {1} へ {2} ダメージ!", Attacker.Name(), Defender.Name(), Damage.Hp);
			}
		}
	}
}

