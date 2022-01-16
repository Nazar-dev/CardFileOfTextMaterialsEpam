using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CardFileOfTextMaterialsEpam.BL.Interfaces;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.BL.Models.Auth;
using CardFileOfTextMaterialsEpam.BL.Validation;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Entities.Auth;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CardFileOfTextMaterialsEpam.BL.Services
{
    public class AuthService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;        
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager,
            IOptionsSnapshot<JwtSettings> jwtSettings, SignInManager<User> signInManager, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
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
        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }


        public async Task<bool> SignIn(UserLoginModel userLoginModel)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == userLoginModel.Email);
            if (user is null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                throw new AuthorizationException();
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
                throw new AuthorizationException();
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

        public async Task<bool> AddUserToRole(string userEmail, string roleName)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == userEmail);
            if (user is null)
            {
                throw new AuthorizationException();
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }

        public async Task<AuthSettings> UpdateUser(User user)
        {
            var resUser =
                await _userManager.Users.SingleOrDefaultAsync(u =>
                    u.Email == user.Email && u.LastName == user.LastName);
            if (resUser is null)
            {
                throw new AuthorizationException();
            }

            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(resUser, user.PasswordHash);
            }

            await _userManager.UpdateAsync(resUser);
            var roles = await _userManager.GetRolesAsync(resUser);
            var token = GenerateJwt(resUser, roles);
            return new AuthSettings(resUser, roles.First(), roles.FirstOrDefault());
        }

        public async Task DeleteUserById(int id)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user is null)
            {
                throw new AuthorizationException();
            }

            await _userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<AuthSettings>> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userList = new List<AuthSettings>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                AuthSettings authUser = new AuthSettings(user, roles.FirstOrDefault());
                userList.Add(authUser);
            }

            return userList;
        }
        public async Task<User> GetUserById(int id)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user is null)
            {
                throw new AuthorizationException("User not found");
            }

            var userRes = _mapper.Map<User>(user);
            return userRes;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user is null)
            {
                throw new AuthorizationException();
            }

            var resUser = _mapper.Map<User>(user);
            return resUser;
        }
        public async Task<IEnumerable<string>> GetUserRoles(string email)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user is null)
            {
                throw new AuthorizationException("User not found");
            }
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }
        public async Task<CardModel> GetUserCards(string email)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user is null)
            {
                throw new AuthorizationException("User not found");
            }

            var cardModel = _mapper.Map<CardModel>(user.Card);
            return cardModel;

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