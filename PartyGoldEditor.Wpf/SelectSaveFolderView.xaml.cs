using System.Windows;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.Wpf
{
    /// <summary>
    /// Interaction logic for SelectSaveFolderView.xaml
    /// </summary>
    public partial class SelectSaveFolderView : Window, ISelectSaveFolderView
    {
        public ISelectSaveFolderPresenter Presenter { get; set; }

        public SelectSaveFolderView()
        {
            InitializeComponent();
        }

        public void ShowDialog(object owner)
        {
            base.ShowDialog();
        }
    }
}
