using System;
using System.Windows.Forms;

namespace Notepad.Logic
{
    public class SearchLogic
    {
        #region CLASS VARIABLES AND PROPERTIES

        private readonly RichTextBox _notepadRichTextBox;

        private int _searchingStringFindIndex;

        private RichTextBoxFinds _richTextBoxFindOptions;

        private int _startIndex;

        private int _endIndex;

        public bool IsForwardDirection { get; set; }

        public bool LetterDiscrimination { get; set; }

        public string SearchingString { get; set; }

        #endregion

        /// <summary>
        ///     Konstruktor.
        /// </summary>
        /// <param name="notepadRichTextBox">Az az INPUT beviteli mező, amelyen a keresést szeretnénk végrehajtani.</param>
        public SearchLogic(RichTextBox notepadRichTextBox)
        {
            _notepadRichTextBox = notepadRichTextBox ?? throw new ArgumentNullException(nameof(notepadRichTextBox));

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
            SearchingString = searchingString;

            if (_searchingStringFindIndex != -1 && IsForwardDirection)
            {
                _notepadRichTextBox.SelectionStart = _searchingStringFindIndex;
            }

            Search(this.SearchingString);

            if (_searchingStringFindIndex == -1)
            {
                MessageBox.Show($@"""{searchingString}"" - No more results found", @"Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        ///     Metódus, amely beállítja a RichTextBox-on a Keresési beállításokat.
        /// </summary>
        public void SetRichTextBoxFindOptions()
        {
            _richTextBoxFindOptions = LetterDiscrimination ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None;

            if (!IsForwardDirection)
            {
                _richTextBoxFindOptions |= RichTextBoxFinds.Reverse;
            }
        }

        #endregion

        #region PRIVATE HELPER Methods

        /// <summary>
        ///     A paraméterben átadott karakterlánc, következő előfordulási helyének a RichTextBox-on belül található INPUT 
        ///         beviteli mezőnek a megkeresését végrehajtó metódus.
        /// </summary>
        /// <param name="searchingString">A keresendő karakterlánc.</param>
        private void Search(string searchingString)
        {
            SetStartEndFindIndexes();

            if (_startIndex != _endIndex)
            {
                _searchingStringFindIndex = _notepadRichTextBox.Find(searchingString, _startIndex, _endIndex, _richTextBoxFindOptions);
            }
            else
            {
                _searchingStringFindIndex = -1;
            }

            _notepadRichTextBox.Focus();
        }

        /// <summary>
        ///    Metódus, amely "kiszámolja" (beállítja), a kezdő (START) és vég (END) INDEX-ek értékeit.
        ///    Ez határozza meg, hogy a karakterláncot melyik intervallumon belül kell vizsgálni.
        /// </summary>
        private void SetStartEndFindIndexes()
        {
            if (IsForwardDirection)
            {
                _startIndex = _notepadRichTextBox.SelectionStart + _notepadRichTextBox.SelectionLength;
                _endIndex = _notepadRichTextBox.Text.Length;
            }
            else
            {
                _startIndex = 0;
                _endIndex = _notepadRichTextBox.SelectionStart;
            }
        }

        /// <summary>
        ///      Az egyes osztályváltozók és objektumok alapértelmezett beállításait megvalósító metódus.
        /// </summary>
        private void SetPropertiesDefaultValue()
        {
            IsForwardDirection = true;
            LetterDiscrimination = false;
            SearchingString = string.Empty;
            _searchingStringFindIndex = 0;

            _richTextBoxFindOptions = RichTextBoxFinds.None;
        }

        #endregion
    }
}
