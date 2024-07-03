using System.CodeDom.Compiler;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Minecraft_Server_GUI
{
    public partial class MainForm : Form
    {
        public string VersionFoldert
        { get; set; }

        System.Diagnostics.Process _process;
        System.Diagnostics.ProcessStartInfo _startInfo;

        string[] _lines;
        List<int> _readedLines = new List<int>();

        bool _addPairsControls = true;
        bool _eulaMsgBox = true;

        delegate void outputOnTBDelegate(string data);

        public MainForm()
        {
            InitializeComponent();

            openSVFAtStartupToolStripMenuItem.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["OpenSVFAtStartup"]);
        }

        private void _process_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            OutputOnTB(e.Data);
        }

        private void OutputOnTB(string data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new outputOnTBDelegate(OutputOnTB), [data]);
                return;
            }
            else
            {
                outputTextBox.Text += data + Environment.NewLine;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(VersionFoldert);
            string jarFile = "";
            foreach (var f in files)
            {
                if (f.EndsWith(".jar"))
                    jarFile = f;
            }

            if (jarFile != "")
            {
                _startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "CMD.exe",
                    WorkingDirectory = VersionFoldert,
                    Arguments = $"/C java -Xmx{xmxMaskedTextBox.Text.Replace(" ", "")} -Xms{xmsMaskedTextBox.Text.Replace(" ", "")} -jar {jarFile} nogui",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true
                };

                _process = new System.Diagnostics.Process();
                _process.StartInfo = _startInfo;

                _process.OutputDataReceived += _process_OutputDataReceived;

                _process.Start();
                _process.BeginOutputReadLine();
            }
            else
                MessageBox.Show("Процесс не был запущен. Файл с расширением (*.jar) не найден.", "Запускаемый файл не обнаружен.");
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            try
            {
                _process.StandardInput.WriteLine("stop");
            }
            catch
            {
                MessageBox.Show("Остановка сервера невозможна. Сервер не работает.", "Процесс не найден.");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            serverPropertiesGroupBox.Size = serverPropertiesGroupBox.MinimumSize;

            ReadProperties();

            foreach (var con in serverPropertiesGroupBox.Controls)
            {
                if (con is NumericUpDown)
                    (con as NumericUpDown).ValueChanged += numericUpDown_ValueChanged;
                if (con is ComboBox)
                    (con as ComboBox).SelectedIndexChanged += comboBox_SelectedIndexChanged;
                if (con is CheckBox)
                    (con as CheckBox).CheckedChanged += checkBox_CheckedChanged;
            }
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    _process.StandardInput.WriteLine(inputTextBox.Text);
                    outputTextBox.Text += inputTextBox.Text + Environment.NewLine;
                }
                catch
                {
                    MessageBox.Show("Ввод команд невозможен. Сервер не работает.", "Процесс не найден.");
                }
                inputTextBox.Clear();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _process.StandardInput.WriteLine("stop");
                _process.WaitForExit();
            }
            catch { }
        }

        private void openSVFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selVerForm = new SelectVersionForm();
            selVerForm.ShowDialog();

            VersionFoldert = selVerForm.VersionFoldert;

            ReadProperties();
        }

        private void openSVFAtStartupToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Program.SaveValue("OpenSVFAtStartup", (sender as ToolStripMenuItem).Checked.ToString());
        }

        private void otherPropertiesButton_Click(object sender, EventArgs e)
        {
            if (serverPropertiesGroupBox.Size == serverPropertiesGroupBox.MinimumSize)
            {
                if (_addPairsControls)
                {
                    int x = 6;
                    int y = 6;
                    for (int i = 0; i < _lines.Length; i++)
                    {
                        bool ok = true;
                        foreach (int j in _readedLines)
                        {
                            if (i == j || !_lines[i].Contains('=') || _lines[i].StartsWith("resource-pack=") || _lines[i].StartsWith("level-name="))
                                ok = false;
                        }
                        if (ok)
                        {
                            string key = _lines[i].Split('=')[0];
                            string value = _lines[i].Split("=")[1];
                            otherPropertiesPanel.Controls.Add(new Label { Text = key, Location = new Point(x, y), AutoSize = true });
                            otherPropertiesPanel.Controls.Add(new TextBox { Text = value, Tag = key, Location = new Point(x + 200, y) });
                            y += 29;
                        }
                    }
                    foreach (var con in otherPropertiesPanel.Controls)
                        if (con is TextBox)
                            (con as TextBox).Leave += textBox_Leave;
                }
                _addPairsControls = false;

                otherPropertiesPanel.Height = 300;
                otherPropertiesPanel.Visible = true;
                Height = MinimumSize.Height;
                Size = new Size(Width, Height + serverPropertiesGroupBox.Height - serverPropertiesGroupBox.MinimumSize.Height);
                otherPropertiesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            }
            else
            {
                otherPropertiesPanel.Anchor = AnchorStyles.Top;
                otherPropertiesPanel.Visible = false;
                serverPropertiesGroupBox.Size = serverPropertiesGroupBox.MinimumSize;
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ChangeProperties($"{(sender as NumericUpDown).Tag}={(sender as NumericUpDown).Value}");
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeProperties($"{(sender as ComboBox).Tag}={((sender as ComboBox).Tag != "level-name" ? (sender as ComboBox).SelectedIndex : (sender as ComboBox).Text)}");
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            ChangeProperties((sender as CheckBox).Tag == "online-mode" ? $"{(sender as CheckBox).Tag}={!(sender as CheckBox).Checked}" : $"{(sender as CheckBox).Tag}={(sender as CheckBox).Checked}");
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            ChangeProperties($"{(sender as TextBox).Tag}={(sender as TextBox).Text}");
        }

        private void outputTextBox_TextChanged(object sender, EventArgs e)
        {
            outputTextBox.SelectionStart = outputTextBox.Text.Length;
            outputTextBox.ScrollToCaret();

            if (outputTextBox.Text.Contains("You need to agree to the EULA in order to run the server. Go to eula.txt for more info.") && _eulaMsgBox)
            {
                _eulaMsgBox = false;
                if
                (
                    MessageBox.Show
                    (
                        "Прочтите пользовательское соглашение: https://account.mojang.com/documents/minecraft_eula (Справка).\n\nПринять пользовательское соглашение?",
                        "Вы не приняли пользовательское соглашение.",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1,
                        0,
                        "https://account.mojang.com/documents/minecraft_eula",
                        "Пользовательское соглашение"
                    ) == DialogResult.Yes
                )
                {
                    var lines = File.ReadAllLines(VersionFoldert + @"\eula.txt");
                    for (int i = 0; i < _lines.Length; i++)
                    {
                        lines[i].Replace("\r", "");
                        if (lines[i].StartsWith("eula="))
                        {
                            lines[i] = "eula=true";
                            System.IO.File.WriteAllLines(VersionFoldert + @"\eula.txt", lines);
                            break;
                        }
                    }
                }
                _eulaMsgBox = true;
            }
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            otherPropertiesPanel.Anchor = AnchorStyles.Top;
            otherPropertiesPanel.Visible = false;
        }

        private void ReadProperties()
        {
            versionToolStripTextBox.Text = VersionFoldert;
            versionToolStripTextBox.Size = new Size(VersionFoldert.Length * 6, 23);
            try
            {
                worldComboBox.Items.Clear();
                var folders = Directory.GetDirectories(VersionFoldert);
                foreach (var folder in folders)
                {
                    var files = Directory.GetFiles(folder);
                    foreach (var file in files)
                        if (file.EndsWith("level.dat"))
                        {
                            var fold = file.Split('\\');
                            worldComboBox.Items.Add(fold[fold.Length - 2]);
                            break;
                        }
                }

                _lines = File.ReadAllLines(VersionFoldert + @"\server.properties");

                for (int i = 0; i < _lines.Length; i++)
                {
                    foreach (var con in serverPropertiesGroupBox.Controls)
                    {
                        if (con is NumericUpDown)
                            if (_lines[i].StartsWith((string)(con as NumericUpDown).Tag + '='))
                            {
                                (con as NumericUpDown).Value = Convert.ToInt32(_lines[i].Split('=')[1]);
                                _readedLines.Add(i);
                                break;
                            }
                        if (con is ComboBox)
                            if (_lines[i].StartsWith((string)(con as ComboBox).Tag + '='))
                            {
                                int value;

                                switch (_lines[i].Split('=')[1].ToLower())
                                {
                                    case "survival":
                                    case "peaceful":
                                        value = 0;
                                        break;
                                    case "creative":
                                    case "easy":
                                        value = 1;
                                        break;
                                    case "adventure":
                                    case "normal":
                                        value = 2;
                                        break;
                                    case "spectator":
                                    case "hard":
                                        value = 3;
                                        break;
                                    default:
                                        value = Convert.ToInt32(_lines[i].Split('=')[1].ToLower());
                                        break;
                                }
                                (con as ComboBox).SelectedIndex = value;

                                _readedLines.Add(i);
                                break;
                            }
                        if (con is CheckBox)
                            if (_lines[i].StartsWith((string)(con as CheckBox).Tag + '='))
                            {
                                (con as CheckBox).Checked = (con as CheckBox).Tag != "online-mode" ? Convert.ToBoolean(_lines[i].Split('=')[1]) : !Convert.ToBoolean(_lines[i].Split('=')[1]);
                                _readedLines.Add(i);
                                break;
                            }
                    }
                    if (_lines[i].StartsWith((string)resourcePackTextBox.Tag + '='))
                        resourcePackTextBox.Text = _lines[i].Split('=')[1];
                    if (_lines[i].StartsWith((string)worldComboBox.Tag + '='))
                        worldComboBox.Text = _lines[i].Split('=')[1];
                }

                serverPropertiesGroupBox.Enabled = true;
                _addPairsControls = true;
                otherPropertiesPanel.Controls.Clear();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Не найден файл \"server.properties\". Возможно это первый запуск сервера и файл ещё не создан.", "Файл свойств не обнаружен");
                serverPropertiesGroupBox.Enabled = false;
            }
        }
        private void ChangeProperties(string line)
        {
            string key = line.Split('=')[0];
            for (int i = 0; i < _lines.Length; i++)
            {
                _lines[i].Replace("\r", "");
                if (_lines[i].StartsWith(key + '='))
                {
                    _lines[i] = line.StartsWith("level-name=") || line.StartsWith("motd=") || line.StartsWith("level-type=") ? line : line.ToLower();
                    System.IO.File.WriteAllLines(VersionFoldert + @"\server.properties", _lines);
                    return;
                }
            }
        }
    }
}
