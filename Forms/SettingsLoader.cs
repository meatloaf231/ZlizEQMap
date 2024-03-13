using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZlizEQMap.Forms
{
    public partial class SettingsLoader : Form
    {
        public List<SettingLoadResult> results = new List<SettingLoadResult>();

        public SettingsLoader()
        {
            InitializeComponent();
        }

        public void BindResults(List<SettingLoadResult> resultsToBind)
        {
            BindingSource source = new BindingSource();
            results = resultsToBind;
            source.DataSource = results;

            dgv_SettingLoadResults.DataSource = source;
            dgv_SettingLoadResults.AutoGenerateColumns = true;
            dgv_SettingLoadResults.AutoSize = false;
        }
    }
}
