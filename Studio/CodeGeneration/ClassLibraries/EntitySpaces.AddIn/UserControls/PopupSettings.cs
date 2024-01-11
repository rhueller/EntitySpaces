﻿using System;
using System.Windows.Forms;
using EntitySpaces.MetadataEngine;

namespace EntitySpaces.AddIn
{
    public partial class PopupSettings : Form
    {
        public PopupSettings()
        {
            InitializeComponent();
        }

        private void PopupSettings_Load(object sender, EventArgs e)
        {
            ucSettings1.PopulateUi();
        }

        public esSettings Settings 
        {
            get => ucSettings1.Settings;
            set => ucSettings1.Settings = value.Clone();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ucSettings1.PopulateSettings();
            DialogResult = DialogResult.OK;
        }
    }
}
