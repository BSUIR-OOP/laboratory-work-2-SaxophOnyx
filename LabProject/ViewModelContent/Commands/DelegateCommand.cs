using System;
using System.Windows.Input;

namespace LabProject
{
    public class DelegateCommand : ICommand
    {
        public Action Action { get; set; }

        public DelegateCommand(Action action)
        {
            Action = action;
        }


        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                
            }

            remove
            {
                
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        void ICommand.Execute(object parameter)
        {
            Action();
        }
    }
}
