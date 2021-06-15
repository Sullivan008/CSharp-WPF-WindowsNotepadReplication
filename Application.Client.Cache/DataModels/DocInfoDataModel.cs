using Application.Client.Cache.Core.Models.Interfaces;
using Application.Client.Cache.DataModels.Enums;

namespace Application.Client.Cache.DataModels
{
    public class DocInfoDataModel : ICacheDataModel
    {
        public string FilePath { get; set; }

        public DocumentState DocumentState { get; set; }
    }
}
