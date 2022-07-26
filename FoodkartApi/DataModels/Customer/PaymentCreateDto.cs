namespace FoodkartApi.DataModels.Customer
{
    public class PaymentCreateDto
    {
        public int PaymentId { get; set; }
        public int TotalAmount { get; set; }
        public string PaymentMode { get; set; }
        public int CustomerId { get; set; }
    }
}
