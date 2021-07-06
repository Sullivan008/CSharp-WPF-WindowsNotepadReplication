using System.Drawing;
using Application.Client.Cache.Infrastructure.Models.Interfaces;

namespace Application.Client.Cache.DataModels
{
    public class FontDialogSettingsDataModel : ICacheDataModel
    {
        public Font Font { get; set; }

        public Color Color { get; set; }
    }
}
