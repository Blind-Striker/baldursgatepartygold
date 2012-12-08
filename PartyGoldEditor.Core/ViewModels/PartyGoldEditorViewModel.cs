using System.Windows.Input;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.ViewModels
{
    public class PartyGoldEditorViewModel : BaseViewModel
    {
        private int _partyGold;
        private int _newPartyGold;
        private string _statusText;
        private string _selectSaveGameName;

        private ICommand _selectSaveFolder;
        private ICommand _selectSaveGame;
        private ICommand _about;
        private ICommand _save;

        public int PartyGold
        {
            get { return _partyGold; }
            set
            {
                if (_partyGold != value)
                {
                    _partyGold = value;
                    RaisePropertyChanged("PartyGold");
                }
            }
        }

        public int NewPartyGold
        {
            get { return _newPartyGold; }
            set
            {
                if (_newPartyGold != value)
                {
                    _newPartyGold = value;
                    RaisePropertyChanged("NewPartyGold");
                }
            }
        }

        public string StatusText
        {
            get { return _statusText; }
            set
            {
                if (_statusText != value)
                {
                    _statusText = value;
                    RaisePropertyChanged("StatusText");
                }
            }
        }

        public string SelectSaveGameName
        {
            get { return _selectSaveGameName; }
            set
            {
                if (_selectSaveGameName != value)
                {
                    _selectSaveGameName = value;
                    RaisePropertyChanged("SelectSaveGameName");
                }
            }
        }

        public ICommand SelectSaveFolder
        {
            get { return _selectSaveFolder; }
            set
            {
                if (_selectSaveFolder != value)
                {
                    _selectSaveFolder = value;
                    RaisePropertyChanged("SelectSaveFolder");
                }
            }
        }

        public ICommand SelectSaveGame
        {
            get { return _selectSaveGame; }
            set
            {
                if (_selectSaveGame != value)
                {
                    _selectSaveGame = value;
                    RaisePropertyChanged("SelectSaveGame");
                }
            }
        }

        public ICommand About
        {
            get { return _about; }
            set
            {
                if (_about != value)
                {
                    _about = value;
                    RaisePropertyChanged("SelectSaveGame");
                }
            }
        }

        public ICommand Save
        {
            get { return _save; }
            set
            {
                if (_save != value)
                {
                    _save = value;
                    RaisePropertyChanged("Save");
                }
            }
        }
    }
}
