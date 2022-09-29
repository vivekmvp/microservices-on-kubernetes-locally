using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly OnlineStoreContext context;

        public ProductController(OnlineStoreContext context)
        {
            #region In Memory Sample Records (Seed data)
            this.context = context;

            if (this.context.Products.Count() == 0)
            {
                //keeping description blank
                this.context.Products.Add(new Product {Id=1, ProdName="Airpod", Description="...", Price=200, StockCount=500, HavingWarranty=true });
                this.context.Products.Add(new Product {Id=2, ProdName="iPad", Description= "...", Price=325, StockCount=100, HavingWarranty=true });
                this.context.Products.Add(new Product {Id=3, ProdName="Tablet", Description= "...", Price=290, StockCount=150, HavingWarranty=false });
                this.context.Products.Add(new Product {Id=4, ProdName="Laptop", Description= "...", Price=950, StockCount=50, HavingWarranty=true });
                this.context.Products.Add(new Product {Id=5, ProdName="Desktop", Description= "...", Price=750, StockCount=45, HavingWarranty=true });
                this.context.Products.Add(new Product {Id=6, ProdName="Keyboard", Description= "...", Price=55, StockCount=700, HavingWarranty=false });
                this.context.Products.Add(new Product {Id=7, ProdName="Mouse", Description= "...", Price=35, StockCount=760, HavingWarranty=false });
                this.context.SaveChanges();
            }
            #endregion            
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await context.Products.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var Product = await context.Products.FindAsync(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Product;
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product Product)
        {
            if (id != Product.Id)
            {
                return BadRequest();
            }

            context.Entry(Product).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product Product)
        {
            context.Products.Add(Product);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = Product.Id }, Product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var Product = await context.Products.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

            context.Products.Remove(Product);
            await context.SaveChangesAsync();

            return Product;
        }

        private bool ProductExists(int id)
        {
            return context.Products.Any(e => e.Id == id);
        }
    }
}
