﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Clock
{
    public partial class MainForm : Form
    {
        ChooseFontForm fontDialog = null;
        public MainForm()
        {
            InitializeComponent();
            labelTime.BackColor = Color.AliceBlue;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, 50);
            SetVisibility(false);
            cmShowConsole.Checked = true;
            fontDialog= new ChooseFontForm();
        }
        void SetVisibility(bool visible)
        {
            cbShowDate.Visible = visible;
            cbShowWeekDay.Visible = visible;
            btnHideControls.Visible = visible;
            this.TransparencyKey = visible ? Color.Empty : this.BackColor;
            this.FormBorderStyle = visible ? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;
            this.ShowInTaskbar = false;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString
                (
                "hh:mm:ss tt",
                System.Globalization.CultureInfo.InvariantCulture
                );
            if (cbShowDate.Checked)
            {
                labelTime.Text += "\n";
                labelTime.Text += DateTime.Now.ToString("dd.MM.yyyy");
            }
            if (cbShowWeekDay.Checked)
            {
                labelTime.Text += "\n";
                labelTime.Text += DateTime.Now.DayOfWeek;
            }
            notifyIcon.Text = labelTime.Text;
        }

        private void btnHideControls_Click(object sender, EventArgs e)
        {
            /*            cbShowDate.Visible = false;
                        btnHideControls.Visible = false;
                        this.TransparencyKey = this.BackColor;
                        this.FormBorderStyle = FormBorderStyle.None;
                        labelTime.BackColor = Color.AliceBlue;
                        this.ShowInTaskbar = false;*/

            SetVisibility(cmShowControls.Checked = false);
        }

        private void labelTime_DoubleClick(object sender, EventArgs e)
        {
            /*            cbShowDate.Visible = true;
                        btnHideControls.Visible = true;
                        this.TransparencyKey = Color.Empty;
                        this.BackColor = Color.MidnightBlue;
                        this.ShowInTaskbar = true;
                        MessageBox.Show
                            (
                            this,
                            "Неожиданно,но оно сработало 0_0",
                            "Info",
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information 
                            );*/
            SetVisibility(cmShowControls.Checked = true);
        }

        private void cmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmTopmost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = cmTopmost.Checked;
        }

        private void cmShowdate_CheckedChanged(object sender, EventArgs e)
        {
            cbShowDate.Checked = cmShowdate.Checked;
        }

        private void cbShowDate_CheckedChanged(object sender, EventArgs e)
        {
            cmShowdate.Checked = cbShowDate.Checked;
        }

        private void cmShowweekday_CheckedChanged(object sender, EventArgs e)
        {
            cbShowWeekDay.Checked = cmShowweekday.Checked;
        }

        private void cbShowWeekDay_CheckedChanged(object sender, EventArgs e)
        {
            cmShowweekday.Checked = cbShowWeekDay.Checked;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (!this.TopMost)
            {
                this.TopMost = true;
                this.TopMost = false;
            }
        }

        private void cmShowControls_CheckedChanged(object sender, EventArgs e)
        {
            SetVisibility(cmShowControls.Checked);
        }

        private void SetColor(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            switch ((sender as ToolStripMenuItem).Text) // или switch (((ToolStripMenuItem)sender).Text)
            {
                case "Background color" : dialog.Color = labelTime.BackColor; break;
                case "Foreground color" : dialog.Color = labelTime.ForeColor; break;
            }
            if(dialog.ShowDialog() == DialogResult.OK) 
            {
                switch((sender as ToolStripMenuItem).Text) //as - это оператор преобразования типа
                    //Оператор 'as' значение слева приводит к типу справа
                {
                    case "Background color" : labelTime.BackColor = dialog.Color; break;
                    case "Foreground color" : labelTime.ForeColor = dialog.Color; break;
                }
            }
        }

        private void cmChoosefont_Click(object sender, EventArgs e)
        {
            //ChooseFontForm chooseFont = new ChooseFontForm();
            //chooseFont.ShowDialog();
            if(fontDialog.ShowDialog() == DialogResult.OK)
                labelTime.Font = fontDialog.Font;
        }

        private void cmShowConsole_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Checked)
                AllocConsole();
            else
                FreeConsole();
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
    }
}