using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    private List<Command> _commands = new List<Command>();
    private int _currentCommandIndex;

    public void ExecuteCommand(Command command)
    {
        _commands.Add(command);
        command.Execute(); // execute command immediately
        _currentCommandIndex = _commands.Count - 1;
    }

    public void Undo()
    {
        if (_commands.Count == 0) return;
        _commands[_currentCommandIndex].Undo();
        _commands.RemoveAt(_currentCommandIndex);
        _currentCommandIndex--;
    }

    public void Redo()
    {
        if (_currentCommandIndex > _commands.Count - 1)
        {
            return;
        }

        _commands[_currentCommandIndex].Execute();
        _currentCommandIndex++;
    }
}
