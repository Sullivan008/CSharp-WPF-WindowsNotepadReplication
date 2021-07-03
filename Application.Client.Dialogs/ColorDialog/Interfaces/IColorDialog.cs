using System.Threading.Tasks;
using Application.Client.Dialogs.ColorDialog.Models;

namespace Application.Client.Dialogs.ColorDialog.Interfaces
{
    public interface IColorDialog
    {
        public Task<ColorDialogResult> ShowColorDialogAsync(ColorDialogOptions dialogOptions);
    }
}
