using System.Windows.Forms;

namespace Notepad.Logic
{
    public class ReplacementLogic
    {
        #region CLASS VARIABLES AND PROPERTIES

        private readonly RichTextBox _notepadRichTextBox;

        private RichTextBoxFinds _richTextBoxFindOptions;

        private int _replacementStringFindIndex;

        private int _startIndex;

        private int _endIndex;

        public bool LetterDiscrimination { get; set; }
        
        #endregion

        /// <summary>
        ///     Konstruktor.
        /// </summary>
        /// <param name="notepadRichTextBox">Az az INPUT beviteli mező, amelyen a keresést szeretnénk végrehajtani.</param>
        public ReplacementLogic(RichTextBox notepadRichTextBox)
        {
            _notepadRichTextBox = notepadRichTextBox;

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
            if (_replacementStringFindIndex != -1)
            {
                /// A kurzor indexét az INPUT beviteli mezőben beállítjuk arra az INDEX-re, ahol az utolsó találati indexünket
                /// kaptuk, különben pedig onnantól kezdjük a keresést ahonnan esetlegesen kicseréltük a cserélendő karakterláncra. 
                if (_replacementStringFindIndex == 0)
                {
                    _notepadRichTextBox.SelectionStart = _replacementStringFindIndex;
                }
                else
                {
                    _notepadRichTextBox.SelectionStart = _replacementStringFindIndex + replacementExpString.Length;
                }
            }

            Search(replacementString);

            if (_replacementStringFindIndex == -1)
            {
                MessageBox.Show("\"" + replacementString + "\" - No more results found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        public void Replace(string replacementString, string replacementExpString)
        {
            if (_notepadRichTextBox.SelectedText.Length > 0)
            {
                _notepadRichTextBox.SelectedText = replacementExpString;

                /// Ha kicseréltük a karakterláncot, akkor a találati index-et meg kell növelni eggyel, mivel akkor mindig ugyan azt
                /// a karakterláncot találná meg legközelebb.
                if (_replacementStringFindIndex == 0)
                {
                    _replacementStringFindIndex++;
                }
            }

            NextSearch(replacementString, replacementExpString);
        }
        
        public void ReplaceAll(string replacementString, string replacementExpString)
        {
            while(_replacementStringFindIndex != -1)
            {
                NextSearch(replacementString, replacementExpString);
                
                if(_notepadRichTextBox.SelectedText.Length > 0)
                {
                    _notepadRichTextBox.SelectedText = replacementExpString;
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
                _richTextBoxFindOptions = RichTextBoxFinds.MatchCase;
            }
            else
            {
                _richTextBoxFindOptions = RichTextBoxFinds.None;
            }
        }

        public void SetReplacementStringFindIndexDefaultValue() => _replacementStringFindIndex = 0;
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
            if (_startIndex != _endIndex)
            {
                _replacementStringFindIndex = _notepadRichTextBox.Find(searchingString, _startIndex, _endIndex, _richTextBoxFindOptions);
            }
            else
            {
                _replacementStringFindIndex = -1;
            }

            _notepadRichTextBox.Focus();
        }

        /// <summary>
        ///    Metódus, amely "kiszámolja" (beállítja), a kezdő (START) és vég (END) INDEX-ek értékeit.
        ///    Ez határozza meg, hogy a karakterláncot melyik intervallumon belül kell vizsgálni.
        /// </summary>
        private void SetStartEndFindIndexes()
        {
            _startIndex = _notepadRichTextBox.SelectionStart + _notepadRichTextBox.SelectionLength;
            _endIndex = _notepadRichTextBox.Text.Length;
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

            _richTextBoxFindOptions = RichTextBoxFinds.None;
        }
        #endregion
    }
}
