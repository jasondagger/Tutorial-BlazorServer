namespace BlazorServer.Models
{
	[Serializable]
	public struct Contact
	{
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;

		public Contact()
		{

		}

		public Contact(
			string firstName,
			string lastName,
			string email
		)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}
	}
}