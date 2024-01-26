using Cocomix_API.DataReponse;
using Cocomix_API.DTO;

namespace Cocomix_API.Service
{
    public interface ProductService
    {
        public Task<List<ProductReponse>> GetListProductReponses();
        public Task<ProductReponse> GetProductReponse(int id);
        public Task<ProductReponse> AddProduct(ProductDTO productDTO);
        public Task<string> DeleteProduct(int id);
        public Task<ProductReponse> UpdateProduct(int id, ProductDTO productDTO);
    }
}
