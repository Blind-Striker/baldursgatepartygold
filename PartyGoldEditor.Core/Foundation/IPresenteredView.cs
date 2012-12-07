using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation
{
    public interface IPresenteredView<T> : IView
    {
        T Presenter { set; get; }
    }
}
