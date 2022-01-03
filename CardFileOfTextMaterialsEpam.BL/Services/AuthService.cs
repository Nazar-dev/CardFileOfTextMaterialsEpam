using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CardFileOfTextMaterialsEpam.BL.Auth;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CardFileOfTextMaterialsEpam.BL.Services
{
    public class AuthService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AuthService(IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager, JwtSettings jwtSettings)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings;
        }
        public async Task<bool> SignUp(UserSignUpModel userSignUpModel)
        {
            var user = _mapper.Map<UserSignUpModel, User>(userSignUpModel);

            var userCreateResult = await _userManager.CreateAsync(user, userSignUpModel.Password);

            if (userCreateResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "USER");
                return true;
            }

            return false;
        }
        public async Task<bool> SignIn(UserLoginModel userLoginModel)
        {
            var user =await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == userLoginModel.Email);
            if (user is null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                throw new ArgumentNullException();
            }

            var userSigninResult = await _userManager.CheckPasswordAsync(user, userLoginModel.Password);

            if (userSigninResult)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token = GenerateJwt(user, roles);
                return true;
            }

            return false;
        }
        public async Task<bool> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentNullException();
            }

            var newRole = new Role
            {
                Name = roleName
            };

            var roleResult = await _roleManager.CreateAsync(newRole);

            if (roleResult.Succeeded)
            {
                return true;
            }

            return false;
        }
        public async Task<bool> AddUserToRole(string userEmail,  string roleName)
        {
            var user =await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == userEmail);
            if (user is null)
            {
                throw new NullReferenceException();
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }
        private string GenerateJwt(User user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
