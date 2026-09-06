public class Reservation
{
    public int ReservationId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime ReservationDate { get; set; }
    public int PersonCount { get; set; }
    public string? SpecialRequest { get; set; }
}