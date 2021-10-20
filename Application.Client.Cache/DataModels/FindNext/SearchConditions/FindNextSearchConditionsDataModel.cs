using Application.Client.Cache.DataModels.FindNext.SearchConditions.Enums;
using Application.Client.Cache.Infrastructure.Models.Interfaces;

namespace Application.Client.Cache.DataModels.FindNext.SearchConditions
{
    public class FindNextSearchConditionsDataModel : ICacheDataModel
    {
        public string FindWhat { get; set; } = string.Empty;

        public DirectionType DirectionType { get; set; } = DirectionType.Up;

        public bool IsMatchCase { get; set; }
    }
}
