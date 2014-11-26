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
			return (turns.Count == 0 || turns.Last().Attacker == SecondMinion) ? FirstMinion : SecondMinion;
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

		public class Turn
		{
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
				return this;
			}
		}
	}
}

