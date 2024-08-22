using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMvcAuthApp.Data;
using MyMvcAuthApp.Models;
using MyMvcAuthApp.Repository;

namespace MyMvcAuthApp.Controllers;

public class HomeController : Controller
{
   

    private readonly IBlogsRepository _dbblog;
    private readonly ApplicationDbContext _db;

    public HomeController( ApplicationDbContext db ,  IBlogsRepository dbblog)
    {
        _dbblog = dbblog;
        _db = db;
    }


    public IActionResult Index()
    {
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Blog()
    {
        var blogs = _dbblog.GetAll();
        return View(blogs);
        
    }
    public IActionResult BlogAdd()
    {
        var kategori = _db.Kategoriler.ToList();
        ViewBag.Kategori = kategori;
        return View();
    }
    [HttpPost]
    public IActionResult BlogAdd(Blogs blog)
    {
         
        _dbblog.Add(blog);
    
        return RedirectToAction("Blog");
    }
    public IActionResult BlogEdit(int id)
    {
        var blog = _dbblog.GetById(id);
        
        var kategori = _db.Kategoriler.ToList();
        ViewBag.Kategori = kategori;
        return View(blog);
    }
    [HttpPost]
    public IActionResult BlogEdit(Blogs blog)
    {
        _dbblog.Update(blog);
        
        return RedirectToAction("Blog");
    }
    public IActionResult BlogDelete(int id)
    {
        var blog = _db.Blogs.Find(id);
        if (blog == null)
        {
            return NotFound();
            
        }
        _db.Blogs.Remove(blog);
        _db.SaveChanges();
        return RedirectToAction("Blog");
    }
    public IActionResult Kategori()
    {
        var kategori = _db.Kategoriler.ToList();

        return View(kategori);
    }
    public IActionResult KategoriAdd()
    {
        return View();
    }
    [HttpPost]
    public IActionResult KategoriAdd(Kategori kategori)
    {
        if (ModelState.IsValid)
        {
            _db.Kategoriler.Add(kategori);
            _db.SaveChanges();
            return RedirectToAction("Kategori");
        }
        
        // Eğer ModelState geçerli değilse, formu tekrar gösterir ve hata mesajlarını gösterir.
        return View(kategori);
    }
    public IActionResult KategoriEdit(int id)
    {
        var kategori = _db.Kategoriler.Find(id);
        return View(kategori);
    }
    [HttpPost]
    public IActionResult KategoriEdit(Kategori kategori)
    {
        _db.Kategoriler.Update(kategori);
        _db.SaveChanges();
        return RedirectToAction("Kategori");
    }
    public IActionResult KategoriDelete(int id)
    {
        var kategori = _db.Kategoriler.Find(id);
        if (kategori == null)
        {
            return NotFound();
        }
        _db.Kategoriler.Remove(kategori);
        _db.SaveChanges();
        return RedirectToAction("Kategori");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
