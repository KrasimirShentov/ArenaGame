//using System;
//using ArenaGame;
//using ArenaGame.Heroes;
//using ArenaGame.Weapons;

//namespace ConsoleArenaGame
//{
//    class Program
//    {
//        static void ConsoleNotification(GameEngine.NotificationArgs args)
//        {
//            Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.");
//            Console.WriteLine($"Attacker: {args.Attacker}");
//            Console.WriteLine($"Defender: {args.Defender}");
//        }

//        static void Main(string[] args)
//        {
//            IWeapon sword = new Sword("Sword");
//            IWeapon dagger = new Dagger("Dagger");
//            IWeapon crossbow = new Crossbow("Deadly Crossbow");
//            IWeapon wand = new Wand("Mystic Wand");

//            Hero heroA = new Knight("Knight", 10, 20, sword);
//            Hero heroB = new Assassin("Assassin", 10, 5, dagger);
//            Hero heroC = new Marksman("Marksman", 5, 15, crossbow);
//            Hero heroD = new Warlock("Warlock", 8, 10, wand);

//            List<Hero> teamA = new List<Hero> { heroA, heroB };
//            List<Hero> teamB = new List<Hero> { heroC, heroD };

//            GameEngine gameEngine = new GameEngine(teamA, teamB)
//            {
//                NotificationsCallBack = ConsoleNotification
//            };

//            gameEngine.Fight();

//        }


//    }
//}
