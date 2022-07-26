namespace FoodkartApi.DataModels.Customer
{
    public class OrderCreateDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? OrderTotal { get; set; }
        public string? OrderStatus { get; set; }
        public int? CustomerId { get; set; }
    }
}
