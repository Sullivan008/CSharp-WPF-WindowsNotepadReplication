using Application.Client.Cache.Infrastructure.Models.Interfaces;

namespace Application.Client.Cache.DataModels.Replace.ReplacementConditions
{
    public class ReplacementConditionsDataModel : ICacheDataModel
    {
        public string ReplaceWith { get; set; } = string.Empty;
    }
}
