namespace MyAngularRestaurantServer.Api.Dtos
{
    public class FeatureDto
    {
        public int FeatureId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string ButtonTitle { get; set; } = null!;
        public string ButtonUrl { get; set; } = null!;
    }
}