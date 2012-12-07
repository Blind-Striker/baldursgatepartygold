using System.Windows.Input;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.ViewModels
{
    public class SelectSaveFolderViewModel : BaseViewModel 
    {
        private string _saveFolderPath;
        private string _description;

        private ICommand _select;
        private ICommand _cancel;
        private ICommand _browse;
        private ICommand _search;

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    RaisePropertyChanged("Description");
                }
            }
        }

        public string SaveFolderPath
        {
            get { return _saveFolderPath; }
            set
            {
                if (_saveFolderPath != value)
                {
                    _saveFolderPath = value;
                    RaisePropertyChanged("SaveFolderPath");
                }
            }
        }

        public ICommand Select
        {
            get { return _select; }
            set
            {
                if (_select != value)
                {
                    _select = value;
                    RaisePropertyChanged("Select");
                }
            }
        }

        public ICommand Cancel
        {
            get { return _cancel; }
            set
            {
                if (_cancel != value)
                {
                    _cancel = value;
                    RaisePropertyChanged("Cancel");
                }
            }
        }

        public ICommand Browse
        {
            get { return _browse; }
            set
            {
                if (_browse != value)
                {
                    _browse = value;
                    RaisePropertyChanged("Browse");
                }
            }
        }

        public ICommand Search
        {
            get { return _search; }
            set
            {
                if (_search != value)
                {
                    _search = value;
                    RaisePropertyChanged("Search");
                }
            }
        }
    }
}
