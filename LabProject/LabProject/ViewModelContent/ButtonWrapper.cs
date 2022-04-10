using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace LabProject
{
    public class ButtonWrapper: INotifyPropertyChanged
    {
        private ICommand _command;

        public ICommand Command
        {
            get { return _command; }
            set
            {
                _command = value;
                NotifyPropertyChanged(nameof(Command));
            }
        }

        private string _content;

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                NotifyPropertyChanged(nameof(Content));
            }
        }


        public ButtonWrapper(ICommand command, string content)
        {
            Command = command;
            Content = content;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
