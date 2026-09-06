namespace MyAngularRestaurantServer.Api.DataAccess.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }
}
