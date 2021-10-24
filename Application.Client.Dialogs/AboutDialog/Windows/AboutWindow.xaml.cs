using System.Windows;
using Application.Utilities.Extensions;

namespace Application.Client.Dialogs.AboutDialog.Windows
{
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            this.HideIcon();

            InitializeComponent();
        }
    }
}
