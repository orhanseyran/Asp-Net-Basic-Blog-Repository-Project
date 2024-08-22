using MyMvcAuthApp.Data;
using MyMvcAuthApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyMvcAuthApp.Repository
{
    public class BlogRepository : IBlogsRepository
    {
        private readonly ApplicationDbContext _db;
        public BlogRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Blogs> GetAll()
        {
            return _db.Blogs.ToList();
        }

        public Blogs GetById(int id)
        {
            return _db.Blogs.Find(id) ?? throw new InvalidOperationException("Blog not found");
        }

        public void Add(Blogs blog)
        {
            _db.Blogs.Add(blog);
            _db.SaveChanges();
        }

        public void Update(Blogs blog)
        {
            var existingBlog = _db.Blogs.FirstOrDefault(b => b.Id == blog.Id);
            if (existingBlog != null)
            {
                existingBlog.Title = blog.Title;
                existingBlog.Content = blog.Content;
                existingBlog.KategoriName = blog.KategoriName;
                existingBlog.CreatedAt = DateTime.Now;

                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var blog = _db.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog != null)
            {
                _db.Blogs.Remove(blog);
                _db.SaveChanges();
            }
        }
    }
}
