using Application.Client.Cache.Core.Models.Interfaces;

namespace Application.Client.Cache.Repository.Interfaces
{
    public interface ICacheRepository<TCacheDataModel> where TCacheDataModel : ICacheDataModel
    {
        TCacheDataModel GetItem();

        void SetItem(TCacheDataModel data);
    }
}
