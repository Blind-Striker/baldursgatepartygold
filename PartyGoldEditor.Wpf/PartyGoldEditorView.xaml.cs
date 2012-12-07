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
using MvpVmSample.Presentation.PartyGoldEditor.Core.Presenters;
using MvpVmSample.Presentation.PartyGoldEditor.Core.ViewModels;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.Wpf
{
    /// <summary>
    /// Interaction logic for Hede.xaml
    /// </summary>
    public partial class PartyGoldEditorView : Window, IPartyGoldEditorView
    {
        public IPartyGoldEditorPresenter Presenter { get; set; }

        public PartyGoldEditorView()
        {
            InitializeComponent();
        }

        private PartyGoldEditorViewModel ViewModel { get { return DataContext as PartyGoldEditorViewModel; } }
    }
}
