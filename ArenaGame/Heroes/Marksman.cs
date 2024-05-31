namespace ArenaGame.Heroes
{
    public class Marksman : Hero
    {
        public double CritChance { get; set; }
        public Marksman(string name, double armor, double strenght, IWeapon weapon) : base(name, armor, strenght, weapon)
        {
            CritChance = 0.25;
        }

        public override double Attack()
        {
            double damage = base.Attack();
            double probability = random.NextDouble();

            if (probability < CritChance)
            {
                damage *= 2.5;
            }
            return damage;
        }
    }
}
