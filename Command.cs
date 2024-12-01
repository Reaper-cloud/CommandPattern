using CommandPattern;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class InsertTextCommand : ICommand
{
    private readonly TextEditor _textEditor;
    private readonly string _text;

    public InsertTextCommand(TextEditor textEditor, string text)
    {
        _textEditor = textEditor;
        _text = text;
    }

    public void Execute()
    {
        _textEditor.InsertText(_text);
    }

    public void Undo()
    {
        _textEditor.DeleteText(_text.Length);
    }
}

public class DeleteTextCommand : ICommand
{
    private readonly TextEditor _textEditor;
    private readonly int _length;
    private string _deletedText;

    public DeleteTextCommand(TextEditor textEditor, int length)
    {
        _textEditor = textEditor;
        _length = length;
    }

    public void Execute()
    {
        _deletedText = _textEditor.DeleteText(_length);
    }

    public void Undo()
    {
        _textEditor.InsertText(_deletedText);
    }
}
