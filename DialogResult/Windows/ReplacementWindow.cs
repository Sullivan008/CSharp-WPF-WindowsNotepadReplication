using Notepad.Logic;
using System;
using System.Windows.Forms;

namespace Notepad.Windows
{
    public partial class ReplacementWindow : Form
    {
        private readonly ReplacementLogic replacementLogic;

        public ReplacementWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Konstruktor
        /// </summary>
        /// <param name="replacementLogic">
        ///     Az üzleti logikát megvalósító objektum. Ez az objektum a Notepad FORM-ban
        ///     kerül legelőször példányosításra, így további műveleteket hajthatunk végre a RichTextBox-on.
        /// </param>
        public ReplacementWindow(ReplacementLogic replacementLogic)
        {
            InitializeComponent();

            this.replacementLogic = replacementLogic;
        }

        #region EVENTS
        /// <summary>
        ///     LOAD EVENT - Az eseményben definiáljuk a felület alapértelmezett megjelenítését. 
        ///     (Gombok engedélyezése, stb...)
        /// </summary>
        private void Replacement_Load(object sender, EventArgs e)
        {
            SetButtonEnabledProperty(false, nextButton, replaceButton, replaceAllButton);
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
                case "Replace":
                    Replace();
                    break;
                case "ReplaceAll":
                    ReplaceAll();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        ///     TEXT CHANGED EVENT - Az esemény akkor fut le, hogyha az KERESENDŐ STRING INPUT beviteli mezőnek az értékét módosítjuk.
        ///     Így engedélyezzük az egyes gombok elérhetőségét.
        /// </summary>
        private void SearchTermTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchTermTextBox.Text.Length > 0)
            {
                SetButtonEnabledProperty(true, nextButton, replaceButton, replaceAllButton);

                replacementLogic.SetReplacementStringFindIndexDefaultValue();
            }
            else
            {
                SetButtonEnabledProperty(false, nextButton, replaceButton, replaceAllButton);
            }
        }

        /// <summary>
        ///     CHACKED CHANGE EVENT - Az esemény akkor fut le, amikor a CheckBox értékét megváltoztatjuk, azaz módosítjuk
        ///     hogy figyelembe kell-e venni a Kis- Nagy betűket.
        /// </summary>
        private void SmallLargeLetterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                replacementLogic.LetterDiscrimination = true;
            }
            else
            {
                replacementLogic.LetterDiscrimination = false;
            }

            replacementLogic.SetRichTextBoxFindOptions();
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
        ///     meg azt a logikát, amely a következő keresendő kifejezést megkeresi az INPUT beviteli mezőben.
        /// </summary>
        private void NextSearch()
        {
            replacementLogic.NextSearch(searchTermTextBox.Text, replacementExpTextBox.Text);
        }

        /// <summary>
        ///     A keresési feltételenek megfelelő találati eredményt (ha van), kicseréli a cserélendő kifejezésre.
        /// </summary>
        private void Replace()
        {
            replacementLogic.Replace(searchTermTextBox.Text, replacementExpTextBox.Text);
        }
        
        /// <summary>
        ///     A keresési feltételnek megfeleleő összes találati eredményt (ha van), kicseréli a cserélendő kifejezésre.
        /// </summary>
        private void ReplaceAll()
        {
            replacementLogic.ReplaceAll(searchTermTextBox.Text, replacementExpTextBox.Text);
        }
        #endregion

        #region PRIVATE HELPER Methods
        /// <summary>
        ///     Metódus, amely a paraméterben átadott Button objektumok Enabled property-jét a paraméterben átadott
        ///     isEnabled paramétere alapján beállítja.
        /// </summary>
        /// <param name="isEnabled">Változó, amely meghatározza, hogy a gomb elérhető lesz-e vagy sem.</param>
        /// <param name="buttons">A BUTTON objektumok, amelyeknek az ENABLED paraméterét állítani kell.</param>
        private void SetButtonEnabledProperty(bool isEnabled, params Button[] buttons)
        {
            foreach (Button item in buttons)
            {
                item.Enabled = isEnabled;
            }
        }
        #endregion
    }
}
