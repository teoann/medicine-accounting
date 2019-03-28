using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicineAccountingAPI.DataLevel;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace MedicineAccountingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private ContextMedicineAccounting _context;
        private Connection _con;

        [HttpGet]
        public List<Product> Get()
        {
            using (_context = new ContextMedicineAccounting(_con.ConnectionOption()))
            {
                return _context.Products.ToList();
            }
        }

        // GET: api/Medicine/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            using (_context = new ContextMedicineAccounting(_con.ConnectionOption()))
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == id);
                return product;
            }
        }

        // POST: api/Medicine
        [HttpPost]
        public void Add([FromBody] Product product)
        {
            using (_context = new ContextMedicineAccounting(_con.ConnectionOption()))
            {
                var newproduct = _context.Products.Add(product);
                _context.SaveChanges();
            }
        }

        // PUT: api/Medicine/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Product product)
        {
            using (_context = new ContextMedicineAccounting(_con.ConnectionOption()))
            {
                if (id != 0 || product.Id != 0 || product.Id == id)
                {
                    var prod = Get(id);
                    if (prod != null)
                    {
                        _context.Products.Remove(prod);
                        _context.Products.Add(prod);
                        _context.SaveChanges();
                    }
                    else
                    {
                        BadRequest();
                    }
                }
                else
                {
                    BadRequest();
                }
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (_context = new ContextMedicineAccounting(_con.ConnectionOption()))
            {
                if(id!=0)
                {
                    var prod = Get(id);
                    if (prod != null)
                    {
                        _context.Products.Remove(prod);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}
