using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Blog.Infrastructure;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication12.Messages.Requests;
using WebApplication12.Messages.Responses;

namespace WebApplication12.Controllers
{
    [Route("api/[controller]")]
    public class Posts : ControllerBase
    {
        private readonly DatabaseRepository _repository;

        public Posts(DatabaseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("details/{id:guid}")]
        public async Task<ActionResult<PostDetailsResponse>> Get(Guid id)
        {
            var post = await Task.FromResult(_repository.GetBlogData()
                .SelectMany(x => x.Posts)
                .FirstOrDefault(x => x.Id == id));

            if (post == null)
            {
                return NotFound();
            }

            return new PostDetailsResponse
            (
                post.Id,
                post.Title,
                post.Content,
                post.CreatedOn
            );
        }

        [HttpGet("{blogId:guid}")]
        public async Task<ActionResult<ICollection<PostListResponse>>> GetList(Guid blogId)
        {
            var blog = await Task.FromResult(_repository.GetBlogData()
                .FirstOrDefault(x => x.Id == blogId));

            if (blog == null)
            {
                return NotFound();
            }

            return blog.Posts.Select(x => new PostListResponse
            (
                x.Id,
                x.Title,
                x.CreatedOn
            )).ToList();
        }

        [HttpPost("{blogId:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Guid>> Post(Guid blogId, [FromBody] CreatePostRequest createPostRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog = _repository.GetBlogData()
                .FirstOrDefault(x => x.Id == blogId);

            if (blog == null)
            {
                return NotFound();
            }

            var post = new Post
            (
                createPostRequest.Id,
                createPostRequest.Title,
                createPostRequest.Content,
                createPostRequest.CreatedOn
            );

            blog.Posts.Add(post);

            await _repository.Update(x => x.Id == blogId, blog);

            return Ok(post.Id);
        }
    }
}