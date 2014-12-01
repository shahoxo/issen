using System;
using System.Linq;
namespace Issen
{
	public class Minion
	{
		private int hp;
		private int strength;

		public Minion (int hp = 50, int strength = 1, int armor = 0)
		{
			this.hp = hp;
			this.strength = strength;
			MaxHp = hp;
			this.Armor = armor;
		}

		public int MaxHp { get; private set; }

		public int Hp
		{
			get {
				return hp;
			}
			set {
				hp = Math.Min(value, MaxHp);
			}
		}

		public int Strength
		{
			get {
				return strength + (MaxHp -  hp);
			}
		}

		public int Armor { get; set; }

		public void DecideCard(int card)
		{
			this.strength = card;
		}

		public virtual void Think(Battle battle) {}

		public string Name()
		{
			return GetType().ToString().Split('.').Last() + GetHashCode();
		}

		public string CurrentStatus()
		{
			return String.Format("[{0}] MaxHp: {1}, Hp: {2}, Strength: {3}", Name(), MaxHp, Hp, Strength);
		}
	}
}

