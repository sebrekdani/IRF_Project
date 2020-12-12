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
        public TableUserControl(List<Player> players, List<string> postList)
        {
            InitializeComponent();
            FillComboBox(postList);
            FillDataGridView(players);
        }

        private void FillDataGridView(List<Player> players)
        {
            playerDataGridView.DataSource = players;
        }

        private void FillComboBox(List<string> postList)
        {
            var postDistinct = (from x in postList
                               select x).Distinct();
            postList.Clear();
            foreach (var item in postDistinct)
            {
                postList.Add(item);
            }
            postsComboBox.DataSource = postList;
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
