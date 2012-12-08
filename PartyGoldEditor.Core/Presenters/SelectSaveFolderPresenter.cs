using System;
using System.Configuration;
using System.Waf.Applications;
using System.Waf.Applications.Services;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.ViewModels;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Presenters
{
    internal class SelectSaveFolderPresenter : BasePresenter<ISelectSaveFolderView,ISelectSaveFolderPresenter>, ISelectSaveFolderPresenter
    {
        private readonly IDialogService _dialogService;
        private readonly IMessageService _messageService;
        private readonly ApplicationSettingsBase _settings;
        private readonly SelectSaveFolderViewModel _saveFolderViewModel;

        public string SavePath { get { return _saveFolderViewModel.SaveFolderPath; } }

        //TODO : Wrap ApplicationSettingsBase to another class
        public SelectSaveFolderPresenter(ISelectSaveFolderView view, IDialogService dialogService,IMessageService messageService, ApplicationSettingsBase settings) 
            : base(view)
        {
            _dialogService = dialogService;
            _messageService = messageService;
            _settings = settings;

            _saveFolderViewModel = new SelectSaveFolderViewModel();

            _saveFolderViewModel.SaveFolderPath = _settings["SavePath"].ToString();

            _saveFolderViewModel.Select = new DelegateCommand(Select, CanSelect);
            _saveFolderViewModel.Cancel = new DelegateCommand(Cancel);
            _saveFolderViewModel.Browse = new DelegateCommand(Browse);
            _saveFolderViewModel.Search = new DelegateCommand(Search);

            View.DataContext = _saveFolderViewModel;
        }

        private void Select()
        {
            _settings["SavePath"] = _saveFolderViewModel.SaveFolderPath;

            _settings.Save();

            View.Close();
        }

        private bool CanSelect()
        {
           return !string.IsNullOrEmpty(_saveFolderViewModel.SaveFolderPath);
        }

        private void Cancel()
        {
            View.Close();
        }

        private void Browse()
        {
            string selectedPath = _dialogService.ShowFolderDialog(View);

            if (!string.IsNullOrEmpty(selectedPath))
            {
                _saveFolderViewModel.SaveFolderPath = selectedPath;
            }
        }

        private void Search()
        {
            _messageService.ShowMessage("Soon...");
        }
    }
}
