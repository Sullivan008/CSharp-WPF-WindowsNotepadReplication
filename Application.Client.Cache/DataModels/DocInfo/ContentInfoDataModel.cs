using Application.Client.Cache.Infrastructure.Models.Interfaces;

namespace Application.Client.Cache.DataModels.DocInfo
{
    public class ContentInfoDataModel : ICacheDataModel
    {
        public int Length { get; set; } = default;

        public int Lines { get; set; } = default(int) + 1;
    }
}
