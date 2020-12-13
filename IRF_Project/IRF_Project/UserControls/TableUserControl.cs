using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IRF_Project.UserControls
{
    public partial class TableUserControl : UserControl
    {
        TeamEntities context = new TeamEntities();
        List<Player> playersToFilter = new List<Player>();
        string _choosenPost;
        public TableUserControl(List<Player> players, List<string> postList)
        {
            InitializeComponent();
            playersToFilter = players;
            FillComboBox(postList);
        }

        private void FillDataGridView(List<Player> players)
        {
            playerDataGridView.DataSource = null;
            playerDataGridView.Rows.Clear();
            playerDataGridView.DataSource = players;
        }

        private void FillComboBox(List<string> postList)
        {
            var postDistinct = (from x in postList
                                select x).Distinct();
            postsComboBox.DataSource = postDistinct.ToList();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            List<Player> exportList = CreateNotInjuredList();
        }

        private List<Player> CreateNotInjuredList()
        {
            List<Player> returnList = new List<Player>();

            var notInjuredPlayers = from x in context.Team
                                    where x.Injured == false
                                    select x;
            var rankedPlayerList = from x in notInjuredPlayers
                                   orderby x.Average descending
                                   select x;
            foreach (var item in rankedPlayerList)
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

                returnList.Add(player);
            }
            return returnList;
        }

        private void postsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            _choosenPost = postsComboBox.SelectedItem.ToString();

            var filteredList = from x in playersToFilter
                               where x.Post == _choosenPost
                               select x;
            FillDataGridView(filteredList.ToList());
        }
    }
}
