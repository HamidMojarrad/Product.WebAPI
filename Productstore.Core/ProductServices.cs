using MongoDB.Driver;

namespace Productstore.Core
{
	public class ProductServices : IProductServices
	{
		private readonly IMongoCollection<Products> _products;

		public ProductServices(IDbClient dbClient)
		{
			_products = dbClient.GetProductsCollection();
		}

		public List<Products> GetProducts() => _products.Find(product => true).ToList();
		

		public Products AddProduct(Products product)
		{

			_products.InsertOne(product);
			return product;

		}

		public Products GetProduct(string id) => _products.Find(product => product.Id == id).First();

		public void DeleteProduct(string id)
		{
			_products.DeleteOne(product => product.Id == id);
		}

		public Products UpdateProduct(Products product)
		{
			GetProduct(product.Id);
			_products.ReplaceOne(p => p.Id == product.Id, product);
			return product;
		}

        
    }
}