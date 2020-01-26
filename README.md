# C# - Windows Notepad Replication [Year of Development: 2015 and 2019]

About the application technologies and operation:

### Technologies:
- Programming Language: C#
- FrontEnd Side: Windows Forms Application (WinForms)
- BackEnd Side: .NET Framework 4.7.2.

### Installation/ Configuration:

1. Restore necessary Packages, run the following command in **PM Console**

   ```
   Update-Package -reinstall
   ```
 
### About the application:

The following application represents **Notepad** in Windows along with it's features.

Application structure:

1. File Menu:
    - **New Document** - You can create a new document. If you already have a started document, you can save it before you create a new document.
    - **Open** - Open an existing document. If you already have a started document, you can save it before you open an existing document.
    - **Save** - You can save your created document. If the document has not been saved yet, you will need to select, through a dialog box, where and under what name the file should be saved. When this is done, clicking the Save Button always saves it in the same file.
    - **Save As** - You can save your created document to another location and file name.
    - **Exit** - Close the application.

2. Edit Menu:
    - **Redo** - Performs an action advance on the document. 
    - **Undo** - Performs an undo operation on the document.
    - **Cut** - Place selected text on the clipboard. Removes the selected text from the document.
    - **Copy** - Copy selected text to the clipboard. The selected text will not be removed from the document.
    - **Paste** - Paste the selected text from the clipboard.
    - **Delete** - Removes the selected text from the document.
    - **Search** - Open the Search Sub-Window.
    - **Find Next** - Searches for the following snippet based on the search criteria specified in Search Sub-Window.
    - **Replace** - Open the Replace Sub-Window.
    - **Jump** - Open the Jump Sub-Window.
    - **Select All** - Select the entire contents of the document.
    - **Time/Date** - Inserts the current date and time into the document.

3. Format Menu:
    - **Word-Wrap** - Adjusts the line break in the document and that the horizontal scroll-bar disappears.
    - **Font** - Sets the selected font settings for the document. If there is selected text, the selected font will be set to the selected text.
    - **Background Color** - Sets the background color selected for the document.
    - **Highlighting** - Sets the background color (Highlighting function) of the selected piece of text.

4. Right mouse button in the document:
    - **Redo** - Performs an action advance on the document. 
    - **Undo** - Performs an undo operation on the document.
    - **Cut** - Place selected text on the clipboard. Removes the selected text from the document.
    - **Copy** - Copy selected text to the clipboard. The selected text will not be removed from the document.
    - **Paste** - Paste the selected text from the clipboard.
    - **Delete** - Removes the selected text from the document.
    - **Select All** - Select the entire contents of the document.

5. Search Sub-Window:
    - **Search Text** - The text to search for.
    - **Direction** - Search forwards or backwards in the text relative to the cursor position.
    - **Small- Large Letter** - Distinguish between upper and lower case letters during the search.
    - **Next Button** - Search for the text you want to search for, based on user-defined search criteria.
    - **Back Button** - Close the window.

6. Replace Sub-Window:
    - **Search Terms**: Text to replace.
    - **Replacement expression**: The replacement text.
    - **Small- Large Letter** - Distinguish between upper and lower case letters during the search.
    - **Next Button** - Search for the text you want to search for, based on user-defined search criteria.
    - **Replace Button** - Replace found text with user-defined text.
    - **Replace All Button** - Finds the user-specified text snippet in the document and replaces it with the user-specified text to replace.
    - **Back Button** - Close the window.

7. Jump Sub-Window:
    - **Line Number** - Move the cursor to the line in the document.
    - **Jump Button** - Jumps to the specified sequence number.
    - **Back Button** - Close the window.
