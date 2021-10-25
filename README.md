# C# - Windows Notepad Replication [Year of Development: 2015, 2019 and 2021]

About the application technologies and operation:

### Technologies:
- Programming Language: C#
- FrontEnd Side: Windows Presentation Foundation (WPF) - .NET 5
- BackEnd Side: .NET 5

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
    - **Find** - Open the 'Find' Sub-Window.
    - **Find Next** - Searches for the following snippet based on the search criteria specified in 'Find' Sub-Window.
    - **Replace** - Open the 'Replace' Sub-Window.
    - **Go to line** - Open the 'Go to line' Sub-Window.
    - **Select All** - Select the entire contents of the document.
    - **Time/Date** - Inserts the current date and time into the document.

3. Format Menu:
    - **Fonts** - Sets the selected font settings for the document.
    - **Background Color** - Sets the background color selected for the document.
    - **Word-Wrap** - Adjusts the line break in the document and that the horizontal scroll-bar disappears or appears.

4. Help Menu:
    - **About** - Open the 'About' Sub-Window.

5. Right mouse button in the document:
    - **Redo** - Performs an action advance on the document. 
    - **Undo** - Performs an undo operation on the document.
    - **Cut** - Place selected text on the clipboard. Removes the selected text from the document.
    - **Copy** - Copy selected text to the clipboard. The selected text will not be removed from the document.
    - **Paste** - Paste the selected text from the clipboard.
    - **Delete** - Removes the selected text from the document.
    - **Select All** - Select the entire contents of the document.

6. 'Search' Sub-Window:
    - **Find what** - The text to search for.
    - **Direction** - Search forwards or backwards in the text relative to the cursor position.
    - **Match case** - Distinguish between upper and lower case letters during the search.
    - **Find next** - Search for the text you want to search for, based on user-defined search criteria.
    - **Cancel** - Close the window.

7. 'Replace' Sub-Window:
    - **Find what**: Text to replace.
    - **Replace with**: The replacement text.
    - **Match case** - Distinguish between upper and lower case letters during the search.
    - **Find next** - Search for the text you want to search for, based on user-defined search criteria.
    - **Replace** - Replace found text with user-defined text.
    - **Replace All** - Finds the user-specified text snippet in the document and replaces it with the user-specified text to replace.
    - **Cancel** - Close the window.

8. 'Go to line' Sub-Window:
    - **Line Number** - Move the cursor to the line in the document.
    - **Go to** - Jumps to the specified sequence number.
    - **Cancel** - Close the window.
