namespace RandomPasswordGenerator.Forms
{
	partial class FrmSelectCharacters
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btnSave = new Button();
			lvwCharacterPicker = new ListView();
			btnSelectAll = new Button();
			btnSelectNone = new Button();
			SuspendLayout();
			// 
			// btnSave
			// 
			btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			btnSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnSave.BackColor = SystemColors.HotTrack;
			btnSave.FlatStyle = FlatStyle.Popup;
			btnSave.ForeColor = Color.White;
			btnSave.Location = new Point(15, 377);
			btnSave.Margin = new Padding(3, 15, 3, 5);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(548, 50);
			btnSave.TabIndex = 1;
			btnSave.Text = "Confirm";
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += BtnSave_Click;
			// 
			// lvwCharacterPicker
			// 
			lvwCharacterPicker.Alignment = ListViewAlignment.SnapToGrid;
			lvwCharacterPicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lvwCharacterPicker.BorderStyle = BorderStyle.None;
			lvwCharacterPicker.CausesValidation = false;
			lvwCharacterPicker.CheckBoxes = true;
			lvwCharacterPicker.Cursor = Cursors.Hand;
			lvwCharacterPicker.GridLines = true;
			lvwCharacterPicker.HeaderStyle = ColumnHeaderStyle.None;
			lvwCharacterPicker.Location = new Point(15, 15);
			lvwCharacterPicker.Name = "lvwCharacterPicker";
			lvwCharacterPicker.Size = new Size(548, 293);
			lvwCharacterPicker.TabIndex = 2;
			lvwCharacterPicker.UseCompatibleStateImageBehavior = false;
			lvwCharacterPicker.View = View.SmallIcon;
			// 
			// btnSelectAll
			// 
			btnSelectAll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			btnSelectAll.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnSelectAll.BackColor = Color.FromArgb(50, 50, 50);
			btnSelectAll.CausesValidation = false;
			btnSelectAll.FlatStyle = FlatStyle.Popup;
			btnSelectAll.ForeColor = SystemColors.ControlDark;
			btnSelectAll.Location = new Point(15, 314);
			btnSelectAll.Name = "btnSelectAll";
			btnSelectAll.Size = new Size(273, 45);
			btnSelectAll.TabIndex = 3;
			btnSelectAll.Text = "Select all";
			btnSelectAll.UseVisualStyleBackColor = false;
			btnSelectAll.Click += BtnSelectAll_Click;
			// 
			// btnSelectNone
			// 
			btnSelectNone.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			btnSelectNone.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnSelectNone.BackColor = Color.FromArgb(50, 50, 50);
			btnSelectNone.CausesValidation = false;
			btnSelectNone.FlatStyle = FlatStyle.Popup;
			btnSelectNone.ForeColor = SystemColors.ControlDark;
			btnSelectNone.Location = new Point(290, 314);
			btnSelectNone.Name = "btnSelectNone";
			btnSelectNone.Size = new Size(273, 45);
			btnSelectNone.TabIndex = 4;
			btnSelectNone.Text = "Select none";
			btnSelectNone.UseVisualStyleBackColor = false;
			btnSelectNone.Click += BtnSelectNone_Click;
			// 
			// FrmSelectCharacters
			// 
			AutoScaleMode = AutoScaleMode.Inherit;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			AutoValidate = AutoValidate.Disable;
			BackColor = Color.FromArgb(25, 25, 25);
			CausesValidation = false;
			ClientSize = new Size(578, 444);
			Controls.Add(btnSelectNone);
			Controls.Add(btnSelectAll);
			Controls.Add(lvwCharacterPicker);
			Controls.Add(btnSave);
			Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FrmSelectCharacters";
			Padding = new Padding(12);
			ShowIcon = false;
			ShowInTaskbar = false;
			SizeGripStyle = SizeGripStyle.Hide;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Select Characters...";
			TopMost = true;
			Load += FrmSelectCharacters_Load;
			ResumeLayout(false);
		}

		#endregion
		private Button btnSave;
		private ListView lvwCharacterPicker;
		private Button btnSelectAll;
		private Button btnSelectNone;
	}
}