using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;

namespace AccountSecure.App
{
    public partial class FrmConfig : Form
    {
        /// <summary>
        /// Section initializes the GUI components
        /// </summary>
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string Read(string strKey)
        {
            string value = "";
            if (!File.Exists(Application.StartupPath + "\\AccountSecure.App.exe"))
            {
                return null;
            }
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Application.StartupPath + "\\AccountSecure.App.exe");
            AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");
            if (appSettingsSection != null)
            {
                foreach (string key in appSettingsSection.Settings.AllKeys)
                {
                    if (key == strKey)
                    {
                        value = appSettingsSection.Settings[key].Value;
                        break;
                    }
                }
            }

            return value.Trim();
        }

        private void Modify(string strKey, string strValue)
        {
            if (!File.Exists(Application.StartupPath + "\\AccountSecure.App.exe"))
            {
                return;
            }
            Configuration objConfig = ConfigurationManager.OpenExeConfiguration(Application.StartupPath + "\\AccountSecure.App.exe");

            ConfigurationManager.AppSettings.Set(strKey, strValue);
            ConfigurationManager.RefreshSection("appSettings");

            //Configuration config = ConfigurationManager.OpenExeConfiguration(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\app.config");
            //AppSettingsSection appSettingsSection = (AppSettingsSection)config.GetSection("appSettings");
            //config.AppSettings.Settings[strKey].Value = strValue;
            
            AppSettingsSection objAppsettings = (AppSettingsSection)objConfig.GetSection("appSettings");
            if (objAppsettings != null)
            {
                objAppsettings.Settings[strKey].Value = strValue;
                objConfig.Save();
            }
        }

        private void ReadAllKeys()
        {
            try
            {
                cmboxMode.SelectedItem = Read("TransferMode");
                cboPreview.SelectedItem = Read("PrintPreviewEnabled");
                cmbFill.SelectedItem = Read("fill");
                cmbOption.SelectedItem = Read("Option");
                txtServerIP.Text = Read("ServerIP");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ReadAllKeys();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex("^([-]|[0-9])[0-9]*$");
            if (MessageBox.Show("Are you sure you want to perform this action?", "Modify Configuration", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Modify("Option", cmbOption.SelectedItem.ToString());
                Modify("TransferMode", cmboxMode.SelectedItem.ToString());
                Modify("PrintPreviewEnabled", cboPreview.SelectedItem.ToString());
                Modify("fill", cmbFill.SelectedItem.ToString());
                Modify("ServerIP", txtServerIP.Text);
               
                MessageBox.Show("Your settings have been updated!");
            }
        }
    }
}
