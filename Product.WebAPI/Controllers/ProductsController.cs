using Microsoft.AspNetCore.Mvc;
using Productstore.Core;

namespace Product.WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly IProductServices _productServices;

		public ProductsController(IProductServices productServices)
		{

			_productServices = productServices;

		}

		//Retrieving all products
		[HttpGet]
		public IActionResult GetProducts()
		{

			return Ok(_productServices.GetProducts());

		}

		//Retrieving a specific product
		[HttpGet("{id}", Name = "GetProduct")]
		public IActionResult GetProduct(string id)
		{
			Products pr = _productServices.GetProduct(id);


			if (pr is null)
			{
				return NotFound();
			}
			return Ok(pr);

		}


		//Adding a new product
		[HttpPost]
		public IActionResult AddProduct(Products product)
		{

			_productServices.AddProduct(product);
			return CreatedAtRoute("GetProduct", new { id = product.Id }, product);

		}


		//Deleting a product
		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(string id)
		{

			_productServices.DeleteProduct(id);
			return NoContent();

		}


		//Updating a product
		[HttpPut]
		public IActionResult UpdateProduct(Products product)
		{

			return Ok(_productServices.UpdateProduct(product));

		}


		//Retrieving all the images related to a specific product
		[HttpGet("{id}/images")]
		public IActionResult GetImages(string id)
		{
			Products pr = _productServices.GetProduct(id);

			if (pr is null)
			{
				return NotFound();
			}
			return Ok(pr.Images);

		}


		//Adding a new image to a product
		[HttpPut("{id}/image")]
		public IActionResult AddImage(string id, Image img)
		{
			Products pr = _productServices.GetProduct(id);


			if (pr is null)
			{
				return NotFound();
			}
			pr.Images.Add(img);
			return Ok(_productServices.UpdateProduct(pr));

		}


		// Retrieving a product's availability number
		[HttpGet("{id}/availability")]
		public IActionResult Getavailability(string id)
		{
			Products pr =  _productServices.GetProduct(id);

			if (pr is null)
			{
				return NotFound();
			}

			return Ok(pr.Availability);
		}


		// Booking a product 
		[HttpPut("{id}/book")]
		public IActionResult BookProduct(string id, Booking bookedProduct)
		{
			Products pr = _productServices.GetProduct(id);

			if (pr is null)
			{
				return NotFound();
			}

			if (pr.Availability > bookedProduct.NoOfProducts)
			{
				pr.BookingInfo.Add(bookedProduct);
				pr.Availability = pr.Availability - bookedProduct.NoOfProducts;
				return Ok(_productServices.UpdateProduct(pr));
			}
			else
            {
				return NoContent();

			}

		}

	}
}