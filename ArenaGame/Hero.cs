namespace ArenaGame
{
    public abstract class Hero : IHero
    {
        protected Random random = new Random();
        public string Name { get; private set; }
        public double Health { get; private set; }
        public double Armor { get; private set; }
        public double Strength { get; private set; }
        public IWeapon Weapon { get; private set; }
        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        public Hero(string name, double armor, double strength, IWeapon weapon)
        {
            Health = 100;
            Name = name;
            Armor = armor;
            Strength = strength;
            Weapon = weapon;
        }

        public virtual double Attack()
        {
            double totalDamage = Strength + Weapon.AttackDamage;
            double coef = random.Next(80, 121);
            double realDamage = totalDamage * (coef / 100.0);
            return realDamage;
        }

        public virtual double Defend(double damage)
        {
            double coef = random.Next(80, 120 + 1);
            double defendPower = (Armor + Weapon.BlockingPower) * (coef / 100);
            double realDamage = damage - defendPower;
            if (realDamage < 0)
                realDamage = 0;
            Health -= realDamage;
            return realDamage;
        }

        public override string ToString()
        {
            return $"{Name} with health {Math.Round(Health, 2)}";
        }
    }
}
