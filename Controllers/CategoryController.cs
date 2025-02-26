using BlogBackASPNETCore.Context;
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

    }
}
