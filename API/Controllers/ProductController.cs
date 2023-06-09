using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext context;
        public ProductsController(StoreContext context)
        {
            this.context = context;
            
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var products = await this.context.Products.ToListAsync();
            return products;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct( int id){
            var products = await this.context.Products.FindAsync(id);
            return products;
        }
    }
}