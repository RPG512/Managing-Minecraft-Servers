using System.Configuration;

namespace Minecraft_Server_GUI
{
    public partial class SelectVersionForm : Form
    {
        public string WorkFoldert
        { get; set; }
        public string VersionFoldert
        { get; set; }

        public SelectVersionForm()
        {
            InitializeComponent();
            checkBox1.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["DirOfVersions"]);
            folderTextBox.Text = ConfigurationManager.AppSettings["WorkFolder"];
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void SelectVersionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WorkFoldert = folderTextBox.Text;
        }

        private void folderTextBox_TextChanged(object sender, EventArgs e)
        {
            versionListBox.Items.Clear();
            if (checkBox1.Checked)
            {
                versionListBox.Items.AddRange(Directory.GetDirectories(folderTextBox.Text));
                try
                {
                    versionListBox.SelectedIndex = Convert.ToInt32(ConfigurationManager.AppSettings["VersionIndex"]);
                }
                catch
                {
                    versionListBox.SelectedIndex = 0;
                }
            }
            else
                VersionFoldert = folderTextBox.Text;
        }

        private void versionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.SaveValue("VersionIndex", versionListBox.SelectedIndex.ToString());
            VersionFoldert = versionListBox.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = checkBox1.Checked;
            Program.SaveValue("DirOfVersions", checkBox1.Checked.ToString());
            folderTextBox_TextChanged(folderTextBox, new EventArgs());
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
