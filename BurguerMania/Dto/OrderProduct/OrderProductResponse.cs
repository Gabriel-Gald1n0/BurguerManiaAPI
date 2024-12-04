namespace BurguerManiaAPI.Dto.OrderProduct
{
    public class OrderProductResponse
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Status { get; set; }
        public float Value { get; set; }
    }
}