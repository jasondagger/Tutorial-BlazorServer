using BlazorServer.Models;

namespace BlazorServer
{
	public sealed class ContactService : IContactService
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
			return m_contactList;
		}

		private List<Contact> m_contactList = new();
	}
}