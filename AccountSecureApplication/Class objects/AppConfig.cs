using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Xml.XPath;
using System.Data.OleDb;

namespace CodeBuilder
{
    public class Config
    {
        static XmlDocument xmlDoc = new XmlDocument();
        /// <summary>
        /// Saves db configuration into app.config
        /// </summary>
        /// <param name="conStr"></param>
        /// <returns></returns>

        public static bool Save(string conStr)
        {

            try
            {
                OleDbConnection cn = new OleDbConnection(conStr);
                cn.Open();
                UpdateKey("dbconfig", conStr);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        /// <summary>
        /// Gets application configuration
        /// </summary>
        /// <returns>returns string</returns>
        public static string Read()
        {
            try
            {
                loadFromConfig();
                return ConfigurationManager.AppSettings["dbconfig"].ToString();
            }
            catch
            {
                return null;
            }
        }
        // Adds a key and value to the App.config
        private static  void AddKey(string strKey, string strValue)
        {
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\app.config");
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings"); 
            try
            {

                if (KeyExists(strKey))
                    throw new ArgumentException("Key name: <" + strKey + "> already exists in the configuration.");
                XmlNode newChild = appSettingsNode.FirstChild.Clone();
                newChild.Attributes["key"].Value = strKey;
                newChild.Attributes["value"].Value = strValue;
                appSettingsNode.AppendChild(newChild);
                //We have to save the configuration in two places, 
                //because while we have a root App.config,
                //we also have an ApplicationName.exe.config.
                xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\app.config");
                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void UpdateKey(string strKey, string newValue)
        {
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\app.config");
            if (!KeyExists(strKey))
                throw new ArgumentNullException("Key", "<" + strKey + "> does not exist in the configuration. Update failed.");

            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");

            // Attempt to locate the requested setting.

            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes["key"].Value == strKey)
                    childNode.Attributes["value"].Value = newValue;
            }
            xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\app.config");
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }
        private void DeleteKey(string strKey)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (!KeyExists(strKey))
                throw new ArgumentNullException("Key", "<" + strKey + "> does not exist in the configuration. Update failed.");
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");
            // Attempt to locate the requested setting.
            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes["key"].Value == strKey)
                    appSettingsNode.RemoveChild(childNode);
            }
            xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\App.config");
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }
        private static bool KeyExists(string strKey)
        {
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\app.config");
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");
            // Attempt to locate the requested setting.
            foreach (XmlNode childNode in appSettingsNode)
            {
                if (childNode.Attributes["key"].Value == strKey)
                    return true;
            }
            return false;
        }
        //This code will add a listviewitem 
        //to a listview for each database entry 
        //in the appSettings section of an App.config file.
        private static void loadFromConfig()
        {
            //this.lstDatabases.Items.Clear();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\app.config");
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");
            foreach (XmlNode node in appSettingsNode.ChildNodes)
            {
                //ListViewItem lvi = new ListViewItem();
                string connStr = node.Attributes["value"].Value.ToString();
                string keyName = node.Attributes["key"].Value.ToString();
                //lvi.Text = keyName;
                //lvi.SubItems.Add(connStr);
                //this.lvDatabases.Items.Add(lvi);

                #region .configuration
                //ConfigurationManager.AppSettings.Set("dbconfig", conStr);
                //Configuration config = ConfigurationManager.OpenExeConfiguration(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\app.config");
                //AppSettingsSection appSettingsSection = (AppSettingsSection)config.GetSection("appSettings");
                //config.AppSettings.Settings["dbconfig"].Value = conStr;
                //config.Save(ConfigurationSaveMode.Modified, true);
                //ConfigurationManager.RefreshSection("appSettings");
                #endregion



            }
        }



    }
}
