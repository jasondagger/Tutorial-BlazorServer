using BlazorServer.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Shared
{
    public sealed partial class DeleteConfirmation
    {
        [Parameter]
        public EventCallback<Contact> OnConfirmed { get; set; } = new();

        public Contact ContactToDelete = new();
        public string BodyContent = string.Empty;

        public void Show() => m_showPopUp = true;
        public void Hide() => m_showPopUp = false;

        private bool m_showPopUp = false;

        private async Task Confirm()
        {
            await OnConfirmed.InvokeAsync(
                ContactToDelete
            );
        }
    }
}