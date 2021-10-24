using System.Drawing;

namespace Application.Client.Dialogs.FontDialog.Services.Interfaces
{
    public interface IFontDialogSettingsService
    {
        public Font Font { get; }

        public Color Color { get; }

        public void SetFont(Font font);

        public void SetColor(Color color);
    }
}
