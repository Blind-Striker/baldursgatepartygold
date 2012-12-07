using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.ViewModels;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.WindowsForms
{
    public partial class SelectSaveFolderView : BaseForm, ISelectSaveFolderView
    {
        public object DataContext
        {
            get { return dataContext.DataSource; }
            set { dataContext.DataSource = value; }
        }

        public ISelectSaveFolderPresenter Presenter { get; set; }

        public SelectSaveFolderView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SelectSaveFolderViewModel saveFolderViewModel = DataContext as SelectSaveFolderViewModel;

            CommandAdapter.AddCommandBinding(btnSelect, saveFolderViewModel.Select);
            CommandAdapter.AddCommandBinding(btnCancel, saveFolderViewModel.Cancel);
            CommandAdapter.AddCommandBinding(btnBrowse, saveFolderViewModel.Browse);
            CommandAdapter.AddCommandBinding(btnSearch, saveFolderViewModel.Search);
        }
    }
}
