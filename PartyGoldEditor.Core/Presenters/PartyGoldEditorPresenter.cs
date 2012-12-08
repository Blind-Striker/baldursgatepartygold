using System;
using System.Configuration;
using System.IO;
using System.Waf.Applications;
using System.Waf.Applications.Services;
using MvpVmSample.Core.Foundation;
using MvpVmSample.Core.InfinityModel;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Models;
using MvpVmSample.Presentation.PartyGoldEditor.Core.ViewModels;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Presenters
{
    internal class PartyGoldEditorPresenter : BasePresenter<IPartyGoldEditorView, IPartyGoldEditorPresenter>, IPartyGoldEditorPresenter
    {
        private readonly IPresenterFactory _presenterFactory;
        private readonly ApplicationSettingsBase _settingsBase;
        private readonly IHeaderRepository _headerRepository;
        private readonly IMessageService _messageService;
        private readonly PartyGoldEditorViewModel _goldEditorViewModel;

        private SaveListItem _saveListItem;

        public PartyGoldEditorPresenter(IPartyGoldEditorView view, IPresenterFactory presenterFactory, ApplicationSettingsBase settingsBase, IHeaderRepository headerRepository, IMessageService messageService) 
            : base(view)
        {
            _presenterFactory = presenterFactory;
            _settingsBase = settingsBase;
            _headerRepository = headerRepository;
            _messageService = messageService;
            _goldEditorViewModel = new PartyGoldEditorViewModel();

            _goldEditorViewModel.SelectSaveFolder = new DelegateCommand(SelectSaveFolder);
            _goldEditorViewModel.SelectSaveGame = new DelegateCommand(SelectSaveGame);
            _goldEditorViewModel.About = new DelegateCommand(About);
            _goldEditorViewModel.Save = new DelegateCommand(Save, CanSave);

            SetViewMessages();

            View.DataContext = _goldEditorViewModel;

            CheckSaveFolderSelected();
        }

        private void SetViewMessages()
        {
            _goldEditorViewModel.StatusText = _saveListItem == null ? "Please select save game." : "Ready.";
            _goldEditorViewModel.SelectSaveGameName = _saveListItem == null ? string.Empty : _saveListItem.DisplayText;
        }

        private void CheckSaveFolderSelected()
        {
            if (string.IsNullOrEmpty(_settingsBase["SavePath"].ToString()))
            {
                SelectSaveFolder();
            }
        }

        private void SetPartyGold()
        {
            Header header = _headerRepository.GetHeader(_saveListItem.FullPath);

            _goldEditorViewModel.PartyGold = header.PartyGold;

            SetViewMessages();
        }

        private void SelectSaveFolder()
        {
            ISelectSaveFolderPresenter selectSaveFolderPresenter = _presenterFactory.CreatePresenter<ISelectSaveFolderPresenter>();

            selectSaveFolderPresenter.View.ShowDialog(View);
        }

        private void SelectSaveGame()
        {
            ISelectSaveGamePresenter selectSaveGamePresenter = _presenterFactory.CreatePresenter<ISelectSaveGamePresenter>();

            selectSaveGamePresenter.View.ShowDialog(View);

            _saveListItem = selectSaveGamePresenter.SelectedSaveListItem;

            var saveCommand = _goldEditorViewModel.Save as DelegateCommand;
            if (saveCommand != null)
            {
                saveCommand.RaiseCanExecuteChanged();
            }

            SetPartyGold();
        }

        private void About()
        {
           
        }

        private void Save()
        {
            uint newPartyGold = _goldEditorViewModel.NewPartyGold;

            string fullPath = _saveListItem.FullPath;

            string destinationPath = _headerRepository.SaveHeader(fullPath, newPartyGold);

            _messageService.ShowMessage(String.Format("Party gold changed successfully. Your new save game is {0}", destinationPath));

            _goldEditorViewModel.PartyGold = newPartyGold;
        }

        private bool CanSave()
        {
            return _saveListItem != null;
        }
    }
}
