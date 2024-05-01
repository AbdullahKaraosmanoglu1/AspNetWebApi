namespace BookApplication.WebApi.Models.UserBookModels
{
    public class UpdateUserBookModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool IsActive { get; set; }
    }
}
