﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace Clock
{
    public partial class MainForm : Form
    {
        ChooseFontForm fontDialog = null;
        AlarmsForm alarms = null;
        Alarm nextAlarm = null;
        public MainForm()
        {
            InitializeComponent();
            labelTime.BackColor = Color.Black;
            labelTime.ForeColor = Color.Red;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, 50);
            SetVisibility(false);
            cmShowConsole.Checked = true;
            LoadSetting();
            //fontDialog = new ChooseFontForm();
            alarms = new AlarmsForm();
            Console.WriteLine(DateTime.MinValue);
            //CompareAlarmsDEBUG();
            axWindowsMediaPlayer.Visible = false;
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
        void SaveSettings()
        {
            StreamWriter sw = new StreamWriter("Settings.ini");
            sw.WriteLine($"{cmTopmost.Checked}");
            sw.WriteLine($"{cmShowControls.Checked}");
            sw.WriteLine($"{cmShowdate.Checked}");
            sw.WriteLine($"{cmShowweekday.Checked}");
            sw.WriteLine($"{cmShowConsole.Checked}");
            sw.WriteLine($"{labelTime.BackColor.ToArgb()}");
            sw.WriteLine($"{labelTime.ForeColor.ToArgb()}");
            sw.WriteLine($"{fontDialog.Filename}");
            sw.WriteLine($"{labelTime.Font.Size}");
            sw.Close();
            //Process.Start("notepad", "Settings.ini");
        }
        void LoadSetting()
        {
            string execution_path = Path.GetDirectoryName(Application.ExecutablePath);
            Directory.SetCurrentDirectory($"{execution_path}\\..\\..\\Fonts");
            StreamReader sr = new StreamReader("Settings.ini");
            cmTopmost.Checked = bool.Parse(sr.ReadLine());
            cmShowControls.Checked = bool.Parse(sr.ReadLine());
            cmShowdate.Checked = bool.Parse(sr.ReadLine());
            cmShowweekday.Checked = bool.Parse(sr.ReadLine());
            cmShowConsole.Checked = bool.Parse(sr.ReadLine());
            labelTime.BackColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
            labelTime.ForeColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
            string font_name = sr.ReadLine();
            int font_size = (int)Convert.ToDouble(sr.ReadLine());
            sr.Close();
            fontDialog= new ChooseFontForm(font_name, font_size);
            labelTime.Font = fontDialog.Font;
        }
        Alarm FindNextAlarm()
        {
            Alarm[] actualAlarms = alarms.LB_Alarms.Items.Cast<Alarm>().Where(a => a.Time > DateTime.Now.TimeOfDay).ToArray();
            //Alarm nextAlarm = new Alarm(actualAlarms.Min()); //new Alarm(alarms.LB_Alarms.Items.Cast<Alarm>().ToArray().Min());
            return actualAlarms.Min();
        }
        bool CompareDates(DateTime date1, DateTime date2)
        {
            return date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day;
        }
        void PlayAlarm()
        {
            axWindowsMediaPlayer.URL = nextAlarm.Filename;
            axWindowsMediaPlayer.settings.volume = 100;
            axWindowsMediaPlayer.Ctlcontrols.play();
            axWindowsMediaPlayer.Visible = true;
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

            if  (
                nextAlarm != null &&
                (
                nextAlarm.Date == DateTime.MinValue ?
                nextAlarm.Weekdays.Contains(DateTime.Now.DayOfWeek) : 
                CompareDates(nextAlarm.Date,DateTime.Now)
                ) &&
                // || nextAlarm.Date == DateTime.MinValue.Date)// &&
                //nextAlarm.Weekdays.Contains(DateTime.Now.DayOfWeek)// &&
                nextAlarm.Time.Hours == DateTime.Now.Hour &&
                nextAlarm.Time.Minutes == DateTime.Now.Minute &&
                nextAlarm.Time.Seconds == DateTime.Now.Second
                )
            {
                System.Threading.Thread.Sleep(1000);
                PlayAlarm();
                //MessageBox.Show(this, nextAlarm.ToString(), "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nextAlarm = null;
            }

            if (alarms.LB_Alarms.Items.Count > 0) nextAlarm = FindNextAlarm(); //alarms.LB_Alarms.Items.Cast<Alarm>().ToArray().Min();
            if (nextAlarm != null) Console.WriteLine(nextAlarm);
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
                case "Background color": dialog.Color = labelTime.BackColor; break;
                case "Foreground color": dialog.Color = labelTime.ForeColor; break;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                switch ((sender as ToolStripMenuItem).Text) //as - это оператор преобразования типа
                                                            //Оператор 'as' значение слева приводит к типу справа
                {
                    case "Background color": labelTime.BackColor = dialog.Color; break;
                    case "Foreground color": labelTime.ForeColor = dialog.Color; break;
                }
            }
        }

        private void cmChoosefont_Click(object sender, EventArgs e)
        {
            //ChooseFontForm chooseFont = new ChooseFontForm();
            //chooseFont.ShowDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void cmLoadOnWinStartup_CheckedChanged(object sender, EventArgs e)
        {
            string key_Name = "ClockPv_319";
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                (
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true
                ); //true - откроет ветку на запись
            if (cmLoadOnWinStartup.Checked) rk.SetValue(key_Name, Application.ExecutablePath);
            else rk.DeleteValue(key_Name, false);
            rk.Dispose();
        }

        private void cmAlarm_Click(object sender, EventArgs e)
        {
            alarms.StartPosition= FormStartPosition.Manual;
            alarms.Location = new Point(this.Location.X - alarms.Width, this.Location.Y*2);
            alarms.ShowDialog();
        }
    }
}