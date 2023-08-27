using RandomPasswordGenerator.Configuration;
using RandomPasswordGenerator.Core;
using RandomPasswordGenerator.Forms;
using ROCFramework_Core.WindowsDesktop.Fonts;
using System.Reflection;

namespace RandomPasswordGenerator
{
	internal static class Program
	{
		/// <summary>Holds application metadata information.</summary>
		public static ApplicationInformation ApplicationInfo { get; private set; }

		/// <summary>Manages private and custom fonts.</summary>
		public static FontFamilyCollection FontCollection { get; private set; }

		/// <summary>
		/// Manages the application settings values reading and writing to/from the registry.
		/// </summary>
		public static RegistryKeys RegistryKeys { get; private set; }

		/// <summary>The main entry point for the application.</summary>
		[STAThread]
		private static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			ApplicationInfo = new ApplicationInformation(Assembly.GetExecutingAssembly());
			RegistryKeys = new RegistryKeys();

			FontCollection = new FontFamilyCollection();
			FontCollection.AddFont(Constants.CONTENT_PATH + @"fonts\Hack-Regular.ttf");
			FontCollection.AddFont(Constants.CONTENT_PATH + @"fonts\Hack-Italic.ttf");
			FontCollection.AddFont(Constants.CONTENT_PATH + @"fonts\Hack-Bold.ttf");
			FontCollection.AddFont(Constants.CONTENT_PATH + @"fonts\Hack-BoldItalic.ttf");

			Application.Run(new FrmGenerator());
		}
	}
}