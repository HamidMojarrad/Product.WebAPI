
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Productstore.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Products> _products;
        public DbClient(IOptions<ProductstoreDbConfig> productstoreDbConfig)
        {
            var client = new MongoClient(productstoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(productstoreDbConfig.Value.Database_Name);
            _products = database.GetCollection<Products>(productstoreDbConfig.Value.Products_Collection_Name);
        }
        public IMongoCollection<Products> GetProductsCollection() => _products;
        
    }
}
