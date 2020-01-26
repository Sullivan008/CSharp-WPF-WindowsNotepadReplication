using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Notepad.Logic
{
    public class JumpLogic
    {
        private readonly RichTextBox _notepadRichTextBox;

        /// <summary>
        ///     Konstruktor.
        /// </summary>
        /// <param name="notepadRichTextBox">Az az INPUT beviteli mező, amelyen a keresést szeretnénk végrehajtani.</param>
        public JumpLogic(RichTextBox notepadRichTextBox)
        {
            _notepadRichTextBox = notepadRichTextBox ?? throw new ArgumentNullException(nameof(notepadRichTextBox));
        }

        #region PUBLIC Methods
        
        /// <summary>
        ///     A paraméterben megadott sorszámú sor elejére helyezi el a kurzort. Így biztosítva azt, hogy a paraméterben
        ///     megadott sorra kerülünk.
        /// </summary>
        /// <param name="lineNumber">Annak a sornak a száma, ahová a kurzort el kell helyezni.</param>
        /// <returns>
        ///     TRUE -  Ha sikeres volt a kurzor elhelyezése
        ///     FALSE - Ha nem sikerült a kurzor elhelyezése (INDEX OUT OF RANGE EXCEPTION)
        /// </returns>
        public bool Jump(int lineNumber)
        {
            if (_notepadRichTextBox.SelectionLength > 0)
            {
                _notepadRichTextBox.SelectionLength = 0;
            }

            if (_notepadRichTextBox.Text.Length > 0)
            {
                try
                {
                    _notepadRichTextBox.SelectionStart =
                        _notepadRichTextBox.Find(_notepadRichTextBox.Lines[lineNumber - 1], RichTextBoxFinds.NoHighlight);

                    return true;
                }
                catch(IndexOutOfRangeException ex)
                {
                    Debug.WriteLine($"++++ ERROR - The sequence number exceeds the total number of rows! See more in Stack Trace: {ex.StackTrace}\n\n" +
                        $"See more in Inner Exception: {ex.InnerException}\n\nSee more in Message: {ex.Message}");
                    
                    return false;
                }
            }

            return false;
        }
        
        /// <summary>
        ///     Függvény, amely visszaadja hogy hány sor található a RichTextBox-ban.
        /// </summary>
        /// <returns>A RichTextBox-ban található sorok száma.</returns>
        public int GetRichTextBoxLineNumbers()
        {
            return _notepadRichTextBox.Lines.Length;
        }

        #endregion
    }
}