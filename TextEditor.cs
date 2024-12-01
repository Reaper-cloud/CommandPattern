using System;
using System.Collections.Generic;

public class TextEditor
{
    private string _text = string.Empty;
    private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

    public string Text => _text;

    public void InsertText(string text)
    {
        _text += text;
    }

    public string DeleteText(int length)
    {
        if (length > _text.Length)
            length = _text.Length;

        string deletedText = _text.Substring(_text.Length - length);
        _text = _text.Substring(0, _text.Length - length);
        return deletedText;
    }

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void Undo()
    {
        if (_commandHistory.Count > 0)
        {
            ICommand command = _commandHistory.Pop();
            command.Undo();
        }
    }
}
