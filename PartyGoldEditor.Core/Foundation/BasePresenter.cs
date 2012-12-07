using System.Waf.Applications;
using MvpVmSample.Presentation.PartyGoldEditor.Core.Views;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation
{
    internal abstract class BasePresenter<TView, TPresenter> : IPresenter<TView>
        where TView : IPresenteredView<TPresenter> where TPresenter : class, IPresenter
    {
        private readonly TView _view;

        protected BasePresenter(TView view)
        {
            _view = view;
            _view.Presenter = this as TPresenter;
        }

        public TView View { get { return _view; } }
    }
}
