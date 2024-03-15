namespace ZlizEQMap
{
    partial class PopoutMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopoutMap));
            this.picBox_PopoutMap = new System.Windows.Forms.PictureBox();
            this.trackBar_Opacity = new System.Windows.Forms.TrackBar();
            this.buttonConfigurePopupMap = new System.Windows.Forms.Button();
            this.radioButton_Centered = new System.Windows.Forms.RadioButton();
            this.trackBar_Zoom = new System.Windows.Forms.TrackBar();
            this.radioButton_ZoomSize = new System.Windows.Forms.RadioButton();
            this.buttonClosePopupMap = new System.Windows.Forms.Button();
            this.panel_DragMove = new System.Windows.Forms.Panel();
            this.checkBoxLockState = new System.Windows.Forms.CheckBox();
            this.panel_Resize = new System.Windows.Forms.Panel();
            this.label_Zoom = new System.Windows.Forms.Label();
            this.label_Opacity = new System.Windows.Forms.Label();
            this.check_AOT = new System.Windows.Forms.CheckBox();
            this.bindingSource_Settings = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_PopoutMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Opacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Zoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Settings)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox_PopoutMap
            // 
            this.picBox_PopoutMap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBox_PopoutMap.BackgroundImage")));
            this.picBox_PopoutMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBox_PopoutMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox_PopoutMap.Location = new System.Drawing.Point(0, 0);
            this.picBox_PopoutMap.Name = "picBox_PopoutMap";
            this.picBox_PopoutMap.Size = new System.Drawing.Size(450, 350);
            this.picBox_PopoutMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_PopoutMap.TabIndex = 1;
            this.picBox_PopoutMap.TabStop = false;
            this.picBox_PopoutMap.SizeChanged += new System.EventHandler(this.picBox_PopoutMap_SizeChanged);
            this.picBox_PopoutMap.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_PopoutMap_Paint);
            this.picBox_PopoutMap.DoubleClick += new System.EventHandler(this.picBox_PopoutMap_DoubleClick);
            // 
            // trackBar_Opacity
            // 
            this.trackBar_Opacity.AutoSize = false;
            this.trackBar_Opacity.LargeChange = 10;
            this.trackBar_Opacity.Location = new System.Drawing.Point(110, 6);
            this.trackBar_Opacity.Maximum = 100;
            this.trackBar_Opacity.Name = "trackBar_Opacity";
            this.trackBar_Opacity.Size = new System.Drawing.Size(200, 20);
            this.trackBar_Opacity.SmallChange = 5;
            this.trackBar_Opacity.TabIndex = 2;
            this.trackBar_Opacity.Tag = "ToggleVis";
            this.trackBar_Opacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Opacity.Value = 100;
            this.trackBar_Opacity.ValueChanged += new System.EventHandler(this.trackBar_Opacity_ValueChanged);
            // 
            // buttonConfigurePopupMap
            // 
            this.buttonConfigurePopupMap.BackColor = System.Drawing.Color.Transparent;
            this.buttonConfigurePopupMap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonConfigurePopupMap.BackgroundImage")));
            this.buttonConfigurePopupMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonConfigurePopupMap.FlatAppearance.BorderSize = 0;
            this.buttonConfigurePopupMap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.buttonConfigurePopupMap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.buttonConfigurePopupMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfigurePopupMap.Location = new System.Drawing.Point(3, 3);
            this.buttonConfigurePopupMap.Name = "buttonConfigurePopupMap";
            this.buttonConfigurePopupMap.Size = new System.Drawing.Size(18, 18);
            this.buttonConfigurePopupMap.TabIndex = 3;
            this.buttonConfigurePopupMap.UseVisualStyleBackColor = false;
            this.buttonConfigurePopupMap.Click += new System.EventHandler(this.buttonConfigurePopupMap_Click);
            // 
            // radioButton_Centered
            // 
            this.radioButton_Centered.AutoSize = true;
            this.radioButton_Centered.Location = new System.Drawing.Point(5, 261);
            this.radioButton_Centered.Name = "radioButton_Centered";
            this.radioButton_Centered.Size = new System.Drawing.Size(68, 17);
            this.radioButton_Centered.TabIndex = 4;
            this.radioButton_Centered.Tag = "";
            this.radioButton_Centered.Text = "Centered";
            this.radioButton_Centered.UseVisualStyleBackColor = true;
            this.radioButton_Centered.Visible = false;
            this.radioButton_Centered.CheckedChanged += new System.EventHandler(this.DisplayStyleRadioButtons_CheckedChanged);
            // 
            // trackBar_Zoom
            // 
            this.trackBar_Zoom.AutoSize = false;
            this.trackBar_Zoom.LargeChange = 25;
            this.trackBar_Zoom.Location = new System.Drawing.Point(16, 32);
            this.trackBar_Zoom.Maximum = 200;
            this.trackBar_Zoom.Minimum = 25;
            this.trackBar_Zoom.Name = "trackBar_Zoom";
            this.trackBar_Zoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Zoom.Size = new System.Drawing.Size(20, 200);
            this.trackBar_Zoom.SmallChange = 5;
            this.trackBar_Zoom.TabIndex = 5;
            this.trackBar_Zoom.Tag = "";
            this.trackBar_Zoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Zoom.Value = 100;
            this.trackBar_Zoom.Visible = false;
            this.trackBar_Zoom.ValueChanged += new System.EventHandler(this.trackBar_Zoom_ValueChanged);
            // 
            // radioButton_ZoomSize
            // 
            this.radioButton_ZoomSize.AutoSize = true;
            this.radioButton_ZoomSize.Checked = true;
            this.radioButton_ZoomSize.Location = new System.Drawing.Point(5, 284);
            this.radioButton_ZoomSize.Name = "radioButton_ZoomSize";
            this.radioButton_ZoomSize.Size = new System.Drawing.Size(71, 17);
            this.radioButton_ZoomSize.TabIndex = 6;
            this.radioButton_ZoomSize.TabStop = true;
            this.radioButton_ZoomSize.Tag = "";
            this.radioButton_ZoomSize.Text = "Fit to Size";
            this.radioButton_ZoomSize.UseVisualStyleBackColor = true;
            this.radioButton_ZoomSize.Visible = false;
            this.radioButton_ZoomSize.CheckedChanged += new System.EventHandler(this.DisplayStyleRadioButtons_CheckedChanged);
            // 
            // buttonClosePopupMap
            // 
            this.buttonClosePopupMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClosePopupMap.BackColor = System.Drawing.Color.Transparent;
            this.buttonClosePopupMap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClosePopupMap.BackgroundImage")));
            this.buttonClosePopupMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClosePopupMap.FlatAppearance.BorderSize = 0;
            this.buttonClosePopupMap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.buttonClosePopupMap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.buttonClosePopupMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClosePopupMap.Location = new System.Drawing.Point(430, 2);
            this.buttonClosePopupMap.Name = "buttonClosePopupMap";
            this.buttonClosePopupMap.Size = new System.Drawing.Size(18, 18);
            this.buttonClosePopupMap.TabIndex = 8;
            this.buttonClosePopupMap.UseVisualStyleBackColor = false;
            this.buttonClosePopupMap.Click += new System.EventHandler(this.buttonClosePopupMap_Click);
            // 
            // panel_DragMove
            // 
            this.panel_DragMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_DragMove.BackColor = System.Drawing.Color.Transparent;
            this.panel_DragMove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_DragMove.BackgroundImage")));
            this.panel_DragMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_DragMove.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panel_DragMove.Location = new System.Drawing.Point(407, 332);
            this.panel_DragMove.Name = "panel_DragMove";
            this.panel_DragMove.Size = new System.Drawing.Size(18, 18);
            this.panel_DragMove.TabIndex = 9;
            this.panel_DragMove.Tag = "";
            this.panel_DragMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandleClickAndDrag);
            // 
            // checkBoxLockState
            // 
            this.checkBoxLockState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxLockState.AutoSize = true;
            this.checkBoxLockState.Location = new System.Drawing.Point(351, 332);
            this.checkBoxLockState.Name = "checkBoxLockState";
            this.checkBoxLockState.Size = new System.Drawing.Size(50, 17);
            this.checkBoxLockState.TabIndex = 10;
            this.checkBoxLockState.Tag = "";
            this.checkBoxLockState.Text = "Lock";
            this.checkBoxLockState.ThreeState = true;
            this.checkBoxLockState.UseVisualStyleBackColor = true;
            this.checkBoxLockState.Visible = false;
            this.checkBoxLockState.CheckStateChanged += new System.EventHandler(this.checkBoxLockState_CheckedChanged);
            // 
            // panel_Resize
            // 
            this.panel_Resize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Resize.BackColor = System.Drawing.Color.Transparent;
            this.panel_Resize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_Resize.BackgroundImage")));
            this.panel_Resize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_Resize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.panel_Resize.Location = new System.Drawing.Point(431, 332);
            this.panel_Resize.Name = "panel_Resize";
            this.panel_Resize.Size = new System.Drawing.Size(18, 18);
            this.panel_Resize.TabIndex = 10;
            this.panel_Resize.Tag = "";
            this.panel_Resize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Resize_MouseDown);
            this.panel_Resize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Resize_MouseMove);
            this.panel_Resize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Resize_MouseUp);
            // 
            // label_Zoom
            // 
            this.label_Zoom.AutoSize = true;
            this.label_Zoom.Location = new System.Drawing.Point(2, 235);
            this.label_Zoom.Name = "label_Zoom";
            this.label_Zoom.Size = new System.Drawing.Size(34, 13);
            this.label_Zoom.TabIndex = 11;
            this.label_Zoom.Tag = "";
            this.label_Zoom.Text = "Zoom";
            this.label_Zoom.Visible = false;
            // 
            // label_Opacity
            // 
            this.label_Opacity.AutoSize = true;
            this.label_Opacity.Location = new System.Drawing.Point(61, 9);
            this.label_Opacity.Name = "label_Opacity";
            this.label_Opacity.Size = new System.Drawing.Size(43, 13);
            this.label_Opacity.TabIndex = 12;
            this.label_Opacity.Tag = "ToggleVis";
            this.label_Opacity.Text = "Opacity";
            // 
            // check_AOT
            // 
            this.check_AOT.AutoSize = true;
            this.check_AOT.Location = new System.Drawing.Point(331, 7);
            this.check_AOT.Name = "check_AOT";
            this.check_AOT.Size = new System.Drawing.Size(48, 17);
            this.check_AOT.TabIndex = 13;
            this.check_AOT.Tag = "ToggleVis";
            this.check_AOT.Text = "AOT";
            this.check_AOT.UseVisualStyleBackColor = true;
            this.check_AOT.CheckedChanged += new System.EventHandler(this.check_AOT_CheckedChanged);
            // 
            // PopoutMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(450, 350);
            this.Controls.Add(this.check_AOT);
            this.Controls.Add(this.label_Opacity);
            this.Controls.Add(this.label_Zoom);
            this.Controls.Add(this.radioButton_Centered);
            this.Controls.Add(this.radioButton_ZoomSize);
            this.Controls.Add(this.panel_Resize);
            this.Controls.Add(this.checkBoxLockState);
            this.Controls.Add(this.panel_DragMove);
            this.Controls.Add(this.buttonClosePopupMap);
            this.Controls.Add(this.trackBar_Zoom);
            this.Controls.Add(this.buttonConfigurePopupMap);
            this.Controls.Add(this.trackBar_Opacity);
            this.Controls.Add(this.picBox_PopoutMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopoutMap";
            this.Text = "Minimap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PopoutMap_FormClosing);
            this.Load += new System.EventHandler(this.PopoutMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_PopoutMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Opacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Zoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Settings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picBox_PopoutMap;
        private System.Windows.Forms.TrackBar trackBar_Opacity;
        private System.Windows.Forms.Button buttonConfigurePopupMap;
        private System.Windows.Forms.RadioButton radioButton_Centered;
        private System.Windows.Forms.TrackBar trackBar_Zoom;
        private System.Windows.Forms.RadioButton radioButton_ZoomSize;
        private System.Windows.Forms.Button buttonClosePopupMap;
        private System.Windows.Forms.Panel panel_DragMove;
        private System.Windows.Forms.CheckBox checkBoxLockState;
        private System.Windows.Forms.Panel panel_Resize;
        private System.Windows.Forms.Label label_Zoom;
        private System.Windows.Forms.Label label_Opacity;
        private System.Windows.Forms.CheckBox check_AOT;
        private System.Windows.Forms.BindingSource bindingSource_Settings;
    }
}