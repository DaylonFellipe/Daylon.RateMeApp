using Daylon.RateMeApp.Application.Interfaces.FeedPosts;
using Microsoft.AspNetCore.Mvc;

namespace Daylon.RateMeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedPostController(IFeedPostService postService) : ControllerBase
    {
        private readonly IFeedPostService _postService = postService;

        // Get
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllPostsAsync()
        {
            var posts = await _postService.GetAllPostsAsync();

            return Ok(posts);
        }
    }
}