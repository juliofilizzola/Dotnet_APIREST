using System.Collections.Concurrent;
using AutoMapper;
using GeekShopping.API.Model;
using GeekShopping.API.Model.Context;
using GeekShopping.API.Model.Data.Dto;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.API.Repository;

public class ProductRepository(MySqlContext context, IMapper mapper) : IProductRepository {
    private readonly MySqlContext _context = context;
    private          IMapper      _mapper  = mapper;

    public async Task<IEnumerable<ProductDTO>> FindAll() {
        List<Product> products = await _context.Products.ToListAsync();
        return _mapper.Map<List<ProductDTO>>(products);
    }

    public async Task<ProductDTO> FindById(long id) {
        Product product = (await _context.Products.Where(prod => prod.Id == id).FirstOrDefaultAsync())!;
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> Create(ProductDTO dto) {
        Product product = _mapper.Map<Product>(dto);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductDTO>(product);

    }

    public async Task<ProductDTO> Update(long id, ProductDTO dto) {
        ProductDTO product = await this.FindById(id);
        // if (product == null) {
        //     throw "not found";
        // }
        Product p = _mapper.Map<Product>(dto);
        _context.Products.Update(p);
        await _context.SaveChangesAsync();
        return dto;
    }

    public async Task<bool> Delete(long id) {
        try {
            ProductDTO product = await this.FindById(id);
            if (product == null) {
                return false;
            }

            Product p = _mapper.Map<Product>(product);
            _context.Products.Remove(p);
            await _context.SaveChangesAsync();
            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}