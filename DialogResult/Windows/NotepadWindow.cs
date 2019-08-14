using Notepad.Logic;
using System;
using System.Windows.Forms;

namespace Notepad.Windows
{
    public partial class NotepadWindow : Form
	{
        #region CLASS VARIABLES
        private readonly NotepadLogic notepadLogic;
        private readonly SearchLogic searchLogic;
        private readonly ReplacementLogic replacementLogic;
        private readonly JumpLogic jumpLogic;
        #endregion

        /// <summary>
        ///     Konstruktor
        /// </summary>
        public NotepadWindow()
		{
			InitializeComponent();

            notepadLogic = new NotepadLogic(notepadRichTextBox);
            searchLogic = new SearchLogic(notepadRichTextBox);
            replacementLogic = new ReplacementLogic(notepadRichTextBox);
            jumpLogic = new JumpLogic(notepadRichTextBox);
		}

        #region Events
        /// <summary>
        ///     Loaded esemény. A FORM betöltődésekor inicializálja a FORM-ot.
        /// </summary>
        private void Notepad_Load(object sender, EventArgs e)
		{
            SetTSMenuItemsEnabledProperty(false, RedoTSMenuItem, UndoTSMenuItem, CutTSMenuItem, CopyTSMenuItem,
                DeleteTSMenuItem, SearchTSMenuItem, FindNextTSMenuItem, RedoCTSMenuItem, UndoCTSMenuItem,
                CutCTSMenuItem, CopyCTSMenuItem, DeleteCTSMenuItem, SelectAllCTSMenuItem, SelectAllTSMenuItem, SaveTSMenuItem, SaveAsTSMenuItem);
		}

        /// <summary>
        ///     CLICK EVENT - Esemény, amely akkor fut le, hogyha valamelyik MENÜ ELEM-re (Menu Item) kattintunk.
        ///     Az, hogy melyik Menu Item-re kattintottunk a SENDER-ben található TAG Property tartalmazza, és ez
        ///     alapján határozzuk majd meg, hogy melyik FUNCTION-t kell végrehajtani.
        /// </summary>
		private void MenuItems_Click(object sender, EventArgs e)
		{
            switch(((ToolStripMenuItem)sender).Tag)
            {
                case "Undo":
                    Undo();
                    break;
                case "Redo":
                    Redo();
                    break;
                case "Copy":
                    Copy();
                    break;
                case "Cut":
                    Cut();
                    break;
                case "Paste":
                    Paste();
                    break;
                case "Delete":
                    Delete();
                    break;
                case "SelectAll":
                    SelectAll();
                    break;
                case "TimeDate":
                    PutTimeDate();
                    break;
                case "WordWrap":
                    WordWrap();
                    break;
                case "NewDocument":
                    NewDocument();
                    break;
                case "OpenDocument":
                    OpenDocument();
                    break;
                case "SaveDocument":
                    SaveDocument();
                    break;
                case "SaveAsDocument":
                    SaveDocument(true);
                    break;
                case "Exit":
                    Exit();
                    break;
                case "Font":
                    FontChange();
                    break;
                case "BackgroundColor":
                    BackgroundColorChange();
                    break;
                case "Highlighting":
                    HighlightingColorChange();
                    break;
                case "Search":
                    Search();
                    break;
                case "FindNext":
                    FindNext();
                    break;
                case "Replace":
                    Replace();
                    break;
                case "Jump":
                    Jump();
                    break;
                default:
                    break;

            }
		}

        /// <summary>
        ///     TEXT CHANGED EVENT - Esemény, amely akkor fut le, amikor a RichTextBox-ban található TEXT változik.
        ///     Vizsgáljuk, hogy taláható-e benne szöveg, s ennek függvényében határozzuk meg, hogy melyik gombok
        ///     (menü elemek) érhetőek el, vagy sem.
        /// </summary>
        private void NotepadRichTextBox_TextChanged(object sender, EventArgs e)
        {
            notepadLogic.DocumentIsSaved = false;

            SetTSMenuItemsEnabledProperty(true, UndoTSMenuItem, UndoCTSMenuItem, CutTSMenuItem, CopyTSMenuItem,
                CutCTSMenuItem, CopyCTSMenuItem, SearchTSMenuItem, FindNextTSMenuItem, SelectAllCTSMenuItem,
                SelectAllTSMenuItem, SaveAsTSMenuItem, SaveTSMenuItem);

            if (notepadRichTextBox.Text.Length.Equals(0))
            {
                SetTSMenuItemsEnabledProperty(false, UndoTSMenuItem, CutTSMenuItem, CopyTSMenuItem, UndoCTSMenuItem,
                    CutCTSMenuItem, CopyCTSMenuItem, SearchTSMenuItem, FindNextTSMenuItem, SelectAllCTSMenuItem,
                    SelectAllTSMenuItem, SaveAsTSMenuItem, SaveTSMenuItem);
            }
        }

        /// <summary>
        ///     SELECTION CHANGE EVENET - Esemény, amely akkor fut le, amikor egy szövegrészletet kijelölünk az
        ///     INPUT Beviteli mezőből. Így egnedélyezzük a TÖRLÉS (DELETE) Gomb elérhetőségét, vagy letiltását.
        /// </summary>
        private void NotepadRichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            if (notepadRichTextBox.SelectedText.Length > 0)
            {
                SetTSMenuItemsEnabledProperty(true, DeleteTSMenuItem, DeleteCTSMenuItem);   
            }
            else
            {
                SetTSMenuItemsEnabledProperty(false, DeleteTSMenuItem, DeleteCTSMenuItem);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        ///     A Szöveges INPUT mezőn egy Visszavonást hajt végre, majd a meghatározott
        ///     gombokat ELÉRHETŐVÉ teszi.
        /// </summary>
        private void Undo()
        {
            notepadLogic.Undo();

            SetTSMenuItemsEnabledProperty(true, RedoTSMenuItem, RedoCTSMenuItem);
        }

        /// <summary>
        ///     A Szöveges INPUT mezőn egy Előrevonást hajt végre, majd a meghatározott
        ///     gombokat LETILTJA, ha azt szükséges.
        /// </summary>
        private void Redo()
        {
            if(!notepadLogic.Redo())
            {
                SetTSMenuItemsEnabledProperty(false, RedoTSMenuItem, RedoCTSMenuItem);
            }
        }

        /// <summary>
        ///     A Szöveges INPUT mezőn a kijelölt szövegrész kivágását hajtja végre, majd a meghatározott
        ///     gombokat ENGEDÉLYEZI, ha azt szükséges.
        /// </summary>
        private void Cut()
        {
            if(notepadRichTextBox.SelectedText.Length > 0)
            {
                notepadLogic.CutOrCopy();

                SetTSMenuItemsEnabledProperty(true, PasteTSMenuItem, PasteCTSMenuItem);
            }
        }

        /// <summary>
        ///     A Szöveges INPUT mezőn a kijelölt szövegrész másolását hajtja végre, majd a meghatározott
        ///     gombokat ENGEDÉLYEZI, ha azt szükséges.
        /// </summary>
        private void Copy()
        {
            if (notepadRichTextBox.SelectedText.Length > 0)
            {
                notepadLogic.CutOrCopy(false);

                SetTSMenuItemsEnabledProperty(true, PasteTSMenuItem, PasteCTSMenuItem);
            }
        }

        /// <summary>
        ///     A szöveges INPUT mezőbe a vágólapon található szöveget beilleszti.
        /// </summary>
        private void Paste()
        {
            notepadLogic.Paste();
        }

        /// <summary>
        ///     Ha van kijelölt rész a szöveges INPUT mezőn, akkor azt kitörli.
        /// </summary>
        private void Delete()
        {
            if(notepadRichTextBox.SelectedText.Length > 0)
            {
                notepadLogic.Delete();
            }
        }

        /// <summary>
        ///     A szöveges INPUT mezőben található szöveget kijelöli.
        /// </summary>
        private void SelectAll()
        {
            notepadLogic.SelectAll();
        }

        /// <summary>
        ///     A szöveges INPUT mezőbe beszúrja az aktuális Dátum/Idő-t.
        /// </summary>
        private void PutTimeDate()
        {
            notepadLogic.PutDateTime();
        }
        
        /// <summary>
        ///     A szöveges INPUT mezőn beállítja a SORTÖRÉS-es megejelenítést,
        ///     vagy annek levételét.
        /// </summary>
        private void WordWrap()
        {
            if(!WordWrapTSMenuItem.Checked)
            {
                WordWrapTSMenuItem.CheckState = CheckState.Checked;

                notepadLogic.SetWordWrap(true);
            }
            else
            {
                WordWrapTSMenuItem.CheckState = CheckState.Unchecked;

                notepadLogic.SetWordWrap(false);
            }
        }

        /// <summary>
        ///     Új dokumentum inicializálást végrehajtó metódus.
        /// </summary>
        private void NewDocument()
        {
            notepadLogic.NewDocument();

            ActiveForm.Text = "Unsaved - Notepad";
        }

        /// <summary>
        ///     Dokumentum megnyitását végrehajtó metódus.
        /// </summary>
        private void OpenDocument()
        {
            /// Tároljuk, a függvény által visszatérített megnyitott dokumentum nevét.
            string openedFileName = notepadLogic.OpenDocument();

            /// Beállítjuk a FORM új címsorát, ha az szükséges.
            if(!openedFileName.Equals(string.Empty))
            {
                ActiveForm.Text = $"{ openedFileName} - Notepad";

                SetTSMenuItemsEnabledProperty(true, SaveAsTSMenuItem);
            }
        }

        /// <summary>
        ///     A dokumentum metését végrehajtó metódus.
        /// </summary>
        /// <param name="isSaveAsOperation">
        ///     Logikai paraméter, amely meghatározza, hogy Mentés Másként parancsot szeretnénk végrehajtani, vagy csak sima mentést.
        /// </param>
        private void SaveDocument(bool isSaveAsOperation = false)
        {
            /// Tároljuk, a függvény által visszatérített megnyitott dokumentum nevét.
            string openedFileName = notepadLogic.SaveDocument(isSaveAsOperation);

            /// Beállítjuk a FORM új címsorát, ha az szükséges.
            if (!openedFileName.Equals(string.Empty))
            {
                ActiveForm.Text = $"{ openedFileName} - Notepad";
            }
        }

        /// <summary>
        ///     Az alkalmazás bezárását végrehajtó metódus.
        /// </summary>
        private void Exit()
        {
            notepadLogic.Exit();
        }
        
        /// <summary>
        ///     A betűtípus és betűszín beállításainak módosítását végrehajtó metódus.
        /// </summary>
        private void FontChange()
        {
            notepadLogic.FontChange();
        }
        
        /// <summary>
        ///     A háttérszín módosítását végrehajtó metódus.
        /// </summary>
        private void BackgroundColorChange()
        {
            notepadLogic.BackgroundColorChange();
        }
        
        /// <summary>
        ///     A kijelölt szövegrész háttérszínének módosítását végrehajtó metódus.
        /// </summary>
        private void HighlightingColorChange()
        {
            notepadLogic.HighlightingColorChange();
        }
        
        /// <summary>
        ///     Keresési ablak megnyitását végrehajtó metódus.
        /// </summary>
        private void Search()
        {
            SearchWindow searchWindow = new SearchWindow(searchLogic);

            searchWindow.Show(this);
        }
        
        /// <summary>
        ///     A keresési ablakban definiált keresési kifejezésnek megfelelően megkeresi a 
        ///     következő eredményt.
        /// </summary>
        private void FindNext()
        {
            if(searchLogic.SearchingString.Equals(string.Empty))
            {
                Search();
            }
            else
            {
                searchLogic.NextSearch(searchLogic.SearchingString);
            }
        }
        
        /// <summary>
        ///     A csere ablak megnyitását végrehajtó metódus.
        /// </summary>
        private void Replace()
        {
            ReplacementWindow replacementWindow = new ReplacementWindow(replacementLogic);

            replacementWindow.Show(this);
        }
        
        /// <summary>
        ///     Az ugrás ablak megnyitását végrehajtó metódus.
        /// </summary>
        private void Jump()
        {
            JumpWindow jumpWindow = new JumpWindow(jumpLogic);

            jumpWindow.Show(this);
        }
        #endregion

        #region PRIVATE HELPER Methods
        /// <summary>
        ///     A paraméterben átadott Menu gombok (Menu Items) elérhetőségét beállító metódus.
        ///     Minden gomb (Menu Item) az isEnabled változóban tárolt értéket fogja képviselni.
        /// </summary>
        /// <param name="isEnabled">Változó, amely meghatározza, hogy a TS MENU ITEM elérhető lesz-e vagy sem.</param>
        /// <param name="tsMenuItems">A TS MENU ITEM objektumok, amelyeknek az ENABLED paraméterét állítani kell.</param>
        private void SetTSMenuItemsEnabledProperty(bool isEnabled, params ToolStripMenuItem[] tsMenuItems)
        {
            foreach (ToolStripMenuItem item in tsMenuItems)
            {
                item.Enabled = isEnabled;
            }
        }
        #endregion
    }
}