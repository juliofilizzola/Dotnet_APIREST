using System.Collections.Concurrent;
using GeekShopping.API.Model.Data.Dto;

namespace GeekShopping.API.Repository;

public interface IProductRepository {
    Task<IEnumerable<ProductDTO>> FindAll();
    Task<ProductDTO>              FindById(long    id);
    Task<ProductDTO>              Create(ProductDTO dto);
    Task<ProductDTO>              Update(long      id, Partitioner<ProductDTO> vo);
    Task<bool>                 Delete(long      id);
}