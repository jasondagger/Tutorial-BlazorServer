using BlazorServer.Models;

namespace BlazorServer
{
	public interface IContactService
	{
		public void AddContact(
			Contact contact
		);
		public List<Contact> GetContacts();
		public bool HasContacts();
	}
}
