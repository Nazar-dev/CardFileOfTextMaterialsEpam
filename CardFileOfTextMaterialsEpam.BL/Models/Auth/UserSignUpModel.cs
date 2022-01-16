namespace CardFileOfTextMaterialsEpam.BL.Models.Auth
{
    public class UserSignUpModel
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int CardId { get; set; }

        public string Password { get; set; }
    }
}
