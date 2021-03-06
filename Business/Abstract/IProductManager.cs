using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductManager
    {
        List<Product> GetAllProducts();
        List<ProductDTO> GetAllProductList();
        ProductDTO GetProductById(int id);
        void AddProduct(AddProductDTO product);
        void UpdateProduct(AddProductDTO product, int id);
    }
}
