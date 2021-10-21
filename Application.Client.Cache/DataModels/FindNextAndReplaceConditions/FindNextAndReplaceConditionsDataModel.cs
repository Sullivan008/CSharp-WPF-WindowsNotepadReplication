using Application.Client.Cache.DataModels.FindNextAndReplaceConditions.Enums;
using Application.Client.Cache.Infrastructure.Models.Interfaces;

namespace Application.Client.Cache.DataModels.FindNextAndReplaceConditions
{
    public class FindNextAndReplaceConditionsDataModel : ICacheDataModel
    {
        public string FindWhat { get; set; } = string.Empty;

        public string ReplaceWith { get; set; } = string.Empty;

        public DirectionType DirectionType { get; set; } = DirectionType.Up;

        public bool IsMatchCase { get; set; }
    }
}
