using Application.Client.Cache.DataModels.FindDialog.Enums;
using Application.Client.Cache.Infrastructure.Models.Interfaces;

namespace Application.Client.Cache.DataModels.FindDialog
{
    public class FindDialogSearchTermsDataModel : ICacheDataModel
    {
        public string Text { get; set; }

        public DirectionType DirectionType { get; set; }

        public bool IsMatchCase { get; set; }
    }
}
