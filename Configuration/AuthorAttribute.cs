namespace RandomPasswordGenerator.Configuration
{
	/// <summary>An attribute to set the assembly's author name.</summary>
	/// <seealso cref="System.Attribute"/>
	[AttributeUsage(AttributeTargets.Assembly)]
	public class AuthorAttribute : Attribute
	{
		/// <summary>Gets the name.</summary>
		/// <value>The author's name.</value>
		public string FullName { get; private set; }

		/// <summary>Initializes a new instance of the <see cref="AuthorAttribute"/> class.</summary>
		/// <param name="fullName">The full name.</param>
		public AuthorAttribute(string fullName)
		{
			FullName = fullName;
		}
	}
}