namespace RandomPasswordGenerator.Forms
{
	/// <summary>Represents a form for selecting characters.</summary>
	public partial class FrmSelectCharacters : Form
	{
		/// <summary>Gets the selected characters as a string.</summary>
		public string SelectedCharacters
		{
			get => new(_selectedCharacters);
		}

		/// <summary>
		/// Gets or sets the base characters. These represent all the possible special characters to
		/// select from, so it's used to fill the selector's list.
		/// </summary>
		private readonly char[] _baseCharacters;

		/// <summary>Gets or sets the selected characters. These represent the user's selection.</summary>
		private char[] _selectedCharacters;

		/// <summary>
		/// Initializes a new instance of the <see cref="FrmSelectCharacters"/> class with base and
		/// selected characters as strings.
		/// </summary>
		/// <param name="baseCharacters">The base characters.</param>
		/// <param name="selectedCharacters">The selected characters.</param>
		public FrmSelectCharacters(string baseCharacters, string selectedCharacters)
		{
			InitializeComponent();
			_baseCharacters = baseCharacters?.ToCharArray() ?? Array.Empty<char>();
			_selectedCharacters = selectedCharacters?.ToCharArray() ?? Array.Empty<char>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FrmSelectCharacters"/> class with base and
		/// selected characters as arrays.
		/// </summary>
		/// <param name="baseCharacters">The base characters.</param>
		/// <param name="selectedCharacters">The selected characters.</param>
		public FrmSelectCharacters(char[] baseCharacters, char[] selectedCharacters)
		{
			InitializeComponent();
			_baseCharacters = baseCharacters;
			_selectedCharacters = selectedCharacters;
		}

		/// <summary>Handles the Click event of the Save button.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void BtnSave_Click(object sender, EventArgs e)
		{
			List<char> selectedCharacters = new();

			foreach (ListViewItem item in lvwCharacterPicker.Items)
			{
				if (item.Checked)
				{
					char c = item.Text[0];
					selectedCharacters.Add(c);
				}
			}

			_selectedCharacters = selectedCharacters.ToArray();

			DialogResult = DialogResult.OK;
		}

		/// <summary>Handles the Click event of the Select All button.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void BtnSelectAll_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in lvwCharacterPicker.Items)
			{
				item.Checked = true;
			}
		}

		/// <summary>Handles the Click event of the Select None button.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void BtnSelectNone_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in lvwCharacterPicker.Items)
			{
				item.Checked = false;
			}
		}

		/// <summary>Handles the Load event of the FrmSelectCharacters form.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void FrmSelectCharacters_Load(object sender, EventArgs e)
		{
			foreach (char c in _baseCharacters)
			{
				var item = lvwCharacterPicker.Items.Add(c.ToString());
				if (_selectedCharacters.Contains(c))
				{
					item.Checked = true;
				}
			}
		}
	}
}