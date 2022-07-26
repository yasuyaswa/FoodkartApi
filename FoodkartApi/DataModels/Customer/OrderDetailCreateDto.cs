namespace FoodkartApi.DataModels.Customer
{
    public class OrderDetailCreateDto
    {
        public int ItemId { get; set; }
        public int Sno { get; set; }
        public int ItemQty { get; set; }
        public int Amount { get; set; }
        public int OrderId { get; set; }
    }
}
