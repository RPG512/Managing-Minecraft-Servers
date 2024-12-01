using System.Configuration;
using System.Windows.Forms;

namespace Minecraft_Server_GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var selVerForm = new SelectVersionForm();

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["OpenSVFAtStartup"]))
            {
                Application.Run(selVerForm); 
            }

            if (selVerForm.WorkFoldert != "")
            {
                if(selVerForm.WorkFoldert != null)
                    SaveValue("WorkFolder", selVerForm.WorkFoldert);

                var mainForm = new MainForm();
                mainForm.VersionFolder = selVerForm.VersionFolder;

                Application.Run(mainForm);
            }
        }

        public static void SaveValue(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.AppSettings[key] = value;
        }
    }
}