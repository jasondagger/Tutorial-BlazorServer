﻿using BlazorServer.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorServer.Components.Contacts
{
	public sealed partial class ContactList
	{
		[Parameter]
		public List<Contact>? Contacts { get; set; } = null;

		public void HideContacts() => m_displayContacts = false;
		public void ShowContacts() => m_displayContacts = true;

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
			_ = UpdateLoadingMessage();
		}

		private readonly Dictionary<string, object> m_textboxAttributes = new()
	{
		{ "placeholder", "First Name" },
		{ "disabled",    "disabled" },
	};

		private bool m_displayEmail = false;
		private bool m_displayContacts = true;
		private string m_loadingMessage = string.Empty;

		private async Task DeleteContact(
			Contact contact
		)
		{
			var result = await jsRuntime.InvokeAsync<bool>(
				"confirm",
				$"Are you sure you want to delete {contact.FirstName} {contact.FirstName}?"
			);

			if (result)
			{
				Contacts?.Remove(
					contact
				);
			}
		}

		private async Task UpdateLoadingMessage()
		{
			const string loadingMessage = "Contacts are loading";
			const char loadingSymbol = '.';
			const int maxSymbols = 3;
			const int loadingMessageDelay = 250;

			while (Contacts is null)
			{
				for (int i = 1; i <= maxSymbols; i++)
				{
					m_loadingMessage = loadingMessage + new string(loadingSymbol, i);
					StateHasChanged();

					await Task.Delay(
						loadingMessageDelay
					);
				}
			}
		}
	}
}