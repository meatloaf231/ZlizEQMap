namespace ZlizEQMap.Forms
{
    partial class MapCoordEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapCoordEditor));
            this.pictureBox_MapCoordEditor = new System.Windows.Forms.PictureBox();
            this.nud_ImageX = new System.Windows.Forms.NumericUpDown();
            this.nud_ImageY = new System.Windows.Forms.NumericUpDown();
            this.nud_TotalX = new System.Windows.Forms.NumericUpDown();
            this.nud_TotalY = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ResetImageSizeX = new System.Windows.Forms.Button();
            this.nud_GridMultiplier = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nud_GridDensity = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_ZeroX = new System.Windows.Forms.NumericUpDown();
            this.nud_ZeroY = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MapCoordEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ImageX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ImageY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TotalX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TotalY)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_GridMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_GridDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ZeroX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ZeroY)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_MapCoordEditor
            // 
            this.pictureBox_MapCoordEditor.Location = new System.Drawing.Point(251, 12);
            this.pictureBox_MapCoordEditor.Name = "pictureBox_MapCoordEditor";
            this.pictureBox_MapCoordEditor.Size = new System.Drawing.Size(552, 474);
            this.pictureBox_MapCoordEditor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_MapCoordEditor.TabIndex = 0;
            this.pictureBox_MapCoordEditor.TabStop = false;
            this.pictureBox_MapCoordEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_MapCoordEditor_Paint);
            // 
            // nud_ImageX
            // 
            this.nud_ImageX.Location = new System.Drawing.Point(147, 19);
            this.nud_ImageX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_ImageX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nud_ImageX.Name = "nud_ImageX";
            this.nud_ImageX.Size = new System.Drawing.Size(71, 20);
            this.nud_ImageX.TabIndex = 1;
            this.nud_ImageX.ValueChanged += new System.EventHandler(this.GridControlsChanged);
            // 
            // nud_ImageY
            // 
            this.nud_ImageY.Location = new System.Drawing.Point(147, 51);
            this.nud_ImageY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_ImageY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nud_ImageY.Name = "nud_ImageY";
            this.nud_ImageY.Size = new System.Drawing.Size(71, 20);
            this.nud_ImageY.TabIndex = 2;
            this.nud_ImageY.ValueChanged += new System.EventHandler(this.GridControlsChanged);
            // 
            // nud_TotalX
            // 
            this.nud_TotalX.Location = new System.Drawing.Point(147, 80);
            this.nud_TotalX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_TotalX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nud_TotalX.Name = "nud_TotalX";
            this.nud_TotalX.Size = new System.Drawing.Size(71, 20);
            this.nud_TotalX.TabIndex = 3;
            this.nud_TotalX.ValueChanged += new System.EventHandler(this.GridControlsChanged);
            // 
            // nud_TotalY
            // 
            this.nud_TotalY.Location = new System.Drawing.Point(147, 109);
            this.nud_TotalY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_TotalY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nud_TotalY.Name = "nud_TotalY";
            this.nud_TotalY.Size = new System.Drawing.Size(71, 20);
            this.nud_TotalY.TabIndex = 4;
            this.nud_TotalY.ValueChanged += new System.EventHandler(this.GridControlsChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ResetImageSizeX);
            this.groupBox1.Controls.Add(this.nud_GridMultiplier);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nud_GridDensity);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nud_ZeroX);
            this.groupBox1.Controls.Add(this.nud_ZeroY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nud_ImageX);
            this.groupBox1.Controls.Add(this.nud_TotalY);
            this.groupBox1.Controls.Add(this.nud_ImageY);
            this.groupBox1.Controls.Add(this.nud_TotalX);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 343);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grid Settings";
            // 
            // btn_ResetImageSizeX
            // 
            this.btn_ResetImageSizeX.Location = new System.Drawing.Point(172, 271);
            this.btn_ResetImageSizeX.Name = "btn_ResetImageSizeX";
            this.btn_ResetImageSizeX.Size = new System.Drawing.Size(46, 20);
            this.btn_ResetImageSizeX.TabIndex = 24;
            this.btn_ResetImageSizeX.Text = "Reset";
            this.btn_ResetImageSizeX.UseVisualStyleBackColor = true;
            this.btn_ResetImageSizeX.Click += new System.EventHandler(this.btn_ResetImageSizeX_Click);
            // 
            // nud_GridMultiplier
            // 
            this.nud_GridMultiplier.Location = new System.Drawing.Point(147, 230);
            this.nud_GridMultiplier.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_GridMultiplier.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_GridMultiplier.Name = "nud_GridMultiplier";
            this.nud_GridMultiplier.Size = new System.Drawing.Size(71, 20);
            this.nud_GridMultiplier.TabIndex = 16;
            this.nud_GridMultiplier.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_GridMultiplier.ValueChanged += new System.EventHandler(this.GridControlsChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Grid Boundary Multiplier";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Grid Density";
            // 
            // nud_GridDensity
            // 
            this.nud_GridDensity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_GridDensity.Location = new System.Drawing.Point(147, 202);
            this.nud_GridDensity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_GridDensity.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nud_GridDensity.Name = "nud_GridDensity";
            this.nud_GridDensity.Size = new System.Drawing.Size(71, 20);
            this.nud_GridDensity.TabIndex = 13;
            this.nud_GridDensity.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nud_GridDensity.ValueChanged += new System.EventHandler(this.GridControlsChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Zero Point Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Zero Point X";
            // 
            // nud_ZeroX
            // 
            this.nud_ZeroX.Location = new System.Drawing.Point(147, 167);
            this.nud_ZeroX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_ZeroX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nud_ZeroX.Name = "nud_ZeroX";
            this.nud_ZeroX.Size = new System.Drawing.Size(71, 20);
            this.nud_ZeroX.TabIndex = 10;
            this.nud_ZeroX.ValueChanged += new System.EventHandler(this.GridControlsChanged);
            // 
            // nud_ZeroY
            // 
            this.nud_ZeroY.Location = new System.Drawing.Point(147, 138);
            this.nud_ZeroY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_ZeroY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nud_ZeroY.Name = "nud_ZeroY";
            this.nud_ZeroY.Size = new System.Drawing.Size(71, 20);
            this.nud_ZeroY.TabIndex = 9;
            this.nud_ZeroY.ValueChanged += new System.EventHandler(this.GridControlsChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Total Map Coordinates Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total Map Coordinates X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Map image size Y (px)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Map image size X (px)";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(18, 358);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(227, 128);
            this.label9.TabIndex = 17;
            this.label9.Text = resources.GetString("label9.Text");
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // MapCoordEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 633);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox_MapCoordEditor);
            this.Name = "MapCoordEditor";
            this.Text = "Map Coordinate Tool";
            this.Load += new System.EventHandler(this.MapCoordFixer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MapCoordEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ImageX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ImageY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TotalX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TotalY)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_GridMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_GridDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ZeroX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ZeroY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_MapCoordEditor;
        private System.Windows.Forms.NumericUpDown nud_ImageX;
        private System.Windows.Forms.NumericUpDown nud_ImageY;
        private System.Windows.Forms.NumericUpDown nud_TotalX;
        private System.Windows.Forms.NumericUpDown nud_TotalY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nud_ZeroX;
        private System.Windows.Forms.NumericUpDown nud_ZeroY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nud_GridDensity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nud_GridMultiplier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_ResetImageSizeX;
    }
}