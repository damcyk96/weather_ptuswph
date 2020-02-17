using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebApplication12.Messages.Requests;
using WebApplication12.Messages.Responses;

namespace WebApplication12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly DatabaseRepository _repository;
        
        public WeatherController(DatabaseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<ICollection<WeatherResponse>> Get()
        {
            return _repository
                .GetWeatherData()
                .Select(x => new WeatherResponse(x.Name, x.Description,x.Temperature))
                .ToArray();
        }

        [HttpGet("{id:guid}")]
        public ActionResult<BlogResponse> Get(Guid id)
        {
            var weather = _repository
                .GetBlogData()
                .FirstOrDefault(x => x.Id == id);

            if (blog == null)
                return NotFound();
            
            return new BlogResponse(blog.Id, blog.Name, blog.CreatedOn, blog.Author.FirstName, blog.Author.LastName);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CreateBlogRequest blogRequest)
        {
            if (blogRequest.CreatedOn < DateTime.Now.AddYears(-1))
            {
                return BadRequest();
            }
            
            var blog = new Blog.Models.Blog
            (
                blogRequest.Id, 
                blogRequest.Name, 
                blogRequest.CreatedOn, 
                blogRequest.Author
            );

            await _repository.Insert(blog);

            return Ok(blog.Id);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CreateBlogRequest blogRequest)
        {
            var blog = _repository
                .GetBlogData()
                .FirstOrDefault(x => x.Id == blogRequest.Id);
            
            if (blog == null)
                return NotFound();

            blog.Author.FirstName = blogRequest.Author.FirstName;
            blog.Author.LastName = blogRequest.Author.LastName;
            blog.Name = blogRequest.Name;
            blog.CreatedOn = blogRequest.CreatedOn;

            await _repository.Update(x => x.Id == blogRequest.Id, blog);
            
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var blog = _repository
                .GetBlogData()
                .FirstOrDefault(x => x.Id == id);
            
            if (blog == null)
                return NotFound();

            await _repository.Delete<Blog.Models.Blog>(x => x.Id == id);

            return Ok();
        }
    }
}