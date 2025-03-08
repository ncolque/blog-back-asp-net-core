using BlogBackASPNETCore.Context;
using BlogBackASPNETCore.Models;
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

        //Post api/Post
        [HttpPost]
        public async Task<IActionResult> PostPosts(Post post)
        {
            try
            {
                _context.Add(post);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPosts", new { id = post.Id }, post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get api/Post/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            try
            {
                var post = await _context.Posts.FindAsync(id);
                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Put api/Post/3
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            try
            {
                if (id != post.Id)
                {
                    return BadRequest();
                }

                var postItem = await _context.Posts.FindAsync(id);
                if (postItem == null)
                {
                    return NotFound();
                }

                postItem.Body = post.Body;
                postItem.Extract = post.Extract;
                postItem.Name = post.Name;
                postItem.Slug = post.Slug;
                postItem.Status = post.Status;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Delete api/Post/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                var post = await _context.Posts.FindAsync(id);
                if (post == null)
                {
                    return NotFound();
                }

                _context.Posts.Remove(post);
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
