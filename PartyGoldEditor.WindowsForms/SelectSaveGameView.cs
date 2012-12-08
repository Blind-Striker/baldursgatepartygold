using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.ViewModels;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.WindowsForms
{
    public partial class SelectSaveGameView : BaseForm, ISelectSaveGameView
    {
        public object DataContext { get { return dataContext.DataSource; } set { dataContext.DataSource = value; } }

        public ISelectSaveGamePresenter Presenter { get; set; }

        public SelectSaveGameView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            SelectSaveGameViewModel selectSaveGameViewModel = DataContext as SelectSaveGameViewModel;

            CommandAdapter.AddCommandBinding(btnSelect, selectSaveGameViewModel.Select);
            CommandAdapter.AddCommandBinding(btnChangeSaveFolder, selectSaveGameViewModel.ChangeSaveFolder);
        }
    }
}
