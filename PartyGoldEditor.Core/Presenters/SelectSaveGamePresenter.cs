using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Waf.Applications;
using System.Waf.Applications.Services;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Models;
using MvpVmSample.Presentation.PartyGoldEditor.Core.ViewModels;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Presenters
{
    internal class SelectSaveGamePresenter : BasePresenter<ISelectSaveGameView, ISelectSaveGamePresenter>, ISelectSaveGamePresenter
    {
        private readonly ApplicationSettingsBase _settingsBase;
        private readonly IPresenterFactory _presenterFactory;
        private readonly IMessageService _messageService;
        private readonly SelectSaveGameViewModel _selectSaveGameViewModel;

        public SaveListItem SelectedSaveListItem
        {
            get  
            {
                if (_selectSaveGameViewModel.SaveListItems == null || _selectSaveGameViewModel.SaveListItems.Count == 0)
                {
                    return null;
                }

                return _selectSaveGameViewModel.SaveListItems[_selectSaveGameViewModel.CurrentSaveListItemSelectedIndex];
            }
        }

        public SelectSaveGamePresenter(ISelectSaveGameView view, ApplicationSettingsBase settingsBase, IPresenterFactory presenterFactory, IMessageService messageService)
            : base(view)
        {
            _settingsBase = settingsBase;
            _presenterFactory = presenterFactory;
            _messageService = messageService;
            _selectSaveGameViewModel = new SelectSaveGameViewModel();

            _selectSaveGameViewModel.Select = new DelegateCommand(Select, CanSelect);
            _selectSaveGameViewModel.ChangeSaveFolder = new DelegateCommand(ChangeSaveFolder);
            _selectSaveGameViewModel.PropertyChanged += SelectSaveGameViewModelPropertyChanged;

            View.DataContext = _selectSaveGameViewModel;

            string savePath = _settingsBase["SavePath"].ToString();

            FillSaveList(savePath);
        }

        private void FillSaveList(string savePath)
        {
            if (string.IsNullOrEmpty(savePath))
            {
                _messageService.ShowWarning("Please select save path");
                return;
            }

            if (!Directory.Exists(savePath))
            {
                _messageService.ShowWarning("Invalid save path. Please select different path");
                return;
            }

            DirectoryInfo info = new DirectoryInfo(savePath);
            DirectoryInfo[] directoryInfos = info.GetDirectories();

            ObservableCollection<SaveListItem> list = new ObservableCollection<SaveListItem>();

            foreach (DirectoryInfo directoryInfo in directoryInfos)
            {
                SaveListItem item = new SaveListItem { DisplayText = directoryInfo.Name, FullPath = directoryInfo.FullName };

                list.Add(item);
            }

            _selectSaveGameViewModel.SaveListItems = list;

            DelegateCommand delegateCommand = _selectSaveGameViewModel.Select as DelegateCommand;
            if (delegateCommand != null)
            {
                delegateCommand.RaiseCanExecuteChanged();
            }
        }

        private void Select()
        {
            View.Close();
        }

        private void ChangeSaveFolder()
        {
            ISelectSaveFolderPresenter selectSaveFolderPresenter = _presenterFactory.CreatePresenter<ISelectSaveFolderPresenter>();

            selectSaveFolderPresenter.View.ShowDialog(View);

            string savePath = selectSaveFolderPresenter.SavePath;

            FillSaveList(savePath);
        }

        private bool CanSelect()
        {
            if (SelectedSaveListItem == null)
            {
                return false;
            }

            string path = SelectedSaveListItem.FullPath;

            string fullPath = Path.Combine(path, "BALDUR.GAM");

            bool exists = File.Exists(fullPath);

            return exists;
        }

        private void SelectSaveGameViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentSaveListItemSelectedIndex")
            {
                DelegateCommand delegateCommand = _selectSaveGameViewModel.Select as DelegateCommand;
                if (delegateCommand != null)
                {
                    delegateCommand.RaiseCanExecuteChanged();
                }
            }
        }
    }
}
