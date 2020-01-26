using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Notepad.Logic
{
    public class NotepadLogic
    {
        #region CLASS VARIABLES AND PROPERTIES

        private readonly RichTextBox _notepadRichTextBox;

        private string _openedFilePath;

        public bool? DocumentIsSaved { get; set; }

        #endregion
        
        /// <summary>
        ///     Konstruktor
        /// </summary>
        public NotepadLogic(RichTextBox notepadRichTextBox)
        {
            _notepadRichTextBox = notepadRichTextBox ?? throw new ArgumentNullException(nameof(notepadRichTextBox));

            SetNotepadRichTextBoxAndPropertiesDefaultValue();
        }

        #region PUBLIC Methods

        /// <summary>
        ///     Az osztályváltozóban meghatározott RichTextBox-on egy Visszavonást (Undo-t) 
        ///     hajt végre.
        /// </summary>
        public void Undo()
        {
            _notepadRichTextBox.Undo();
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
            _notepadRichTextBox.Redo();

            return _notepadRichTextBox.CanRedo;
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
            Clipboard.SetText(_notepadRichTextBox.SelectedText);

            if (isCut)
            {
                _notepadRichTextBox.SelectedText = string.Empty;
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
                _notepadRichTextBox.SelectedText = Clipboard.GetText();
            }
        }

        /// <summary>
        ///     Az osztályváltozóban meghatározott RichTextBox-on található kijelölt szövegrészt
        ///     eltávolítja az objektumból.
        /// </summary>
        public void Delete()
        {
            _notepadRichTextBox.SelectedText = string.Empty;
        }

        /// <summary>
        ///     Az osztályváltozóban meghatározott RichTextBox-on található összes szövegrészt
        ///     kijelöli.
        /// </summary>
        public void SelectAll()
        {
            _notepadRichTextBox.SelectAll();
        }

        /// <summary>
        ///     Az osztályváltozóban meghatározott RichTextBox-on található, az aktuálisan elhelyezkedő
        ///     kurzur helyzetébe beszúrja az aktuális Időt.
        /// </summary>
        public void PutDateTime()
        {
            _notepadRichTextBox.SelectedText = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     Az osztályváltozóban meghatározott RichTextBox-on beállítja a SOR TÖRÉST.
        /// </summary>
        /// <param name="isWordWrap">
        ///     Meghatározza, hogy az osztályváltozó objektumán, be kell-e állítani a SORTÖRÉST.
        /// </param>
        public void SetWordWrap(bool isWordWrap)
        {
            _notepadRichTextBox.WordWrap = isWordWrap;
        }

        /// <summary>
        ///     Új dokumentum inicializálását végrehajtó metódus.
        /// </summary>
        public void NewDocument()
        {
            if (DocumentIsSaved == false)
            {
                DialogResult result = MessageBox.Show(@"The file is not saved. Do you want to save?", @"New Document",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                switch (result)
                {
                    case DialogResult.Yes:
                    {
                        if (_openedFilePath.Equals(string.Empty))
                        {
                            NewFileSave();
                        }
                        else
                        {
                            ExistingFileSave();
                        }

                        SetNotepadRichTextBoxAndPropertiesDefaultValue();
                        break;
                    }
                    case DialogResult.No:
                        SetNotepadRichTextBoxAndPropertiesDefaultValue();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($@"Switching Type is not exists this method: {nameof(NewDocument)}!");
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
                dialog.Filter = @"Text File (*txt)|*.txt|Rich Text Format (*rtf)|*.rtf|All File (*.*)|*.*";
                
                if(dialog.ShowDialog() == DialogResult.OK && !dialog.FileName.Equals(string.Empty))
                {
                    try
                    {
                        _notepadRichTextBox.LoadFile(dialog.FileName, dialog.FileName.Contains(".rtf")
                                ? RichTextBoxStreamType.RichText
                                : RichTextBoxStreamType.PlainText);

                        DocumentIsSaved = true;
                        _openedFilePath = dialog.FileName;
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(@"ERROR - Failed to open file!");

                        Debug.WriteLine($"++++ ERROR - Failed to open file! See more in Stack Trace: {ex.StackTrace}\n\n" +
                            $"See more in Inner Exception: {ex.InnerException}\n\nSee more in Message: {ex.Message}");

                        SetNotepadRichTextBoxAndPropertiesDefaultValue();
                    }
                }
            }

            return Path.GetFileName(_openedFilePath);
        }

        /// <summary>
        ///     A dokumentum mentését végrehajtó metódus.
        /// </summary>
        /// <param name="isSaveAsOperation">
        ///     Logikai paraméter, amely meghatározza, hogy Mentés Másként parancsot szeretnénk végrehajtani, vagy csak sima mentést.
        /// </param>
        /// <returns>
        ///     Az elmentett dokumentum neve.
        /// </returns>
        public string SaveDocument(bool isSaveAsOperation)
        {
            if(isSaveAsOperation)
            {
                NewFileSave();
            }
            else
            {
                if(_openedFilePath.Equals(string.Empty))
                {
                    NewFileSave();
                }
                else
                {
                    ExistingFileSave();
                }
            }

            return Path.GetFileName(_openedFilePath);
        }

        /// <summary>
        ///     Az alkalmazás bezárását végrehajtó metódus.
        /// </summary>
        public void Exit()
        {
            if (DocumentIsSaved == false)
            {
                DialogResult result = MessageBox.Show(@"The file is not saved. Do you want to save?", @"Exit",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                switch (result)
                {
                    case DialogResult.Yes when _openedFilePath.Equals(string.Empty):
                        NewFileSave();
                        break;
                    case DialogResult.Yes:
                        ExistingFileSave();
                        break;
                    case DialogResult.No:
                        Application.Exit();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($@"Switching Type is not exists this method: {nameof(Exit)}!");
                }
            }

            Application.Exit();
        }
        
        /// <summary>
        ///     Metódus amely megváltoztatja a betűtípus beállításait (Betűtípus, méret, stb...) és betűszín beállításait.
        /// </summary>
        public void FontChange()
        {
            using (FontDialog dialog = new FontDialog())
            {
                dialog.ShowColor = true;
                
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    if(_notepadRichTextBox.SelectedText.Length > 0)
                    {
                        _notepadRichTextBox.SelectionFont = dialog.Font;
                        _notepadRichTextBox.SelectionColor = dialog.Color;
                    }
                    else
                    {
                        _notepadRichTextBox.Font = dialog.Font;
                        _notepadRichTextBox.ForeColor = dialog.Color;
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
                    _notepadRichTextBox.BackColor = dialog.Color;
                }
            }
        }
        
        /// <summary>
        ///     Metódus amely megváltoztatja az INPUT beviteli mezőben kijelölt szövegrész háttérszínét.
        /// </summary>
        public void HighlightingColorChange()
        {
            if(_notepadRichTextBox.SelectedText.Length > 0)
            {
                using (ColorDialog dialog = new ColorDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        _notepadRichTextBox.SelectionBackColor = dialog.Color;
                    }
                }
            }
        }

        #endregion

        #region PRIVATE HELPER Methods

        /// <summary>
        ///     Új dokumentum mentésekor végrehajtódó metódus.
        /// </summary>
        private void NewFileSave()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = @"Text File (*txt)|*.txt|Rich Text Formátum (*rtf)|*.rtf";

                if (dialog.ShowDialog() == DialogResult.OK && !dialog.FileName.Equals(string.Empty))
                {
                    try
                    {
                        _notepadRichTextBox.SaveFile(dialog.FileName,
                            Path.GetExtension(dialog.FileName) == ".txt" ? RichTextBoxStreamType.PlainText : RichTextBoxStreamType.RichText);

                        DocumentIsSaved = true;
                        _openedFilePath = dialog.FileName;
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(@"ERROR - Failed to save file!");

                        Debug.WriteLine($"++++ ERROR - Failed to save file! See more in Stack Trace: {ex.StackTrace}\n\n" +
                            $"See more in Inner Exception: {ex.InnerException}\n\nSee more in Message: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        ///     Meglévő dokumentum mentésekor végrehajtódó metódus.
        /// </summary>
        private void ExistingFileSave()
        {
            try
            {
                _notepadRichTextBox.SaveFile(_openedFilePath,
                    Path.GetExtension(_openedFilePath) == ".txt" ? RichTextBoxStreamType.PlainText : RichTextBoxStreamType.RichText);

                DocumentIsSaved = true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(@"ERROR - Failed to save file!");

                Debug.WriteLine($"++++ ERROR - Failed to save file! See more in Stack Trace: {ex.StackTrace}\n\n" +
                    $"See more in Inner Exception: {ex.InnerException}\n\nSee more in Message: {ex.Message}");
            }
        }

        /// <summary>
        ///      Az osztályváltozóban meghatározott RichTextBox-on beállítja az alapértelmezett beállításokat.
        /// </summary>
        private void SetNotepadRichTextBoxAndPropertiesDefaultValue()
        {
            _notepadRichTextBox.Clear();
            _notepadRichTextBox.BackColor = Color.White;
            _notepadRichTextBox.Font = new Font("Arial Narrow", 12);
            _notepadRichTextBox.ForeColor = Color.Black;

            DocumentIsSaved = null;
            _openedFilePath = string.Empty;
        }
        #endregion
    }
}