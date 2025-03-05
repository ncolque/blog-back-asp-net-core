using BlogBackASPNETCore.Context;
using BlogBackASPNETCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogBackASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        //Get api/Category
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var listCategories = await _context.Categories.ToListAsync();
                return Ok(listCategories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Post api/Category
        [HttpPost]
        public async Task<IActionResult> PostCategory(Category category)
        {
            try
            {
                _context.Add(category);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCategories", new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get api/Category/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Put api/Category/3
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            try
            {
                if (id != category.Id)
                {
                    return BadRequest();
                }
                var categoryItem = await _context.Categories.FindAsync(id);

                if (categoryItem == null)
                {
                    return NotFound();
                }

                categoryItem.name = category.name;
                categoryItem.slug = category.slug;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Delete api/Category/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
