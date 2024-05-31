using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ArenaGame.Heroes
{
    public class Warlock : Hero
    {
        public double Mana { get; set; }
        public double SpellPower { get; set; }
        public Warlock(string name, double armor, double strenght, IWeapon weapon)
            : base(name, armor, strenght, weapon)
        {
            Mana = 100;
            SpellPower = 21.5;
        }

        public override double Attack()
        {
            double baseDamage = base.Attack();

            if (Mana >= 20)
            {
                Mana -= 20;
                return baseDamage + SpellPower;
            }
            return baseDamage;
        }

        public override double Defend(double damage)
        {
            double baseDefense = base.Defend(damage);

            if (Mana >= 10)
            {
                Mana -= 10;
                baseDefense /= 1.35;
            }

            return base.Defend(damage);
        }

        public void RegenerateMana()
        {
            Mana += 10;

            if (Mana > 100)
            {
                Mana = 100;
            }
        }
    }
}
