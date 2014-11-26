using System;
namespace Issen
{
	public class Damage
	{
		public Damage(int hp)
		{
			Hp = hp;
		}

		public int Hp { get; private set; }

		public static Damage MinionToMinion(Minion attacker, Minion defender)
		{
			var hpDamage = Math.Max(attacker.Strength - defender.Armor, 0);
			return new Damage(hp: hpDamage);
		}
	}
}

