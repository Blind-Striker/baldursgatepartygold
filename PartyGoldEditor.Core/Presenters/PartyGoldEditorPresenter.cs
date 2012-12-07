using System;
using System.Waf.Applications;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.ViewModels;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Presenters
{
    internal class PartyGoldEditorPresenter : BasePresenter<IPartyGoldEditorView, IPartyGoldEditorPresenter>, IPartyGoldEditorPresenter
    {
        private readonly IPresenterFactory _presenterFactory;
        private readonly PartyGoldEditorViewModel _goldEditorViewModel;

        public PartyGoldEditorPresenter(IPartyGoldEditorView view, IPresenterFactory presenterFactory) 
            : base(view)
        {
            _presenterFactory = presenterFactory;
            _goldEditorViewModel = new PartyGoldEditorViewModel();

            _goldEditorViewModel.SelectSaveFolder = new DelegateCommand(SelectSaveFolder);
            _goldEditorViewModel.SelectSaveGame = new DelegateCommand(SelectSaveGame);
            _goldEditorViewModel.About = new DelegateCommand(About);
            _goldEditorViewModel.Save = new DelegateCommand(Save, CanSave);

            _goldEditorViewModel.PartyGold = 1000;
            _goldEditorViewModel.StatusText = "Ready.";

            View.DataContext = _goldEditorViewModel;
        }

        private void SelectSaveFolder()
        {
            ISelectSaveFolderPresenter selectSaveFolderPresenter = _presenterFactory.CreatePresenter<ISelectSaveFolderPresenter>();

            selectSaveFolderPresenter.View.ShowDialog(View);
        }

        private void SelectSaveGame()
        {
            
        }

        private void About()
        {
           
        }

        private void Save()
        {
           
        }

        private bool CanSave()
        {
            return true;
        }
    }
}
