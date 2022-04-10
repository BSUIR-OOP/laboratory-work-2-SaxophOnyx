using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace LabProject
{
    public class ColorPicker: INotifyPropertyChanged
    {
        private byte _a;

        public byte A
        {
            get { return _a; }
            set
            {
                _a = value;
                NotifyPropertyChanged(nameof(A));
            }
        }

        private byte _r;

        public byte R
        {
            get { return _r; }
            set
            {
                _r = value;
                NotifyPropertyChanged(nameof(R));
            }
        }

        private byte _g;

        public byte G
        {
            get { return _g; }
            set
            {
                _g = value;
                NotifyPropertyChanged(nameof(G));
            }
        }

        private byte _b;

        public byte B
        {
            get { return _b; }
            set
            {
                _b = value;
                NotifyPropertyChanged(nameof(B));
            }
        }


        public ColorPicker(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }


        public Color GetColor()
        {
            return Color.FromArgb(A, R, G, B);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
