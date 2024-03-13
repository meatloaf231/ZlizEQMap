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
            this.sliderZoom = new System.Windows.Forms.TrackBar();
            this.check_ShowAnnotations = new System.Windows.Forms.CheckBox();
            this.check_ShowPlayerLocHistory = new System.Windows.Forms.CheckBox();
            this.check_ClearNoteAfterEntry = new System.Windows.Forms.CheckBox();
            this.check_AutoUpdateNoteLocation = new System.Windows.Forms.CheckBox();
            this.check_AutoParseFromLogs = new System.Windows.Forms.CheckBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelConnectedZones = new System.Windows.Forms.FlowLayoutPanel();
            this.labelConnectedZones = new System.Windows.Forms.Label();
            this.flowSubMaps = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSettingsHelp = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.txtWaypoint = new System.Windows.Forms.TextBox();
            this.labelCharName = new System.Windows.Forms.Label();
            this.buttonOpenPopoutMap = new System.Windows.Forms.Button();
            this.panelMainControls = new System.Windows.Forms.Panel();
            this.nud_scale = new System.Windows.Forms.NumericUpDown();
            this.splitContainerMapAndLegend = new System.Windows.Forms.SplitContainer();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLegend = new System.Windows.Forms.Panel();
            this.buttonAutosize = new System.Windows.Forms.Button();
            this.buttonStretch = new System.Windows.Forms.Button();
            this.buttonCenter = new System.Windows.Forms.Button();
            this.buttonZoom = new System.Windows.Forms.Button();
            this.buttonNormal = new System.Windows.Forms.Button();
            this.label_Scale = new System.Windows.Forms.Label();
            this.nud_playerX = new System.Windows.Forms.NumericUpDown();
            this.label_PlayerX = new System.Windows.Forms.Label();
            this.label_PlayerY = new System.Windows.Forms.Label();
            this.nud_playerY = new System.Windows.Forms.NumericUpDown();
            this.label_Zoom = new System.Windows.Forms.Label();
            this.label_Opacity = new System.Windows.Forms.Label();
            this.nud_HistoryToKeep = new System.Windows.Forms.NumericUpDown();
            this.label_AnnotationFontSize = new System.Windows.Forms.Label();
            this.label_HistoryToKeep = new System.Windows.Forms.Label();
            this.button_AddNote = new System.Windows.Forms.Button();
            this.txt_NewNote = new System.Windows.Forms.TextBox();
            this.zoneAnnotationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgv_ZoneAnnotation = new System.Windows.Forms.DataGridView();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XCoord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YCoord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Show = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txt_NewNoteCoords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_SetNoteCoordsToPlayerLoc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_NotesFont = new System.Windows.Forms.Button();
            this.button_NotesColor = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.colorDialog_Notes = new System.Windows.Forms.ColorDialog();
            this.fontDialog_Notes = new System.Windows.Forms.FontDialog();
            this.button_ResetZoom = new System.Windows.Forms.Button();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelZoneName = new ZlizEQMap.ZlizLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderZoom)).BeginInit();
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
            this.panelLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_playerX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_playerY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_HistoryToKeep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneAnnotationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ZoneAnnotation)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(5, 3);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(256, 256);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            this.picBox.WaitOnLoad = true;
            this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Paint);
            // 
            // checkLegend
            // 
            this.checkLegend.AutoSize = true;
            this.checkLegend.Checked = true;
            this.checkLegend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkLegend.Location = new System.Drawing.Point(7, 99);
            this.checkLegend.Name = "checkLegend";
            this.checkLegend.Size = new System.Drawing.Size(61, 17);
            this.checkLegend.TabIndex = 11;
            this.checkLegend.Text = "Legend";
            this.checkLegend.UseVisualStyleBackColor = true;
            this.checkLegend.CheckedChanged += new System.EventHandler(this.checkLegend_CheckedChanged);
            // 
            // checkEnableDirection
            // 
            this.checkEnableDirection.AutoSize = true;
            this.checkEnableDirection.Checked = true;
            this.checkEnableDirection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkEnableDirection.Location = new System.Drawing.Point(6, 122);
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
            this.labelLegend.Location = new System.Drawing.Point(12, 15);
            this.labelLegend.MinimumSize = new System.Drawing.Size(100, 22);
            this.labelLegend.Name = "labelLegend";
            this.labelLegend.Size = new System.Drawing.Size(659, 22);
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
            this.btnAutosize.Location = new System.Drawing.Point(6, 6);
            this.btnAutosize.Name = "btnAutosize";
            this.btnAutosize.Size = new System.Drawing.Size(75, 23);
            this.btnAutosize.TabIndex = 6;
            this.btnAutosize.Text = "Autosize";
            this.btnAutosize.UseVisualStyleBackColor = true;
            this.btnAutosize.Click += new System.EventHandler(this.btnAutosize_Click);
            // 
            // checkAutoSizeOnMapSwitch
            // 
            this.checkAutoSizeOnMapSwitch.AutoSize = true;
            this.checkAutoSizeOnMapSwitch.Checked = true;
            this.checkAutoSizeOnMapSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoSizeOnMapSwitch.Location = new System.Drawing.Point(87, 9);
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
            this.sliderOpacity.AutoSize = false;
            this.sliderOpacity.Location = new System.Drawing.Point(60, 35);
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
            this.checkAlwaysOnTop.AutoSize = true;
            this.checkAlwaysOnTop.Location = new System.Drawing.Point(186, 38);
            this.checkAlwaysOnTop.Name = "checkAlwaysOnTop";
            this.checkAlwaysOnTop.Size = new System.Drawing.Size(47, 17);
            this.checkAlwaysOnTop.TabIndex = 8;
            this.checkAlwaysOnTop.Text = "AOT";
            this.toolTip1.SetToolTip(this.checkAlwaysOnTop, "Always-On-Top");
            this.checkAlwaysOnTop.UseVisualStyleBackColor = true;
            // 
            // sliderZoom
            // 
            this.sliderZoom.AutoSize = false;
            this.sliderZoom.Location = new System.Drawing.Point(60, 61);
            this.sliderZoom.Maximum = 200;
            this.sliderZoom.Minimum = 10;
            this.sliderZoom.Name = "sliderZoom";
            this.sliderZoom.Size = new System.Drawing.Size(120, 20);
            this.sliderZoom.TabIndex = 31;
            this.sliderZoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.sliderZoom, "Opacity Level (10-100%)");
            this.sliderZoom.Value = 100;
            this.sliderZoom.Scroll += new System.EventHandler(this.sliderZoom_Scroll);
            // 
            // check_ShowAnnotations
            // 
            this.check_ShowAnnotations.AutoSize = true;
            this.check_ShowAnnotations.Location = new System.Drawing.Point(6, 20);
            this.check_ShowAnnotations.Name = "check_ShowAnnotations";
            this.check_ShowAnnotations.Size = new System.Drawing.Size(121, 17);
            this.check_ShowAnnotations.TabIndex = 38;
            this.check_ShowAnnotations.Text = "Show Notes on Map";
            this.check_ShowAnnotations.ThreeState = true;
            this.toolTip1.SetToolTip(this.check_ShowAnnotations, "Always-On-Top");
            this.check_ShowAnnotations.UseVisualStyleBackColor = true;
            this.check_ShowAnnotations.CheckStateChanged += new System.EventHandler(this.check_ShowAnnotations_CheckStateChanged);
            // 
            // check_ShowPlayerLocHistory
            // 
            this.check_ShowPlayerLocHistory.AutoSize = true;
            this.check_ShowPlayerLocHistory.Location = new System.Drawing.Point(6, 146);
            this.check_ShowPlayerLocHistory.Name = "check_ShowPlayerLocHistory";
            this.check_ShowPlayerLocHistory.Size = new System.Drawing.Size(103, 17);
            this.check_ShowPlayerLocHistory.TabIndex = 40;
            this.check_ShowPlayerLocHistory.Text = "Location History";
            this.toolTip1.SetToolTip(this.check_ShowPlayerLocHistory, "Always-On-Top");
            this.check_ShowPlayerLocHistory.UseVisualStyleBackColor = true;
            this.check_ShowPlayerLocHistory.CheckedChanged += new System.EventHandler(this.check_ShowPlayerLocHistory_CheckedChanged);
            // 
            // check_ClearNoteAfterEntry
            // 
            this.check_ClearNoteAfterEntry.AutoSize = true;
            this.check_ClearNoteAfterEntry.Location = new System.Drawing.Point(6, 75);
            this.check_ClearNoteAfterEntry.Name = "check_ClearNoteAfterEntry";
            this.check_ClearNoteAfterEntry.Size = new System.Drawing.Size(107, 17);
            this.check_ClearNoteAfterEntry.TabIndex = 42;
            this.check_ClearNoteAfterEntry.Text = "Clear after entry";
            this.toolTip1.SetToolTip(this.check_ClearNoteAfterEntry, "Always-On-Top");
            this.check_ClearNoteAfterEntry.UseVisualStyleBackColor = true;
            // 
            // check_AutoUpdateNoteLocation
            // 
            this.check_AutoUpdateNoteLocation.AutoSize = true;
            this.check_AutoUpdateNoteLocation.Location = new System.Drawing.Point(166, 144);
            this.check_AutoUpdateNoteLocation.Name = "check_AutoUpdateNoteLocation";
            this.check_AutoUpdateNoteLocation.Size = new System.Drawing.Size(87, 17);
            this.check_AutoUpdateNoteLocation.TabIndex = 47;
            this.check_AutoUpdateNoteLocation.Text = "Auto-update";
            this.toolTip1.SetToolTip(this.check_AutoUpdateNoteLocation, "Always-On-Top");
            this.check_AutoUpdateNoteLocation.UseVisualStyleBackColor = true;
            // 
            // check_AutoParseFromLogs
            // 
            this.check_AutoParseFromLogs.AutoSize = true;
            this.check_AutoParseFromLogs.Location = new System.Drawing.Point(15, 74);
            this.check_AutoParseFromLogs.Name = "check_AutoParseFromLogs";
            this.check_AutoParseFromLogs.Size = new System.Drawing.Size(120, 17);
            this.check_AutoParseFromLogs.TabIndex = 51;
            this.check_AutoParseFromLogs.Text = "Suspend Autoparse";
            this.toolTip1.SetToolTip(this.check_AutoParseFromLogs, "Always-On-Top");
            this.check_AutoParseFromLogs.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.Controls.Add(this.picBox);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(565, 476);
            this.panelMain.TabIndex = 13;
            // 
            // panelConnectedZones
            // 
            this.panelConnectedZones.Controls.Add(this.labelConnectedZones);
            this.panelConnectedZones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConnectedZones.Location = new System.Drawing.Point(0, 0);
            this.panelConnectedZones.Name = "panelConnectedZones";
            this.panelConnectedZones.Size = new System.Drawing.Size(700, 31);
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
            this.flowSubMaps.Size = new System.Drawing.Size(127, 476);
            this.flowSubMaps.TabIndex = 7;
            // 
            // btnSettingsHelp
            // 
            this.btnSettingsHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsHelp.Location = new System.Drawing.Point(897, 726);
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
            // buttonOpenPopoutMap
            // 
            this.buttonOpenPopoutMap.Location = new System.Drawing.Point(186, 6);
            this.buttonOpenPopoutMap.Name = "buttonOpenPopoutMap";
            this.buttonOpenPopoutMap.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenPopoutMap.TabIndex = 15;
            this.buttonOpenPopoutMap.Text = "Popout Map";
            this.buttonOpenPopoutMap.UseVisualStyleBackColor = true;
            this.buttonOpenPopoutMap.Click += new System.EventHandler(this.buttonOpenPopoutMap_Click);
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
            this.panelMainControls.Location = new System.Drawing.Point(485, 12);
            this.panelMainControls.Name = "panelMainControls";
            this.panelMainControls.Size = new System.Drawing.Size(512, 52);
            this.panelMainControls.TabIndex = 17;
            // 
            // nud_scale
            // 
            this.nud_scale.DecimalPlaces = 2;
            this.nud_scale.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nud_scale.Location = new System.Drawing.Point(102, 97);
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
            this.splitContainerMapAndLegend.Size = new System.Drawing.Size(700, 478);
            this.splitContainerMapAndLegend.SplitterDistance = 567;
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
            this.splitContainerMain.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerMain.Panel2MinSize = 100;
            this.splitContainerMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerMain.Size = new System.Drawing.Size(700, 649);
            this.splitContainerMain.SplitterDistance = 478;
            this.splitContainerMain.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panelLegend);
            this.panel1.Controls.Add(this.panelConnectedZones);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 167);
            this.panel1.TabIndex = 14;
            // 
            // panelLegend
            // 
            this.panelLegend.AutoScroll = true;
            this.panelLegend.Controls.Add(this.labelLegend);
            this.panelLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLegend.Location = new System.Drawing.Point(0, 31);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(700, 136);
            this.panelLegend.TabIndex = 14;
            // 
            // buttonAutosize
            // 
            this.buttonAutosize.Location = new System.Drawing.Point(175, 128);
            this.buttonAutosize.Name = "buttonAutosize";
            this.buttonAutosize.Size = new System.Drawing.Size(73, 23);
            this.buttonAutosize.TabIndex = 17;
            this.buttonAutosize.Text = "Auto";
            this.buttonAutosize.UseVisualStyleBackColor = true;
            this.buttonAutosize.Click += new System.EventHandler(this.buttonAutosize_Click);
            // 
            // buttonStretch
            // 
            this.buttonStretch.Location = new System.Drawing.Point(175, 70);
            this.buttonStretch.Name = "buttonStretch";
            this.buttonStretch.Size = new System.Drawing.Size(73, 23);
            this.buttonStretch.TabIndex = 18;
            this.buttonStretch.Text = "Stretch";
            this.buttonStretch.UseVisualStyleBackColor = true;
            this.buttonStretch.Click += new System.EventHandler(this.buttonStretch_Click);
            // 
            // buttonCenter
            // 
            this.buttonCenter.Location = new System.Drawing.Point(175, 41);
            this.buttonCenter.Name = "buttonCenter";
            this.buttonCenter.Size = new System.Drawing.Size(73, 23);
            this.buttonCenter.TabIndex = 19;
            this.buttonCenter.Text = "Center";
            this.buttonCenter.UseVisualStyleBackColor = true;
            this.buttonCenter.Click += new System.EventHandler(this.buttonCenter_Click);
            // 
            // buttonZoom
            // 
            this.buttonZoom.Location = new System.Drawing.Point(175, 99);
            this.buttonZoom.Name = "buttonZoom";
            this.buttonZoom.Size = new System.Drawing.Size(73, 23);
            this.buttonZoom.TabIndex = 20;
            this.buttonZoom.Text = "Zoom";
            this.buttonZoom.UseVisualStyleBackColor = true;
            this.buttonZoom.Click += new System.EventHandler(this.buttonZoom_Click);
            // 
            // buttonNormal
            // 
            this.buttonNormal.Location = new System.Drawing.Point(175, 12);
            this.buttonNormal.Name = "buttonNormal";
            this.buttonNormal.Size = new System.Drawing.Size(73, 23);
            this.buttonNormal.TabIndex = 21;
            this.buttonNormal.Text = "Normal";
            this.buttonNormal.UseVisualStyleBackColor = true;
            this.buttonNormal.Click += new System.EventHandler(this.buttonNormal_Click);
            // 
            // label_Scale
            // 
            this.label_Scale.AutoSize = true;
            this.label_Scale.Location = new System.Drawing.Point(12, 94);
            this.label_Scale.Name = "label_Scale";
            this.label_Scale.Size = new System.Drawing.Size(84, 13);
            this.label_Scale.TabIndex = 23;
            this.label_Scale.Text = "Force map scale";
            // 
            // nud_playerX
            // 
            this.nud_playerX.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nud_playerX.Location = new System.Drawing.Point(64, 20);
            this.nud_playerX.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nud_playerX.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.nud_playerX.Name = "nud_playerX";
            this.nud_playerX.Size = new System.Drawing.Size(44, 21);
            this.nud_playerX.TabIndex = 24;
            this.nud_playerX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_playerX.ValueChanged += new System.EventHandler(this.nud_playerX_ValueChanged);
            // 
            // label_PlayerX
            // 
            this.label_PlayerX.AutoSize = true;
            this.label_PlayerX.Location = new System.Drawing.Point(12, 22);
            this.label_PlayerX.Name = "label_PlayerX";
            this.label_PlayerX.Size = new System.Drawing.Size(46, 13);
            this.label_PlayerX.TabIndex = 26;
            this.label_PlayerX.Text = "Player X";
            // 
            // label_PlayerY
            // 
            this.label_PlayerY.AutoSize = true;
            this.label_PlayerY.Location = new System.Drawing.Point(12, 49);
            this.label_PlayerY.Name = "label_PlayerY";
            this.label_PlayerY.Size = new System.Drawing.Size(46, 13);
            this.label_PlayerY.TabIndex = 27;
            this.label_PlayerY.Text = "Player Y";
            // 
            // nud_playerY
            // 
            this.nud_playerY.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nud_playerY.Location = new System.Drawing.Point(64, 47);
            this.nud_playerY.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nud_playerY.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.nud_playerY.Name = "nud_playerY";
            this.nud_playerY.Size = new System.Drawing.Size(44, 21);
            this.nud_playerY.TabIndex = 28;
            this.nud_playerY.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nud_playerY.ValueChanged += new System.EventHandler(this.nud_playerY_ValueChanged);
            // 
            // label_Zoom
            // 
            this.label_Zoom.AutoSize = true;
            this.label_Zoom.Location = new System.Drawing.Point(6, 61);
            this.label_Zoom.Name = "label_Zoom";
            this.label_Zoom.Size = new System.Drawing.Size(33, 13);
            this.label_Zoom.TabIndex = 32;
            this.label_Zoom.Text = "Zoom";
            // 
            // label_Opacity
            // 
            this.label_Opacity.AutoSize = true;
            this.label_Opacity.Location = new System.Drawing.Point(6, 36);
            this.label_Opacity.Name = "label_Opacity";
            this.label_Opacity.Size = new System.Drawing.Size(44, 13);
            this.label_Opacity.TabIndex = 34;
            this.label_Opacity.Text = "Opacity";
            // 
            // nud_HistoryToKeep
            // 
            this.nud_HistoryToKeep.Location = new System.Drawing.Point(115, 144);
            this.nud_HistoryToKeep.Name = "nud_HistoryToKeep";
            this.nud_HistoryToKeep.Size = new System.Drawing.Size(52, 21);
            this.nud_HistoryToKeep.TabIndex = 35;
            // 
            // label_AnnotationFontSize
            // 
            this.label_AnnotationFontSize.AutoSize = true;
            this.label_AnnotationFontSize.Location = new System.Drawing.Point(7, 149);
            this.label_AnnotationFontSize.Name = "label_AnnotationFontSize";
            this.label_AnnotationFontSize.Size = new System.Drawing.Size(136, 13);
            this.label_AnnotationFontSize.TabIndex = 37;
            this.label_AnnotationFontSize.Text = "Notes Font Style and Color";
            // 
            // label_HistoryToKeep
            // 
            this.label_HistoryToKeep.AutoSize = true;
            this.label_HistoryToKeep.Location = new System.Drawing.Point(173, 146);
            this.label_HistoryToKeep.Name = "label_HistoryToKeep";
            this.label_HistoryToKeep.Size = new System.Drawing.Size(55, 13);
            this.label_HistoryToKeep.TabIndex = 39;
            this.label_HistoryToKeep.Text = "# to track";
            // 
            // button_AddNote
            // 
            this.button_AddNote.Location = new System.Drawing.Point(166, 45);
            this.button_AddNote.Name = "button_AddNote";
            this.button_AddNote.Size = new System.Drawing.Size(87, 23);
            this.button_AddNote.TabIndex = 41;
            this.button_AddNote.Text = "Add Note";
            this.button_AddNote.UseVisualStyleBackColor = true;
            this.button_AddNote.Click += new System.EventHandler(this.button_AddNote_Click);
            // 
            // txt_NewNote
            // 
            this.txt_NewNote.Location = new System.Drawing.Point(6, 48);
            this.txt_NewNote.Name = "txt_NewNote";
            this.txt_NewNote.Size = new System.Drawing.Size(127, 21);
            this.txt_NewNote.TabIndex = 43;
            this.txt_NewNote.Text = "New Note";
            // 
            // dgv_ZoneAnnotation
            // 
            this.dgv_ZoneAnnotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ZoneAnnotation.AutoGenerateColumns = false;
            this.dgv_ZoneAnnotation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ZoneAnnotation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Note,
            this.XCoord,
            this.YCoord,
            this.Show});
            this.dgv_ZoneAnnotation.DataSource = this.zoneAnnotationBindingSource;
            this.dgv_ZoneAnnotation.Location = new System.Drawing.Point(721, 483);
            this.dgv_ZoneAnnotation.Name = "dgv_ZoneAnnotation";
            this.dgv_ZoneAnnotation.RowHeadersWidth = 15;
            this.dgv_ZoneAnnotation.RowTemplate.Height = 21;
            this.dgv_ZoneAnnotation.Size = new System.Drawing.Size(272, 237);
            this.dgv_ZoneAnnotation.TabIndex = 44;
            this.dgv_ZoneAnnotation.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ZoneAnnotation_CellValueChanged);
            // 
            // Note
            // 
            this.Note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Note.DataPropertyName = "Note";
            this.Note.FillWeight = 176.9911F;
            this.Note.HeaderText = "Note";
            this.Note.MinimumWidth = 50;
            this.Note.Name = "Note";
            // 
            // XCoord
            // 
            this.XCoord.DataPropertyName = "X";
            this.XCoord.FillWeight = 34.58654F;
            this.XCoord.HeaderText = "X";
            this.XCoord.MinimumWidth = 40;
            this.XCoord.Name = "XCoord";
            this.XCoord.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.XCoord.Width = 40;
            // 
            // YCoord
            // 
            this.YCoord.DataPropertyName = "Y";
            this.YCoord.FillWeight = 46.11596F;
            this.YCoord.HeaderText = "Y";
            this.YCoord.MinimumWidth = 40;
            this.YCoord.Name = "YCoord";
            this.YCoord.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.YCoord.Width = 40;
            // 
            // Show
            // 
            this.Show.DataPropertyName = "Show";
            this.Show.FillWeight = 142.3064F;
            this.Show.HeaderText = "Show";
            this.Show.Name = "Show";
            this.Show.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Show.Width = 50;
            // 
            // txt_NewNoteCoords
            // 
            this.txt_NewNoteCoords.Location = new System.Drawing.Point(166, 74);
            this.txt_NewNoteCoords.Name = "txt_NewNoteCoords";
            this.txt_NewNoteCoords.Size = new System.Drawing.Size(87, 21);
            this.txt_NewNoteCoords.TabIndex = 45;
            this.txt_NewNoteCoords.Text = "0, 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "at:";
            // 
            // button_SetNoteCoordsToPlayerLoc
            // 
            this.button_SetNoteCoordsToPlayerLoc.Location = new System.Drawing.Point(166, 101);
            this.button_SetNoteCoordsToPlayerLoc.Name = "button_SetNoteCoordsToPlayerLoc";
            this.button_SetNoteCoordsToPlayerLoc.Size = new System.Drawing.Size(87, 37);
            this.button_SetNoteCoordsToPlayerLoc.TabIndex = 48;
            this.button_SetNoteCoordsToPlayerLoc.Text = "Set to Player Location";
            this.button_SetNoteCoordsToPlayerLoc.UseVisualStyleBackColor = true;
            this.button_SetNoteCoordsToPlayerLoc.Click += new System.EventHandler(this.button_SetNoteCoordsToPlayerLoc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button_NotesFont);
            this.groupBox1.Controls.Add(this.button_NotesColor);
            this.groupBox1.Controls.Add(this.check_AutoUpdateNoteLocation);
            this.groupBox1.Controls.Add(this.check_ShowAnnotations);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_SetNoteCoordsToPlayerLoc);
            this.groupBox1.Controls.Add(this.txt_NewNoteCoords);
            this.groupBox1.Controls.Add(this.label_AnnotationFontSize);
            this.groupBox1.Controls.Add(this.button_AddNote);
            this.groupBox1.Controls.Add(this.txt_NewNote);
            this.groupBox1.Controls.Add(this.check_ClearNoteAfterEntry);
            this.groupBox1.Location = new System.Drawing.Point(721, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 175);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notes";
            // 
            // button_NotesFont
            // 
            this.button_NotesFont.BackColor = System.Drawing.SystemColors.Control;
            this.button_NotesFont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_NotesFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_NotesFont.Location = new System.Drawing.Point(10, 122);
            this.button_NotesFont.Name = "button_NotesFont";
            this.button_NotesFont.Size = new System.Drawing.Size(79, 24);
            this.button_NotesFont.TabIndex = 50;
            this.button_NotesFont.Text = "Edit Font";
            this.button_NotesFont.UseVisualStyleBackColor = false;
            this.button_NotesFont.Click += new System.EventHandler(this.button_NotesFont_Click);
            // 
            // button_NotesColor
            // 
            this.button_NotesColor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_NotesColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_NotesColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_NotesColor.Location = new System.Drawing.Point(95, 122);
            this.button_NotesColor.Name = "button_NotesColor";
            this.button_NotesColor.Size = new System.Drawing.Size(38, 24);
            this.button_NotesColor.TabIndex = 49;
            this.button_NotesColor.UseVisualStyleBackColor = false;
            this.button_NotesColor.Click += new System.EventHandler(this.button_NotesColor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.check_AutoParseFromLogs);
            this.groupBox2.Controls.Add(this.buttonAutosize);
            this.groupBox2.Controls.Add(this.buttonStretch);
            this.groupBox2.Controls.Add(this.buttonNormal);
            this.groupBox2.Controls.Add(this.buttonCenter);
            this.groupBox2.Controls.Add(this.buttonZoom);
            this.groupBox2.Controls.Add(this.label_PlayerX);
            this.groupBox2.Controls.Add(this.nud_playerX);
            this.groupBox2.Controls.Add(this.label_PlayerY);
            this.groupBox2.Controls.Add(this.label_Scale);
            this.groupBox2.Controls.Add(this.nud_playerY);
            this.groupBox2.Controls.Add(this.nud_scale);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 167);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Debugging";
            // 
            // button_ResetZoom
            // 
            this.button_ResetZoom.Location = new System.Drawing.Point(186, 61);
            this.button_ResetZoom.Name = "button_ResetZoom";
            this.button_ResetZoom.Size = new System.Drawing.Size(44, 20);
            this.button_ResetZoom.TabIndex = 52;
            this.button_ResetZoom.Text = "Reset";
            this.button_ResetZoom.UseVisualStyleBackColor = true;
            this.button_ResetZoom.Click += new System.EventHandler(this.button_ResetZoom_Click);
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Main.Controls.Add(this.tabPage1);
            this.tabControl_Main.Controls.Add(this.tabPage2);
            this.tabControl_Main.Location = new System.Drawing.Point(721, 71);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(274, 225);
            this.tabControl_Main.TabIndex = 52;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonOpenPopoutMap);
            this.tabPage1.Controls.Add(this.button_ResetZoom);
            this.tabPage1.Controls.Add(this.btnAutosize);
            this.tabPage1.Controls.Add(this.sliderZoom);
            this.tabPage1.Controls.Add(this.checkAutoSizeOnMapSwitch);
            this.tabPage1.Controls.Add(this.label_Zoom);
            this.tabPage1.Controls.Add(this.checkEnableDirection);
            this.tabPage1.Controls.Add(this.checkAlwaysOnTop);
            this.tabPage1.Controls.Add(this.check_ShowPlayerLocHistory);
            this.tabPage1.Controls.Add(this.label_Opacity);
            this.tabPage1.Controls.Add(this.checkLegend);
            this.tabPage1.Controls.Add(this.sliderOpacity);
            this.tabPage1.Controls.Add(this.label_HistoryToKeep);
            this.tabPage1.Controls.Add(this.nud_HistoryToKeep);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(266, 199);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(266, 199);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // ZlizEQMapFormExperimental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 761);
            this.Controls.Add(this.dgv_ZoneAnnotation);
            this.Controls.Add(this.tabControl_Main);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.panelMainControls);
            this.Controls.Add(this.labelZoneName);
            this.Controls.Add(this.btnSettingsHelp);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ZlizEQMapFormExperimental";
            this.Text = "ZlizEQMap (Experimental UI)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZlizEQMapFormExperimental_FormClosing);
            this.Load += new System.EventHandler(this.ZlizEQMapFormExperimental_Load);
            this.SizeChanged += new System.EventHandler(this.ZlizEQMapFormExperimental_SizeChanged);
            this.Resize += new System.EventHandler(this.ZlizEQMapFormExperimental_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderZoom)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
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
            this.panelLegend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_playerX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_playerY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_HistoryToKeep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneAnnotationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ZoneAnnotation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private Button buttonOpenPopoutMap;
        private Panel panelMainControls;
        private NumericUpDown nud_scale;
        private SplitContainer splitContainerMain;
        private SplitContainer splitContainerMapAndLegend;
        private CheckBox checkAlwaysOnTop;
        private Panel panel1;
        private Button buttonAutosize;
        private Button buttonStretch;
        private Button buttonCenter;
        private Button buttonZoom;
        private Button buttonNormal;
        private Label label_Scale;
        private NumericUpDown nud_playerX;
        private Label label_PlayerX;
        private Label label_PlayerY;
        private NumericUpDown nud_playerY;
        private TrackBar sliderZoom;
        private Label label_Zoom;
        private Label label_Opacity;
        private NumericUpDown nud_HistoryToKeep;
        private Label label_AnnotationFontSize;
        private CheckBox check_ShowAnnotations;
        private Label label_HistoryToKeep;
        private CheckBox check_ShowPlayerLocHistory;
        private Button button_AddNote;
        private CheckBox check_ClearNoteAfterEntry;
        private TextBox txt_NewNote;
        private BindingSource zoneAnnotationBindingSource;
        private DataGridView dgv_ZoneAnnotation;
        private TextBox txt_NewNoteCoords;
        private Label label1;
        private CheckBox check_AutoUpdateNoteLocation;
        private Button button_SetNoteCoordsToPlayerLoc;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox check_AutoParseFromLogs;
        private DataGridViewTextBoxColumn Note;
        private DataGridViewTextBoxColumn XCoord;
        private DataGridViewTextBoxColumn YCoord;
        private DataGridViewCheckBoxColumn Show;
        private ColorDialog colorDialog_Notes;
        private Button button_NotesColor;
        private FontDialog fontDialog_Notes;
        private Button button_NotesFont;
        private Button button_ResetZoom;
        private TabControl tabControl_Main;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panelLegend;
    }
}

