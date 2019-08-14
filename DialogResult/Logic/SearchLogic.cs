using System.Windows.Forms;

namespace Notepad.Logic
{
    public class SearchLogic
    {
        #region CLASS VARIABLES AND PROPERTIES
        private readonly RichTextBox notepadRichTextBox;

        /// <summary>
        ///     Tároljuk a keresett karakterlánc találati INDEX-ét az INPUT beviteli mezőben.
        /// </summary>
        private int searchingStringFindIndex;

        /// <summary>
        ///     Tároljuk a RichTextBox Keresési beállításait.
        /// </summary>
        private RichTextBoxFinds richTextBoxFindOptions;

        /// <summary>
        ///     Tároljuk, hogy melyik INDEX-en fogjuk kezdeni a keresést a vizsgálandó karakterláncon.
        /// </summary>
        private int startIndex;

        /// <summary>
        ///     Tároljuk, hogy hol lesz a vég INDEX ameddig kereshetünk a vizsgálandó karakterláncon.
        /// </summary>
        private int endIndex;

        /// <summary>
        ///     Tároljuk, hogy a keresési művelet előrefelé történik-e (FALSE esetén hátrafelé fog történni)
        /// </summary>
        public bool IsForwardDirection { get; set; }

        /// <summary>
        ///     Tároljuk, hogy Kis- Nagy betűs megkülönböztetési keresést hajtunk-e végre.
        /// </summary>
        public bool LetterDiscrimination { get; set; }

        /// <summary>
        ///     Tároljuk a SEARCH Window-ban meghatározott keresendő karakterláncot.
        /// </summary>
        public string SearchingString { get; set; }
        #endregion

        /// <summary>
        ///     Konstruktor.
        /// </summary>
        /// <param name="notepadRichTextBox">Az az INPUT beviteli mező, amelyen a keresést szeretnénk végrehajtani.</param>
        public SearchLogic(RichTextBox notepadRichTextBox)
        {
            this.notepadRichTextBox = notepadRichTextBox;

            SetRichTextBoxFindOptions();
            SetPropertiesDefaultValue();
        }

        #region PUBLIC Methods
        /// <summary>
        ///     A paraméterben átadott karakterlánc, következő előfordulási helyének a RichTextBox-on belül található INPUT 
        ///     beviteli mezőnek a megkeresését végrehajtó metódus.
        /// </summary>
        /// <param name="searchingString">A keresendő karakterlánc.</param>
        public void NextSearch(string searchingString)
        {
            this.SearchingString = searchingString;

            /// Ha még van keresési lehetőség, azaz még lehet hogy van találati lehetőség az INPUT beviteli mezőben
            /// akkor a kurzor indexét az INPUT beviteli mezőben beállítjuk arra az INDEX-re, ahol az utolsó találati indexünket
            /// kaptuk.
            if (searchingStringFindIndex != -1 && IsForwardDirection)
            {
                notepadRichTextBox.SelectionStart = searchingStringFindIndex;
            }

            Search(this.SearchingString);

            if (searchingStringFindIndex == -1)
            {
                MessageBox.Show("\"" + searchingString + "\" - No more results found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        ///     Metódus, amely beállítja a RichTextBox-on a Keresési beállításokat.
        /// </summary>
        public void SetRichTextBoxFindOptions()
        {
            /// Kis-Nagy betű megkülönböztetésének beállítása.
            if (LetterDiscrimination)
            {
                richTextBoxFindOptions = RichTextBoxFinds.MatchCase;
            }
            else
            {
                richTextBoxFindOptions = RichTextBoxFinds.None;
            }

            /// Előlről vagy pedig Hátulról történő keresés beállítása
            if (!IsForwardDirection)
            {
                richTextBoxFindOptions |= RichTextBoxFinds.Reverse;
            }
        }
        #endregion

        #region PRIVATE HELPER Methods
        /// <summary>
        ///     A paraméterben átadott karakterlánc, következő előfordulási helyének a RichTextBox-on belül található INPUT 
        ///         beviteli mezőnek a megkeresését végrehajtó metódus. Sikeres keresés esetén, a FOCUS-t a talált karakterláncra
        ///         irányítja.
        ///     Sikertelen keresés esetén a "searchingStringFindIndex" az -1 értéket fog képviselni!
        /// </summary>
        /// <param name="searchingString">A keresendő karakterlánc.</param>
        private void Search(string searchingString)
        {
            SetStartEndFindIndexes();

            /// Csak akkor hajtjuk végre a Keresést, ha az END és a START index az nem egyenlő. Erre azért van szükség, mivel 
            /// ha visszafelé keresünk, akkor ha a START és az END Index megegyezik, akkor újra a végéről megismétli a keresési
            /// eljárást.
            if (startIndex != endIndex)
            {
                searchingStringFindIndex = notepadRichTextBox.Find(searchingString, startIndex, endIndex, richTextBoxFindOptions);
            }
            else
            {
                searchingStringFindIndex = -1;
            }

            notepadRichTextBox.Focus();
        }

        /// <summary>
        ///    Metódus, amely "kiszámolja" (beállítja), a kezdő (START) és vég (END) INDEX-ek értékeit.
        ///    Ez határozza meg, hogy a karakterláncot melyik intervallumon belül kell vizsgálni.
        /// </summary>
        private void SetStartEndFindIndexes()
        {
            if (IsForwardDirection)
            {
                startIndex = notepadRichTextBox.SelectionStart + notepadRichTextBox.SelectionLength;
                endIndex = notepadRichTextBox.Text.Length;
            }
            else
            {
                startIndex = 0;
                endIndex = notepadRichTextBox.SelectionStart;
            }
        }

        /// <summary>
        ///      Az egyes osztályváltozók és objektumok alapértelmezett beállításait megvalósító metódus.
        ///      - Alapértelmezetten Előre történő keresés beállítása.
        ///      - Kis- Nagy betű megkülönböztetésének kikapcsolása. (Logikai változó és a RichTextBox Keresési beállításaiban is a beállítása)
        /// </summary>
        private void SetPropertiesDefaultValue()
        {
            IsForwardDirection = true;
            LetterDiscrimination = false;
            SearchingString = string.Empty;
            searchingStringFindIndex = 0;

            richTextBoxFindOptions = RichTextBoxFinds.None;
        }
        #endregion
    }
}
