namespace MyAngularRestaurantServer.Api.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string NameSurname { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}