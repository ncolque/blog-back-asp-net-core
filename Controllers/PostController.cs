using BlogBackASPNETCore.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogBackASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        //Get api/Post
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var listPosts = await _context.Posts.ToListAsync();
                return Ok(listPosts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
