namespace BookApplication.WebApi.Models.BookCategoryModels
{
    public class UpdateBookCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SlugName { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }

    }
}
