﻿namespace Clock
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelTime = new System.Windows.Forms.Label();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmTopmost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmShowdate = new System.Windows.Forms.ToolStripMenuItem();
            this.cmShowweekday = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.cbShowDate = new System.Windows.Forms.CheckBox();
            this.btnHideControls = new System.Windows.Forms.Button();
            this.cbShowWeekDay = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmColors = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmBackColor = new System.Windows.Forms.ToolStripMenuItem();
            this.cmForeColor = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.ContextMenuStrip = this.contextMenu;
            this.labelTime.Font = new System.Drawing.Font("Franklin Gothic Medium", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.Color.Red;
            this.labelTime.Location = new System.Drawing.Point(12, 9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(214, 50);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "labelTime";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTime.DoubleClick += new System.EventHandler(this.labelTime_DoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmTopmost,
            this.toolStripSeparator1,
            this.cmShowdate,
            this.cmShowweekday,
            this.toolStripSeparator3,
            this.cmColors,
            this.toolStripSeparator2,
            this.cmExit});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(181, 154);
            // 
            // cmTopmost
            // 
            this.cmTopmost.CheckOnClick = true;
            this.cmTopmost.Name = "cmTopmost";
            this.cmTopmost.Size = new System.Drawing.Size(180, 22);
            this.cmTopmost.Text = "Topmost";
            this.cmTopmost.CheckedChanged += new System.EventHandler(this.cmTopmost_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // cmShowdate
            // 
            this.cmShowdate.CheckOnClick = true;
            this.cmShowdate.Name = "cmShowdate";
            this.cmShowdate.Size = new System.Drawing.Size(180, 22);
            this.cmShowdate.Text = "Show date";
            this.cmShowdate.CheckedChanged += new System.EventHandler(this.cmShowdate_CheckedChanged);
            // 
            // cmShowweekday
            // 
            this.cmShowweekday.CheckOnClick = true;
            this.cmShowweekday.Name = "cmShowweekday";
            this.cmShowweekday.Size = new System.Drawing.Size(180, 22);
            this.cmShowweekday.Text = "Show weekday";
            this.cmShowweekday.CheckedChanged += new System.EventHandler(this.cmShowweekday_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // cmExit
            // 
            this.cmExit.Name = "cmExit";
            this.cmExit.Size = new System.Drawing.Size(180, 22);
            this.cmExit.Text = "Exit";
            this.cmExit.Click += new System.EventHandler(this.cmExit_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // cbShowDate
            // 
            this.cbShowDate.AutoSize = true;
            this.cbShowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbShowDate.ForeColor = System.Drawing.Color.Red;
            this.cbShowDate.Location = new System.Drawing.Point(21, 163);
            this.cbShowDate.Name = "cbShowDate";
            this.cbShowDate.Size = new System.Drawing.Size(176, 29);
            this.cbShowDate.TabIndex = 1;
            this.cbShowDate.Text = "Показать дату";
            this.cbShowDate.UseVisualStyleBackColor = true;
            this.cbShowDate.CheckedChanged += new System.EventHandler(this.cbShowDate_CheckedChanged);
            // 
            // btnHideControls
            // 
            this.btnHideControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnHideControls.ForeColor = System.Drawing.Color.Red;
            this.btnHideControls.Location = new System.Drawing.Point(21, 271);
            this.btnHideControls.Name = "btnHideControls";
            this.btnHideControls.Size = new System.Drawing.Size(176, 52);
            this.btnHideControls.TabIndex = 2;
            this.btnHideControls.Text = "Hide controls";
            this.btnHideControls.UseVisualStyleBackColor = true;
            this.btnHideControls.Click += new System.EventHandler(this.btnHideControls_Click);
            // 
            // cbShowWeekDay
            // 
            this.cbShowWeekDay.AutoSize = true;
            this.cbShowWeekDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbShowWeekDay.ForeColor = System.Drawing.Color.Red;
            this.cbShowWeekDay.Location = new System.Drawing.Point(21, 211);
            this.cbShowWeekDay.Name = "cbShowWeekDay";
            this.cbShowWeekDay.Size = new System.Drawing.Size(256, 29);
            this.cbShowWeekDay.TabIndex = 3;
            this.cbShowWeekDay.Text = "Показать день недели";
            this.cbShowWeekDay.UseVisualStyleBackColor = true;
            this.cbShowWeekDay.CheckedChanged += new System.EventHandler(this.cbShowWeekDay_CheckedChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // cmColors
            // 
            this.cmColors.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmBackColor,
            this.cmForeColor});
            this.cmColors.Name = "cmColors";
            this.cmColors.Size = new System.Drawing.Size(180, 22);
            this.cmColors.Text = "Colors";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // cmBackColor
            // 
            this.cmBackColor.Name = "cmBackColor";
            this.cmBackColor.Size = new System.Drawing.Size(180, 22);
            this.cmBackColor.Text = "Background color";
            // 
            // cmForeColor
            // 
            this.cmForeColor.Name = "cmForeColor";
            this.cmForeColor.Size = new System.Drawing.Size(180, 22);
            this.cmForeColor.Text = "Foreground color";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 362);
            this.Controls.Add(this.cbShowWeekDay);
            this.Controls.Add(this.btnHideControls);
            this.Controls.Add(this.cbShowDate);
            this.Controls.Add(this.labelTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clock PV_319";
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox cbShowDate;
        private System.Windows.Forms.Button btnHideControls;
        private System.Windows.Forms.CheckBox cbShowWeekDay;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmTopmost;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmShowdate;
        private System.Windows.Forms.ToolStripMenuItem cmShowweekday;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmColors;
        private System.Windows.Forms.ToolStripMenuItem cmBackColor;
        private System.Windows.Forms.ToolStripMenuItem cmForeColor;
    }
}

