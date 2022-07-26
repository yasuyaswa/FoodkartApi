using System.ComponentModel.DataAnnotations;

namespace FoodkartApi.DataModels.Customer
{
    public class CustomerCreateDto
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string CustomerPass { get; set; }
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessage = "Mobile Number is required.")]
        public long CustomerMobile { get; set; }
    }
}
