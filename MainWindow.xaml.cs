using Microsoft.VisualBasic;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly TextEditor _textEditor;

        public MainWindow()
        {
            InitializeComponent();
            _textEditor = new TextEditor();
        }

        private void InsertTextButton_Click(object sender, RoutedEventArgs e)
        {
            string textToInsert = InputTextBox.Text;
            if (!string.IsNullOrEmpty(textToInsert))
            {
                ICommand insertCommand = new InsertTextCommand(_textEditor, textToInsert);
                _textEditor.ExecuteCommand(insertCommand);
                UpdateOutput();
                InputTextBox.Clear();
            }
        }

        private void DeleteTextButton_Click(object sender, RoutedEventArgs e)
        {
            int lengthToDelete = int.TryParse(InputTextBox.Text, out int length) ? length : 0;
            if (lengthToDelete > 0)
            {
                ICommand deleteCommand = new DeleteTextCommand(_textEditor, lengthToDelete);
                _textEditor.ExecuteCommand(deleteCommand);
                UpdateOutput();
                InputTextBox.Clear();
            }
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            _textEditor.Undo();
            UpdateOutput();
        }

        private void UpdateOutput()
        {
            OutputTextBlock.Text = _textEditor.Text;
        }
    }
}
