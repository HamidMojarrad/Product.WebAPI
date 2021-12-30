
namespace Productstore.Core
{
    public interface IProductServices
    {
        List<Products> GetProducts();

        Products AddProduct(Products product);

        Products GetProduct(string id);

        void DeleteProduct(string id);

        Products UpdateProduct(Products product);
    }
}
