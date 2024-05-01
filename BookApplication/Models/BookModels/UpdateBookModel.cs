namespace BookApplication.WebApi.Models.BookModels
{
    public class UpdateBookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public string ImagePath { get; set; }
        public string SlugName { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public int BookCategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
