using Application.Client.Cache.DataModels.FindDialog.Enums;
using Application.Client.Cache.Infrastructure.Models.Interfaces;

namespace Application.Client.Cache.DataModels.FindDialog
{
    public class FindDialogSettingsDataModel : ICacheDataModel
    {
        public string FindWhat { get; set; }

        public DirectionType DirectionType { get; set; } = DirectionType.Up;

        public bool IsMatchCase { get; set; }
    }
}
