using Microsoft.AspNetCore.Identity;

namespace CardFileOfTextMaterialsEpam.DAL.Entities.Auth
{
    public class User:IdentityUser<int>
    {
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
    }
}
