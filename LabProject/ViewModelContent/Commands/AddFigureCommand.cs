using System;
using System.Windows.Input;

namespace LabProject
{
    public partial class ViewModel
    {
        private class AddFigureCommand : ICommand
        {
            private CreateDisplayableFigure _delegate;

            private Action<CreateDisplayableFigure> _action;


            public AddFigureCommand(Action<CreateDisplayableFigure> action, CreateDisplayableFigure method)
            {
                _action = action;
                _delegate = method;
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
                _action(_delegate);
            }
        }
    }
}
