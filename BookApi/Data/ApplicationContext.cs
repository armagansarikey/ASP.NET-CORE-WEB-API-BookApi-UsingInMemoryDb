using BookApi.Models;

namespace BookApi.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set; }
        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book(){Id = 1, Title = "Benim Adım Kırmızı", Author = "Orhan Pamuk", Price = 150},
                new Book(){Id = 2, Title = "Mesnevi", Author = "Mevlana", Price = 350},
                new Book(){Id = 3, Title = "Gece Yarısı Kütüphanesi", Author = "Matt Haig", Price = 250},
                new Book(){Id = 4, Title = "Beyaz Diş", Author = "Jack London", Price = 175}
            };
        }
    }
}
