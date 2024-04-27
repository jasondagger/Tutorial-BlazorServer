using Microsoft.AspNetCore.Components;
using BlazorServer.Models;

namespace BlazorServer.Components.Contacts
{
	public sealed partial class ContactInfo
	{
		[Parameter]
		public Contact CurrentContact { get; set; } = new();
		[Parameter]
		public bool DisplayEmail { get; set; } = false;
		[Parameter]
		public EventCallback<Contact> DeleteCurrentContact { get; set; } = new();

		private bool m_displayInfo = false;
	}
}