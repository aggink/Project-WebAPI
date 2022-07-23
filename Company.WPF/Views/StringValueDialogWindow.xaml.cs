using System.Windows;
using System.Windows.Controls;

namespace Company.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для StringValueDialogWindow.xaml
    /// </summary>
    public partial class StringValueDialogWindow
    {
        public string Header { get => HeaderTextBlock.Text; set => HeaderTextBlock.Text = value; }
        public string Message { get => MessageTextBox.Text; set => MessageTextBox.Text = value; }

        public StringValueDialogWindow()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object Sender, RoutedEventArgs E)
        {
            if (!(E.Source is Button button)) return;
            DialogResult = !button.IsCancel;
            Close();
        }
    }
}
