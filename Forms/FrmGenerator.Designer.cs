namespace RandomPasswordGenerator.Forms
{
	partial class FrmGenerator
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenerator));
			btnGenerate = new Button();
			btnToClipboard = new Button();
			staStrip = new StatusStrip();
			stalblAuthor = new ToolStripStatusLabel();
			snackTimer = new System.Windows.Forms.Timer(components);
			snackbar = new Label();
			lblResult = new Label();
			lblSpecialChars = new Label();
			btnSelectSpecialCharacters = new Button();
			nudPasswordLength = new NumericUpDown();
			chkIncludeSpecialChars = new CheckBox();
			lblPwdLen = new Label();
			chkIncludeDigits = new CheckBox();
			chkIncludeLetters = new CheckBox();
			cboLetterCasing = new ComboBox();
			groupBox1 = new GroupBox();
			staStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudPasswordLength).BeginInit();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// btnGenerate
			// 
			btnGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			btnGenerate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnGenerate.BackColor = SystemColors.HotTrack;
			btnGenerate.Cursor = Cursors.Hand;
			btnGenerate.FlatStyle = FlatStyle.Popup;
			btnGenerate.Font = new Font("Arial", 16F, FontStyle.Regular, GraphicsUnit.Point);
			btnGenerate.ForeColor = Color.White;
			btnGenerate.Location = new Point(19, 588);
			btnGenerate.Margin = new Padding(4, 10, 4, 10);
			btnGenerate.MaximumSize = new Size(1136, 67);
			btnGenerate.MinimumSize = new Size(1136, 67);
			btnGenerate.Name = "btnGenerate";
			btnGenerate.Size = new Size(1136, 67);
			btnGenerate.TabIndex = 7;
			btnGenerate.Text = "&Generate Random Password";
			btnGenerate.UseVisualStyleBackColor = false;
			btnGenerate.Click += BtnGenerate_Click;
			// 
			// btnToClipboard
			// 
			btnToClipboard.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnToClipboard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnToClipboard.Cursor = Cursors.Hand;
			btnToClipboard.FlatStyle = FlatStyle.Popup;
			btnToClipboard.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btnToClipboard.Location = new Point(975, 395);
			btnToClipboard.Margin = new Padding(4);
			btnToClipboard.MaximumSize = new Size(180, 45);
			btnToClipboard.MinimumSize = new Size(180, 45);
			btnToClipboard.Name = "btnToClipboard";
			btnToClipboard.Size = new Size(180, 45);
			btnToClipboard.TabIndex = 8;
			btnToClipboard.Text = "&Copy to Clipboard";
			btnToClipboard.UseVisualStyleBackColor = true;
			btnToClipboard.Click += BtnToClipboard_Click;
			btnToClipboard.MouseLeave += BtnToClipboard_MouseLeave;
			btnToClipboard.MouseHover += BtnToClipboard_MouseHover;
			// 
			// staStrip
			// 
			staStrip.AutoSize = false;
			staStrip.BackColor = Color.FromArgb(30, 30, 30);
			staStrip.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
			staStrip.ImageScalingSize = new Size(24, 24);
			staStrip.Items.AddRange(new ToolStripItem[] { stalblAuthor });
			staStrip.Location = new Point(0, 665);
			staStrip.Name = "staStrip";
			staStrip.Padding = new Padding(21, 0, 2, 0);
			staStrip.RightToLeft = RightToLeft.Yes;
			staStrip.Size = new Size(1174, 50);
			staStrip.SizingGrip = false;
			staStrip.TabIndex = 8;
			staStrip.Text = "Created by: Arnie González on Jan 14, 2017";
			// 
			// stalblAuthor
			// 
			stalblAuthor.DisplayStyle = ToolStripItemDisplayStyle.Text;
			stalblAuthor.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
			stalblAuthor.Margin = new Padding(0);
			stalblAuthor.Name = "stalblAuthor";
			stalblAuthor.Padding = new Padding(6);
			stalblAuthor.Size = new Size(563, 50);
			stalblAuthor.Text = "Created by:  Arnie González on Jan 14, 2017 | Last Update: October 2020";
			// 
			// snackTimer
			// 
			snackTimer.Interval = 1;
			snackTimer.Tick += SnackTimer_Tick;
			// 
			// snackbar
			// 
			snackbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			snackbar.BackColor = Color.LimeGreen;
			snackbar.ForeColor = Color.White;
			snackbar.Location = new Point(247, 0);
			snackbar.Margin = new Padding(4, 0, 4, 0);
			snackbar.Name = "snackbar";
			snackbar.Size = new Size(680, 80);
			snackbar.TabIndex = 11;
			snackbar.Text = "Password Saved to Clipboard!";
			snackbar.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblResult
			// 
			lblResult.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lblResult.BackColor = Color.FromArgb(30, 30, 30);
			lblResult.BorderStyle = BorderStyle.FixedSingle;
			lblResult.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lblResult.ForeColor = SystemColors.Highlight;
			lblResult.Location = new Point(19, 444);
			lblResult.Margin = new Padding(3, 0, 3, 10);
			lblResult.MaximumSize = new Size(1136, 124);
			lblResult.MinimumSize = new Size(1136, 124);
			lblResult.Name = "lblResult";
			lblResult.Padding = new Padding(6);
			lblResult.Size = new Size(1136, 124);
			lblResult.TabIndex = 6;
			lblResult.Text = "WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW";
			lblResult.TextAlign = ContentAlignment.MiddleCenter;
			lblResult.UseMnemonic = false;
			lblResult.TextChanged += LblResult_TextChanged;
			// 
			// lblSpecialChars
			// 
			lblSpecialChars.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lblSpecialChars.BackColor = Color.FromArgb(50, 50, 50);
			lblSpecialChars.CausesValidation = false;
			lblSpecialChars.FlatStyle = FlatStyle.Popup;
			lblSpecialChars.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblSpecialChars.ForeColor = Color.Silver;
			lblSpecialChars.Location = new Point(602, 232);
			lblSpecialChars.Margin = new Padding(3);
			lblSpecialChars.MaximumSize = new Size(365, 40);
			lblSpecialChars.MinimumSize = new Size(365, 40);
			lblSpecialChars.Name = "lblSpecialChars";
			lblSpecialChars.Size = new Size(365, 40);
			lblSpecialChars.TabIndex = 19;
			lblSpecialChars.Text = "~`!@#$%^&*()_+-={}[]:\"\";'<>?,./";
			lblSpecialChars.TextAlign = ContentAlignment.MiddleLeft;
			lblSpecialChars.UseMnemonic = false;
			lblSpecialChars.TextChanged += LblSpecialChars_TextChanged;
			// 
			// btnSelectSpecialCharacters
			// 
			btnSelectSpecialCharacters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			btnSelectSpecialCharacters.AutoSize = true;
			btnSelectSpecialCharacters.Cursor = Cursors.Hand;
			btnSelectSpecialCharacters.FlatStyle = FlatStyle.Popup;
			btnSelectSpecialCharacters.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point);
			btnSelectSpecialCharacters.Location = new Point(973, 232);
			btnSelectSpecialCharacters.Name = "btnSelectSpecialCharacters";
			btnSelectSpecialCharacters.Size = new Size(83, 40);
			btnSelectSpecialCharacters.TabIndex = 18;
			btnSelectSpecialCharacters.Text = "Select";
			btnSelectSpecialCharacters.UseVisualStyleBackColor = true;
			btnSelectSpecialCharacters.Click += BtnSelectSpecialCharacters_Click;
			// 
			// nudPasswordLength
			// 
			nudPasswordLength.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			nudPasswordLength.BackColor = Color.FromArgb(25, 25, 25);
			nudPasswordLength.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
			nudPasswordLength.ForeColor = SystemColors.Highlight;
			nudPasswordLength.Location = new Point(602, 82);
			nudPasswordLength.Margin = new Padding(4);
			nudPasswordLength.Maximum = new decimal(new int[] { 75, 0, 0, 0 });
			nudPasswordLength.MaximumSize = new Size(365, 0);
			nudPasswordLength.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
			nudPasswordLength.MinimumSize = new Size(365, 0);
			nudPasswordLength.Name = "nudPasswordLength";
			nudPasswordLength.Size = new Size(365, 40);
			nudPasswordLength.TabIndex = 12;
			nudPasswordLength.TextAlign = HorizontalAlignment.Center;
			nudPasswordLength.Value = new decimal(new int[] { 15, 0, 0, 0 });
			nudPasswordLength.ValueChanged += NudPasswordLength_ValueChanged;
			// 
			// chkIncludeSpecialChars
			// 
			chkIncludeSpecialChars.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			chkIncludeSpecialChars.Cursor = Cursors.Hand;
			chkIncludeSpecialChars.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
			chkIncludeSpecialChars.ForeColor = Color.White;
			chkIncludeSpecialChars.Location = new Point(80, 232);
			chkIncludeSpecialChars.Margin = new Padding(4);
			chkIncludeSpecialChars.MaximumSize = new Size(370, 40);
			chkIncludeSpecialChars.MinimumSize = new Size(370, 40);
			chkIncludeSpecialChars.Name = "chkIncludeSpecialChars";
			chkIncludeSpecialChars.Size = new Size(370, 40);
			chkIncludeSpecialChars.TabIndex = 17;
			chkIncludeSpecialChars.Text = "Include &Special Characters:";
			chkIncludeSpecialChars.UseVisualStyleBackColor = true;
			chkIncludeSpecialChars.CheckedChanged += ChkIncludeSpecialCharacters_CheckedChanged;
			// 
			// lblPwdLen
			// 
			lblPwdLen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lblPwdLen.AutoEllipsis = true;
			lblPwdLen.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lblPwdLen.ForeColor = Color.White;
			lblPwdLen.Location = new Point(80, 82);
			lblPwdLen.Margin = new Padding(4, 0, 4, 0);
			lblPwdLen.MaximumSize = new Size(370, 40);
			lblPwdLen.MinimumSize = new Size(370, 40);
			lblPwdLen.Name = "lblPwdLen";
			lblPwdLen.Size = new Size(370, 40);
			lblPwdLen.TabIndex = 13;
			lblPwdLen.Text = "Password Length:";
			lblPwdLen.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// chkIncludeDigits
			// 
			chkIncludeDigits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			chkIncludeDigits.Cursor = Cursors.Hand;
			chkIncludeDigits.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
			chkIncludeDigits.ForeColor = Color.White;
			chkIncludeDigits.Location = new Point(80, 140);
			chkIncludeDigits.Margin = new Padding(4);
			chkIncludeDigits.MaximumSize = new Size(370, 40);
			chkIncludeDigits.MinimumSize = new Size(370, 40);
			chkIncludeDigits.Name = "chkIncludeDigits";
			chkIncludeDigits.Size = new Size(370, 40);
			chkIncludeDigits.TabIndex = 14;
			chkIncludeDigits.Text = "Include &Digits (0-9)";
			chkIncludeDigits.UseVisualStyleBackColor = true;
			chkIncludeDigits.CheckedChanged += ChkIncludeDigits_CheckedChanged;
			// 
			// chkIncludeLetters
			// 
			chkIncludeLetters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			chkIncludeLetters.Cursor = Cursors.Hand;
			chkIncludeLetters.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
			chkIncludeLetters.ForeColor = Color.White;
			chkIncludeLetters.Location = new Point(80, 186);
			chkIncludeLetters.Margin = new Padding(4);
			chkIncludeLetters.MaximumSize = new Size(370, 40);
			chkIncludeLetters.MinimumSize = new Size(370, 40);
			chkIncludeLetters.Name = "chkIncludeLetters";
			chkIncludeLetters.Size = new Size(370, 40);
			chkIncludeLetters.TabIndex = 15;
			chkIncludeLetters.Text = "Include &Letters (A-Z | a-z):";
			chkIncludeLetters.UseVisualStyleBackColor = true;
			chkIncludeLetters.CheckedChanged += ChkIncludeLetters_CheckedChanged;
			// 
			// cboLetterCasing
			// 
			cboLetterCasing.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			cboLetterCasing.BackColor = Color.FromArgb(25, 25, 25);
			cboLetterCasing.Cursor = Cursors.Hand;
			cboLetterCasing.DropDownStyle = ComboBoxStyle.DropDownList;
			cboLetterCasing.Enabled = false;
			cboLetterCasing.FlatStyle = FlatStyle.Popup;
			cboLetterCasing.Font = new Font("Arial", 14F, FontStyle.Italic, GraphicsUnit.Point);
			cboLetterCasing.ForeColor = SystemColors.Highlight;
			cboLetterCasing.ImeMode = ImeMode.Off;
			cboLetterCasing.Location = new Point(602, 187);
			cboLetterCasing.Margin = new Padding(4);
			cboLetterCasing.MaximumSize = new Size(365, 0);
			cboLetterCasing.MinimumSize = new Size(365, 0);
			cboLetterCasing.Name = "cboLetterCasing";
			cboLetterCasing.Size = new Size(365, 39);
			cboLetterCasing.Sorted = true;
			cboLetterCasing.TabIndex = 16;
			cboLetterCasing.SelectedIndexChanged += CboLetterFormat_SelectedIndexChanged;
			// 
			// groupBox1
			// 
			groupBox1.BackColor = Color.FromArgb(30, 30, 30);
			groupBox1.Controls.Add(lblPwdLen);
			groupBox1.Controls.Add(lblSpecialChars);
			groupBox1.Controls.Add(cboLetterCasing);
			groupBox1.Controls.Add(btnSelectSpecialCharacters);
			groupBox1.Controls.Add(chkIncludeLetters);
			groupBox1.Controls.Add(nudPasswordLength);
			groupBox1.Controls.Add(chkIncludeDigits);
			groupBox1.Controls.Add(chkIncludeSpecialChars);
			groupBox1.Font = new Font("Arial", 15F, FontStyle.Underline, GraphicsUnit.Point);
			groupBox1.ForeColor = SystemColors.AppWorkspace;
			groupBox1.Location = new Point(19, 33);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(40);
			groupBox1.Size = new Size(1136, 355);
			groupBox1.TabIndex = 20;
			groupBox1.TabStop = false;
			groupBox1.Text = "Password Options:";
			// 
			// FrmGenerator
			// 
			AccessibleRole = AccessibleRole.Window;
			AutoScaleDimensions = new SizeF(144F, 144F);
			AutoScaleMode = AutoScaleMode.Dpi;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			BackColor = Color.FromArgb(20, 20, 20);
			BackgroundImageLayout = ImageLayout.Stretch;
			ClientSize = new Size(1174, 715);
			Controls.Add(snackbar);
			Controls.Add(groupBox1);
			Controls.Add(lblResult);
			Controls.Add(btnGenerate);
			Controls.Add(staStrip);
			Controls.Add(btnToClipboard);
			Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
			ForeColor = Color.DimGray;
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(4);
			MaximizeBox = false;
			MaximumSize = new Size(1200, 775);
			MinimumSize = new Size(1200, 775);
			Name = "FrmGenerator";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Arnie's Random Password Generator";
			Load += FrmGenerator_Load;
			SizeChanged += FrmGenerator_SizeChanged;
			staStrip.ResumeLayout(false);
			staStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudPasswordLength).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion
		private Button btnGenerate;
		private Button btnToClipboard;
		private StatusStrip staStrip;
		private ToolStripStatusLabel stalblAuthor;
		private System.Windows.Forms.Timer snackTimer;
		private ContextMenuStrip specialCharsMenu;
		private ToolStripMenuItem spchMenuAllButThis;
		private ToolStripMenuItem spchMenuNoneButThis;
		private Label snackbar;
		private Label lblResult;
		private Label lblSpecialChars;
		private Button btnSelectSpecialCharacters;
		private NumericUpDown nudPasswordLength;
		private CheckBox chkIncludeSpecialChars;
		private Label lblPwdLen;
		private CheckBox chkIncludeDigits;
		private CheckBox chkIncludeLetters;
		private ComboBox cboLetterCasing;
		private GroupBox groupBox1;
	}
}

