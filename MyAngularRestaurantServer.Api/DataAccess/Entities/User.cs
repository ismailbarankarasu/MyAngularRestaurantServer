namespace MyAngularRestaurantServer.Api.DataAccess.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string NameSurname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
    }
}