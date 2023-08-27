using RandomPasswordGenerator.Core;
using ROCFramework_Core.Enums;
using ROCFramework_Core.Extensions.Enum;

namespace RandomPasswordGenerator.Forms
{
	/// <summary>Represents a partial class for the password generator form.</summary>
	public partial class FrmGenerator : Form
	{
		//private const int EM_GETLINECOUNT = 0xba; // Get the line count
		//private const int EM_SETSEL = 0xB1; // Define the message value

		/// <summary>
		/// Gets a value indicating whether the form is in a valid state to generate a password.
		/// </summary>
		private bool _canGenerate
		{
			get => chkIncludeDigits.Checked || chkIncludeLetters.Checked || (chkIncludeSpecialChars.Checked && lblSpecialChars.Text.Length > 0);
		}

		/// <summary>
		/// Calculates and gets the intercept constant used in the linear equation when calculating
		/// the zoom factor of the result label's text.
		/// </summary>
		private float _zoomFactorIntercept
		{
			get => MINIMUM_RESULT_ZOOM_FACTOR - (_zoomFactorSlope * (float)nudPasswordLength.Minimum);
		}

		/// <summary>
		/// Calculates and gets the slope constant used in the linear equation when calculating the
		/// zoom factor of the result label's text.
		/// </summary>
		private float _zoomFactorSlope
		{
			get => (MAXIMUM_RESULT_ZOOM_FACTOR - MINIMUM_RESULT_ZOOM_FACTOR) / ((float)nudPasswordLength.Maximum - (float)nudPasswordLength.Minimum);
		}

		/// <summary>The default font size for the result label.</summary>
		private const float DEFAULT_RESULT_LABEL_FONT_SIZE = 14;

		/// <summary>The maximum zoom factor for the result label.</summary>
		private const float MAXIMUM_RESULT_ZOOM_FACTOR = 0.98f;

		/// <summary>
		/// The message displayed when attempting to generate a password without selecting options.
		/// </summary>
		private const string MESSAGE_GENERATE_PASSWORD_FIRST = "You must generate a password first!";

		/// <summary>The message displayed when the selected options state is invalid.</summary>
		private const string MESSAGE_INVALID_OPTIONS_STATE = "You must select one or more options above!";

		/// <summary>The default idle message for the result label.</summary>
		private const string MESSAGE_RESULT_TEXT_IDLE = "Click the 'Generate Password' button below";

		/// <summary>The minimum zoom factor for the result label.</summary>
		private const float MINIMUM_RESULT_ZOOM_FACTOR = 0.6f;

		/// <summary>The color used to indicate failure.</summary>
		private readonly Color _failureColor = Color.Red;

		/// <summary>The password generator instance.</summary>
		private readonly PasswordGenerator _passwordGenerator;

		/// <summary>The primary color used.</summary>
		private readonly Color _primaryColor = Color.FromKnownColor(KnownColor.Highlight);

		/// <summary>The color used to indicate success.</summary>
		private readonly Color _successColor = Color.Green;

		/// <summary>The counter for the idle state of the snack bar.</summary>
		private int _snackBarIdleCounter = 0;

		/// <summary>The action associated with the snack bar timer.</summary>
		private string _snackBarTimerAction = string.Empty;

		/// <summary>Initializes a new instance of the FrmGenerator class.</summary>
		public FrmGenerator()
		{
			InitializeComponent();

			_passwordGenerator = new();
		}

		// The following 2 lines were left here because they were previously used when for a textbox
		// rather than a label.
		/*[DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern int SendMessage(int hWnd, int wMsg, int wParam, int lParam);*/

		/// <summary>Converts the casing option to its corresponding title.</summary>
		/// <param name="selection">The casing option.</param>
		/// <returns>The title corresponding to the casing option.</returns>
		private static string CasingOptionToTitle(LetterCasingOptions selection)
		{
			return selection switch
			{
				LetterCasingOptions.UpperLower => "Upper and Lower Case",
				LetterCasingOptions.UpperOnly => "Upper Case only",
				LetterCasingOptions.LowerOnly => "Lower Case only",
				_ => "Unknown",
			};
		}

		/// <summary>Converts the casing title to its corresponding enum name.</summary>
		/// <param name="title">The casing title.</param>
		/// <returns>The enum name corresponding to the casing title.</returns>
		private static string CasingTitleToEnumName(string title)
		{
			return title switch
			{
				"Upper and Lower Case" => "UpperLower",
				"Upper Case only" => "UpperOnly",
				"Lower Case only" => "LowerOnly",
				_ => throw new ArgumentOutOfRangeException(nameof(title), $"The value '{title}' is not a member of the enum")
			};
		}

		/// <summary>Handles the click event of the Generate button.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void BtnGenerate_Click(object sender, EventArgs e)
		{
			try
			{
				if (_passwordGenerator.IsOptionStateInvalid)
				{
					lblResult.ForeColor = _failureColor;
					lblResult.Text = MESSAGE_INVALID_OPTIONS_STATE;
					_passwordGenerator.ResetPassword();
				}
				else
				{
					lblResult.ForeColor = _successColor;
					lblResult.Text = _passwordGenerator.GeneratePassword();
					btnGenerate.Focus();
				}
			}
			catch (Exception ex) // Exception might be coming from PasswordGenerator.OnPasswordGenerationException
			{
				throw new Exception(ex.Message);
			}
		}

		/// <summary>Handles the click event of the special characters selector button.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void BtnSelectSpecialCharacters_Click(object sender, EventArgs e)
		{
			using FrmSelectCharacters characterSelectionForm = new(PasswordGenerator.DEFAULT_SPECIAL, _passwordGenerator.SelectedSpecialCharacters);
			DialogResult result = characterSelectionForm.ShowDialog();
			if (result == DialogResult.OK)
			{
				lblSpecialChars.Text = characterSelectionForm.SelectedCharacters;
				LblSpecialChars_TextChanged(lblSpecialChars, null);
			}
		}

		/// <summary>Handles the click event of the Copy To Clipboard button.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void BtnToClipboard_Click(object sender, EventArgs e)
		{
			string[] messages = new string[] {
				MESSAGE_GENERATE_PASSWORD_FIRST,
				MESSAGE_INVALID_OPTIONS_STATE,
				MESSAGE_RESULT_TEXT_IDLE
			};

			if (_passwordGenerator.IsPasswordGenerated || !messages.Contains(lblResult.Text))
			{
				Clipboard.SetText(lblResult.Text);
				if (Clipboard.GetText() == lblResult.Text)
				{
					ShowSnackbar("Password Saved to Clipboard!");
					lblResult.Focus();
				}
			}
			else
			{
				lblResult.ForeColor = _failureColor;
				lblResult.Text = MESSAGE_GENERATE_PASSWORD_FIRST;
			}
		}

		/// <summary>Handles the MouseHover event of the Copy To Clipboard button.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void BtnToClipboard_MouseHover(object sender, EventArgs e)
		{
			btnToClipboard.ForeColor = btnGenerate.BackColor;
		}

		/// <summary>Handles the MouseLeave event of the Copy To Clipboard button.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void BtnToClipboard_MouseLeave(object sender, EventArgs e)
		{
			btnToClipboard.ForeColor = stalblAuthor.ForeColor;
		}

		/// <summary>Handles the SelectedIndexChanged event of the Letter Format combo box.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void CboLetterFormat_SelectedIndexChanged(object sender, EventArgs e)
		{
			_passwordGenerator.SetLetterCasing(Enums.ParseEnum<LetterCasingOptions>(CasingTitleToEnumName(cboLetterCasing.SelectedItem.ToString())));
		}

		/// <summary>Handles the CheckedChanged event of the Include Digits checkbox.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void ChkIncludeDigits_CheckedChanged(object sender, EventArgs e)
		{
			_passwordGenerator.SetIncludeDigits(chkIncludeDigits.CheckState == CheckState.Checked);
			SetPasswordLengthMinimum();
			btnGenerate.Enabled = _canGenerate;
		}

		/// <summary>Handles the CheckedChanged event of the Include Letters checkbox.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void ChkIncludeLetters_CheckedChanged(object sender, EventArgs e)
		{
			_passwordGenerator.SetIncludeLetters(chkIncludeLetters.CheckState == CheckState.Checked);
			cboLetterCasing.Enabled = _passwordGenerator.IncludeLetters;
			SetPasswordLengthMinimum();
			btnGenerate.Enabled = _canGenerate;
		}

		/// <summary>Handles the CheckedChanged event of the Include Special Characters checkbox.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void ChkIncludeSpecialCharacters_CheckedChanged(object sender, EventArgs e)
		{
			_passwordGenerator.SetIncludeSpecialCharacters(chkIncludeSpecialChars.CheckState == CheckState.Checked);
			lblSpecialChars.Enabled = _passwordGenerator.IncludeSpecialCharacters;
			SetPasswordLengthMinimum();
			btnGenerate.Enabled = _canGenerate;

			if (chkIncludeSpecialChars.Checked)
			{
				if (string.IsNullOrEmpty(_passwordGenerator.SelectedSpecialCharacters))
					_passwordGenerator.SetAllowedSpecialCharacters();
				lblSpecialChars.Text = _passwordGenerator.SelectedSpecialCharacters;
			}
		}

		/// <summary>Handles the Load event of the FrmGenerator form.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void FrmGenerator_Load(object sender, EventArgs e)
		{
			ResetOptionsToDefault(true);
			stalblAuthor.Text = $"Version {Program.ApplicationInfo.Version} | {Program.ApplicationInfo.Copyright} {Program.ApplicationInfo.Author}";
		}

		/// <summary>Handles the SizeChanged event of the FrmGenerator form.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void FrmGenerator_SizeChanged(object sender, EventArgs e)
		{
			SetSnackbar();
		}

		/// <summary>Handles the TextChanged event of the Result Label.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void LblResult_TextChanged(object sender, EventArgs e)
		{
			SetResultLabelFontSize();
		}

		/// <summary>Handles the TextChanged event of the Special Characters Label.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void LblSpecialChars_TextChanged(object sender, EventArgs e)
		{
			_passwordGenerator.SetAllowedSpecialCharacters(lblSpecialChars.Text);

			bool wasChecked = chkIncludeSpecialChars.Checked;

			chkIncludeSpecialChars.Checked = lblSpecialChars.Text.Length > 0;

			if (wasChecked == chkIncludeSpecialChars.Checked)
			{
				SetPasswordLengthMinimum();
				btnGenerate.Enabled = _canGenerate;
			}
		}

		/// <summary>Handles the ValueChanged event of the Password Length NumericUpDown control.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void NudPasswordLength_ValueChanged(object sender, EventArgs e)
		{
			_passwordGenerator.SetResultLength(Convert.ToInt32(nudPasswordLength.Value));
		}

		/// <summary>Resets the form controls to their default values.</summary>
		/// <returns>True if the controls were successfully reset; otherwise, false.</returns>
		private bool ResetControlsToDefault()
		{
			try
			{
				foreach (LetterCasingOptions option in Enums.GetValues<LetterCasingOptions>())
				{
					cboLetterCasing.Items.Add(CasingOptionToTitle(option));
				}
				cboLetterCasing.SelectedIndex = cboLetterCasing.FindStringExact(CasingOptionToTitle(LetterCasingOptions.UpperLower));
				chkIncludeDigits.Checked = true;
				chkIncludeLetters.Checked = true;
				chkIncludeSpecialChars.Checked = true;
				nudPasswordLength.Value = _passwordGenerator.PotentialMinimumLength;
				lblSpecialChars.Text = PasswordGenerator.DEFAULT_SPECIAL;
				ResetResultLabel();
				SetSnackbar();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}

		/// <summary>Resets the password generator options to their default values.</summary>
		/// <param name="alsoResetControls">
		/// Specifies whether to also reset the form controls to their default values. Default is false.
		/// </param>
		private void ResetOptionsToDefault(bool alsoResetControls = false)
		{
			_passwordGenerator.ResetOptions();
			if (alsoResetControls) ResetControlsToDefault();
		}

		/// <summary>Resets the result label to its default state.</summary>
		private void ResetResultLabel()
		{
			lblResult.ForeColor = _primaryColor;
			//lblResult.Font = new Font(Program.FontCollection.GetFamilyExact("Hack"), DEFAULT_RESULT_LABEL_FONT_SIZE);
			lblResult.Font = new Font(Program.FontCollection.GetFamilyExact("Hack"), DEFAULT_RESULT_LABEL_FONT_SIZE);
			lblResult.Text = MESSAGE_RESULT_TEXT_IDLE;
		}

		/// <summary>
		/// Sets the minimum value for the password length NumericUpDown control based on the
		/// password generator's minimum length.
		/// </summary>
		/// <returns>The minimum value for the password length.</returns>
		private decimal SetPasswordLengthMinimum()
		{
			nudPasswordLength.Minimum = _passwordGenerator.PotentialMinimumLength;
			return nudPasswordLength.Minimum;
		}

		/// <summary>
		/// <para>
		/// Sets the size of the result label font using a linear equation to calculate its proper
		/// size, based on the label's dimesions and text length.
		/// </para>
		/// <h4>Other members involved:</h4><br/><seealso cref="_zoomFactorIntercept"/><br/><seealso cref="_zoomFactorSlope"/>
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
		private void SetResultLabelFontSize()
		{
			using Graphics g = this.CreateGraphics();
			float currentFontSize = lblResult.Font.Size;
			SizeF textSize = g.MeasureString(lblResult.Text, lblResult.Font);

			float heightRatio = lblResult.Height / textSize.Height;
			float widthRatio = lblResult.Width / textSize.Width;

			float finalRatio = Math.Min(heightRatio, widthRatio);

			float newFontSize = currentFontSize * finalRatio;
			float zoomFactor = ((_zoomFactorSlope * lblResult.Text.Length) + _zoomFactorIntercept); // The result from a linear equation.
			newFontSize *= zoomFactor;

			lblResult.Font = new Font(Program.FontCollection.GetFamilyExact("Hack"), newFontSize);
		}

		/// <summary>Sets the position of the snackbar control.</summary>
		private void SetSnackbar()
		{
			snackbar.Top = snackbar.Height * -1;
			snackbar.Left = (Width - snackbar.Width) / 2;
		}

		/// <summary>Displays a snackbar with the specified message.</summary>
		/// <param name="message">The message to display in the snackbar.</param>
		private void ShowSnackbar(string message)
		{
			snackbar.Text = message;
			snackbar.Top = snackbar.Height * -1;
			_snackBarTimerAction = "show";
			snackTimer.Start();
		}

		/// <summary>Handles the Tick event of the SnackTimer control.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The EventArgs instance containing the event data.</param>
		private void SnackTimer_Tick(object sender, EventArgs e)
		{
			snackbar.Left = (Width - snackbar.Width) / 2;
			switch (_snackBarTimerAction)
			{
				case "show":
					if (snackbar.Top < 0)
					{
						snackbar.Top += 3;
					}
					else { _snackBarTimerAction = "pause"; }
					break;

				case "pause":
					_snackBarIdleCounter++;
					if (_snackBarIdleCounter >= 100) // 1 second
					{
						_snackBarTimerAction = "hide";
					}
					break;

				case "hide":
					if (snackbar.Top != snackbar.Height * -1)
					{
						snackbar.Top -= 3;
					}
					else { _snackBarIdleCounter = 0; snackTimer.Stop(); }
					break;
			}
		}

		/*
		 * LEFT THESE METHODS HERE AS BACKUP. ONE OF THEM SHOWS HOW TO GET THE CURRENT TEXT LINES IN A TEXTBOX
		private void TxtResult_TextChanged(object sender, EventArgs e)
		{
			var textbox = sender as TextBox;
			var numberOfLines = SendMessage(textbox.Handle.ToInt32(), EM_GETLINECOUNT, 0, 0);
			textbox.Height = (textbox.Font.Height + 5) * numberOfLines;
		}

		private void TxtSpecialChars_KeyPress(object sender, KeyPressEventArgs e)
		{
			var textbox = sender as TextBox;
			var character = e.KeyChar;
			bool supportedCharacterEntered = PasswordGenerator.DEFAULT_SPECIAL.Contains(character);
			bool textBoxAlreadyContainsCharacter = textbox.Text.Contains(character);

			if (!char.IsControl(character) && (!supportedCharacterEntered || textBoxAlreadyContainsCharacter))
				e.Handled = true;
		}
		*/
	}
}