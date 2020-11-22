using GerenciadorAlmoxarifado.Data;
using GerenciadorAlmoxarifado.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorAlmoxarifado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Product[]>> Get()
        {
            try
            {
                IQueryable<Product> query = _context.Products.OrderBy(product => product.Id);
                return Ok(await query.ToArrayAsync());
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Product[]>> GetByName(string name)
        {
            try
            {
                IQueryable<Product> query = _context.Products
                    .AsNoTracking()
                    .Where(product => product.Name.ToLower().Contains(name.ToLower()))
                    .OrderBy(product => product.Id);
                Product[] products = await query.ToArrayAsync();
                return Ok(products);
            }
            catch (Exception exception)
            {
                return InternalError(exception);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            try
            {
                Product product = await _context.Products.FindAsync(id);
                if (product == null) return NotFound();

                return Ok(product);
            }
            catch (Exception exception)
            {
                return InternalError(exception);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                if ((await _context.SaveChangesAsync()) > 0)
                {
                    return Created($"/api/product{product.Id}", product);
                } else
                {
                    return BadRequest($"Não foi possível cadastrar o produto {product.Name}");
                }

            }
            catch (Exception exception)
            {
                return InternalError(exception);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, Product product)
        {
            try
            {
                if (id != product.Id) return NotFound();

                Product thisProduct = await _context.Products.AsNoTracking().FirstOrDefaultAsync(findProduct => findProduct.Id == id);
                if (thisProduct == null) return NotFound();

                _context.Entry(product).State = EntityState.Modified;
                if ((await _context.SaveChangesAsync()) > 0)
                {
                    return Ok(product);
                } else
                {
                    return BadRequest($"Não foi possível atualizar o produto {product.Name}");
                }
            }
            catch (Exception exception)
            {
                return InternalError(exception);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Product product = await _context.Products.FindAsync(id);
                if (product == null) return NotFound();

                _context.Products.Remove(product);
                if ((await _context.SaveChangesAsync()) > 0)
                {
                    return Ok();
                } else
                {
                    return BadRequest($"Não foi possível apagar o produto {product.Name}");
                }
            }
            catch (Exception exception)
            {
                return InternalError(exception);
            }
        }
        
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult InternalError(Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Houve um erro interno: {exception.Message}");
        }
    }
}
