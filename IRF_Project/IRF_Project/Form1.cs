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
        List<string> postList = new List<string>();
        public Form1()
        {
            InitializeComponent();
            CreatePlayers();
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
                postList.Add(player.Post);
                player.Goal = item.Goal;
                player.Assist = item.Assist;
                player.YellowCard = item.YellowCard;
                player.RedCard = item.RedCard;
                player.Injured = item.Injured;
                player.Average = item.Average;
                players.Add(player);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoginController loginController = new LoginController();
                loginController.Controller(emailTextBox.Text, passwordTextBox.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            if (emailTextBox.Text=="manager@footballclub.com" && passwordTextBox.Text=="ClubManag3r")
            {
                TableUserControl tableUserControl = new TableUserControl(players, postList);
                mainPanel.Controls.Add(tableUserControl);
                tableUserControl.Dock = DockStyle.Fill;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            emailTextBox.Clear();
            passwordTextBox.Clear();
        }
    }
}
