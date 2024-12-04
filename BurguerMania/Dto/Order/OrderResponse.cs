namespace BurguerManiaAPI.Dto.Order
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public string? Status { get; set; }
        public float Value { get; set; }
    }
}