using MvpVmSample.Presentation.PartyGoldEditor.Core.Foundation;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core.Views
{
    public interface ISelectSaveFolderView : IPresenteredView<ISelectSaveFolderPresenter>
    {
        void ShowDialog(object owner);

        void Close();
    }
}
