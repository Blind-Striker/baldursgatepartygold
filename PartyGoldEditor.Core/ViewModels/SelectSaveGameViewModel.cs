using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Models;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.ViewModels
{
    public class SelectSaveGameViewModel : BaseViewModel
    {
        private int _currentSaveListItemSelectedIndex;
        private ObservableCollection<SaveListItem> _saveListItems;

        private ICommand _select;
        private ICommand _changeSaveFolder;

        public int CurrentSaveListItemSelectedIndex
        {
            get { return _currentSaveListItemSelectedIndex; }
            set
            {
                _currentSaveListItemSelectedIndex = value;
                RaisePropertyChanged("CurrentSaveListItemSelectedIndex");
            }
        }

        public ObservableCollection<SaveListItem> SaveListItems
        {
            get { return _saveListItems; }
            set
            {
                _saveListItems = value;
                RaisePropertyChanged("SaveListItems");
            }
        }

        public ICommand Select
        {
            get { return _select; }
            set
            {
                _select = value;
                RaisePropertyChanged("Select");
            }
        }

        public ICommand ChangeSaveFolder
        {
            get { return _changeSaveFolder; }
            set
            {
                _changeSaveFolder = value;
                RaisePropertyChanged("ChangeSaveFolder");
            }
        }
    }
}
