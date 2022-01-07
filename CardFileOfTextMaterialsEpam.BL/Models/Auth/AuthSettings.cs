using System;
using System.Collections.Generic;
using System.Text;
using CardFileOfTextMaterialsEpam.BL.Auth;

namespace CardFileOfTextMaterialsEpam.BL.Models.Auth
{
    public class AuthSettings
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string About { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string RegisterDate { get; set; }
        public string Token { get; set; }

        public AuthSettings(User user, string role)
        {
            Id = user.Id;
            Email = user.Email;
            FirstName = user.FirstName;
            SecondName = user.LastName;
            PhoneNumber = user.PhoneNumber;
            Role = role;
        }

        public AuthSettings(User user, string role, string token) : this(user, role)
        {
            Token = token;
        }
    }
}
