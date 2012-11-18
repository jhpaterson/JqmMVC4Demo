using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JqmMVC4Demo.Models;
using JqmMVC4Demo.Filters;

namespace JqmMVC4Demo.Controllers
{
    public class PostsController : ApiController
    {
        PostRepository repository = new PostRepository();

        // GET api/Posts
        public IEnumerable<Post> Get()
        {
            return repository.GetAll();

        }

        // GET api/Posts/5
        public Post Get(int id)
        {
            return repository.Find(id);
        }

        // POST api/Posts
        [ValidateFilter]
        public HttpResponseMessage Post(Post post)
        {
            post.PublishDate = DateTime.Now;
            repository.Add(post);
            var response = Request.CreateResponse<Post>(HttpStatusCode.Created, post);
            string uri = Url.Link("DefaultApi", new { id = post.ID });
            response.Headers.Location = new Uri(uri);
            return response;
        }

    }
}