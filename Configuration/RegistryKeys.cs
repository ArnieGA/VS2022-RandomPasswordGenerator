using RandomPasswordGenerator.Core;
using ROCFramework_Core.Enums;
using static ROCFramework_Core.WinRegistry.WinRegistryTools;

namespace RandomPasswordGenerator.Configuration
{
	/// <summary>
	/// Provides an abstract way of getting/setting configuration values from/to the registry.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
	public class RegistryKeys
	{
		/// <summary>Gets or sets the allowed digits registry value.</summary>
		/// <value>
		/// A string containing a collection of digits that the user has chosen to use in the
		/// character base for the password generator.
		/// </value>
		public string AllowedDigits
		{
			get
			{
				return GetRegistryValueOrDefault(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.ALLOWED_DIGITS, Constants.RegistryKeys.Defaults.ALLOWED_DIGITS, true);
			}
			set
			{
				SetRegistryValue(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.ALLOWED_DIGITS, value);
			}
		}

		/// <summary>Gets or sets the allowed lowercase letters registry value.</summary>
		/// <value>
		/// A string containing a collection of lowercase letters that the user has chosen to use in
		/// the character base for the password generator.
		/// </value>
		public string AllowedLowercase
		{
			get
			{
				return GetRegistryValueOrDefault(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.ALLOWED_LOWERCASE, Constants.RegistryKeys.Defaults.ALLOWED_LOWERCASE, true);
			}
			set
			{
				SetRegistryValue(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.ALLOWED_LOWERCASE, value);
			}
		}

		/// <summary>Gets or sets the allowed special characters registry value.</summary>
		/// <value>
		/// A string containing a collection of special characters that the user has chosen to use
		/// in the character base for the password generator.
		/// </value>
		public string AllowedSpecialCharacters
		{
			get
			{
				return GetRegistryValueOrDefault(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.ALLOWED_SPECIAL, Constants.RegistryKeys.Defaults.ALLOWED_SPECIAL, true);
			}
			set
			{
				SetRegistryValue(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.ALLOWED_SPECIAL, value);
			}
		}

		/// <summary>Gets or sets the allowed uppercase registry value.</summary>
		/// <value>
		/// A string containing a collection of uppercase letters that the user has chosen to use in
		/// the character base for the password generator.
		/// </value>
		public string AllowedUppercase
		{
			get
			{
				return GetRegistryValueOrDefault(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.ALLOWED_UPPERCASE, Constants.RegistryKeys.Defaults.ALLOWED_UPPERCASE, true);
			}
			set
			{
				SetRegistryValue(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.ALLOWED_UPPERCASE, value);
			}
		}

		/// <summary>
		/// Gets or sets the <c>IncludeDigits</c> registry value. This value represents whether to
		/// include digits in the generated password.
		/// </summary>
		/// <value><c>true</c> if [include digits]; otherwise, <c>false</c>.</value>
		public bool IncludeDigits
		{
			get
			{
				return GetRegistryValueOrDefault(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.INCLUDE_DIGITS, Constants.RegistryKeys.Defaults.INCLUDE_DIGITS, true);
			}
			set
			{
				SetRegistryValue(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.INCLUDE_DIGITS, value.ToString());
			}
		}

		/// <summary>
		/// Gets or sets the <c>IncludeLetters</c> registry value. This value represents whether to
		/// include letters in the generated password.
		/// </summary>
		/// <value><c>true</c> if [include letters]; otherwise, <c>false</c>.</value>
		public bool IncludeLetters
		{
			get
			{
				return GetRegistryValueOrDefault(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.INCLUDE_LETTERS, Constants.RegistryKeys.Defaults.INCLUDE_LETTERS, true);
			}
			set
			{
				SetRegistryValue(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.INCLUDE_LETTERS, value.ToString());
			}
		}

		/// <summary>
		/// Gets or sets the <c>IncludeSpecialCharacters</c> registry value. This value represents
		/// whether to include special characters in the generated password.
		/// </summary>
		/// <value><c>true</c> if [include special characters]; otherwise, <c>false</c>.</value>
		public bool IncludeSpecialCharacters
		{
			get
			{
				return GetRegistryValueOrDefault(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.INCLUDE_SPECIAL, Constants.RegistryKeys.Defaults.INCLUDE_SPECIAL, true);
			}
			set
			{
				SetRegistryValue(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.INCLUDE_SPECIAL, value.ToString());
			}
		}

		/// <summary>Gets or sets the letter casing registry value.</summary>
		/// <value>
		/// A value that represents the letter casing the user has chosen for the generated
		/// password. <br/><i>UpperLower</i> = Both upper and lower case. <br/><i>LowerOnly</i> =
		/// Lowercase only. <i>UpperOnly</i> = Uppercase only
		/// </value>
		public LetterCasingOptions LetterCasing
		{
			get
			{
				return GetRegistryValueOrDefault(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.LETTER_CASING, Constants.RegistryKeys.Defaults.LETTER_CASING, true);
			}
			set
			{
				SetRegistryValue(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.LETTER_CASING, value.ToString());
			}
		}

		/// <summary>Gets or sets the minimum length registry key.</summary>
		/// <value>A number that represents the minimum length allowed for the generated password.</value>
		public int MinimumLength
		{
			get
			{
				return GetRegistryValueOrDefault(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.MINIMUM_LENGTH, Constants.RegistryKeys.Defaults.MINIMUM_LENGTH, true);
			}
			set
			{
				SetRegistryValue(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.MINIMUM_LENGTH, value.ToString());
			}
		}

		/// <summary>Gets or sets the minimum numeric length registry value.</summary>
		/// <value>A number that represents the minimum length allowed for numeric-only passwords.</value>
		public int MinimumNumericLength
		{
			get
			{
				return GetRegistryValueOrDefault(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.MINIMUM_NUMERIC_LENGTH, Constants.RegistryKeys.Defaults.MINIMUM_NUMERIC_LENGTH, true);
			}
			set
			{
				SetRegistryValue(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.MINIMUM_NUMERIC_LENGTH, value.ToString());
			}
		}

		/// <summary>Gets or set the result length registry value.</summary>
		/// <value>A number that represents the length chosen by the user for the generated password.</value>
		public int ResultLength
		{
			get
			{
				return GetRegistryValueOrDefault(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.RESULT_LENGTH, Constants.RegistryKeys.Defaults.RESULT_LENGTH, true);
			}
			set
			{
				SetRegistryValue(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.RESULT_LENGTH, value.ToString());
			}
		}

		/// <summary>Gets or sets the shuffle times registry value.</summary>
		/// <value>A number that represents the times the generator will shuffle characters.</value>
		public int ShuffleTimes
		{
			get
			{
				return GetRegistryValueOrDefault(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.SHUFFLE_TIMES, Constants.RegistryKeys.Defaults.SHUFFLE_TIMES, true);
			}
			set
			{
				SetRegistryValue(BaseKeys.CurrentUser, Constants.APP_REGISTRY_SUBKEY, Constants.RegistryKeys.SHUFFLE_TIMES, value.ToString());
			}
		}
	}
}