using AutoMapper;
using Cocomix_API.DataReponse;
using Cocomix_API.DTO;
using Cocomix_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cocomix_API.Service.ServiceIMPL
{
    public class ProductServiceIMPL : ProductService
    {
        private readonly QLCHContext _context;
        private readonly IMapper _mapper;

        public ProductServiceIMPL(QLCHContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductReponse> AddProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductReponse>(product);
        }

        public async Task<string> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return "Delete Product Success";
            }
            return "Not found";
        }

        public async Task<List<ProductReponse>> GetListProductReponses()
        {
            var list_products = await _context.Products.ToListAsync();

            return _mapper.Map<List<ProductReponse>>(list_products);
        }

        public async Task<ProductReponse> GetProductReponse(int id)
        {
            var product = await _context.Products.FindAsync(id); //dữ liệu lấy từ database

            if (product != null) //Tìm thấy
            {
                return _mapper.Map<ProductReponse>(product);
            }

            return null; //Tìm ko thấy thì trả về null (rỗng)
        }

        public async Task<ProductReponse> UpdateProduct(int id, ProductDTO productDTO)
        {
            var product_old = await _context.Products.FindAsync(id);
            if (product_old != null)
            {
                product_old.Name = productDTO.Name ?? product_old.Name;
                product_old.Note = productDTO.Note ?? product_old.Note;
                product_old.Price = productDTO.Price ?? product_old.Price;
                product_old.Quantity = productDTO.Quantity ?? product_old.Quantity;
                await _context.SaveChangesAsync();
                return _mapper.Map<ProductReponse>(product_old);
            }
            return null;
        }
    }
}
