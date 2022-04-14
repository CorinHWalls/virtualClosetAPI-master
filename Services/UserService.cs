using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using virtualClosetApi.Services.Context;
using virtualClosetApi.Models;

namespace virtualClosetApi.Services
{
    public class UserService : ControllerBase
    {
        private readonly DataContext _context;
        public UserService(DataContext dataFromContext)
        {
            _context = dataFromContext;
        }


        public IEnumerable<UserModel> GetAllUsers()
        {
            return _context.UserInfo;
        }

        //Checks if user exists - WORKS
        public bool DoesUserExist(string? Username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username.ToLower() == Username.ToLower()) != null;
        }

        //Returns username - WORKS
        public UserModel GetUserByUsername(string Username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username.ToLower() == Username.ToLower() );
        }

        public IEnumerable<UserModel> GetCurrentUser (UserModel currentUser)
        {
            return _context.UserInfo.Where(user => user.Username == currentUser.Username);
        }


        public bool AddUser(CreateAccountModel User)
        {
            var result = false;
            if (!DoesUserExist(User.Username))
            {
                var newUser = new UserModel();
                var hashedPassword = HashPassword(User.Password);

                newUser.Id = User.Id;
                newUser.Username = User.Username;
                newUser.Salt = hashedPassword.Salt;
                newUser.Hash = hashedPassword.Hash;
                newUser.Name = User.Name;
    
                _context.Add(newUser);
                result = _context.SaveChanges() != 0;

            }
            return result;
        }

        public IActionResult Login([FromBody] LoginModel User)
        {
            IActionResult Result = Unauthorized();
            if (DoesUserExist(User.Username))
            {
                var foundUser = GetUserByUsername(User.Username);
                if (VerifyUserPassword(User.Password, foundUser.Hash, foundUser.Salt))
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    Result = Ok(new { Token = tokenString });
                }
            }
            return Result;
        }

        public PasswordModel HashPassword(string ?Password)
        {
            var newHashedPassword = new PasswordModel();
            var SaltBytes = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(SaltBytes);
            var Salt = Convert.ToBase64String(SaltBytes);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var HashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = HashPassword;
            return newHashedPassword;
        }


        public bool VerifyUserPassword(string ?Password, string ?storedHash, string ?storedSalt)
        {
            var SaltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000); 
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == storedHash;
        }

    }
}