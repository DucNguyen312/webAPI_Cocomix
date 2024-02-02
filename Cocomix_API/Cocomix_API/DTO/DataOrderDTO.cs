namespace Cocomix_API.DTO
{
    public class DataOrderDTO
    {
        public string? Note { get; set; }
        public string? Status { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? TotalProduct { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
