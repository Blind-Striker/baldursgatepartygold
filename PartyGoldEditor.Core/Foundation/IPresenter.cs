using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation
{
    //Marker interface
    public interface IPresenter
    {
         
    }

    public interface IPresenter<TView> : IPresenter
        where TView : IView
    {
        TView View { get; }
    }
}
