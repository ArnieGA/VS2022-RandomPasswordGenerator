using ROCFramework_Core.Enums;

namespace RandomPasswordGenerator.Core
{
	/// <summary>Provides constant values that can be accessed solution-wide.</summary>
	public static class Constants
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public static readonly string APP_EXE_NAME = @"Random Password Generator.exe";
		public static readonly string APP_NAME = @"Random Password Generator";
		public static readonly string APP_PATH;
		public static readonly string APP_REGISTRY_SUBKEY = @"SOFTWARE\" + COMPANY_NAME + @"\" + APP_NAME;
		public static readonly string COMPANY_NAME = @"Realm Of Code Solutions";
		public static readonly string CONTENT_PATH;
		public static readonly string STARTUP_REGISTRY_SUBKEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

		static Constants()
		{
#if DEBUG
			APP_PATH = AppDomain.CurrentDomain.BaseDirectory + @"\";
			CONTENT_PATH = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Content\"));
#else
			APP_PATH = Application.StartupPath;
			CONTENT_PATH = Path.Combine(Application.StartupPath, @"Content\");
#endif
		}

		public static class Colors
		{
			public static readonly Color DarkGrey = Color.FromArgb(51, 51, 51);
			public static readonly Color OffWhite = Color.FromArgb(247, 247, 247);
			public static readonly Color StatusError = Color.FromArgb(225, 38, 85);
			public static readonly Color StatusOk = Color.FromArgb(28, 191, 42);
		}

		public static class RegistryKeys
		{
			public static readonly string ALLOWED_DIGITS = "allowedDigits";
			public static readonly string ALLOWED_LOWERCASE = "allowedLowerCase";
			public static readonly string ALLOWED_SPECIAL = "allowedSpecialCharacters";
			public static readonly string ALLOWED_UPPERCASE = "allowedUpperCase";
			public static readonly string INCLUDE_DIGITS = "includeDigits";
			public static readonly string INCLUDE_LETTERS = "includeLetters";
			public static readonly string INCLUDE_SPECIAL = "includeSpecialCharacters";
			public static readonly string LETTER_CASING = "letterCasing";
			public static readonly string MINIMUM_LENGTH = "minimumLength";
			public static readonly string MINIMUM_NUMERIC_LENGTH = "minimumNumericLength";
			public static readonly string RESULT_LENGTH = "resultLength";
			public static readonly string SHUFFLE_TIMES = "shuffleTimes";

			public static class Defaults
			{
				public static readonly string ALLOWED_DIGITS = "0123456789";
				public static readonly string ALLOWED_LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
				public static readonly string ALLOWED_SPECIAL = @"~`!@#$%^&*()_+-={}[]:\"";'<>?,./";
				public static readonly string ALLOWED_UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
				public static readonly bool INCLUDE_DIGITS = true;
				public static readonly bool INCLUDE_LETTERS = true;
				public static readonly bool INCLUDE_SPECIAL = true;
				public static readonly LetterCasingOptions LETTER_CASING = LetterCasingOptions.UpperLower;
				public static readonly int MINIMUM_LENGTH = 6;
				public static readonly int MINIMUM_NUMERIC_LENGTH = 1;
				public static readonly int RESULT_LENGTH = 6;
				public static readonly int SHUFFLE_TIMES = 10;
			}
		}
	}
}