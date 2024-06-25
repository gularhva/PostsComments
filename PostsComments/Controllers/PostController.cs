using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostsComments.Data.Entities;
using PostsComments.DTO;
using PostsComments.Services.Abstractions;

namespace PostsComments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public ResponseModel<IEnumerable<Post>> Get()
        {
            var data = _postService.Get();
            return data;
        }
        [HttpPost]
        public ResponseModel<Post> Post([FromQuery] PostDTO model)
        {
            var data = _postService.Post(model);
            return data;
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public ResponseModel<Post> Delete([FromRoute] int id)
        {
            var data = _postService.Delete(id);
            return data;
        }
        [HttpPut]
        [Route("Put/{id}")]
        public ResponseModel<Post> Put([FromRoute] int id, PostDTO model)
        {
            var data = _postService.Update(id, model);
            return data;
        }
    }
}
