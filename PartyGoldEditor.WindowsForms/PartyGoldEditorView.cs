using System.Waf.Presentation.WinForms;
using System.Windows.Forms;
using MvpVmSample.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Presenters;
using MvpVmSample.Presentation.PartyGoldEditor.Core.ViewModels;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.WindowsForms
{
    public partial class PartyGoldEditorView : Form, IPartyGoldEditorView
    {
        public IPartyGoldEditorPresenter Presenter { get; set; }

        public object DataContext
        {
            get { return dataContext.DataSource; }
            set { dataContext.DataSource = value; }
        }

        private readonly CommandAdapter _commandAdapter;

        public PartyGoldEditorView()
        {
            InitializeComponent();
            _commandAdapter = new CommandAdapter();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            PartyGoldEditorViewModel partyGoldEditorView = DataContext as PartyGoldEditorViewModel;

            toolStrStatus.DataBindings.Add("Text", DataContext, "StatusText");
            toolStrSelectedSaveGameName.DataBindings.Add("Text", DataContext, "SelectSaveGameName");

            _commandAdapter.AddCommandBinding(tsmiSetSaveFolder, partyGoldEditorView.SelectSaveFolder);
            _commandAdapter.AddCommandBinding(tsmiSelectSaveGame, partyGoldEditorView.SelectSaveGame);
            _commandAdapter.AddCommandBinding(tsmiAbout, partyGoldEditorView.About);
            _commandAdapter.AddCommandBinding(btnSave, partyGoldEditorView.Save);
        }
    }
}
