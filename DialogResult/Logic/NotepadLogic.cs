using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Notepad.Logic
{
    public class NotepadLogic
    {
        #region CLASS VARIABLES AND PROPERTIES
        private readonly RichTextBox notepadRichTextBox;

        /// <summary>
        ///     Ebben fogjuk eltárolni annak a fájlnak az elérési útvonalát, amelyet megnyitottunk szerkesztésre.
        /// </summary>
        private string openedFilePath;

        /// <summary>
        ///     Logikai változó, amelyben eltároljuk, hogy a Dokumentumunk mentett állapotban van-e.
        /// </summary>
        public bool? DocumentIsSaved { get; set; }
        #endregion
        
        /// <summary>
        ///     Konstruktor
        /// </summary>
        public NotepadLogic(RichTextBox notepadRichTextBox)
        {
            this.notepadRichTextBox = notepadRichTextBox;

            SetNotepadRichTextBoxAndPropertiesDefaultValue();
        }

        #region Methods
        /// <summary>
        ///     Az osztályváltozóban meghatározott RichTextBox-on egy Visszavonást (Undo-t) 
        ///     hajt végre.
        /// </summary>
        public void Undo()
        {
            notepadRichTextBox.Undo();
        }

        /// <summary>
        ///     Az osztályváltozóban meghatározott RichTextBox-on egy Előrevonást (Redo-t) 
        ///     hajt végre.
        /// </summary>
        /// <returns>
        ///     TRUE -  Ha még van előrehozási művelet.
        ///     FALSE - Ha már nincs.
        /// </returns>
        public bool Redo()
        {
            notepadRichTextBox.Redo();

            return notepadRichTextBox.CanRedo;
        }

        /// <summary>
        ///     Az osztályváltozóban meghatározott RichTextBox-on található kijelölt szövegrészt
        ///     a vágólapra helyez, majd azt a kijelölt szövegrészt, eltünteti az objektumból, ha a 
        ///     paraméterben meghatározott logikai érték ezt engedi. Ha nem engedi, akkor csak "MÁSOLÁSI"
        ///     műveletet hajtunk végre.
        /// </summary>
        /// <param name="isCut">
        ///     Logikai változó, amely meghatározza, hogy KIVÁGÁSI műveletet hajtunk végre.
        ///     TRUE -  Ha KIVÁGÁSI műveletet hajtunk végre (DEFAULT TRUE VALUE)
        ///     FALSE - Ha MÁSOLÁSI műveletet hajtunk végre.
        /// </param>
        public void CutOrCopy(bool isCut = true)
        {
            Clipboard.SetText(notepadRichTextBox.SelectedText);

            if (isCut)
            {
                notepadRichTextBox.SelectedText = string.Empty;
            }
        }

        /// <summary>
        ///     Az osztályváltozóban meghatározott RichTextBox-ba beilleszti a vágólapon található 
        ///     értéket, arra a megfelelő helyre, ahol a kurzor pontosan áll.
        /// </summary>
        public void Paste()
        {
            if (Clipboard.ContainsText())
            {
                notepadRichTextBox.SelectedText = Clipboard.GetText();
            }
        }

        /// <summary>
        ///     Az osztályváltozóban meghatározott RichTextBox-on található kijelölt szövegrészt
        ///     eltávolítja az objektumból.
        /// </summary>
        public void Delete()
        {
            notepadRichTextBox.SelectedText = string.Empty;
        }

        /// <summary>
        ///     Az osztályváltozóban meghatározott RichTextBox-on található összes szövegrészt
        ///     kijelöli.
        /// </summary>
        public void SelectAll()
        {
            notepadRichTextBox.SelectAll();
        }

        /// <summary>
        ///     Az osztályváltozóban meghatározott RichTextBox-on található, az aktuálisan elhelyezkedő
        ///     kurzur helyzetébe beszúrja az aktuális Időt.
        /// </summary>
        public void PutDateTime()
        {
            notepadRichTextBox.SelectedText = DateTime.Now.ToString();
        }

        /// <summary>
        ///     Az osztályváltozóban meghatározott RichTextBox-on beállítja a SOR TÖRÉST.
        /// </summary>
        /// <param name="isWordWrap">
        ///     Meghatározza, hogy az osztályváltozó objektumán, be kell-e állítani a SORTÖRÉST.
        ///     TRUE -  Ha be kell állítani.
        ///     FALSE - Ha nem kell beállítani.
        /// </param>
        public void SetWordWrap(bool isWordWrap)
        {
            notepadRichTextBox.WordWrap = isWordWrap;
        }

        /// <summary>
        ///     Új dokumentum inicializálását végrehajtó metódus. Vizsgálatra kerülnek benne a következők:
        ///         - A dokumentum módosult-e, azaz volt-e már mentve, legyen az egy mentetlen dokuementum vagy egy megnyitott dokumentum.
        ///         - Ha még nem volt mentve, akkor szeretnénk-e menteni.
        ///             - Megvizsgáljuk, hogy volt-e megnyitásra bármilyen dokumentum is. Ha volt, akkor ugyan abba mentjük le.
        ///             - Ha nem, egy új fájlnév megadása után kerül lementésre, az aktuális helyre a dokumentum.
        /// </summary>
        public void NewDocument()
        {
            DialogResult result;

            /// Vizsgáljuk, hogy a Dokumentum volt-e már mentve. Ez azt is befolyásolja, hogyha egy korábbi dokumentumot megnyitottunk,
            /// de nem biztos hogy abban végeztünk módosítást.
            if (DocumentIsSaved == false)
            {
                result = MessageBox.Show("The file is not saved. Do you want to save?", "New Document",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    /// Vizsgáljuk, hogy megnyitott fájlban dolgozunk-e vagy sem.
                    if (openedFilePath.Equals(string.Empty))
                    {
                        NewFileSave();
                    }
                    else
                    {
                        ExistingFileSave();
                    }

                    SetNotepadRichTextBoxAndPropertiesDefaultValue();
                }
                else if (result == DialogResult.No)
                {
                    SetNotepadRichTextBoxAndPropertiesDefaultValue();
                }
            }
            else
            {
                SetNotepadRichTextBoxAndPropertiesDefaultValue();
            }
        }

        /// <summary>
        ///     A dokuemtum megnyitását végrehajtó metódus.
        /// </summary>
        /// <returns>
        ///     A megnyitott dokumentum neve.
        /// </returns>
        public string OpenDocument()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Text File (*txt)|*.txt|Rich Text Format (*rtf)|*.rtf|All File (*.*)|*.*";
                
                if(dialog.ShowDialog() == DialogResult.OK && !dialog.FileName.Equals(string.Empty))
                {
                    try
                    {
                        /// A Stream lehetőségeknek megfelelően olvassuk be a fájl tartalmát.
                        if(dialog.FileName.Contains(".rtf"))
                        {
                            notepadRichTextBox.LoadFile(dialog.FileName, RichTextBoxStreamType.RichText);
                        }
                        else
                        {
                            notepadRichTextBox.LoadFile(dialog.FileName, RichTextBoxStreamType.PlainText);
                        }

                        DocumentIsSaved = true;
                        openedFilePath = dialog.FileName;
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("ERROR - Failed to open file!");

                        Debug.WriteLine($"++++ ERROR - Failed to open file! See more in Stack Trace: {ex.StackTrace}\n\n" +
                            $"See more in Inner Exception: {ex.InnerException}\n\nSee more in Message: {ex.Message}");

                        SetNotepadRichTextBoxAndPropertiesDefaultValue();
                    }
                }
            }

            return Path.GetFileName(openedFilePath);
        }

        /// <summary>
        ///     A dokumentum mentését végrehajtó metódus. A logikai paraméterben meghatározott értéknek megfelelően eldöntjük, hogy
        ///     SaveAs vagy Save parancsot szeretnénk végrehajtani. 
        /// </summary>
        /// <param name="isSaveAsOperation">
        ///     Logikai paraméter, amely meghatározza, hogy Mentés Másként parancsot szeretnénk végrehajtani, vagy csak sima mentést.
        /// </param>
        /// <returns>
        ///     Az elmentett dokumentum neve. Ha SAVE parancs hajtódott végre, akkor ugyan az a név marad, a SaveAs-el ellentétben.
        /// </returns>
        public string SaveDocument(bool isSaveAsOperation)
        {
            if(isSaveAsOperation)
            {
                NewFileSave();
            }
            else
            {
                if(openedFilePath.Equals(string.Empty))
                {
                    NewFileSave();
                }
                else
                {
                    ExistingFileSave();
                }
            }

            return Path.GetFileName(openedFilePath);
        }

        /// <summary>
        ///     Az alkalmazás bezárását végrehajtó metódus. Vizsgálatra kerülnek benne a következők:
        ///         - A dokumentum módosult-e, azaz volt-e már mentve, legyen az egy mentetlen dokuementum vagy egy megnyitott dokumentum.
        ///         - Ha még nem volt mentve, akkor szeretnénk-e menteni.
        ///             - Megvizsgáljuk, hogy volt-e megnyitásra bármilyen dokumentum is. Ha volt, akkor ugyan abba mentjük le.
        ///             - Ha nem, egy új fájlnév megadása után kerül lementésre, az aktuális helyre a dokumentum.
        /// </summary>
        public void Exit()
        {
            DialogResult result;

            /// Vizsgáljuk, hogy a Dokumentum volt-e már mentve. Ez azt is befolyásolja, hogyha egy korábbi dokumentumot megnyitottunk,
            /// de nem biztos hogy abban végeztünk módosítást.
            if (DocumentIsSaved == false)
            {
                result = MessageBox.Show("The file is not saved. Do you want to save?", "Exit",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    /// Vizsgáljuk, hogy megnyitott fájlban dolgozunk-e vagy sem.
                    if (openedFilePath.Equals(string.Empty))
                    {
                        NewFileSave();
                    }
                    else
                    {
                        ExistingFileSave();
                    }
                }
                else if (result == DialogResult.No)
                {
                    Application.Exit();
                }
            }

            Application.Exit();
        }
        
        /// <summary>
        ///     Metódus amely megváltoztatja a betűtípus beállításait (Betűtípus, méret, stb...) és betűszín beállításait.
        ///     Ha van megfelelően kijelölt rész, akkor az új beállítások csak arra az egységre lesznek érvényesek, azonban
        ///         ha nem jelölünk ki semmit, akkor az egész INPUT beviteli mezőre érvényes lesz!
        /// </summary>
        public void FontChange()
        {
            using (FontDialog dialog = new FontDialog())
            {
                dialog.ShowColor = true;
                
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    if(notepadRichTextBox.SelectedText.Length > 0)
                    {
                        notepadRichTextBox.SelectionFont = dialog.Font;
                        notepadRichTextBox.SelectionColor = dialog.Color;
                    }
                    else
                    {
                        notepadRichTextBox.Font = dialog.Font;
                        notepadRichTextBox.ForeColor = dialog.Color;
                    }
                }
            }
        }
        
        /// <summary>
        ///     Metódus, amely megváltoztatja az INPUT beviteli mező háttérszínét
        /// </summary>
        public void BackgroundColorChange()
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    notepadRichTextBox.BackColor = dialog.Color;
                }
            }
        }
        
        /// <summary>
        ///     Metódus amely megváltoztatja az INPUT beviteli mezőben kijelölt szövegrész háttérszínét.
        ///     Csak akkor jelenik meg dialógus ablak, amikor van kijelölt szövegrész.
        /// </summary>
        public void HighlightingColorChange()
        {
            if(notepadRichTextBox.SelectedText.Length > 0)
            {
                using (ColorDialog dialog = new ColorDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        notepadRichTextBox.SelectionBackColor = dialog.Color;
                    }
                }
            }
        }
        #endregion

        #region PRIVATE HELPER Methods
        /// <summary>
        ///     Új dokumentum mentésekor végrehajtódó metódus.
        ///     Egy dialógus ablak megnyitásával meghatározzuk a fájl mentési pozícióját és a fájl nevét (kiterjesztéssel
        ///         együtt), majd annak megfelelően kerül mentésre a fájl. A mentés során eltároljuk az osztályváltozóban
        ///         a fájl mentési helyét, annak érdekében, hogyha nem új dokumentumot hozunk létre, akkor ha új műveleteket
        ///         hajtunk ezzel a dokumentummal végre, akkor ugyan abba a fájlba tudjuk a mentést végrehajtani.
        /// </summary>
        private void NewFileSave()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Text File (*txt)|*.txt|Rich Text Formátum (*rtf)|*.rtf";

                if (dialog.ShowDialog() == DialogResult.OK && !dialog.FileName.Equals(string.Empty))
                {
                    try
                    {
                        /// A kiterjesztésnek megfelelően állítjuk be a fájl mentési beállításait.
                        notepadRichTextBox.SaveFile(dialog.FileName,
                            Path.GetExtension(dialog.FileName) == ".txt" ? RichTextBoxStreamType.PlainText : RichTextBoxStreamType.RichText);

                        DocumentIsSaved = true;
                        openedFilePath = dialog.FileName;
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("ERROR - Failed to save file!");

                        Debug.WriteLine($"++++ ERROR - Failed to save file! See more in Stack Trace: {ex.StackTrace}\n\n" +
                            $"See more in Inner Exception: {ex.InnerException}\n\nSee more in Message: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        ///     Meglévő dokumentum mentésekor végrehajtódó metódus.
        ///     Az osztályváltozóban található fájl elérés helyét tároló változóban (openedFilePath)-ben található elérési
        ///     útvonalra elmentjük a fájl tartalmát.
        /// </summary>
        private void ExistingFileSave()
        {
            try
            {
                /// A kiterjesztésnek megfelelően állítjuk be a fájl mentési beállításait.
                notepadRichTextBox.SaveFile(openedFilePath,
                    Path.GetExtension(openedFilePath) == ".txt" ? RichTextBoxStreamType.PlainText : RichTextBoxStreamType.RichText);

                DocumentIsSaved = true;
            }
            catch (IOException ex)
            {
                MessageBox.Show("ERROR - Failed to save file!");

                Debug.WriteLine($"++++ ERROR - Failed to save file! See more in Stack Trace: {ex.StackTrace}\n\n" +
                    $"See more in Inner Exception: {ex.InnerException}\n\nSee more in Message: {ex.Message}");
            }
        }

        /// <summary>
        ///      Az osztályváltozóban meghatározott RichTextBox-on beállítja az alapértelmezett beállításokat.
        ///      - Kiüríti az objektumot.
        ///      - Az új dokumentum mentetlen állapotban lesz.
        ///      - Az objektum betütípus beállításat (szín, méret, stb...)
        /// </summary>
        private void SetNotepadRichTextBoxAndPropertiesDefaultValue()
        {
            notepadRichTextBox.Clear();
            notepadRichTextBox.BackColor = Color.White;
            notepadRichTextBox.Font = new Font("Arial Narrow", 12);
            notepadRichTextBox.ForeColor = Color.Black;

            DocumentIsSaved = null;
            openedFilePath = string.Empty;
        }
        #endregion
    }
}