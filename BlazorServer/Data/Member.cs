namespace BlazorServer.Data
{
    public sealed class Member
    {
        public string MemberId { get; set; } = string.Empty;
        public string MemberName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public DateTime JoiningDate { get; set; } = DateTime.MinValue;
    }
}