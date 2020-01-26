using Notepad.Logic;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Notepad.Windows
{
    public partial class JumpWindow : Form
	{
        private readonly JumpLogic _jumpLogic;

        /// <summary>
        ///     Konstruktor.
        /// </summary>
        /// <param name="jumpLogic">
        ///     Az üzleti logikát megvalósító objektum. Ez az objektum a Notepad FORM-ban
        ///     kerül legelőször példányosításra, így további műveleteket hajthatunk végre a RichTextBox-on.
        /// </param>
        public JumpWindow(JumpLogic jumpLogic)
		{
			InitializeComponent();

            _jumpLogic = jumpLogic ?? throw new ArgumentNullException(nameof(jumpLogic));
		}

        #region Events

        /// <summary>
        ///     CLICK EVENT - Esemény, amely akkor fut le, ha valamelyik gombot megnyomjuk a SEARCH Window
        ///     felületen.
        /// </summary>
        private void Buttons_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Tag)
            {
                case "Back":
                    CloseWindow();
                    break;
                case "Jump":
                    LineJump();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($@"Switching Type is not exists this method: {nameof(Buttons_Click)}!");
            }
        }

        /// <summary>
        ///     TEXT CHANGE EVENT - Az esemény akkor fut le, amikor az INPUT beviteli mezőben található értéket
        ///     módosítjuk. Figyelünk arra, hogy soha ne legyen üres ez a mező.
        /// </summary>
        private void LineNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (lineNumberTextBox.Text.Length < 0)
            {
                lineNumberTextBox.Text = @"1";
            }
        }

        #endregion

        #region PRIVATE Helper Methods

        /// <summary>
        ///     Az INPUT beviteli mezőben meghatározott sorszámú sorra való ugrásért felelős metódus. 
        ///     A metódus lekezeli a kivételeket, illetve csak EGÉSZ SZÁM bevitelét engedélyezi.
        /// </summary>
        private void LineJump()
        {
            try
            {
                int lineNumber = int.Parse(lineNumberTextBox.Text);
                
                if(lineNumber < 0)
                {
                    MessageBox.Show(@"The sequence number must be at least 1!", @"Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if(_jumpLogic.Jump(lineNumber))
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(@"The sequence number cannot contain characters!", @"Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lineNumberTextBox.Text = _jumpLogic.GetRichTextBoxLineNumbers().ToString();
                    }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(@"The sequence number cannot contain characters!", @"Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Debug.WriteLine($"++++ ERROR - The sequence number cannot contain characters! See more in Stack Trace: {ex.StackTrace}\n\n" +
                    $"See more in Inner Exception: {ex.InnerException}\n\nSee more in Message: {ex.Message}");
            }
        }

        /// <summary>
        ///     A SEARCH Window felület bezárásáért felelős metódus.
        /// </summary>
        private void CloseWindow()
        {
            Close();
        }

        #endregion
    }
}
