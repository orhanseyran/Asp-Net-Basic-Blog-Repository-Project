using MyMvcAuthApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMvcAuthApp.Repository
{
    public interface IBlogsRepository
    {
        List<Blogs> GetAll();
        Blogs GetById(int id);
        void Add(Blogs blog);
        void Update(Blogs blog);
        void Delete(int id);
        
    }
}