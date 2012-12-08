using System;
using System.Configuration;
using System.Waf.Applications;
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
        private readonly PartyGoldEditorViewModel _goldEditorViewModel;

        private SaveListItem _saveListItem;

        public PartyGoldEditorPresenter(IPartyGoldEditorView view, IPresenterFactory presenterFactory, ApplicationSettingsBase settingsBase) 
            : base(view)
        {
            _presenterFactory = presenterFactory;
            _settingsBase = settingsBase;
            _goldEditorViewModel = new PartyGoldEditorViewModel();

            _goldEditorViewModel.SelectSaveFolder = new DelegateCommand(SelectSaveFolder);
            _goldEditorViewModel.SelectSaveGame = new DelegateCommand(SelectSaveGame);
            _goldEditorViewModel.About = new DelegateCommand(About);
            _goldEditorViewModel.Save = new DelegateCommand(Save, CanSave);

            SetViewMessages();
            _goldEditorViewModel.PartyGold = 1000;

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

            var delegateCommand = _goldEditorViewModel.Save as DelegateCommand;
            if (delegateCommand != null)
            {
                delegateCommand.RaiseCanExecuteChanged();
            }

            SetViewMessages();
        }

        private void About()
        {
           
        }

        private void Save()
        {
        }

        private bool CanSave()
        {
            return _saveListItem != null;
        }
    }
}
