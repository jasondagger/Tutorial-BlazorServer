using Microsoft.AspNetCore.Components;

namespace BlazorServer.Components.Contacts
{
	public sealed partial class TextBox
	{
		[Parameter(CaptureUnmatchedValues = true)]
		public Dictionary<string, object> CustomAttributes { get; set; } = new();
	}
}
