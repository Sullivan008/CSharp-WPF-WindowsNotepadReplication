using Application.Client.Cache.DataModels.Enums;
using Application.Client.Cache.Infrastructure.Models.Interfaces;

namespace Application.Client.Cache.DataModels
{
    public class DocInfoDataModel : ICacheDataModel
    {
        public string FilePath { get; set; }

        public DocumentState DocumentState { get; set; }
    }
}
