﻿using System;
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
        public Form1()
        {
            InitializeComponent();
            LoginUserControl loginUserControl = new LoginUserControl();
            mainPanel.Controls.Add(loginUserControl);
            loginUserControl.Dock = DockStyle.Fill;
        }
    }
}
