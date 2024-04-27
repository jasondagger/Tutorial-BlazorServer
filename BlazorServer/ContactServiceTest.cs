using BlazorServer.Models;

namespace BlazorServer
{
	public sealed class ContactServiceTest : IContactService
	{
		public void AddContact(
			Contact contact
		)
		{
			m_contactList.Add(
				contact
			);
		}

		public bool HasContacts()
		{
			return m_contactList.Count > 0u;
		}

		public List<Contact> GetContacts()
		{
			return new List<Contact>()
			{
				new(
					"Richard",
					"Lewis",
					"r.lewis@gmail.com"
				)
			};
		}

		private List<Contact> m_contactList = new();
	}
}