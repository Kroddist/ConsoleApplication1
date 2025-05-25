using System;
using System.Collections.Generic;

namespace WinFormsApp1.Commands
{
    public class ProjectManager
    {
        private readonly List<ICommand> _commands = new List<ICommand>();
        private readonly List<ICommand> _history = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void ExecuteCommands()
        {
            foreach (var command in _commands)
            {
                command.Execute();
                _history.Add(command);
            }
            _commands.Clear();
        }

        public void UndoLastCommand()
        {
            if (_history.Count > 0)
            {
                var lastCommand = _history[_history.Count - 1];
                lastCommand.Undo();
                _history.RemoveAt(_history.Count - 1);
            }
        }
    }
} 