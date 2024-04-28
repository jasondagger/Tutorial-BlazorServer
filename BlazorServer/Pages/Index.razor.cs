using BlazorServer.Components.Contacts;
using BlazorServer.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
	public sealed partial class Index
	{
		protected async override Task OnInitializedAsync()
		{
			await Task.Delay(
				5000
			);
			m_contacts = m_contactService.GetContacts();

			//m_contacts = new()
			//{
			//	new Contact(
			//		"John",
			//		"Thomas",
			//		"john.thomas@gmail.com"
			//	),
			//	new Contact(
			//		"Timothy",
			//		"Kellen",
			//		"tim.kel@outlook.com"
			//	),
			//	new Contact(
			//		"Lexi",
			//		"Albright",
			//		"lalbright@yahoo.com"
			//	),
			//};

			await base.OnInitializedAsync();
		}

		[Inject]
		private IContactService m_contactService { get; set; } = new ContactService();
		[Inject]
		private NavigationManager? m_navigationManager { get; set; } = null;

		private List<Contact>? m_contacts = null;
		private ContactList? m_contactList = null;
		private bool m_areContactsDisplayed = true;

		private void Navigate()
		{
			m_navigationManager?.NavigateTo(
				"./PageDirective"
			);
		}

		private void ToggleContacts()
		{
			m_areContactsDisplayed = !m_areContactsDisplayed;
			if (m_areContactsDisplayed) 
			{
				m_contactList?.ShowContacts();
			}
            else
            {
				m_contactList?.HideContacts();
            }
		}
	}
}