using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMvcAuthApp.Models;

namespace MyMvcAuthApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Blogs> Blogs { get; set; }
    public DbSet<Kategori> Kategoriler { get; set; }
    
    

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
