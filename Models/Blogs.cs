namespace MyMvcAuthApp.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Content { get; set; }

        public string? KategoriName { get; set; }

        public ICollection<Kategori> Kategoriler { get; set; } = new List<Kategori>();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       
    }
}