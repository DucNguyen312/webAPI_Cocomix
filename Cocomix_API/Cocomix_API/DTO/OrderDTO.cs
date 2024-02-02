using System.ComponentModel.DataAnnotations;

namespace Cocomix_API.DTO
{
    public class OrderDTO
    {
        [Required]
        [MinLength(1)]
        public List<ProductOrder> Product { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
        

    }
}
