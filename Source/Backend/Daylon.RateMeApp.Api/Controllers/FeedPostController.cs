using Daylon.RateMeApp.Application.Interfaces.FeedPosts;
using Daylon.RateMeApp.Communication.Requests.FeedPost;
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

        // Post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(RequestCreateFeedPostJson request)
        {
            var postDTO = await _postService.CreatePostAsync(request);

            return Created("", postDTO);
        }
    }
}