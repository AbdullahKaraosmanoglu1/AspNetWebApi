using BookApplication.WebApi.Models.UserModels;

namespace BookApplication.Data
{
    public class ApplicationContext
    {
        public static List<BookModel> BooksList { get; set; }
        static ApplicationContext()
        {
            BooksList = new List<BookModel>()
            {
                new BookModel() {Id=1, Title="Beyaz Diş", Price=100},
                new BookModel() {Id=2, Title="Gazap Üzümleri", Price=200},
                new BookModel() {Id=3, Title="Genç Verterin Acıları", Price=300}
            };
        }
    }
}
