using ROCFramework_Core.Enums;
using ROCFramework_Core.Extensions.IEnumerable;
using ROCFramework_Core.Extensions.String;

namespace RandomPasswordGenerator.Core
{
	/// <summary>This is a tool class that handles password generation.</summary>
	internal class PasswordGenerator
	{
		/// <summary>The configured result's length.</summary>
		public int ConfiguredLength { get => _options.ResultLength; }

		/// <summary>The last generated password.</summary>
		public string GeneratedPassword { get => _generatedPassword; }

		/// <summary>The configured setting for whether to include digits when generating a password.</summary>
		public bool IncludeDigits { get => _options.IncludeDigits; }

		/// <summary>
		/// The configured setting for whether to include letters when generating a password.
		/// </summary>
		public bool IncludeLetters { get => _options.IncludeLetters; }

		/// <summary>
		/// The configured setting for whether to include special characters when generating a password.
		/// </summary>
		public bool IncludeSpecialCharacters { get => _options.IncludeSpecialCharacters; }

		/// <summary>
		/// Gets a value indicating whether configured options are in a valid state. For example,
		/// setting all flags to false (include digits, include letters, include special characters)
		/// will leave this instance in an invalid options state. You can use this value to help you
		/// configure UI states.
		/// </summary>
		/// <value><c>true</c> if this instance is option state invalid; otherwise, <c>false</c>.</value>
		public bool IsOptionStateInvalid { get => !IncludeDigits && !IncludeLetters && !IncludeSpecialCharacters; }

		/// <summary>
		/// Gets a value that represents whether a password has been generated, or it has been reset.
		/// </summary>
		/// <value><c>true</c> if a password has been generated and set; otherwise, <c>false</c>.</value>
		public bool IsPasswordGenerated { get => !string.IsNullOrEmpty(_generatedPassword); }

		/// <summary>Gets the configured letter casing. <br/><seealso cref="LetterCasingOptions"/></summary>
		/// <value>The letter casing.</value>
		public LetterCasingOptions LetterCasing { get => _options.LetterCasing; }

		/// <summary>
		/// Calculates and gets the maximum possible length based on the current generator settings.
		/// </summary>
		/// <value>The maximum possible length.</value>
		public int PotentialMaximumLength
		{
			get
			{
				int maximumLetters = IncludeLetters
					? LetterCasing switch
					{
						LetterCasingOptions.UpperLower => DEFAULT_UPPERCASE.Length + DEFAULT_LOWERCASE.Length,
						LetterCasingOptions.UpperOnly => DEFAULT_UPPERCASE.Length,
						LetterCasingOptions.LowerOnly => DEFAULT_LOWERCASE.Length,
						_ => throw new InvalidOperationException("Impossible to get here, but got here.")
					}
					: 0;

				int plausibleMaximumLength = maximumLetters
					+ (IncludeDigits ? DEFAULT_DIGITS.Length : 0)
					+ (IncludeSpecialCharacters ? SelectedSpecialCharacters.Length : 0);

				return Math.Max(ConfiguredLength, plausibleMaximumLength);
			}
		}

		/// <summary>
		/// Calculates and gets the minimum possible length based on the current generator settings.
		/// </summary>
		/// <value>The minimum possible length.</value>
		public int PotentialMinimumLength
		{
			get => (IncludeDigits && !IncludeLetters && !IncludeSpecialCharacters)
				? MINIMUM_NUMERIC_PASSWORD_LENGTH
				: MINIMUM_PASSWORD_LENGTH;
		}

		/// <summary>Gets the user-selected special characters.</summary>
		/// <value>The selected special characters.</value>
		public string SelectedSpecialCharacters
		{
			get => _options.AllowedSpecialCharacters;
		}

		/// <summary>
		/// Represents the original <see cref="RandomGeneratorOptions"/> object used to create this
		/// instance. The <see cref="ResetOptions"/> method can be called to reset the options of
		/// this instance back to the original options.
		/// </summary>
		private readonly RandomGeneratorOptions _defaultOptions;

		/// <summary>
		/// The character base that will be used to generate the random password. It is generated in
		/// the <see cref="SetBaseCharacters"/> method.
		/// </summary>
		private string _baseCharacters;

		/// <summary>Holds the generated password.</summary>
		private string _generatedPassword;

		/// <summary>
		/// Represents the mutable <see cref="RandomGeneratorOptions"/> object that can be modified.
		/// It differs from the <see cref="_defaultOptions"/> in that it allows changes to its properties.
		/// </summary>
		private RandomGeneratorOptions _options;

		/// <summary>The default set of digits.</summary>
		public const string DEFAULT_DIGITS = @"0123456789";

		/// <summary>The default set of lowercase letters.</summary>
		public const string DEFAULT_LOWERCASE = @"abcdefghijklmnopqrstuvwxyz";

		/// <summary>The default set of special characters.</summary>
		public const string DEFAULT_SPECIAL = @"~`!@#$%^&*()_+-={}[]:"";'<>?,./";

		/// <summary>The default set of uppercase letters.</summary>
		public const string DEFAULT_UPPERCASE = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		/// <summary>The minimum length required for a numeric password: 1.</summary>
		public const int MINIMUM_NUMERIC_PASSWORD_LENGTH = 1;

		/// <summary>The minimum length required for a password: 6.</summary>
		public const int MINIMUM_PASSWORD_LENGTH = 6;

		/// <summary>
		/// Initializes a new instance of the <see cref="PasswordGenerator"/> class with optional
		/// custom options.
		/// </summary>
		/// <param name="options">
		/// The <see cref="RandomGeneratorOptions"/> used to customize password generation. If null,
		/// default options will be used with a default result length of 15 characters.
		/// </param>
		public PasswordGenerator(RandomGeneratorOptions options = null)
		{
			_defaultOptions = options ?? new RandomGeneratorOptions
			{
				ResultLength = 15
			};
			ResetOptions();
		}

		/// <summary>
		/// Generates a randomized string based on the input value. It performs the 2nd layer of
		/// character randomness in the algorithm.
		/// </summary>
		/// <param name="value">The input string.</param>
		/// <returns>A randomized string.</returns>
		private string Randomize(string value)
		{
			string result = string.Empty;
			Random random = new();
			for (int i = 0; i < Math.Max(_options.ResultLength, PotentialMinimumLength); i++)
			{
				int randomIndex = random.Next(0, value.Length);
				char randomChar = value.ElementAt(randomIndex);

				// This if statement ensures characters are not repeated in this operation
				if (value.Length > 1 && result.Any() && result.Last().Equals(randomChar))
					i--;
				else
					result += value.ElementAt(randomIndex);
			}
			return result;
		}

		/// <summary>Sets the base characters for generating the password.</summary>
		private void SetBaseCharacters()
		{
			ResetPassword();
			_baseCharacters = String.Empty;
			if (_options.IncludeLetters)
			{
				switch (_options.LetterCasing)
				{
					case LetterCasingOptions.UpperLower:
					{
						_baseCharacters += DEFAULT_UPPERCASE + DEFAULT_LOWERCASE;
						break;
					}
					case LetterCasingOptions.UpperOnly:
					{
						_baseCharacters += DEFAULT_UPPERCASE;
						break;
					}
					case LetterCasingOptions.LowerOnly:
					{
						_baseCharacters += DEFAULT_LOWERCASE;
						break;
					}
				}
			}
			if (_options.IncludeDigits)
				_baseCharacters += DEFAULT_DIGITS;
			if (_options.IncludeSpecialCharacters)
				_baseCharacters += _options.AllowedSpecialCharacters;
		}

		/// <summary>Validates the presence of digits in the character array.</summary>
		/// <param name="value">The character array to validate.</param>
		/// <returns>True if the validation is successful, otherwise false.</returns>
		private bool ValidateDigits(char[] value)
		{
			bool containsDigits = value.Any(DEFAULT_DIGITS.Contains);
			return (!IncludeDigits && !containsDigits) || (IncludeDigits && containsDigits);
		}

		/// <summary>Validates the presence of letters in the character array.</summary>
		/// <param name="value">The character array to validate.</param>
		/// <param name="casing">The letter casing option.</param>
		/// <returns>True if the validation is successful, otherwise false.</returns>
		private bool ValidateLetters(char[] value, LetterCasingOptions casing)
		{
			bool containsUpper = value.Any(DEFAULT_UPPERCASE.Contains);
			bool containsLower = value.Any(DEFAULT_LOWERCASE.Contains);
			return casing switch
			{
				LetterCasingOptions.UpperLower => (!IncludeLetters && !containsLower && !containsUpper) || (IncludeLetters && containsLower && containsUpper),
				LetterCasingOptions.UpperOnly => (!IncludeLetters && !containsLower && !containsUpper) || (IncludeLetters && !containsLower && containsUpper),
				LetterCasingOptions.LowerOnly => (!IncludeLetters && !containsLower && !containsUpper) || (IncludeLetters && containsLower && !containsUpper),
				_ => throw new ArgumentException(message: "Impossible to get here, but got here."),
			};
		}

		/// <summary>Validates the presence of special characters in the character array.</summary>
		/// <param name="value">The character array to validate.</param>
		/// <returns>True if the validation is successful, otherwise false.</returns>
		private bool ValidateSpecialCharacters(char[] value)
		{
			bool containsSpecialCharacters = value.Any(SelectedSpecialCharacters.Contains);
			return (!IncludeSpecialCharacters && !containsSpecialCharacters) || (IncludeSpecialCharacters && containsSpecialCharacters);
		}

		/// <summary>Invokes the callback after a password has been generated.</summary>
		/// <param name="generatedPassword">The generated password.</param>
		protected virtual void OnAfterPasswordGenerated(string generatedPassword)
		{
			_options.OnAfterPasswordGenerated?.Invoke(generatedPassword);
		}

		/// <summary>Invokes the callback before generating a password.</summary>
		protected virtual void OnBeforePasswordGenerated()
		{
			_options.OnBeforePasswordGenerated?.Invoke();
		}

		/// <summary>Invokes the callback when an exception occurs during password generation.</summary>
		/// <param name="exception">The exception that occurred.</param>
		protected virtual void OnPasswordGenerationException(Exception exception)
		{
			ResetPassword();
			_options.OnPasswordGenerationException?.Invoke(exception);
		}

		/// <summary>Invokes the callback when resetting the password.</summary>
		protected virtual void OnPasswordReset()
		{
			_options.OnPasswordReset?.Invoke();
		}

		/// <summary>Generates the password.</summary>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		public string GeneratePassword()
		{
			try
			{
				OnBeforePasswordGenerated();
				SetBaseCharacters();

				string shuffledCharacters = _baseCharacters.Shuffle(_options.ShuffleTimes);
				string randomGeneration = Randomize(shuffledCharacters);

				char[] passwordCharacters = randomGeneration.ToCharArray();
				string specialCharacters = _options.AllowedSpecialCharacters.Shuffle(_options.ShuffleTimes);

				bool lettersValidated = ValidateLetters(passwordCharacters, LetterCasing);
				bool digitsValidated = ValidateDigits(passwordCharacters);
				bool specialCharactersValidated = ValidateSpecialCharacters(passwordCharacters);

				do
				{
					Random random = new();
					if (!lettersValidated)
					{
						switch (LetterCasing)
						{
							case LetterCasingOptions.UpperLower:
								passwordCharacters[random.Next(0, passwordCharacters.Length)] = DEFAULT_UPPERCASE[random.Next(0, DEFAULT_UPPERCASE.Length)];
								passwordCharacters[random.Next(0, passwordCharacters.Length)] = DEFAULT_LOWERCASE[random.Next(0, DEFAULT_LOWERCASE.Length)];
								break;

							case LetterCasingOptions.UpperOnly:
								passwordCharacters[random.Next(0, passwordCharacters.Length)] = DEFAULT_UPPERCASE[random.Next(0, DEFAULT_UPPERCASE.Length)];
								break;

							case LetterCasingOptions.LowerOnly:
								passwordCharacters[random.Next(0, passwordCharacters.Length)] = DEFAULT_LOWERCASE[random.Next(0, DEFAULT_LOWERCASE.Length)];
								break;

							default:
								throw new ArgumentException(message: "Impossible to get here, but got here.");
						}
					}
					if (!digitsValidated)
					{
						passwordCharacters[random.Next(0, passwordCharacters.Length)] = DEFAULT_DIGITS[random.Next(0, DEFAULT_DIGITS.Length)];
					}
					if (!specialCharactersValidated)
					{
						passwordCharacters[random.Next(0, passwordCharacters.Length)] = specialCharacters[random.Next(0, specialCharacters.Length)];
					}

					lettersValidated = ValidateLetters(passwordCharacters, LetterCasing);
					digitsValidated = ValidateDigits(passwordCharacters);
					specialCharactersValidated = ValidateSpecialCharacters(passwordCharacters);
				}
				while (!lettersValidated || !digitsValidated || !specialCharactersValidated);

				_generatedPassword = new string(passwordCharacters);

				OnAfterPasswordGenerated(_generatedPassword);

				return _generatedPassword;
			}
			catch (Exception ex)
			{
				OnPasswordGenerationException(ex);
				return null;
			}
		}

		/// <summary>Resets the options to the default values.</summary>
		public void ResetOptions()
		{
			_options = new RandomGeneratorOptions(_defaultOptions);
		}

		/// <summary>Resets the generated password and invokes the password reset callback.</summary>
		public void ResetPassword()
		{
			_generatedPassword = null;
			OnPasswordReset();
		}

		/// <summary>Sets the allowed special characters for password generation.</summary>
		/// <param name="specialCharacters">The string containing special characters.</param>
		public void SetAllowedSpecialCharacters(string specialCharacters = DEFAULT_SPECIAL)
		{
			string result = "";
			foreach (char item in specialCharacters)
			{
				if (!DEFAULT_DIGITS.Contains(item)
					&& !DEFAULT_LOWERCASE.Contains(item)
					&& !DEFAULT_UPPERCASE.Contains(item)
					&& DEFAULT_SPECIAL.Contains(item))
					result += item;
			}
			_options.AllowedSpecialCharacters = result;
			SetBaseCharacters();
		}

		/// <summary>Sets whether to include digits in password generation.</summary>
		/// <param name="include">True to include digits, false otherwise.</param>
		public void SetIncludeDigits(bool include)
		{
			_options.IncludeDigits = include;
			SetBaseCharacters();
		}

		/// <summary>Sets whether to include letters in password generation.</summary>
		/// <param name="include">True to include letters, false otherwise.</param>
		public void SetIncludeLetters(bool include)
		{
			_options.IncludeLetters = include;
			SetBaseCharacters();
		}

		/// <summary>Sets whether to include special characters in password generation.</summary>
		/// <param name="include">True to include special characters, false otherwise.</param>
		public void SetIncludeSpecialCharacters(bool include)
		{
			_options.IncludeSpecialCharacters = include;
			SetBaseCharacters();
		}

		/// <summary>Sets the letter casing option for password generation.</summary>
		/// <param name="letterCasing">The letter casing option.</param>
		public void SetLetterCasing(LetterCasingOptions letterCasing)
		{
			_options.LetterCasing = letterCasing;
			SetBaseCharacters();
		}

		/// <summary>Sets the callback action to be invoked after a password has been generated.</summary>
		/// <param name="action">The callback action.</param>
		public void SetOnAfterPasswordGeneratedEvent(Action<string> action)
		{
			_options.OnAfterPasswordGenerated = action;
		}

		/// <summary>Sets the callback action to be invoked before generating a password.</summary>
		/// <param name="action">The callback action.</param>
		public void SetOnBeforePasswordGeneratedEvent(Action action)
		{
			_options.OnBeforePasswordGenerated = action;
		}

		/// <summary>
		/// Sets the callback action to be invoked when an exception occurs during password generation.
		/// </summary>
		/// <param name="action">The callback action.</param>
		public void SetOnPasswordGenerationExceptionEvent(Action<Exception> action)
		{
			_options.OnPasswordGenerationException = action;
		}

		/// <summary>Sets the callback action to be invoked when resetting the password.</summary>
		/// <param name="action">The callback action.</param>
		public void SetOnPasswordResetEvent(Action action)
		{
			_options.OnPasswordReset = action;
		}

		/// <summary>Sets the length of the generated password.</summary>
		/// <param name="length">The length of the password.</param>
		public void SetResultLength(int length)
		{
			ResetPassword();
			_options.ResultLength = length;
		}

		/// <summary>Sets the number of times the characters are shuffled during password generation.</summary>
		/// <param name="amount">The number of times to shuffle the characters.</param>
		public void SetShuffleTimes(int amount)
		{
			_options.ShuffleTimes = amount;
		}
	}

	/// <summary>Options for configuring the behavior of the random generator.</summary>
	internal class RandomGeneratorOptions
	{
		/// <summary>
		/// Gets or sets the string containing the allowed special characters for password generation.
		/// </summary>
		public string AllowedSpecialCharacters { get; set; } = Program.RegistryKeys?.AllowedSpecialCharacters ?? Constants.RegistryKeys.Defaults.ALLOWED_SPECIAL;

		/// <summary>Gets or sets a value indicating whether to include digits in password generation.</summary>
		public bool IncludeDigits { get; set; } = Program.RegistryKeys?.IncludeDigits ?? Constants.RegistryKeys.Defaults.INCLUDE_DIGITS;

		/// <summary>Gets or sets a value indicating whether to include letters in password generation.</summary>
		public bool IncludeLetters { get; set; } = Program.RegistryKeys?.IncludeLetters ?? Constants.RegistryKeys.Defaults.INCLUDE_LETTERS;

		/// <summary>
		/// Gets or sets a value indicating whether to include special characters in password generation.
		/// </summary>
		public bool IncludeSpecialCharacters { get; set; } = Program.RegistryKeys?.IncludeSpecialCharacters ?? Constants.RegistryKeys.Defaults.INCLUDE_SPECIAL;

		/// <summary>Gets or sets the letter casing option for password generation.</summary>
		public LetterCasingOptions LetterCasing { get; set; } = Program.RegistryKeys?.LetterCasing ?? Constants.RegistryKeys.Defaults.LETTER_CASING;

		/// <summary>
		/// Gets or sets the callback action to be invoked after a password has been generated.
		/// </summary>
		public Action<string> OnAfterPasswordGenerated { get; set; }

		/// <summary>Gets or sets the callback action to be invoked before generating a password.</summary>
		public Action OnBeforePasswordGenerated { get; set; }

		/// <summary>
		/// Gets or sets the callback action to be invoked when an exception occurs during password generation.
		/// </summary>
		public Action<Exception> OnPasswordGenerationException { get; set; }

		/// <summary>Gets or sets the callback action to be invoked when resetting the password.</summary>
		public Action OnPasswordReset { get; set; }

		/// <summary>Gets or sets the length of the generated password.</summary>
		public int ResultLength { get; set; } = Program.RegistryKeys?.ResultLength ?? Constants.RegistryKeys.Defaults.RESULT_LENGTH;

		/// <summary>
		/// Gets or sets the number of times the characters are shuffled during password generation.
		/// </summary>
		public int ShuffleTimes { get; set; } = Program.RegistryKeys?.ShuffleTimes ?? Constants.RegistryKeys.Defaults.SHUFFLE_TIMES;

		/// <summary>Initializes a new instance of the <see cref="RandomGeneratorOptions"/> class.</summary>
		public RandomGeneratorOptions()
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="RandomGeneratorOptions"/> class based on
		/// another instance.
		/// </summary>
		/// <param name="other">
		/// The other <see cref="RandomGeneratorOptions"/> instance to copy from.
		/// </param>
		public RandomGeneratorOptions(RandomGeneratorOptions other)
		{
			AllowedSpecialCharacters = other.AllowedSpecialCharacters;
			IncludeDigits = other.IncludeDigits;
			IncludeLetters = other.IncludeLetters;
			IncludeSpecialCharacters = other.IncludeSpecialCharacters;
			LetterCasing = other.LetterCasing;
			ResultLength = other.ResultLength;
			ShuffleTimes = other.ShuffleTimes;
			OnBeforePasswordGenerated = other.OnBeforePasswordGenerated;
			OnAfterPasswordGenerated = other.OnAfterPasswordGenerated;
			OnPasswordGenerationException = other.OnPasswordGenerationException;
			OnPasswordReset = other.OnPasswordReset;
		}
	}
}