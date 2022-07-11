using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IWebHostEnvironment _environment;


        public ProductController(IProductManager productManager, IWebHostEnvironment environment)
        {
            _productManager = productManager;
            _environment = environment;
        }

        [HttpGet("getall")]
        public IActionResult GetAllProduct()
        {
            var products = _productManager.GetAllProducts();

            if (products.Count == 0)
                return Ok(new { status = 200, message = "Hec bir mehsul tapilmadi." });

            return Ok(new { status = 200, message = products });
        }

        
        [HttpGet("productlist")]
        public IActionResult ProductList()
        {
            Console.WriteLine("Serverden gelir.");
            var productList = _productManager.GetAllProductList();

            return Ok(new { status = 200, message = productList });
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id){

            var product = _productManager.GetProductById(id);

            return Ok(new {status = 200, message = product});
        }


        [HttpPost("add")]
        public IActionResult AddProduct(AddProductDTO product)
        {
            
            try
            {
                _productManager.AddProduct(product);
            }
            catch (Exception e)
            {
                return Ok(new { status = 400, message = e });
            }
            return Ok(new { status = 200, message = "Mehsul elave olundu." });
        }


        [HttpPost("uploadcover")]
        public async Task<IActionResult> UploadPhotoAsync(IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }
            return Ok(new { status = 200, message = path });
        }


        [HttpPost("uploadimages")]
        public async Task<IActionResult> UploadImagesAsync(IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            List<string> photos = new();

            return Ok(new { status = 200, message = path });
        }

        [HttpPut("updateproduct/{id}")]
        public async Task<IActionResult> UpdateProduct(AddProductDTO model, int id)
        {

            _productManager.UpdateProduct(model, id);
            return Ok(new { status = 200, message = "Mehsul yenilendi" });
        }
    }
}
