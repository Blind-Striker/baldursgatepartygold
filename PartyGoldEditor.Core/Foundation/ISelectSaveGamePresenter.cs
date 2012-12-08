using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Models;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation
{
    public interface ISelectSaveGamePresenter : IPresenter<ISelectSaveGameView>
    {
        SaveListItem SelectedSaveListItem { get; }
    }
}
