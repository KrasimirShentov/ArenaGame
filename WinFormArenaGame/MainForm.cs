using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;

namespace WinFormArenaGame
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();


            tbKnight = new TextBox();
            tbAssassin = new TextBox();
            tbMarksman = new TextBox();
            tbWarlock = new TextBox();
        }

        private void gameNotification(GameEngine.NotificationArgs args)
        {
            TextBox tbAttacker;
            if (args.Attacker is Knight)
                tbAttacker = tbKnight;
            else if (args.Attacker is Assassin)
                tbAttacker = tbAssassin;
            else if (args.Attacker is Marksman)
                tbAttacker = tbMarksman;
            else if (args.Attacker is Warlock)
                tbAttacker = tbWarlock;
            else
                return;

            string text = $"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.\r\n";

            tbAttacker.AppendText(text);

            DateTime dt = DateTime.Now;
            while (DateTime.Now - dt < TimeSpan.FromMilliseconds(300))
            {
                Application.DoEvents();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            lbWinner.Text = "";
            tbKnight.Text = "";
            tbAssassin.Text = "";
            tbWarlock.Text = "";
            tbMarksman.Text = "";
            lbWinner.Visible = false;

            IWeapon sword = new Sword("Sword");
            IWeapon dagger = new Dagger("Dagger");
            IWeapon crossbow = new Crossbow("Crossbow");
            IWeapon wand = new Wand("Wand");

            Hero heroA = new Knight("Knight", 10, 20, sword);
            Hero heroB = new Assassin("Assassin", 10, 5, dagger);
            Hero heroC = new Marksman("Marksman", 5, 15, crossbow);
            Hero heroD = new Warlock("Warlock", 8, 10, wand);

            List<Hero> teamA = new List<Hero> { heroA, heroB };
            List<Hero> teamB = new List<Hero> { heroC, heroD };

            GameEngine gameEngine = new GameEngine(teamA, teamB)
            {
                NotificationsCallBack = gameNotification
            };

            imgFight.Enabled = true;
            gameEngine.Fight();
            imgFight.Enabled = false;

            string winningTeam = (gameEngine.WinningTeam == teamA) ? "Team A" : "Team B";
            lbWinner.Text = $"And the winner is: {winningTeam}";
            lbWinner.Visible = true;
        }

        private void lbWinner_Click(object sender, EventArgs e)
        {
        }
    }
}
