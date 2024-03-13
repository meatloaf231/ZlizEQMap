namespace ZlizEQMap.Forms
{
    partial class SettingsLoader
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
            this.button_Backup = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.dgv_SettingLoadResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SettingLoadResults)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Backup
            // 
            this.button_Backup.Location = new System.Drawing.Point(269, 399);
            this.button_Backup.Name = "button_Backup";
            this.button_Backup.Size = new System.Drawing.Size(110, 23);
            this.button_Backup.TabIndex = 0;
            this.button_Backup.Text = "Create Backup";
            this.button_Backup.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(458, 399);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(110, 23);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // dgv_SettingLoadResults
            // 
            this.dgv_SettingLoadResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SettingLoadResults.Location = new System.Drawing.Point(12, 61);
            this.dgv_SettingLoadResults.Name = "dgv_SettingLoadResults";
            this.dgv_SettingLoadResults.Size = new System.Drawing.Size(776, 332);
            this.dgv_SettingLoadResults.TabIndex = 2;
            // 
            // SettingsLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_SettingLoadResults);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Backup);
            this.Name = "SettingsLoader";
            this.Text = "SettingsParser";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SettingLoadResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Backup;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.DataGridView dgv_SettingLoadResults;
    }
}