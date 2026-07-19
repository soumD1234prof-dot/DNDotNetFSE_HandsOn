public class User
{
    public string Username { get; set; }
    public string Password { get; set; } // In production, store a hash, never plain text
}