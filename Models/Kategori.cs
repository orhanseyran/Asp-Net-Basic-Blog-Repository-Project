namespace MyMvcAuthApp.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string? Name { get; set; }
  

         public Blogs? Blog { get; set; }

        
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
    }
    
}