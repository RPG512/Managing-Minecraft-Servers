namespace Minecraft_Server_GUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            runButton = new Button();
            outputTextBox = new TextBox();
            inputTextBox = new TextBox();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openSVFToolStripMenuItem = new ToolStripMenuItem();
            openSVFAtStartupToolStripMenuItem = new ToolStripMenuItem();
            versionToolStripTextBox = new ToolStripTextBox();
            serverPropertiesGroupBox = new GroupBox();
            otherPropertiesPanel = new Panel();
            otherPropertiesButton = new Button();
            worldGroupBox = new GroupBox();
            worldComboBox = new ComboBox();
            resourcePackTextBox = new TextBox();
            label8 = new Label();
            enableCommandBlockCheckBox = new CheckBox();
            spawnProtectionNumericUpDown = new NumericUpDown();
            label7 = new Label();
            forceGamemodeCheckBox = new CheckBox();
            allowNetherCheckBox = new CheckBox();
            spawnNPCsCheckBox = new CheckBox();
            spawnMonstersCheckBox = new CheckBox();
            spawnAnimalsCheckBox = new CheckBox();
            allowFlightCheckBox = new CheckBox();
            pvpCheckBox = new CheckBox();
            onlineModeCheckBox = new CheckBox();
            whiteListCheckBox = new CheckBox();
            gamemodeComboBox = new ComboBox();
            label6 = new Label();
            difficultyComboBox = new ComboBox();
            label5 = new Label();
            maxPlayersNumericUpDown = new NumericUpDown();
            label4 = new Label();
            serverStarupParamGroupBox = new GroupBox();
            xmxMaskedTextBox = new MaskedTextBox();
            label3 = new Label();
            xmsMaskedTextBox = new MaskedTextBox();
            label2 = new Label();
            stopButton = new Button();
            menuStrip1.SuspendLayout();
            serverPropertiesGroupBox.SuspendLayout();
            worldGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spawnProtectionNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxPlayersNumericUpDown).BeginInit();
            serverStarupParamGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // runButton
            // 
            runButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            runButton.Location = new Point(12, 453);
            runButton.Name = "runButton";
            runButton.Size = new Size(80, 23);
            runButton.TabIndex = 0;
            runButton.Text = "Запустить";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // outputTextBox
            // 
            outputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            outputTextBox.Location = new Point(381, 30);
            outputTextBox.Multiline = true;
            outputTextBox.Name = "outputTextBox";
            outputTextBox.ReadOnly = true;
            outputTextBox.ScrollBars = ScrollBars.Both;
            outputTextBox.Size = new Size(492, 417);
            outputTextBox.TabIndex = 1;
            outputTextBox.WordWrap = false;
            outputTextBox.TextChanged += outputTextBox_TextChanged;
            // 
            // inputTextBox
            // 
            inputTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            inputTextBox.AutoCompleteCustomSource.AddRange(new string[] { "advancement (grant|revoke)", "attribute <target> <attribute> (get|base|modifier)", "execute (run|if|unless|as|at|store|positioned|rotated|facing|align|anchored|in|summon|on)", "bossbar (add|remove|list|set|get)", "clear [<targets>]", "clone (<begin>|from)", "damage <target> <amount> [<damageType>]", "data (merge|get|remove|modify)", "datapack (enable|disable|list)", "debug (start|stop|function)", "defaultgamemode <gamemode>", "difficulty [peaceful|easy|normal|hard]", "effect (clear|give)", "me <action>", "enchant <targets> <enchantment> [<level>]", "experience (add|set|query)", "xp -> experience", "fill <from> <to> <block> [replace|keep|outline|hollow|destroy]", "fillbiome <from> <to> <biome> [replace]", "forceload (add|remove|query)", "function <name>", "gamemode <gamemode> [<target>]", resources.GetString("inputTextBox.AutoCompleteCustomSource"), "give <targets> <item> [<count>]", "help [<command>]", "item (replace|modify)", "kick <targets> [<reason>]", "kill [<targets>]", "list [uuids]", "locate (structure|biome|poi)", "loot (replace|insert|give|spawn)", "msg <targets> <message>", "tell -> msg", "w -> msg", "particle <name> [<pos>]", "place (feature|jigsaw|structure|template)", "playsound <sound> (master|music|record|weather|block|hostile|neutral|player|ambient|voice)", "reload", "recipe (give|take)", "return <value>", "ride <target> (mount|dismount)", "say <message>", "schedule (function|clear)", "scoreboard (objectives|players)", "seed", "setblock <pos> <block> [destroy|keep|replace]", "spawnpoint [<targets>]", "setworldspawn [<pos>]", "spectate [<target>]", "spreadplayers <center> <spreadDistance> <maxRange> (<respectTeams>|under)", "stopsound <targets> [*|master|music|record|weather|block|hostile|neutral|player|ambient|voice]", "summon <entity> [<pos>]", "tag <targets> (add|remove|list)", "team (list|add|remove|empty|join|leave|modify)", "teammsg <message>", "tm -> teammsg", "teleport (<location>|<destination>|<targets>)", "tp -> teleport", "tellraw <targets> <message>", "time (set|add|query)", "title <targets> (clear|reset|title|subtitle|actionbar|times)", "trigger <objective> [add|set]", "weather (clear|rain|thunder)", "worldborder (add|set|center|damage|get|warning)", "jfr (start|stop)", "ban-ip <target> [<reason>]", "banlist [ips|players]", "ban <targets> [<reason>]", "deop <targets>", "op <targets>", "pardon <targets>", "pardon-ip <target>", "perf (start|stop)", "save-all [flush]", "save-off", "save-on", "setidletimeout <minutes>", "stop", "whitelist (on|off|list|add|remove|reload)" });
            inputTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            inputTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            inputTextBox.Location = new Point(509, 453);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(364, 23);
            inputTextBox.TabIndex = 2;
            inputTextBox.KeyDown += inputTextBox_KeyDown;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(381, 456);
            label1.Name = "label1";
            label1.Size = new Size(131, 15);
            label1.TabIndex = 3;
            label1.Text = "Поле ввода команд    /";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, versionToolStripTextBox });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(885, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.CheckOnClick = true;
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openSVFToolStripMenuItem, openSVFAtStartupToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 23);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // openSVFToolStripMenuItem
            // 
            openSVFToolStripMenuItem.Name = "openSVFToolStripMenuItem";
            openSVFToolStripMenuItem.Size = new Size(319, 22);
            openSVFToolStripMenuItem.Text = "Открыть окно выбора версий";
            openSVFToolStripMenuItem.Click += openSVFToolStripMenuItem_Click;
            // 
            // openSVFAtStartupToolStripMenuItem
            // 
            openSVFAtStartupToolStripMenuItem.Checked = true;
            openSVFAtStartupToolStripMenuItem.CheckOnClick = true;
            openSVFAtStartupToolStripMenuItem.CheckState = CheckState.Checked;
            openSVFAtStartupToolStripMenuItem.Name = "openSVFAtStartupToolStripMenuItem";
            openSVFAtStartupToolStripMenuItem.Size = new Size(319, 22);
            openSVFAtStartupToolStripMenuItem.Text = "Открывать окно выбора версий при запуске";
            openSVFAtStartupToolStripMenuItem.CheckedChanged += openSVFAtStartupToolStripMenuItem_CheckedChanged;
            // 
            // versionToolStripTextBox
            // 
            versionToolStripTextBox.Name = "versionToolStripTextBox";
            versionToolStripTextBox.ReadOnly = true;
            versionToolStripTextBox.Size = new Size(100, 23);
            // 
            // serverPropertiesGroupBox
            // 
            serverPropertiesGroupBox.AutoSize = true;
            serverPropertiesGroupBox.Controls.Add(otherPropertiesPanel);
            serverPropertiesGroupBox.Controls.Add(otherPropertiesButton);
            serverPropertiesGroupBox.Controls.Add(worldGroupBox);
            serverPropertiesGroupBox.Controls.Add(resourcePackTextBox);
            serverPropertiesGroupBox.Controls.Add(label8);
            serverPropertiesGroupBox.Controls.Add(enableCommandBlockCheckBox);
            serverPropertiesGroupBox.Controls.Add(spawnProtectionNumericUpDown);
            serverPropertiesGroupBox.Controls.Add(label7);
            serverPropertiesGroupBox.Controls.Add(forceGamemodeCheckBox);
            serverPropertiesGroupBox.Controls.Add(allowNetherCheckBox);
            serverPropertiesGroupBox.Controls.Add(spawnNPCsCheckBox);
            serverPropertiesGroupBox.Controls.Add(spawnMonstersCheckBox);
            serverPropertiesGroupBox.Controls.Add(spawnAnimalsCheckBox);
            serverPropertiesGroupBox.Controls.Add(allowFlightCheckBox);
            serverPropertiesGroupBox.Controls.Add(pvpCheckBox);
            serverPropertiesGroupBox.Controls.Add(onlineModeCheckBox);
            serverPropertiesGroupBox.Controls.Add(whiteListCheckBox);
            serverPropertiesGroupBox.Controls.Add(gamemodeComboBox);
            serverPropertiesGroupBox.Controls.Add(label6);
            serverPropertiesGroupBox.Controls.Add(difficultyComboBox);
            serverPropertiesGroupBox.Controls.Add(label5);
            serverPropertiesGroupBox.Controls.Add(maxPlayersNumericUpDown);
            serverPropertiesGroupBox.Controls.Add(label4);
            serverPropertiesGroupBox.Location = new Point(12, 30);
            serverPropertiesGroupBox.MinimumSize = new Size(363, 342);
            serverPropertiesGroupBox.Name = "serverPropertiesGroupBox";
            serverPropertiesGroupBox.Size = new Size(363, 364);
            serverPropertiesGroupBox.TabIndex = 4;
            serverPropertiesGroupBox.TabStop = false;
            serverPropertiesGroupBox.Text = "Настройки сервера";
            // 
            // otherPropertiesPanel
            // 
            otherPropertiesPanel.Anchor = AnchorStyles.Top;
            otherPropertiesPanel.AutoScroll = true;
            otherPropertiesPanel.BorderStyle = BorderStyle.FixedSingle;
            otherPropertiesPanel.Location = new Point(6, 326);
            otherPropertiesPanel.Name = "otherPropertiesPanel";
            otherPropertiesPanel.Size = new Size(351, 16);
            otherPropertiesPanel.TabIndex = 22;
            otherPropertiesPanel.Visible = false;
            // 
            // otherPropertiesButton
            // 
            otherPropertiesButton.Location = new Point(6, 297);
            otherPropertiesButton.Name = "otherPropertiesButton";
            otherPropertiesButton.Size = new Size(351, 23);
            otherPropertiesButton.TabIndex = 21;
            otherPropertiesButton.Text = "Остальные настройки";
            otherPropertiesButton.UseVisualStyleBackColor = true;
            otherPropertiesButton.Click += otherPropertiesButton_Click;
            // 
            // worldGroupBox
            // 
            worldGroupBox.Controls.Add(worldComboBox);
            worldGroupBox.Location = new Point(6, 240);
            worldGroupBox.Name = "worldGroupBox";
            worldGroupBox.Size = new Size(351, 51);
            worldGroupBox.TabIndex = 20;
            worldGroupBox.TabStop = false;
            worldGroupBox.Text = "Мир";
            // 
            // worldComboBox
            // 
            worldComboBox.FormattingEnabled = true;
            worldComboBox.Location = new Point(6, 22);
            worldComboBox.Name = "worldComboBox";
            worldComboBox.Size = new Size(339, 23);
            worldComboBox.TabIndex = 0;
            worldComboBox.Tag = "level-name";
            worldComboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            // 
            // resourcePackTextBox
            // 
            resourcePackTextBox.Location = new Point(105, 211);
            resourcePackTextBox.Name = "resourcePackTextBox";
            resourcePackTextBox.PlaceholderText = "https://example.com/resource-pack.zip";
            resourcePackTextBox.Size = new Size(252, 23);
            resourcePackTextBox.TabIndex = 19;
            resourcePackTextBox.Tag = "resource-pack";
            resourcePackTextBox.Leave += textBox_Leave;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 214);
            label8.Name = "label8";
            label8.Size = new Size(93, 15);
            label8.TabIndex = 18;
            label8.Text = "Пакет ресурсов";
            // 
            // enableCommandBlockCheckBox
            // 
            enableCommandBlockCheckBox.AutoSize = true;
            enableCommandBlockCheckBox.Location = new Point(193, 183);
            enableCommandBlockCheckBox.Name = "enableCommandBlockCheckBox";
            enableCommandBlockCheckBox.Size = new Size(127, 19);
            enableCommandBlockCheckBox.TabIndex = 17;
            enableCommandBlockCheckBox.Tag = "enable-command-block";
            enableCommandBlockCheckBox.Text = "Командные блоки";
            enableCommandBlockCheckBox.UseVisualStyleBackColor = true;
            // 
            // spawnProtectionNumericUpDown
            // 
            spawnProtectionNumericUpDown.Location = new Point(102, 182);
            spawnProtectionNumericUpDown.Maximum = new decimal(new int[] { 30000000, 0, 0, 0 });
            spawnProtectionNumericUpDown.Name = "spawnProtectionNumericUpDown";
            spawnProtectionNumericUpDown.Size = new Size(60, 23);
            spawnProtectionNumericUpDown.TabIndex = 16;
            spawnProtectionNumericUpDown.Tag = "spawn-protection";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 184);
            label7.Name = "label7";
            label7.Size = new Size(90, 15);
            label7.TabIndex = 15;
            label7.Text = "Защита спауна";
            // 
            // forceGamemodeCheckBox
            // 
            forceGamemodeCheckBox.AutoSize = true;
            forceGamemodeCheckBox.Location = new Point(193, 155);
            forceGamemodeCheckBox.Name = "forceGamemodeCheckBox";
            forceGamemodeCheckBox.Size = new Size(164, 19);
            forceGamemodeCheckBox.TabIndex = 14;
            forceGamemodeCheckBox.Tag = "force-gamemode";
            forceGamemodeCheckBox.Text = "Сбрасывать режим игры";
            forceGamemodeCheckBox.UseVisualStyleBackColor = true;
            // 
            // allowNetherCheckBox
            // 
            allowNetherCheckBox.AutoSize = true;
            allowNetherCheckBox.Location = new Point(6, 155);
            allowNetherCheckBox.Name = "allowNetherCheckBox";
            allowNetherCheckBox.Size = new Size(98, 19);
            allowNetherCheckBox.TabIndex = 13;
            allowNetherCheckBox.Tag = "allow-nether";
            allowNetherCheckBox.Text = "Нижний мир";
            allowNetherCheckBox.UseVisualStyleBackColor = true;
            // 
            // spawnNPCsCheckBox
            // 
            spawnNPCsCheckBox.AutoSize = true;
            spawnNPCsCheckBox.Location = new Point(193, 130);
            spawnNPCsCheckBox.Name = "spawnNPCsCheckBox";
            spawnNPCsCheckBox.Size = new Size(117, 19);
            spawnNPCsCheckBox.TabIndex = 12;
            spawnNPCsCheckBox.Tag = "spawn-npcs";
            spawnNPCsCheckBox.Text = "Жители деревни";
            spawnNPCsCheckBox.UseVisualStyleBackColor = true;
            // 
            // spawnMonstersCheckBox
            // 
            spawnMonstersCheckBox.AutoSize = true;
            spawnMonstersCheckBox.Location = new Point(6, 130);
            spawnMonstersCheckBox.Name = "spawnMonstersCheckBox";
            spawnMonstersCheckBox.Size = new Size(78, 19);
            spawnMonstersCheckBox.TabIndex = 11;
            spawnMonstersCheckBox.Tag = "spawn-monsters";
            spawnMonstersCheckBox.Text = "Монстры";
            spawnMonstersCheckBox.UseVisualStyleBackColor = true;
            // 
            // spawnAnimalsCheckBox
            // 
            spawnAnimalsCheckBox.AutoSize = true;
            spawnAnimalsCheckBox.Location = new Point(193, 105);
            spawnAnimalsCheckBox.Name = "spawnAnimalsCheckBox";
            spawnAnimalsCheckBox.Size = new Size(84, 19);
            spawnAnimalsCheckBox.TabIndex = 10;
            spawnAnimalsCheckBox.Tag = "spawn-animals";
            spawnAnimalsCheckBox.Text = "Животные";
            spawnAnimalsCheckBox.UseVisualStyleBackColor = true;
            // 
            // allowFlightCheckBox
            // 
            allowFlightCheckBox.AutoSize = true;
            allowFlightCheckBox.Location = new Point(6, 105);
            allowFlightCheckBox.Name = "allowFlightCheckBox";
            allowFlightCheckBox.Size = new Size(60, 19);
            allowFlightCheckBox.TabIndex = 9;
            allowFlightCheckBox.Tag = "allow-flight";
            allowFlightCheckBox.Text = "Полёт";
            allowFlightCheckBox.UseVisualStyleBackColor = true;
            // 
            // pvpCheckBox
            // 
            pvpCheckBox.AutoSize = true;
            pvpCheckBox.Location = new Point(193, 80);
            pvpCheckBox.Name = "pvpCheckBox";
            pvpCheckBox.Size = new Size(47, 19);
            pvpCheckBox.TabIndex = 8;
            pvpCheckBox.Tag = "pvp";
            pvpCheckBox.Text = "PVP";
            pvpCheckBox.UseVisualStyleBackColor = true;
            // 
            // onlineModeCheckBox
            // 
            onlineModeCheckBox.AutoSize = true;
            onlineModeCheckBox.Location = new Point(6, 80);
            onlineModeCheckBox.Name = "onlineModeCheckBox";
            onlineModeCheckBox.Size = new Size(161, 19);
            onlineModeCheckBox.TabIndex = 7;
            onlineModeCheckBox.Tag = "online-mode";
            onlineModeCheckBox.Text = "Пиратский(online mode)";
            onlineModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // whiteListCheckBox
            // 
            whiteListCheckBox.AutoSize = true;
            whiteListCheckBox.Location = new Point(193, 53);
            whiteListCheckBox.Name = "whiteListCheckBox";
            whiteListCheckBox.Size = new Size(104, 19);
            whiteListCheckBox.TabIndex = 6;
            whiteListCheckBox.Tag = "white-list";
            whiteListCheckBox.Text = "Белый список";
            whiteListCheckBox.UseVisualStyleBackColor = true;
            // 
            // gamemodeComboBox
            // 
            gamemodeComboBox.FormattingEnabled = true;
            gamemodeComboBox.Items.AddRange(new object[] { "Выживание", "Творческий", "Приключение", "Наблюдатель" });
            gamemodeComboBox.Location = new Point(254, 22);
            gamemodeComboBox.Name = "gamemodeComboBox";
            gamemodeComboBox.Size = new Size(103, 23);
            gamemodeComboBox.TabIndex = 3;
            gamemodeComboBox.Tag = "gamemode";
            gamemodeComboBox.Text = "Выживание";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 54);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 4;
            label6.Text = "Сложность";
            // 
            // difficultyComboBox
            // 
            difficultyComboBox.FormattingEnabled = true;
            difficultyComboBox.Items.AddRange(new object[] { "Мирный", "Лёгкий", "Нормальный", "Сложный" });
            difficultyComboBox.Location = new Point(81, 51);
            difficultyComboBox.Name = "difficultyComboBox";
            difficultyComboBox.Size = new Size(97, 23);
            difficultyComboBox.TabIndex = 5;
            difficultyComboBox.Tag = "difficulty";
            difficultyComboBox.Text = "Лёгкий";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(172, 24);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 2;
            label5.Text = "Режим игры";
            // 
            // maxPlayersNumericUpDown
            // 
            maxPlayersNumericUpDown.Location = new Point(106, 22);
            maxPlayersNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            maxPlayersNumericUpDown.Name = "maxPlayersNumericUpDown";
            maxPlayersNumericUpDown.Size = new Size(60, 23);
            maxPlayersNumericUpDown.TabIndex = 1;
            maxPlayersNumericUpDown.Tag = "max-players";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 24);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 0;
            label4.Text = "Кол-во игроков";
            // 
            // serverStarupParamGroupBox
            // 
            serverStarupParamGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            serverStarupParamGroupBox.Controls.Add(xmxMaskedTextBox);
            serverStarupParamGroupBox.Controls.Add(label3);
            serverStarupParamGroupBox.Controls.Add(xmsMaskedTextBox);
            serverStarupParamGroupBox.Controls.Add(label2);
            serverStarupParamGroupBox.Location = new Point(12, 378);
            serverStarupParamGroupBox.Name = "serverStarupParamGroupBox";
            serverStarupParamGroupBox.Size = new Size(363, 69);
            serverStarupParamGroupBox.TabIndex = 5;
            serverStarupParamGroupBox.TabStop = false;
            serverStarupParamGroupBox.Text = "Параметры запуска сервера";
            // 
            // xmxMaskedTextBox
            // 
            xmxMaskedTextBox.Location = new Point(198, 37);
            xmxMaskedTextBox.Mask = "000G";
            xmxMaskedTextBox.Name = "xmxMaskedTextBox";
            xmxMaskedTextBox.Size = new Size(100, 23);
            xmxMaskedTextBox.TabIndex = 3;
            xmxMaskedTextBox.Text = "4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(198, 19);
            label3.Name = "label3";
            label3.Size = new Size(159, 15);
            label3.TabIndex = 2;
            label3.Text = "Максимальный объём ОЗУ";
            // 
            // xmsMaskedTextBox
            // 
            xmsMaskedTextBox.Location = new Point(6, 37);
            xmsMaskedTextBox.Mask = "000G";
            xmsMaskedTextBox.Name = "xmsMaskedTextBox";
            xmsMaskedTextBox.Size = new Size(100, 23);
            xmsMaskedTextBox.TabIndex = 1;
            xmsMaskedTextBox.Text = "1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(155, 15);
            label2.TabIndex = 0;
            label2.Text = "Минимальный объём ОЗУ";
            // 
            // stopButton
            // 
            stopButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            stopButton.Location = new Point(98, 453);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(80, 23);
            stopButton.TabIndex = 6;
            stopButton.Text = "Остановить";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 488);
            Controls.Add(stopButton);
            Controls.Add(serverStarupParamGroupBox);
            Controls.Add(serverPropertiesGroupBox);
            Controls.Add(inputTextBox);
            Controls.Add(label1);
            Controls.Add(outputTextBox);
            Controls.Add(runButton);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(901, 527);
            Name = "MainForm";
            Text = "Minecraft Server GUI";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ResizeBegin += MainForm_ResizeBegin;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            serverPropertiesGroupBox.ResumeLayout(false);
            serverPropertiesGroupBox.PerformLayout();
            worldGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spawnProtectionNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxPlayersNumericUpDown).EndInit();
            serverStarupParamGroupBox.ResumeLayout(false);
            serverStarupParamGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button runButton;
        private TextBox outputTextBox;
        private TextBox inputTextBox;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openSVFToolStripMenuItem;
        private ToolStripMenuItem openSVFAtStartupToolStripMenuItem;
        private ToolStripTextBox versionToolStripTextBox;
        private GroupBox serverPropertiesGroupBox;
        private GroupBox serverStarupParamGroupBox;
        private Label label2;
        private MaskedTextBox xmsMaskedTextBox;
        private MaskedTextBox xmxMaskedTextBox;
        private Label label3;
        private NumericUpDown maxPlayersNumericUpDown;
        private Label label4;
        private ComboBox difficultyComboBox;
        private Label label5;
        private ComboBox gamemodeComboBox;
        private Label label6;
        private CheckBox spawnAnimalsCheckBox;
        private CheckBox allowFlightCheckBox;
        private CheckBox pvpCheckBox;
        private CheckBox onlineModeCheckBox;
        private CheckBox whiteListCheckBox;
        private NumericUpDown spawnProtectionNumericUpDown;
        private Label label7;
        private CheckBox forceGamemodeCheckBox;
        private CheckBox allowNetherCheckBox;
        private CheckBox spawnNPCsCheckBox;
        private CheckBox spawnMonstersCheckBox;
        private CheckBox enableCommandBlockCheckBox;
        private TextBox resourcePackTextBox;
        private Label label8;
        private GroupBox worldGroupBox;
        private ComboBox worldComboBox;
        private Button otherPropertiesButton;
        private Button stopButton;
        private Panel otherPropertiesPanel;
    }
}
