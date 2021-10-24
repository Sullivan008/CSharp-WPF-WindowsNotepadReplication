using Application.Client.Dialogs.AboutDialog.Enums;
using Application.Utilities.Guard;

namespace Application.Client.Dialogs.AboutDialog.Models
{
    public class AboutDialogResult
    {
        private readonly AboutDialogResultType? _aboutDialogResultType;
        public AboutDialogResultType AboutDialogResultType
        {
            get
            {
                Guard.ThrowIfNull(_aboutDialogResultType, nameof(AboutDialogResultType));

                return _aboutDialogResultType!.Value;
            }

            init => _aboutDialogResultType = value;
        }
    }
}
