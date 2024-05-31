namespace ArenaGame
{
    public class GameEngine
    {
        public class NotificationArgs
        {
            public Hero Attacker { get; set; }
            public Hero Defender { get; set; }
            public double Attack { get; set; }
            public double Damage { get; set; }
        }

        public delegate void GameNotifications(NotificationArgs args);

        private Random random = new Random();
        public List<Hero> TeamA { get; set; }
        public List<Hero> TeamB { get; set; }
        public List<Hero> WinningTeam { get; private set; }
        public GameNotifications NotificationsCallBack { get; set; }

        public GameEngine(List<Hero> teamA, List<Hero> teamB)
        {
            TeamA = teamA;
            TeamB = teamB;
        }
        public void Fight()
        {
            bool teamAAttacking = true;

            while (IsAnyHeroAlive(TeamA) && IsAnyHeroAlive(TeamB))
            {
                Hero attacker;
                Hero defender;

                do
                {
                    if (teamAAttacking)
                    {
                        attacker = SelectRandomHeroFromTeam(TeamA);
                        defender = SelectRandomHeroFromTeam(TeamB);
                    }
                    else
                    {
                        attacker = SelectRandomHeroFromTeam(TeamB);
                        defender = SelectRandomHeroFromTeam(TeamA);
                    }
                } while (attacker.Health <= 0 || defender.Health <= 0); // Ensure both attacker and defender have positive health

                double attackDamage = attacker.Attack();
                double actualDamage = defender.Defend(attackDamage);

                if (NotificationsCallBack != null)
                {
                    NotificationsCallBack(new NotificationArgs()
                    {
                        Attacker = attacker,
                        Defender = defender,
                        Attack = attackDamage,
                        Damage = actualDamage
                    });
                }

                teamAAttacking = !teamAAttacking;
            }

            if (!IsAnyHeroAlive(TeamA))
            {
                WinningTeam = TeamB;
            }
            else
            {
                WinningTeam = TeamA;
            }

            Console.WriteLine($"The winning team is: {(WinningTeam == TeamA ? "Team A" : "Team B")}");

        }

        private Hero SelectRandomHeroFromTeam(List<Hero> team)
        {
            return team[random.Next(team.Count)];
        }

        private bool IsAnyHeroAlive(List<Hero> team)
        {
            foreach (Hero hero in team)
            {
                if (hero.Health > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
