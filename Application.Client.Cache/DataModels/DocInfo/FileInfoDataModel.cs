using Application.Client.Cache.Infrastructure.Models.Interfaces;

namespace Application.Client.Cache.DataModels.DocInfo
{
    public class FileInfoDataModel : ICacheDataModel
    {
        public string FilePath { get; set; } = string.Empty;
    }
}
