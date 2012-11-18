using System.Collections.Generic;
using System.Linq;

namespace JqmMVC4Demo.Models
{
    public class PostRepository
    {
        BlogContext db = new BlogContext();

        public IEnumerable<Post> GetAll()
        {
            return db.Posts;
        }

        public Post Find(int id)
        {
            return db.Posts.SingleOrDefault(p => p.ID == id);
        }

        public void Add(Post p)
        {
            db.Posts.Add(p);
            db.SaveChanges();
        }
    }
}