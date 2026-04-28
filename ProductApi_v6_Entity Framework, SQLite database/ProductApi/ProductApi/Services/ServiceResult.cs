using ProductApi.Models;

namespace ProductApi.Services
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<Product>? Products { get; set; }
    }
}