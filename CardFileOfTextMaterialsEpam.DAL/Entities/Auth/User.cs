using Microsoft.AspNetCore.Identity;

namespace CardFileOfTextMaterialsEpam.DAL.Entities.Auth
{
    public class User:IdentityUser<int>
    {
        public int CardId{ get; set; }  
        public Card Card{ get; set; }  
        public string FirstName { get; set; }
        public string  LastName { get; set; }
    }
}
