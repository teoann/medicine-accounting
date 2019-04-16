using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicineAccountingAPI.DataLevel;
using Microsoft.Extensions.Configuration;


namespace MedicineAccountingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private ContextMedicineAccounting _context;

        [HttpGet]
        public List<Product> Get()
        {
            using (_context = new ContextMedicineAccounting(Connection.ConnectionOption()))
            {
                return _context.Products.ToList();
            }
        }

        //GET: api/Medicine/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            using (_context = new ContextMedicineAccounting(Connection.ConnectionOption()))
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == id);
                return product;
            }
        }

        // POST: api/Medicine
        [HttpPost]
        public bool Add([FromBody] Product product)
        {
            using (_context = new ContextMedicineAccounting(Connection.ConnectionOption()))
            {
                if (product!=null)
                {
                    var newproduct = _context.Products.Add(product);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    BadRequest("The input data couldn't be nullable");
                    return false;
                }
            }
        }

        // PUT: api/Medicine/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            using (_context = new ContextMedicineAccounting(Connection.ConnectionOption()))
            {
                //if (id != 0 || product.Id != 0 || product.Id == id)
                //{
                    var prod = _context.Products.FirstOrDefault(x => x.Id == id);
                    if (prod != null)
                    {
                        _context.Products.Remove(prod);
                        _context.Products.Add(product);
                        _context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return NotFound("No product with such Id");
                    }
                //}
                //else
                //{
                //    return BadRequest("The input data isn't valid");
                //}
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Product> Delete(int id)
        {
            using (_context = new ContextMedicineAccounting(Connection.ConnectionOption()))
            {
                if (id != 0)
                {
                    var prod = _context.Products.FirstOrDefault(x => x.Id == id);
                    if (prod != null)
                    {
                        _context.Products.Remove(prod);
                        _context.SaveChanges();
                        return /*Ok(*/_context.Products.ToList();
                    }
                    else
                    {
                        return null;//NotFound("Doesn't exist product with the same id");
                    }
                }
                else
                {
                    return null;//BadRequest();
                }
            }
        }
    }
}
