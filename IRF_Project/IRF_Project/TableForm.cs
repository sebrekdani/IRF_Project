using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace IRF_Project
{
    public partial class TableForm : Form
    {
        TeamEntities context = new TeamEntities();
        List<Player> playersToFilter = new List<Player>();
        string _choosenPost;
        Form1 _mainForm;

        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;
        string[] headers = new string[]
        {
            "Name",
            "Year",
            "Month",
            "Day",
            "Post",
            "Goal",
            "Assist",
            "Yellow Card",
            "Red Card",
            "Average"
        };

        public TableForm(Form1 mainForm, List<Player> players, List<string> postList)
        {
            InitializeComponent();
            playersToFilter = players;
            FillComboBox(postList);
            FillDataGridView(players);
            _mainForm = mainForm;
            CreateLogOutButton();
        }

        private void CreateLogOutButton()
        {
            CostumButton exportBT = new CostumButton("Export list", postsComboBox.Top, postsComboBox.Left + postsComboBox.Width + 50);
            exportBT.Click += ExportBT_Click;
            Controls.Add(exportBT);

            CostumButton logOutBT = new CostumButton("Log Out", exportBT.Top, exportBT.Left + exportBT.Width + 50);
            logOutBT.Click += LogOutBT_Click;
            Controls.Add(logOutBT);
        }

        private void LogOutBT_Click(object sender, EventArgs e)
        {
            _mainForm.Enabled = true;
            this.Close();
        }

        private void ExportBT_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to export \n the list of not injured players ordered by 'Average' to excel?","Exporting to excel...",MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            List<Player> exportList = CreateNotInjuredList();
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;
                CreateTable(exportList);
                FormatTable();
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();
            return ExcelCoordinate;
        }

        private void CreateTable(List<Player> exportList)
        {
            object[,] values = new object[exportList.Count, headers.Length];
            for (int col = 1; col <= headers.Length; col++)
            {
                xlSheet.Cells[1, col] = headers[col-1];
            }
            int counter = 0;
            foreach (Player player in exportList)
            {
                values[counter, 0] = player.Name;
                values[counter, 1] = player.Year;
                values[counter, 2] = player.Month;
                values[counter, 3] = player.Day;
                values[counter, 4] = player.Post;
                values[counter, 5] = player.Goal;
                values[counter, 6] = player.Assist;
                values[counter, 7] = player.YellowCard;
                values[counter, 8] = player.RedCard;
                values[counter, 9] = player.Average;
                counter++;
                xlSheet.get_Range(GetCell(2, 1), GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
            }
        }

        private void FormatTable()
        {
            Excel.Range headerRange = xlSheet.get_Range(GetCell(1, 1), GetCell(1, headers.Length));
            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            headerRange.EntireColumn.AutoFit();
            headerRange.RowHeight = 40;
            headerRange.Interior.Color = Color.FromArgb(255, 66, 66);
            headerRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

            int lastRowID = xlSheet.UsedRange.Rows.Count;
            Excel.Range tableRange = xlSheet.get_Range(GetCell(2, 1), GetCell(lastRowID, headers.Length));
            tableRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

            Excel.Range firstColRange = xlSheet.get_Range(GetCell(2, 1), GetCell(lastRowID, 1));
            firstColRange.Font.Bold = true;
            firstColRange.Interior.Color = Color.FromArgb(252, 255, 66);

            Excel.Range centerColsRange = xlSheet.get_Range(GetCell(2, 6), GetCell(lastRowID, 9));
            centerColsRange.HorizontalAlignment= Excel.XlHAlign.xlHAlignCenter;

            Excel.Range lastColRange = xlSheet.get_Range(GetCell(2, headers.Length), GetCell(lastRowID, headers.Length));
            lastColRange.Interior.Color = Color.FromArgb(252, 255, 66);
            lastColRange.NumberFormat = "?.??";
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
