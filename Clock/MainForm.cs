﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString
                (
                "hh:mm:ss tt",
                System.Globalization.CultureInfo.InvariantCulture
                );
            if(cbShowDate.Checked ) 
            {
                labelTime.Text += "\n";
                labelTime.Text += DateTime.Now.ToString("dd.MM.yyyy");
            }
        }

        private void btnHideControls_Click(object sender, EventArgs e)
        {
            cbShowDate.Visible = false;
            btnHideControls.Visible = false;
            this.TransparencyKey = this.BackColor;
            this.FormBorderStyle = FormBorderStyle.None;
            labelTime.BackColor = Color.AliceBlue;
            this.ShowInTaskbar = false;
        }

        private void labelTime_DoubleClick(object sender, EventArgs e)
        {
            cbShowDate.Visible = true;
            btnHideControls.Visible = true;
            this.TransparencyKey = Color.Empty;
            this.BackColor = Color.MidnightBlue;
            MessageBox.Show
                (
                this,
                "Неожиданно,но оно сработало 0_0",
                "Info",
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information 
                );
        }
    }
}
