using MvpVmSample.Core.InfinityModel;

namespace MvpVmSample.Core.Foundation
{
    public interface IHeaderRepository
    {
        Header GetHeader(string savePath);
        string SaveHeader(string destinationPath, uint partyGold);
    }
}