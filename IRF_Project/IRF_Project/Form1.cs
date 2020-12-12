using IRF_Project.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_Project
{
    public partial class Form1 : Form
    {
        TeamEntities context = new TeamEntities();
        List<Player> players = new List<Player>();
        public Form1()
        {
            InitializeComponent();
            CreatePlayers();
            if (true /*ha sikeres a bejelentkezés*/)
            {
                TableUserControl tableUserControl = new TableUserControl(players);
                mainPanel.Controls.Add(tableUserControl);
                tableUserControl.Dock = DockStyle.Fill;
            }
        }

        private void CreatePlayers()
        {
            var Players = from x in context.Team
                          select x;
            foreach (var item in Players)
            {
                Player player = new Player();
                player.Name = item.Name;
                player.Year = item.Year;
                player.Month = (Months)Enum.Parse(typeof(Months), item.Month.ToString());
                player.Day = item.Day;
                player.Post = item.Post;
                player.Goal = item.Goal;
                player.Assist = item.Assist;
                player.YellowCard = item.YellowCard;
                player.RedCard = item.RedCard;
                player.Injured = item.Injured;
                player.Average = item.Average;
                players.Add(player);
            }
        }
    }
}
