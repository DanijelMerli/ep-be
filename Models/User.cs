namespace EsportsProphetAPI.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}