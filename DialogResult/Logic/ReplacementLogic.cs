using System.Windows.Forms;

namespace Notepad.Logic
{
    public class ReplacementLogic
    {
        #region CLASS VARIABLES AND PROPERTIES
        private readonly RichTextBox notepadRichTextBox;

        /// <summary>
        ///     Tároljuk a RichTextBox Keresési beállításait.
        /// </summary>
        private RichTextBoxFinds richTextBoxFindOptions;

        /// <summary>
        ///     Tároljuk a cserélendő keresett karakterlánc találati INDEX-ét az INPUT beviteli mezőben.
        /// </summary>
        private int replacementStringFindIndex;

        /// <summary>
        ///     Tároljuk, hogy melyik INDEX-en fogjuk kezdeni a keresést a vizsgálandó karakterláncon.
        /// </summary>
        private int startIndex;

        /// <summary>
        ///     Tároljuk, hogy hol lesz a vég INDEX ameddig kereshetünk a vizsgálandó karakterláncon.
        /// </summary>
        private int endIndex;

        /// <summary>
        ///     Tároljuk, hogy Kis- Nagy betűs megkülönböztetési keresést hajtunk-e végre.
        /// </summary>
        public bool LetterDiscrimination { get; set; }
        #endregion

        /// <summary>
        ///     Konstruktor.
        /// </summary>
        /// <param name="notepadRichTextBox">Az az INPUT beviteli mező, amelyen a keresést szeretnénk végrehajtani.</param>
        public ReplacementLogic(RichTextBox notepadRichTextBox)
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
        /// <param name="replacementString">A cserélendő karakterlánc.</param>
        /// <param name="replacementExpString">Az a karakterlánc, amelyre cserélni szeretnénk a cserélendő karakterláncot.</param>
        public void NextSearch(string replacementString, string replacementExpString)
        {
            /// Ha még van keresési lehetőség, azaz még lehet hogy van találati lehetőség az INPUT beviteli mezőben
            /// akkor...
            if (replacementStringFindIndex != -1)
            {
                /// A kurzor indexét az INPUT beviteli mezőben beállítjuk arra az INDEX-re, ahol az utolsó találati indexünket
                /// kaptuk, különben pedig onnantól kezdjük a keresést ahonnan esetlegesen kicseréltük a cserélendő karakterláncra. 
                if (replacementStringFindIndex == 0)
                {
                    notepadRichTextBox.SelectionStart = replacementStringFindIndex;
                }
                else
                {
                    notepadRichTextBox.SelectionStart = replacementStringFindIndex + replacementExpString.Length;
                }
            }

            Search(replacementString);

            if (replacementStringFindIndex == -1)
            {
                MessageBox.Show("\"" + replacementString + "\" - No more results found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        public void Replace(string replacementString, string replacementExpString)
        {
            if (notepadRichTextBox.SelectedText.Length > 0)
            {
                notepadRichTextBox.SelectedText = replacementExpString;

                /// Ha kicseréltük a karakterláncot, akkor a találati index-et meg kell növelni eggyel, mivel akkor mindig ugyan azt
                /// a karakterláncot találná meg legközelebb.
                if (replacementStringFindIndex == 0)
                {
                    replacementStringFindIndex++;
                }
            }

            NextSearch(replacementString, replacementExpString);
        }
        
        public void ReplaceAll(string replacementString, string replacementExpString)
        {
            while(replacementStringFindIndex != -1)
            {
                NextSearch(replacementString, replacementExpString);
                
                if(notepadRichTextBox.SelectedText.Length > 0)
                {
                    notepadRichTextBox.SelectedText = replacementExpString;
                }
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
        }

        public void SetReplacementStringFindIndexDefaultValue() => replacementStringFindIndex = 0;
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
                replacementStringFindIndex = notepadRichTextBox.Find(searchingString, startIndex, endIndex, richTextBoxFindOptions);
            }
            else
            {
                replacementStringFindIndex = -1;
            }

            notepadRichTextBox.Focus();
        }

        /// <summary>
        ///    Metódus, amely "kiszámolja" (beállítja), a kezdő (START) és vég (END) INDEX-ek értékeit.
        ///    Ez határozza meg, hogy a karakterláncot melyik intervallumon belül kell vizsgálni.
        /// </summary>
        private void SetStartEndFindIndexes()
        {
            startIndex = notepadRichTextBox.SelectionStart + notepadRichTextBox.SelectionLength;
            endIndex = notepadRichTextBox.Text.Length;
        }

        /// <summary>
        ///      Az egyes osztályváltozók és objektumok alapértelmezett beállításait megvalósító metódus.
        ///      - Alapértelmezetten Előre történő keresés beállítása.
        ///      - Kis- Nagy betű megkülönböztetésének kikapcsolása. (Logikai változó és a RichTextBox Keresési beállításaiban is a beállítása)
        /// </summary>
        private void SetPropertiesDefaultValue()
        {
            LetterDiscrimination = false;
            SetReplacementStringFindIndexDefaultValue();

            richTextBoxFindOptions = RichTextBoxFinds.None;
        }
        #endregion
    }
}
