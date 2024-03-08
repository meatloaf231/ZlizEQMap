using System;
using System.Windows.Forms;

namespace ZlizEQMap
{
    partial class ZlizEQMapFormExperimental
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
            this.picBox = new System.Windows.Forms.PictureBox();
            this.checkLegend = new System.Windows.Forms.CheckBox();
            this.checkEnableDirection = new System.Windows.Forms.CheckBox();
            this.labelLegend = new TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel();
            this.comboZone = new System.Windows.Forms.ComboBox();
            this.checkGroupByContinent = new System.Windows.Forms.CheckBox();
            this.btnAutosize = new System.Windows.Forms.Button();
            this.checkAutoSizeOnMapSwitch = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabelWiki = new System.Windows.Forms.LinkLabel();
            this.sliderOpacity = new System.Windows.Forms.TrackBar();
            this.btnSetWaypoint = new System.Windows.Forms.Button();
            this.textBoxCharName = new System.Windows.Forms.TextBox();
            this.checkAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMapContainer = new System.Windows.Forms.Panel();
            this.panelConnectedZones = new System.Windows.Forms.FlowLayoutPanel();
            this.labelConnectedZones = new System.Windows.Forms.Label();
            this.flowSubMaps = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSettingsHelp = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.txtWaypoint = new System.Windows.Forms.TextBox();
            this.labelCharName = new System.Windows.Forms.Label();
            this.btnMinisize = new System.Windows.Forms.Button();
            this.panelMainControls = new System.Windows.Forms.Panel();
            this.nud_scale = new System.Windows.Forms.NumericUpDown();
            this.labelZoneName = new ZlizEQMap.ZlizLabel();
            this.splitContainerMapAndLegend = new System.Windows.Forms.SplitContainer();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonAutosize = new System.Windows.Forms.Button();
            this.buttonStretch = new System.Windows.Forms.Button();
            this.buttonCenter = new System.Windows.Forms.Button();
            this.buttonZoom = new System.Windows.Forms.Button();
            this.buttonNormal = new System.Windows.Forms.Button();
            this.buttonForceRedraw = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderOpacity)).BeginInit();
            this.panelMain.SuspendLayout();
            this.panelConnectedZones.SuspendLayout();
            this.panelMainControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMapAndLegend)).BeginInit();
            this.splitContainerMapAndLegend.Panel1.SuspendLayout();
            this.splitContainerMapAndLegend.Panel2.SuspendLayout();
            this.splitContainerMapAndLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(5, 3);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(200, 200);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            this.picBox.WaitOnLoad = true;
            this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Paint);
            // 
            // checkLegend
            // 
            this.checkLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkLegend.AutoSize = true;
            this.checkLegend.Checked = true;
            this.checkLegend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkLegend.Location = new System.Drawing.Point(624, 532);
            this.checkLegend.Name = "checkLegend";
            this.checkLegend.Size = new System.Drawing.Size(61, 17);
            this.checkLegend.TabIndex = 11;
            this.checkLegend.Text = "Legend";
            this.checkLegend.UseVisualStyleBackColor = true;
            this.checkLegend.CheckedChanged += new System.EventHandler(this.checkLegend_CheckedChanged);
            // 
            // checkEnableDirection
            // 
            this.checkEnableDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkEnableDirection.AutoSize = true;
            this.checkEnableDirection.Checked = true;
            this.checkEnableDirection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkEnableDirection.Location = new System.Drawing.Point(550, 532);
            this.checkEnableDirection.Name = "checkEnableDirection";
            this.checkEnableDirection.Size = new System.Drawing.Size(68, 17);
            this.checkEnableDirection.TabIndex = 10;
            this.checkEnableDirection.Text = "Direction";
            this.checkEnableDirection.UseVisualStyleBackColor = true;
            this.checkEnableDirection.CheckedChanged += new System.EventHandler(this.checkEnableDirection_CheckedChanged);
            // 
            // labelLegend
            // 
            this.labelLegend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLegend.AutoSize = false;
            this.labelLegend.AutoSizeHeightOnly = true;
            this.labelLegend.BackColor = System.Drawing.SystemColors.Window;
            this.labelLegend.BaseStylesheet = null;
            this.labelLegend.Location = new System.Drawing.Point(3, 5);
            this.labelLegend.MinimumSize = new System.Drawing.Size(100, 22);
            this.labelLegend.Name = "labelLegend";
            this.labelLegend.Size = new System.Drawing.Size(745, 22);
            this.labelLegend.TabIndex = 13;
            this.labelLegend.Text = "Legend";
            // 
            // comboZone
            // 
            this.comboZone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboZone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboZone.FormattingEnabled = true;
            this.comboZone.Location = new System.Drawing.Point(207, 3);
            this.comboZone.Name = "comboZone";
            this.comboZone.Size = new System.Drawing.Size(298, 21);
            this.comboZone.TabIndex = 2;
            this.comboZone.DropDownClosed += new System.EventHandler(this.comboZone_DropDownClosed);
            // 
            // checkGroupByContinent
            // 
            this.checkGroupByContinent.AutoSize = true;
            this.checkGroupByContinent.Checked = true;
            this.checkGroupByContinent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkGroupByContinent.Location = new System.Drawing.Point(382, 30);
            this.checkGroupByContinent.Name = "checkGroupByContinent";
            this.checkGroupByContinent.Size = new System.Drawing.Size(120, 17);
            this.checkGroupByContinent.TabIndex = 5;
            this.checkGroupByContinent.Text = "Group by Continent";
            this.checkGroupByContinent.UseVisualStyleBackColor = true;
            this.checkGroupByContinent.CheckedChanged += new System.EventHandler(this.checkGroupByContinent_CheckedChanged);
            // 
            // btnAutosize
            // 
            this.btnAutosize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAutosize.Location = new System.Drawing.Point(12, 528);
            this.btnAutosize.Name = "btnAutosize";
            this.btnAutosize.Size = new System.Drawing.Size(75, 23);
            this.btnAutosize.TabIndex = 6;
            this.btnAutosize.Text = "Autosize";
            this.btnAutosize.UseVisualStyleBackColor = true;
            this.btnAutosize.Click += new System.EventHandler(this.btnAutosize_Click);
            // 
            // checkAutoSizeOnMapSwitch
            // 
            this.checkAutoSizeOnMapSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkAutoSizeOnMapSwitch.AutoSize = true;
            this.checkAutoSizeOnMapSwitch.Checked = true;
            this.checkAutoSizeOnMapSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoSizeOnMapSwitch.Location = new System.Drawing.Point(93, 532);
            this.checkAutoSizeOnMapSwitch.Name = "checkAutoSizeOnMapSwitch";
            this.checkAutoSizeOnMapSwitch.Size = new System.Drawing.Size(93, 17);
            this.checkAutoSizeOnMapSwitch.TabIndex = 7;
            this.checkAutoSizeOnMapSwitch.Text = "On Mapswitch";
            this.checkAutoSizeOnMapSwitch.UseVisualStyleBackColor = true;
            // 
            // linkLabelWiki
            // 
            this.linkLabelWiki.AutoSize = true;
            this.linkLabelWiki.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelWiki.Location = new System.Drawing.Point(175, 6);
            this.linkLabelWiki.Name = "linkLabelWiki";
            this.linkLabelWiki.Size = new System.Drawing.Size(26, 13);
            this.linkLabelWiki.TabIndex = 1;
            this.linkLabelWiki.TabStop = true;
            this.linkLabelWiki.Text = "Wiki";
            this.toolTip1.SetToolTip(this.linkLabelWiki, "Open the zone\'s page on the Wiki");
            this.linkLabelWiki.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelWiki_LinkClicked);
            // 
            // sliderOpacity
            // 
            this.sliderOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderOpacity.AutoSize = false;
            this.sliderOpacity.Location = new System.Drawing.Point(420, 532);
            this.sliderOpacity.Maximum = 20;
            this.sliderOpacity.Minimum = 2;
            this.sliderOpacity.Name = "sliderOpacity";
            this.sliderOpacity.Size = new System.Drawing.Size(120, 20);
            this.sliderOpacity.TabIndex = 9;
            this.sliderOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.sliderOpacity, "Opacity Level (10-100%)");
            this.sliderOpacity.Value = 20;
            this.sliderOpacity.Scroll += new System.EventHandler(this.sliderOpacity_Scroll);
            // 
            // btnSetWaypoint
            // 
            this.btnSetWaypoint.Location = new System.Drawing.Point(300, 26);
            this.btnSetWaypoint.Name = "btnSetWaypoint";
            this.btnSetWaypoint.Size = new System.Drawing.Size(55, 23);
            this.btnSetWaypoint.TabIndex = 4;
            this.btnSetWaypoint.Text = "Set WP";
            this.toolTip1.SetToolTip(this.btnSetWaypoint, "Set waypoint on map");
            this.btnSetWaypoint.UseVisualStyleBackColor = true;
            this.btnSetWaypoint.Click += new System.EventHandler(this.btnSetWaypoint_Click);
            // 
            // textBoxCharName
            // 
            this.textBoxCharName.Location = new System.Drawing.Point(74, 3);
            this.textBoxCharName.MaxLength = 32;
            this.textBoxCharName.Name = "textBoxCharName";
            this.textBoxCharName.Size = new System.Drawing.Size(95, 21);
            this.textBoxCharName.TabIndex = 14;
            this.textBoxCharName.Text = "*";
            this.toolTip1.SetToolTip(this.textBoxCharName, "Type character name here");
            this.textBoxCharName.TextChanged += new System.EventHandler(this.textBoxCharName_TextChanged);
            // 
            // checkAlwaysOnTop
            // 
            this.checkAlwaysOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAlwaysOnTop.AutoSize = true;
            this.checkAlwaysOnTop.Location = new System.Drawing.Point(367, 532);
            this.checkAlwaysOnTop.Name = "checkAlwaysOnTop";
            this.checkAlwaysOnTop.Size = new System.Drawing.Size(47, 17);
            this.checkAlwaysOnTop.TabIndex = 8;
            this.checkAlwaysOnTop.Text = "AOT";
            this.toolTip1.SetToolTip(this.checkAlwaysOnTop, "Always-On-Top");
            this.checkAlwaysOnTop.UseVisualStyleBackColor = true;
            this.checkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.checkAlwaysOnTop_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.Controls.Add(this.panelMapContainer);
            this.panelMain.Controls.Add(this.picBox);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(604, 333);
            this.panelMain.TabIndex = 13;
            // 
            // panelMapContainer
            // 
            this.panelMapContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMapContainer.Location = new System.Drawing.Point(403, 263);
            this.panelMapContainer.Name = "panelMapContainer";
            this.panelMapContainer.Size = new System.Drawing.Size(190, 52);
            this.panelMapContainer.TabIndex = 1;
            // 
            // panelConnectedZones
            // 
            this.panelConnectedZones.Controls.Add(this.labelConnectedZones);
            this.panelConnectedZones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConnectedZones.Location = new System.Drawing.Point(0, 0);
            this.panelConnectedZones.Name = "panelConnectedZones";
            this.panelConnectedZones.Size = new System.Drawing.Size(750, 24);
            this.panelConnectedZones.TabIndex = 6;
            this.panelConnectedZones.WrapContents = false;
            // 
            // labelConnectedZones
            // 
            this.labelConnectedZones.AutoSize = true;
            this.labelConnectedZones.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectedZones.Location = new System.Drawing.Point(3, 0);
            this.labelConnectedZones.Name = "labelConnectedZones";
            this.labelConnectedZones.Size = new System.Drawing.Size(95, 13);
            this.labelConnectedZones.TabIndex = 4;
            this.labelConnectedZones.Text = "Connected Zones:";
            // 
            // flowSubMaps
            // 
            this.flowSubMaps.AutoScroll = true;
            this.flowSubMaps.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowSubMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowSubMaps.Location = new System.Drawing.Point(0, 0);
            this.flowSubMaps.Name = "flowSubMaps";
            this.flowSubMaps.Size = new System.Drawing.Size(138, 333);
            this.flowSubMaps.TabIndex = 7;
            // 
            // btnSettingsHelp
            // 
            this.btnSettingsHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsHelp.Location = new System.Drawing.Point(772, 528);
            this.btnSettingsHelp.Name = "btnSettingsHelp";
            this.btnSettingsHelp.Size = new System.Drawing.Size(100, 23);
            this.btnSettingsHelp.TabIndex = 12;
            this.btnSettingsHelp.Text = "Settings && Help";
            this.btnSettingsHelp.UseVisualStyleBackColor = true;
            this.btnSettingsHelp.Click += new System.EventHandler(this.btnSettingsHelp_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // txtWaypoint
            // 
            this.txtWaypoint.Location = new System.Drawing.Point(207, 28);
            this.txtWaypoint.Name = "txtWaypoint";
            this.txtWaypoint.Size = new System.Drawing.Size(87, 21);
            this.txtWaypoint.TabIndex = 3;
            this.txtWaypoint.Text = "0, 0";
            // 
            // labelCharName
            // 
            this.labelCharName.AutoSize = true;
            this.labelCharName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCharName.Location = new System.Drawing.Point(4, 6);
            this.labelCharName.Name = "labelCharName";
            this.labelCharName.Size = new System.Drawing.Size(64, 13);
            this.labelCharName.TabIndex = 5;
            this.labelCharName.Text = "Char Name:";
            // 
            // btnMinisize
            // 
            this.btnMinisize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinisize.Location = new System.Drawing.Point(691, 528);
            this.btnMinisize.Name = "btnMinisize";
            this.btnMinisize.Size = new System.Drawing.Size(75, 23);
            this.btnMinisize.TabIndex = 15;
            this.btnMinisize.Text = "Minisize";
            this.btnMinisize.UseVisualStyleBackColor = true;
            this.btnMinisize.Click += new System.EventHandler(this.btnMinisize_Click);
            // 
            // panelMainControls
            // 
            this.panelMainControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMainControls.BackColor = System.Drawing.Color.Transparent;
            this.panelMainControls.Controls.Add(this.labelCharName);
            this.panelMainControls.Controls.Add(this.comboZone);
            this.panelMainControls.Controls.Add(this.textBoxCharName);
            this.panelMainControls.Controls.Add(this.checkGroupByContinent);
            this.panelMainControls.Controls.Add(this.linkLabelWiki);
            this.panelMainControls.Controls.Add(this.btnSetWaypoint);
            this.panelMainControls.Controls.Add(this.txtWaypoint);
            this.panelMainControls.Location = new System.Drawing.Point(360, 12);
            this.panelMainControls.Name = "panelMainControls";
            this.panelMainControls.Size = new System.Drawing.Size(512, 52);
            this.panelMainControls.TabIndex = 17;
            // 
            // nud_scale
            // 
            this.nud_scale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_scale.DecimalPlaces = 2;
            this.nud_scale.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nud_scale.Location = new System.Drawing.Point(828, 254);
            this.nud_scale.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_scale.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nud_scale.Name = "nud_scale";
            this.nud_scale.Size = new System.Drawing.Size(44, 21);
            this.nud_scale.TabIndex = 15;
            this.nud_scale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_scale.ValueChanged += new System.EventHandler(this.nud_scale_ValueChanged);
            // 
            // labelZoneName
            // 
            this.labelZoneName.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZoneName.Location = new System.Drawing.Point(13, 13);
            this.labelZoneName.Name = "labelZoneName";
            this.labelZoneName.Size = new System.Drawing.Size(352, 55);
            this.labelZoneName.TabIndex = 0;
            this.labelZoneName.Text = "Zone";
            // 
            // splitContainerMapAndLegend
            // 
            this.splitContainerMapAndLegend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerMapAndLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMapAndLegend.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMapAndLegend.Name = "splitContainerMapAndLegend";
            // 
            // splitContainerMapAndLegend.Panel1
            // 
            this.splitContainerMapAndLegend.Panel1.AutoScroll = true;
            this.splitContainerMapAndLegend.Panel1.Controls.Add(this.panelMain);
            // 
            // splitContainerMapAndLegend.Panel2
            // 
            this.splitContainerMapAndLegend.Panel2.AutoScroll = true;
            this.splitContainerMapAndLegend.Panel2.Controls.Add(this.flowSubMaps);
            this.splitContainerMapAndLegend.Panel2MinSize = 125;
            this.splitContainerMapAndLegend.Size = new System.Drawing.Size(750, 335);
            this.splitContainerMapAndLegend.SplitterDistance = 606;
            this.splitContainerMapAndLegend.TabIndex = 14;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point(16, 71);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.AutoScroll = true;
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerMapAndLegend);
            this.splitContainerMain.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerMain.Panel1MinSize = 250;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.AutoScroll = true;
            this.splitContainerMain.Panel2.Controls.Add(this.panel1);
            this.splitContainerMain.Panel2.Controls.Add(this.panelConnectedZones);
            this.splitContainerMain.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerMain.Panel2MinSize = 100;
            this.splitContainerMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerMain.Size = new System.Drawing.Size(750, 450);
            this.splitContainerMain.SplitterDistance = 335;
            this.splitContainerMain.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.labelLegend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 87);
            this.panel1.TabIndex = 14;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(795, 335);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(77, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonAutosize
            // 
            this.buttonAutosize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutosize.Location = new System.Drawing.Point(799, 85);
            this.buttonAutosize.Name = "buttonAutosize";
            this.buttonAutosize.Size = new System.Drawing.Size(73, 23);
            this.buttonAutosize.TabIndex = 17;
            this.buttonAutosize.Text = "Autosize";
            this.buttonAutosize.UseVisualStyleBackColor = true;
            this.buttonAutosize.Click += new System.EventHandler(this.buttonAutosize_Click);
            // 
            // buttonStretch
            // 
            this.buttonStretch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStretch.Location = new System.Drawing.Point(799, 114);
            this.buttonStretch.Name = "buttonStretch";
            this.buttonStretch.Size = new System.Drawing.Size(73, 23);
            this.buttonStretch.TabIndex = 18;
            this.buttonStretch.Text = "Stretch";
            this.buttonStretch.UseVisualStyleBackColor = true;
            this.buttonStretch.Click += new System.EventHandler(this.buttonStretch_Click);
            // 
            // buttonCenter
            // 
            this.buttonCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCenter.Location = new System.Drawing.Point(799, 143);
            this.buttonCenter.Name = "buttonCenter";
            this.buttonCenter.Size = new System.Drawing.Size(73, 23);
            this.buttonCenter.TabIndex = 19;
            this.buttonCenter.Text = "Center";
            this.buttonCenter.UseVisualStyleBackColor = true;
            this.buttonCenter.Click += new System.EventHandler(this.buttonCenter_Click);
            // 
            // buttonZoom
            // 
            this.buttonZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZoom.Location = new System.Drawing.Point(799, 172);
            this.buttonZoom.Name = "buttonZoom";
            this.buttonZoom.Size = new System.Drawing.Size(73, 23);
            this.buttonZoom.TabIndex = 20;
            this.buttonZoom.Text = "Zoom";
            this.buttonZoom.UseVisualStyleBackColor = true;
            this.buttonZoom.Click += new System.EventHandler(this.buttonZoom_Click);
            // 
            // buttonNormal
            // 
            this.buttonNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNormal.Location = new System.Drawing.Point(799, 201);
            this.buttonNormal.Name = "buttonNormal";
            this.buttonNormal.Size = new System.Drawing.Size(73, 23);
            this.buttonNormal.TabIndex = 21;
            this.buttonNormal.Text = "Normal";
            this.buttonNormal.UseVisualStyleBackColor = true;
            this.buttonNormal.Click += new System.EventHandler(this.buttonNormal_Click);
            // 
            // buttonForceRedraw
            // 
            this.buttonForceRedraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonForceRedraw.Location = new System.Drawing.Point(772, 281);
            this.buttonForceRedraw.Name = "buttonForceRedraw";
            this.buttonForceRedraw.Size = new System.Drawing.Size(100, 23);
            this.buttonForceRedraw.TabIndex = 22;
            this.buttonForceRedraw.Text = "Force Redraw";
            this.buttonForceRedraw.UseVisualStyleBackColor = true;
            this.buttonForceRedraw.Click += new System.EventHandler(this.buttonForceRedraw_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(790, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Scale";
            // 
            // ZlizEQMapFormExperimental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonForceRedraw);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonNormal);
            this.Controls.Add(this.nud_scale);
            this.Controls.Add(this.buttonZoom);
            this.Controls.Add(this.buttonCenter);
            this.Controls.Add(this.buttonStretch);
            this.Controls.Add(this.buttonAutosize);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.checkAlwaysOnTop);
            this.Controls.Add(this.sliderOpacity);
            this.Controls.Add(this.checkLegend);
            this.Controls.Add(this.checkEnableDirection);
            this.Controls.Add(this.checkAutoSizeOnMapSwitch);
            this.Controls.Add(this.panelMainControls);
            this.Controls.Add(this.btnAutosize);
            this.Controls.Add(this.labelZoneName);
            this.Controls.Add(this.btnSettingsHelp);
            this.Controls.Add(this.btnMinisize);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ZlizEQMapFormExperimental";
            this.Text = "ZlizEQMap (Experimental UI)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZlizEQMapFormExperimental_FormClosing);
            this.SizeChanged += new System.EventHandler(this.ZlizEQMapFormExperimental_SizeChanged);
            this.Resize += new System.EventHandler(this.ZlizEQMapFormExperimental_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderOpacity)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelConnectedZones.ResumeLayout(false);
            this.panelConnectedZones.PerformLayout();
            this.panelMainControls.ResumeLayout(false);
            this.panelMainControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_scale)).EndInit();
            this.splitContainerMapAndLegend.Panel1.ResumeLayout(false);
            this.splitContainerMapAndLegend.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMapAndLegend)).EndInit();
            this.splitContainerMapAndLegend.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.CheckBox checkLegend;
        private System.Windows.Forms.CheckBox checkEnableDirection;
        private ZlizLabel labelZoneName;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel labelLegend;
        private System.Windows.Forms.ComboBox comboZone;
        private System.Windows.Forms.CheckBox checkGroupByContinent;
        private System.Windows.Forms.Button btnAutosize;
        private System.Windows.Forms.CheckBox checkAutoSizeOnMapSwitch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelConnectedZones;
        private System.Windows.Forms.FlowLayoutPanel panelConnectedZones;
        private System.Windows.Forms.FlowLayoutPanel flowSubMaps;
        private System.Windows.Forms.LinkLabel linkLabelWiki;
        private System.Windows.Forms.Button btnSettingsHelp;
        private System.Windows.Forms.TrackBar sliderOpacity;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnSetWaypoint;
        private System.Windows.Forms.TextBox txtWaypoint;
        private System.Windows.Forms.TextBox textBoxCharName;
        private System.Windows.Forms.Label labelCharName;
        private Button btnMinisize;
        private Panel panelMainControls;
        private NumericUpDown nud_scale;
        private SplitContainer splitContainerMain;
        private SplitContainer splitContainerMapAndLegend;
        private CheckBox checkAlwaysOnTop;
        private Panel panel1;
        private Button buttonAutosize;
        private CheckBox checkBox1;
        private Button buttonStretch;
        private Button buttonCenter;
        private Button buttonZoom;
        private Button buttonNormal;
        private Button buttonForceRedraw;
        private Label label1;
        private Panel panelMapContainer;
    }
}

