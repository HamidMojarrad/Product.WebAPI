
using MongoDB.Driver;

namespace Productstore.Core
{
    public interface IDbClient
    {
        IMongoCollection<Products> GetProductsCollection();
    }
}
