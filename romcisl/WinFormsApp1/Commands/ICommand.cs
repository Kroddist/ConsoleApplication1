using System;

namespace WinFormsApp1.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
} 