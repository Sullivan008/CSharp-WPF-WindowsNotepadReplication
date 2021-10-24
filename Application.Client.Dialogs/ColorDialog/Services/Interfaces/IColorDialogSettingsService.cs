using System.Drawing;

namespace Application.Client.Dialogs.ColorDialog.Services.Interfaces
{
    public interface IColorDialogSettingsService
    {
        Color Color { get; }

        int[] CustomColors { get; }

        void SetColor(Color color);

        void SetCustomColors(int[] customColors);
    }
}
