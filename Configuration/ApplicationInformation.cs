using System.Diagnostics;
using System.Reflection;

namespace RandomPasswordGenerator.Configuration
{
	/// <summary>Represents information about the application.</summary>
	public class ApplicationInformation
	{
		/// <summary>Holds the entire file version information of the application.</summary>
		private readonly FileVersionInfo _fileVersionInfo;

		/// <summary>Gets the author of the application.</summary>
		public string Author { get; private set; }

		/// <summary>Gets the company of the application.</summary>
		public string Company { get; private set; }

		/// <summary>Gets the copyright of the application.</summary>
		public string Copyright { get; private set; }

		/// <summary>Gets the version of the application.</summary>
		public string Version { get; private set; }

		/// <summary>Gets the version information of the application.</summary>
		public Version VersionInfo { get; private set; }

		/// <summary>Gets the name of the application.</summary>
		public string Name { get; private set; }

		/// <summary>Gets the description of the application.</summary>
		public string Description { get; private set; }

		/// <summary>Initializes a new instance of the <see cref="ApplicationInformation"/> class.</summary>
		public ApplicationInformation(Assembly assembly)
		{
			//_fileVersionInfo = FileVersionInfo.GetVersionInfo(Path.GetFileName(Assembly.GetExecutingAssembly().Location));
			_fileVersionInfo = FileVersionInfo.GetVersionInfo(Path.GetFileName(assembly.Location));

			var authorAttribute = (AuthorAttribute)Attribute.GetCustomAttribute(assembly, typeof(AuthorAttribute));
			Author = authorAttribute?.FullName ?? "Unknown";

			Company = _fileVersionInfo.CompanyName;
			Copyright = _fileVersionInfo.LegalCopyright;
			Version = _fileVersionInfo.ProductVersion;
			VersionInfo = new Version(Version);
			Name = _fileVersionInfo.ProductName;
			Description = _fileVersionInfo.Comments;
		}
	}
}