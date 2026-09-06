namespace MyAngularRestaurantServer.Api.DataAccess.Entities
{
    public class ContactInfo
    {
        public int ContactInfoId { get; set; }
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string OpeningHours { get; set; } = null!;
    }
}