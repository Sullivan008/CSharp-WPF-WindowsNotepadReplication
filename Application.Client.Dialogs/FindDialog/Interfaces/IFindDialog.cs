using System.Threading.Tasks;
using Application.Client.Dialogs.FindDialog.Delegates;

namespace Application.Client.Dialogs.FindDialog.Interfaces
{
    public interface IFindDialog
    {
        public event OnFindNextEventHandler OnFindNextEvent;

        Task ShowAsync();
    }
}
