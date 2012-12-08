using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.Wpf
{
    /// <summary>
    /// Interaction logic for SelectSaveGameView.xaml
    /// </summary>
    public partial class SelectSaveGameView : Window, ISelectSaveGameView
    {
        public ISelectSaveGamePresenter Presenter { get; set; }

        public SelectSaveGameView()
        {
            InitializeComponent();
        }

        public void ShowDialog(object owner)
        {
            base.ShowDialog();
        }
    }
}
