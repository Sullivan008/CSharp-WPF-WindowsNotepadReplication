using System.Drawing;
using Application.Client.Cache.Infrastructure.Models.Interfaces;

namespace Application.Client.Cache.DataModels
{
    public class ColorDialogSettingsDataModel : ICacheDataModel
    {
        public Color Color { get; set; }

        public int[]? CustomColors { get; set; }
    }
}
