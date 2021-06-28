using System.Threading.Tasks;
using Application.Client.Dialogs.FontDialog.Models.Options;
using Application.Client.Dialogs.FontDialog.Models.Result;

namespace Application.Client.Dialogs.FontDialog.Interfaces
{
    public interface IFontDialog
    {
        public Task<FontDialogResult> ShowFontDialogAsync(FontDialogOptions fontDialogOptions);
    }
}
