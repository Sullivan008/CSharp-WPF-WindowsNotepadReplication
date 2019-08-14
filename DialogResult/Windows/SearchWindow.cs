using Notepad.Logic;
using System;
using System.Windows.Forms;

namespace Notepad.Windows
{
    public partial class SearchWindow : Form
	{
        private readonly SearchLogic searchLogic;

        /// <summary>
        ///     Konstruktor
        /// </summary>
        /// <param name="searchLogic">
        ///     Az üzleti logikát megvalósító objektum. Ez az objektum a Notepad FORM-ban
        ///     kerül legelőször példányosításra, így további műveleteket hajthatunk végre a RichTextBox-on.
        /// </param>
        public SearchWindow(SearchLogic searchLogic)
		{
			InitializeComponent();

            this.searchLogic = searchLogic;
		}

        #region Events
        /// <summary>
        ///     LOAD EVENT - Az eseményben definiáljuk a felület alapértelmezett megjelenítését. 
        ///     (Gombok engedélyezése, stb...)
        /// </summary>
        private void Search_Load(object sender, EventArgs e)
		{
			nextButton.Enabled = false;
			forwardRadioButton.Checked = true;
		}

        /// <summary>
        ///     CLICK EVENT - Esemény, amely akkor fut le, ha valamelyik gombot megnyomjuk a SEARCH Window
        ///     felületen.
        /// </summary>
        private void Buttons_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Tag)
            {
                case "Back":
                    CloseWindow();
                    break;
                case "Next":
                    NextSearch();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        ///     TEXT CHANGED EVENT - Az esemény akkor fut le, hogyha az INPUT beviteli mezőnek az értékét módosítjuk.
        ///     Így engedélyezzük a "Következő Keresése" gombot.
        /// </summary>
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!((TextBox)sender).Text.Equals(string.Empty))
            {
                nextButton.Enabled = true;
            }
            else
            {
                nextButton.Enabled = false;
            }
        }

        /// <summary>
        ///     CHECKED CHANGE EVENT - Az esemény akkor fut le, amikor a Radio Button-ok között váltunk, azaz módosítjuk
        ///     a keresés irányát (Előrefelé vagy pedig hátrafelé)
        /// </summary>
        private void Direction_CheckedChanged(object sender, EventArgs e)
        {
            switch (((RadioButton)sender).Tag)
            {
                case "1":
                    searchLogic.IsForwardDirection = true;
                    break;
                case "2":
                    searchLogic.IsForwardDirection = false;
                    break;
            }

            searchLogic.SetRichTextBoxFindOptions();
        }

        /// <summary>
        ///     CHACKED CHANGE EVENT - Az esemény akkor fut le, amikor a CheckBox értékét megváltoztatjuk, azaz módosítjuk
        ///     hogy figyelembe kell-e venni a Kis- Nagy betűket.
        /// </summary>
        private void SmallLargeLetterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                searchLogic.LetterDiscrimination = true;
            }
            else
            {
                searchLogic.LetterDiscrimination = false;
            }

            searchLogic.SetRichTextBoxFindOptions();
        }
        
        #endregion

        #region Methods
        /// <summary>
        ///     A SEARCH Window felület bezárásáért felelős metódus.
        /// </summary>
        private void CloseWindow()
        {
            this.Close();
        }
        
        /// <summary>
        ///     A következő találati eredmény kereséséért felelős metódus. Ez a metódus hívja meg/ hajtja
        ///     meg azt a logikát, amely a következő keresendő kifejezést megkeresi a RichTextBox INPUT beviteli mezőben.
        /// </summary>
        private void NextSearch()
        {
            searchLogic.NextSearch(searchTextBox.Text);
        }
        #endregion
	}
}
