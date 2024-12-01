namespace Minecraft_Server_GUI
{
    /// <summary>
    /// Диалоговое окно ввода данных типа <see langword="string"/>.
    /// </summary>
    partial class InputBox
    {
        private string? _value;
        /// <summary>
        /// Возвращает введённое значение.
        /// </summary>
        public string? Value
        {
            get => _value;
        }

        private DialogResult _dialogResult;
        /// <summary>
        /// Возвращает результат взаимодействия с диалоговым окном.
        /// </summary>
        public DialogResult DialogResult
        {
            get => _dialogResult;
        }

        static private bool IsInitialised { get; set; } = false;

        static private readonly Form form = new();
        static private readonly Label label = new();
        static private readonly TextBox textBox = new();
        static private readonly Button okButton = new();
        static private readonly Button cancelButton = new();

        /// <summary>
        /// InitializeComponent.
        /// </summary>
        public InputBox()
        {
            InitializeComponent();
        }

        private static void InitializeComponent()
        {
            if (!IsInitialised)
            {
                okButton.Text = "OK";
                cancelButton.Text = "Cancel";
                okButton.DialogResult = DialogResult.OK;
                cancelButton.DialogResult = DialogResult.Cancel;

                label.SetBounds(9, 20, 372, 13);
                textBox.SetBounds(12, 36, 372, 20);
                okButton.SetBounds(228, 72, 75, 23);
                cancelButton.SetBounds(309, 72, 75, 23);

                label.AutoSize = true;
                textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
                okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                form.ClientSize = new Size(396, 107);
                form.Controls.AddRange([label, textBox, okButton, cancelButton]);
                form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = okButton;
                form.CancelButton = cancelButton;

                IsInitialised = true;
            }
        }

        /// <summary>
        /// Отображает окно ввода с указанным текстом, подписью и значением по умолчанию.
        /// </summary>
        /// <param name="text">Комментарий к вводимой строке.</param>
        /// <param name="caption">Заголовок окна.</param>
        /// <param name="value">Значение по умолчанию.</param>
        /// <returns>Результат взаимодействия с диалоговым окном.</returns>
        public DialogResult ShowDialog(string? text, string? caption, string? value)
        {
            form!.Text = caption;
            label!.Text = text;
            textBox!.Text = value;

            _dialogResult = form.ShowDialog();
            _value = textBox.Text;
            return _dialogResult;
        }
        /// <summary>
        /// Отображает окно ввода с указанным текстом и подписью.
        /// </summary>
        /// <param name="text">Комментарий к вводимой строке.</param>
        /// <param name="caption">Заголовок окна.</param>
        /// <returns>Результат взаимодействия с диалоговым окном.</returns>
        public DialogResult ShowDialog(string? text, string? caption) => ShowDialog(text, caption, null);
        /// <summary>
        /// Отображает окно ввода с указанным текстом.
        /// </summary>
        /// <param name="text">Комментарий к вводимой строке.</param>
        /// <returns>Результат взаимодействия с диалоговым окном.</returns>
        public DialogResult ShowDialog(string? text) => ShowDialog(text, null, null);

        /// <summary>
        /// Отображает окно ввода с указанным текстом, подписью и значением по умолчанию.
        /// </summary>
        /// <param name="text">Комментарий к вводимой строке.</param>
        ///<param name="caption">Заголовок окна.</param>
        /// <param name="value">Значение по умолчанию.</param>
        /// <returns>Введённая строка.</returns>
        public static string Show(string? text, string? caption, string? value)
        {
            InitializeComponent();

            form.Text = caption;
            label.Text = text;
            textBox.Text = value;

            if(form.ShowDialog() == DialogResult.OK)
                return textBox.Text;
            return "";
        }
        /// <summary>
        /// Отображает окно ввода с указанным текстом и подписью.
        /// </summary>
        /// <param name="text">Комментарий к вводимой строке.</param>
        /// <param name="caption">Заголовок окна.</param>
        /// <returns>Введённая строка.</returns>
        public static string Show(string? text, string? caption) => Show(text, caption, null);
        /// <summary>
        /// Отображает окно ввода с указанным текстом.
        /// </summary>
        /// <param name="text">Комментарий к вводимой строке.</param>
        /// <returns>Введённая строка.</returns>
        public static string Show(string? text) => Show(text, null);
    }
}