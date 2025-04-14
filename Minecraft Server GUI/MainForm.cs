using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using Timer = System.Windows.Forms.Timer;

namespace Minecraft_Server_GUI
{
    public partial class MainForm : Form
    {
        public string? VersionFolder
        { get; set; }

        string? _execFilePath;
        //Перевести в коллекцию
        readonly List<Process> _processes;
        readonly ProcessStartInfo _startInfo;
        int _tabIndex = 0;

        readonly Timer _timer;

        string[]? _lines;
		readonly List<int> _readedLines;

        bool _addPairsControls = true;
        bool _eulaMsgBox = true;

		private IProgressTracker _tracker = new VanillaProgressTracker();
		private CoreType _detectedCore = CoreType.Unknown;
        private string? _coreVersion;

		delegate void OutputOnTBDelegate(string data);

        public MainForm()
        {
            InitializeComponent();

            _processes = [];
			_startInfo = new()
			{
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardInput = true,
                StandardOutputEncoding = Encoding.Default,
                StandardInputEncoding = Encoding.Default
			};
			_timer = new()
			{
				Interval = 5000,
				Enabled = false
			};
			_timer.Tick += Timer_Tick;
			_readedLines = [];

			openSVFAtStartupToolStripMenuItem.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["OpenSVFAtStartup"]);
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null) 
                OutputOnTB(e.Data);
        }

        private void OutputOnTB(string data)
        {
	        if (InvokeRequired)
            {
                BeginInvoke(new OutputOnTBDelegate(OutputOnTB), [data]);
                return;
            }
	        outputTextBox.Text += data + Environment.NewLine;

            if(startProgressBar.Value < 100 )
                UpdateProgress(data);
		}

		private void UpdateProgress(string logLine)
		{
			if (_detectedCore == CoreType.Unknown)
				DetectCore(logLine);
			var match = Regex.Match(logLine, @"Starting minecraft server version ((\d+).(\d+)((.(\d+))|))");
			if (match.Success)
            {
                _coreVersion = match.Groups[1].Value;
                coreToolStripTextBox.Text += " - " + _coreVersion;
                
            }

			// Обновляем прогресс
			int progress = _tracker.UpdateProgress(logLine);
			startProgressBar.Value = progress;
            if (progress == 100)
                Task.Run(() => {
                    Thread.Sleep(800);
				    startProgressBar.Visible = false;
                    //startProgressBar.Value = 0;
                    //_processes[_tabIndex].StandardInput.WriteLine("help");
				});
		}

		private void DetectCore(string logLine)
		{
			if (logLine.Contains("FML") || logLine.Contains("ForgeModLoader") || logLine.Contains("Forge Version Check") || logLine.Contains("forgeserver") || logLine.Contains("--fml.forgeVersion"))
			{
				_tracker = new ForgeProgressTracker();
				_detectedCore = CoreType.Forge;
			}
			else if (logLine.Contains("Fabric"))
			{
				//_tracker = new FabricProgressTracker(); // Реализуй этот трекер
				_detectedCore = CoreType.Fabric;
			}
			else if (logLine.Contains("Spigot") || logLine.Contains("CraftBukkit"))
			{
				//_tracker = new SpigotProgressTracker(); // Реализуй этот трекер
				_detectedCore = CoreType.Spigot;
			}
			else if (logLine.Contains("Quilt"))
			{
				//_tracker = new QuiltProgressTracker(); // Реализуй этот трекер
				_detectedCore = CoreType.Quilt;
			}
			else if (logLine.Contains("Starting minecraft server"))
			{
				_tracker = new VanillaProgressTracker();
				_detectedCore = CoreType.Vanilla;
			}
			else
			{
				//_tracker = new FallbackProgressTracker(); // Реализуй этот трекер для fallback
				_detectedCore = CoreType.Unknown;
			}
            coreToolStripTextBox.Text = _detectedCore.ToString();
		}

        /// <summary>
        /// Определение типа исполняемого файла и запуск.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runButton_Click(object sender, EventArgs e)
        {// можно записывать подсказки ввода команд перенаправляя после ввода help REMOVE 0, 34
            try
            {
                _processes[_tabIndex].StandardInput.Write("");
                MessageBox.Show("Не удалось запустить сервер.\nСервер уже запущен!", "Ошибка запуска.", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
            }
            catch{}

            if (!FindExecFile())
                return;

            _detectedCore = CoreType.Unknown;
            _tracker.ResetProgress();
			startProgressBar.Value = 0;
            _processes.Add(new()
            {
                StartInfo = _startInfo
            });
            _processes[_tabIndex].OutputDataReceived += Process_OutputDataReceived;

            _processes[_tabIndex].Start();
            _processes[_tabIndex].BeginOutputReadLine();

            _timer.Start();
            startProgressBar.Visible = true;
        }

        private bool FindExecFile()
        {
	        const string errT = "Процесс не был запущен. Файл с расширением (*.jar) не найден.\nВы можете выбрать путь к файлу в меню вручную.";
	        const string errC = "Исполняемый файл не обнаружен.";
	        if (string.IsNullOrEmpty(_execFilePath))
	        {
		        var files = Directory.GetFiles(VersionFolder!);
		        string runFile = "";
		        foreach (var f in files)
		        {
			        if (f.EndsWith(".jar"))
			        {
				        runFile = f;
				        serverStarupParamGroupBox.Enabled = true;
			        }
			        else if(f.EndsWith(".bat"))
			        {
				        runFile = f;
				        serverStarupParamGroupBox.Enabled = false;
				        break;
			        }
		        }

		        if (!string.IsNullOrEmpty(runFile))
			        if (runFile.EndsWith(".jar"))
				        ChangeStartInfo("java.exe", VersionFolder!, runFile);
			        else
				        ChangeStartInfo(runFile, VersionFolder!);

		        else
		        {
			        MessageBox.Show(errT, errC);
			        return false;
		        }
	        }
	        else
	        {
		        string folder = Path.GetDirectoryName(_execFilePath)!;

		        if (_execFilePath.EndsWith(".jar"))
		        {
			        serverStarupParamGroupBox.Enabled = true;

			        ChangeStartInfo("java.exe", folder, _execFilePath);
		        }
		        else if (_execFilePath.EndsWith(".bat"))
		        {
			        ChangeStartInfo(_execFilePath, folder);
		        }
		        else
		        {
			        MessageBox.Show(errT, errC);
			        return false;
		        }
	        }

	        return true;
        }

        private void Timer_Tick(object? sender, EventArgs e)
		{
            try
            {
                using (Process p = Process.GetProcessesByName("java").FirstOrDefault(p => p.Id == _processes[_tabIndex].Id || (p.StartTime >= _processes[_tabIndex].StartTime && p.StartTime <= _processes[_tabIndex].StartTime.AddSeconds(15))) ?? Process.GetProcessesByName("java").First())
                    memToolStripTextBox.Text = $"ОЗУ: {p.WorkingSet64 / 1048576f:#.0}Мб";
            }
            catch
            {
	            try
	            {
		            _processes[_tabIndex].StandardInput.WriteLine();
	            }
	            catch
	            {
		            _timer.Stop();
                    memToolStripTextBox.Clear();
                    _processes.Remove(_processes[_tabIndex]);
                    startProgressBar.Visible = false;
	            }
            }
		}

		private void ChangeStartInfo(string fileName, string workingDirectory, string? arguments = null)
        {
            _startInfo.FileName = fileName;
            _startInfo.WorkingDirectory = workingDirectory;
            _startInfo.Arguments = arguments != null ? $"-Xmx{xmxMaskedTextBox.Text.Replace(" ", "")} -Xms{xmsMaskedTextBox.Text.Replace(" ", "")} -jar {arguments} nogui" : null;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            try
            {
                _processes[_tabIndex].StandardInput.WriteLine("stop");
                Task.Run(() =>
                {
                    _processes[_tabIndex].WaitForExit();
                    _processes.Remove(_processes[_tabIndex]);
                    if (_processes.Count == 0)
                    {
                        _timer.Stop();
                        memToolStripTextBox.Clear();
                    }
                });
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
                switch (con)
                {
	                case NumericUpDown numericUpDown:
		                numericUpDown.ValueChanged += NumericUpDown_ValueChanged!;
		                break;
	                case ComboBox comboBox:
		                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged!;
		                break;
	                case CheckBox checkBox:
		                checkBox.CheckedChanged += CheckBox_CheckedChanged!;
		                break;
                }
            }
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && (inputTextBox.AutoCompleteCustomSource.IndexOf(inputTextBox.Text) < 0 || !inputTextBox.Text.Contains(' ')))
            {
                try
                {
                    _processes[_tabIndex].StandardInput.WriteLine(inputTextBox.Text);
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
                _processes[_tabIndex].StandardInput.Write("");
                if (MessageBox.Show("Вы уверены, что хотите закрыть программу?\nЭто приведёт к закрытию всех серверов, запущенных текущей программой.", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            catch { }
			try
            {
	            _processes.ForEach(p =>
	            {
		            p.StandardInput.WriteLine("stop");
		            p.WaitForExit();
	            });
            }
            catch { }
        }

        private void openSVFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selVerForm = new SelectVersionForm();
            selVerForm.ShowDialog();

            if (!string.IsNullOrEmpty(selVerForm.VersionFolder))
            {
                VersionFolder = selVerForm.VersionFolder;

                ReadProperties();
            }
        }

        private void openSVFAtStartupToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Program.SaveValue("OpenSVFAtStartup", openSVFAtStartupToolStripMenuItem.Checked.ToString());
        }

        private void execFileSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { InitialDirectory = VersionFolder! };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
	            bool reselect = false;
                try
                {
                    var efps = File.ReadAllLines(@".\EFPs.dat");
                    for (int i = 0; i < efps!.Length; i++)
                    {
                        if (!efps[i].StartsWith(VersionFolder + '='))
                            continue;
                        efps[i] = VersionFolder + '=' + ofd.FileName;
                        File.WriteAllLines(@".\EFPs.dat", efps);
                        reselect = true;
                    }
                }
                catch{}

                if(!reselect)
                    File.AppendAllText(@".\EFPs.dat", VersionFolder + '=' + ofd.FileName + '\n');

				_execFilePath = ofd.FileName;

                serverStarupParamGroupBox.Enabled = _execFilePath.EndsWith(".jar");
            }
        }

        private void startRCONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RCON_on_Telegram.Program.Main(["-ingui"]);
        }

        private void settingsRCONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsRCON = new SettingsRCON();
            if(settingsRCON.ShowDialog() == DialogResult.OK)
            {
                //РАБОТАЕМ СДЕСЬ
            }
        }

        /// <summary>
        /// <para>Открывает и закрывает панель неучтённых настроек сервера.</para>
        /// Если открывается впервые, создаёт пары controls "ключ - значение" со значениями строк файла параметров, не использованных для предопределённых пар в основных настройках.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OtherPropertiesButton_Click(object sender, EventArgs e)
        {
            if (serverPropertiesGroupBox.Size == serverPropertiesGroupBox.MinimumSize)
            {
                if (_addPairsControls)
                {
                    int x = 6;
                    int y = 6;
                    for (int i = 0; i < _lines!.Length; i++)
                    {
                        bool ok = true;
                        foreach (var j in _readedLines.Where(j => i == j || !_lines[i].Contains('=') || _lines[i].StartsWith("resource-pack=") || _lines[i].StartsWith("level-name=")))
	                        ok = false;

                        if (!ok)
	                        continue;

                        string key = _lines[i].Split('=')[0];
                        string value = _lines[i].Split("=")[1];
                        otherPropertiesPanel.Controls.Add(new Label { Text = key, Location = new Point(x, y), AutoSize = true });
                        otherPropertiesPanel.Controls.Add(new TextBox { Text = value, Tag = key, Location = new Point(x + 200, y) });
                        y += 29;
                    }
                    foreach (var con in otherPropertiesPanel.Controls)
                        if (con is TextBox textBox)
                            textBox.Leave += TextBox_Leave!;
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

        /// <summary>
        /// Общий метод автоматического сохранения настроек сервера для <see cref="NumericUpDown"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ChangeProperties($"{(sender as NumericUpDown)!.Tag}={(sender as NumericUpDown)!.Value}");
        }

        /// <summary>
        /// Общий метод автоматического сохранения настроек сервера для <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox)!.Text == "Создать новый мир")
            {
                InputBox inputBox = new();
                if (inputBox.ShowDialog("Введите название нового мира", "Новый мир", "Новый мир") == DialogResult.OK)
                {
                    worldComboBox.Items.Insert(0, inputBox.Value);
                    worldComboBox.SelectedIndex = 0;
                }
            }
            ChangeProperties($"{(sender as ComboBox)!.Tag}={(!(sender as ComboBox)!.Tag!.Equals("level-name") ? (sender as ComboBox)!.SelectedIndex : (sender as ComboBox)!.Text)}");
        }

        /// <summary>
        /// Общий метод автоматического сохранения настроек сервера для <see cref="CheckBox"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChangeProperties((sender as CheckBox)!.Tag!.Equals("online-mode") ? $"{(sender as CheckBox)!.Tag}={!(sender as CheckBox)!.Checked}" : $"{(sender as CheckBox)!.Tag}={(sender as CheckBox)!.Checked}");
        }

        /// <summary>
        /// Общий метод автоматического сохранения настроек сервера для <see cref="TextBox"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            ChangeProperties($"{(sender as TextBox)!.Tag}={(sender as TextBox)!.Text}");
        }

        /// <summary>
        /// <para>Автоматическая прокрутка многострочного <see cref="TextBox"/>.</para>
        /// Если встречается предупреждение eula, предлагает его принять, изменив соответствующий текстовый файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    var lines = File.ReadAllLines(VersionFolder + @"\eula.txt");
                    for (int i = 0; i < _lines!.Length; i++)
                    {
                        lines[i].Replace("\r", "");
                        if (lines[i].StartsWith("eula="))
                        {
                            lines[i] = "eula=true";
                            System.IO.File.WriteAllLines(VersionFolder + @"\eula.txt", lines);
                            break;
                        }
                    }
                }
                outputTextBox.Clear();
                _eulaMsgBox = true;
            }
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            otherPropertiesPanel.Anchor = AnchorStyles.Top;
            otherPropertiesPanel.Visible = false;
        }

        /// <summary>
        /// <para>Считывает настройки сервера из файла server.properties и заносит данные в необходимом формате в предопределённые Controls.</para>
        /// <para>Указывает путь к каталогу версии в меню.</para>
        /// Очищает поле вывода.
        /// </summary>
        private void ReadProperties()
        {
            versionToolStripTextBox.Text = VersionFolder;
            versionToolStripTextBox.Size = new Size(VersionFolder!.Length * 6, 23);

            outputTextBox.Clear();

            _execFilePath = null;
            try
            {
	            var efps = File.ReadAllLines(@".\EFPs.dat");
	            for (int i = 0; i < efps!.Length; i++)
	            {
		            if (!efps[i].StartsWith(VersionFolder + '='))
			            continue;

		            _execFilePath = efps[i].Split('=')[^1];
                    break;
	            }
            }
            catch{}

            FindExecFile();

			try
            {
                worldComboBox.Items.Clear();
                var folders = Directory.GetDirectories(VersionFolder);
                foreach (var folder in folders)
                {
                    var files = Directory.GetFiles(folder);
                    foreach (var file in files)
                        if (file.EndsWith("level.dat"))
                        {
                            var fold = file.Split('\\');
                            worldComboBox.Items.Add(fold[^2]);
                            break;
                        }
                }
                worldComboBox.Items.Add("Создать новый мир");

                _lines = File.ReadAllLines(VersionFolder + @"\server.properties", Encoding.Default);

                for (int i = 0; i < _lines.Length; i++)
                {
                    foreach (var con in serverPropertiesGroupBox.Controls)
                    {
                        if (con is NumericUpDown down)
                            if (_lines[i].StartsWith((string)down.Tag! + '='))
                            {
                                down.Value = Convert.ToInt32(_lines[i].Split('=')[1]);
                                _readedLines.Add(i);
                                break;
                            }
                        if (con is ComboBox comboBox)
                            if (_lines[i].StartsWith((string)comboBox.Tag! + '='))
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
                                comboBox.SelectedIndex = value;

                                _readedLines.Add(i);
                                break;
                            }
                        if (con is CheckBox checkBox)
                            if (_lines[i].StartsWith((string)checkBox.Tag! + '='))
                            {
                                checkBox.Checked = !checkBox.Tag!.Equals("online-mode") ? Convert.ToBoolean(_lines[i].Split('=')[1]) : !Convert.ToBoolean(_lines[i].Split('=')[1]);
                                _readedLines.Add(i);
                                break;
                            }
                    }
                    if (_lines[i].StartsWith((string)resourcePackTextBox.Tag! + '='))
                        resourcePackTextBox.Text = _lines[i].Split('=')[1];
                    if (_lines[i].StartsWith((string)worldComboBox.Tag! + '='))
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
        /// <summary>
        /// Находит строку в server.properties, начинающуюся на "Свойство=", и изменяет на <paramref name="line"></paramref>
        /// </summary>
        /// <param name="line">Пара значений "Свойство=Значение"</param>
        private void ChangeProperties(string line)
        {
            string key = line.Split('=')[0];
            for (int i = 0; i < _lines!.Length; i++)
            {
                if (!_lines[i].StartsWith(key + '='))
                    continue;
                _lines[i] = line.StartsWith("level-name=") || line.StartsWith("motd=") || line.StartsWith("level-type=") ? line : line.ToLower();
                File.WriteAllLines(VersionFolder + @"\server.properties", _lines, Encoding.Default);
                return;
            }
        }
    }
}
