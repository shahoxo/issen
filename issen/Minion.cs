// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
namespace Issen
{
	public class Minion
	{
		const int DefaultHp = 50;
		const int DefaultStrength = 1;
		const int DefaultArmor = 0;
		private int hp;
		private int strength;

		public Minion ()
		{
			hp = DefaultHp;
			MaxHp = hp;
			strength = DefaultStrength;
			this.Armor = DefaultArmor;
		}

		public Minion (int hp, int strength)
		{
			this.hp = hp;
			this.strength = strength;
			MaxHp = hp;
			this.Armor = DefaultArmor;
		}

		public int MaxHp { get; private set; }

		public int Hp {
			get {
				return hp;
			}
			set {
				hp = Math.Min(value, MaxHp);
			}
		}

		public int Strength {
			get {
				return strength + (MaxHp -  hp);
			}
		}

		public int Armor { get; set; }

		public void DecideStrength(int strength) {
			this.strength = strength;
		}
	}
}

