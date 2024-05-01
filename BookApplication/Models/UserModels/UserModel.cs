namespace BookApplication.WebApi.Models.UserModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string AccessToken { get; set; }        
        public string Email { get; set; }
        public decimal MoneyAmount { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
    }
}
