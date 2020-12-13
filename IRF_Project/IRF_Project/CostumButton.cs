using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_Project
{
    class CostumButton : Button
    {
        public CostumButton(string text, int top, int left)
        {
            Width = 100;
            Height = 20;
            Top = top;
            Left = left;
            Text = text;
        }
    }
}
