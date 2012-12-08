using System.Waf.Foundation;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Models
{
    public class SaveListItem : Model
    {
        private string _fullPath;
        private string _displayText;

        public string FullPath
        {
            get { return _fullPath; }
            set
            {
                _fullPath = value;
                RaisePropertyChanged("FullPath");
            }
        }

        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                _displayText = value;
                RaisePropertyChanged("DisplayText");
            }
        }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
