using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Views
{
    public interface ISelectSaveGameView : IPresenteredView<ISelectSaveGamePresenter>
    {
        void ShowDialog(object owner);

        void Close();
    }
}
