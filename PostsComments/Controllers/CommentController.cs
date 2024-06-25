using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostsComments.Data.Entities;
using PostsComments.DTO;
using PostsComments.Services.Abstractions;

namespace PostsComments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public ResponseModel<IEnumerable<Comment>> Get()
        {
            var data = _commentService.Get();
            return data;
        }
        [HttpPost]
        public ResponseModel<Comment> Post([FromQuery] CommentDTO model)
        {
            var data = _commentService.Post(model);
            return data;
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public ResponseModel<Comment> Delete([FromRoute] int id)
        {
            var data = _commentService.Delete(id);
            return data;
        }
        [HttpPut]
        [Route("Put/{id}")]
        public ResponseModel<Comment> Put([FromRoute] int id, CommentDTO model)
        {
            var data = _commentService.Update(id, model);
            return data;
        }
    }
}
