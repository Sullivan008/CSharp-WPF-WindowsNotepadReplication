using Application.Client.Cache.DataModels.DocInfo.Enums;
using Application.Client.Cache.Infrastructure.Models.Interfaces;

namespace Application.Client.Cache.DataModels.DocInfo
{
    public class DocInfoDataModel : ICacheDataModel
    {
        public DocumentState DocumentState { get; set; } = DocumentState.Unmodified;

        public FileInfoDataModel FileInfo { get; set; } = new();

        public ContentInfoDataModel ContentInfo { get; set; } = new();
    }
}
