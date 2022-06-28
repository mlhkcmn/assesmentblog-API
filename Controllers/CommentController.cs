using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Data;

namespace Api.Controllers
{
    [ApiController]

    public class CommentController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public CommentController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("api/[controller]/byUserAndPostId")]
        public IActionResult AddComment([FromBody]PostComment commentObj)
        {
            Comment comment = new Comment();

            comment.UserId = commentObj.UserId;
            comment.PostId = commentObj.PostId;
            comment.ZComment = commentObj.ZComment;
            comment.UserName = commentObj.UserName;

            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet("api/[controller]/byPostId/{id}")]
        public IActionResult GetComments(int id)
        {
            var comments = _dbContext.Comments.Where(cmm => cmm.PostId == id);
            
            if(comments != null) {
                return Ok(comments);
            } else {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}