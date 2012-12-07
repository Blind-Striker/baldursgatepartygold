using System.Waf.Applications;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation
{
    public interface IPresenterFactory
    {
        T CreatePresenter<T>()
            where T : IPresenter;

        T CreatePresenter<T>(object argumentsAsAnonymousType)
            where T : IPresenter;
    }
}