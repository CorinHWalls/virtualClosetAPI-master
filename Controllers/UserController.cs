using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using virtualClosetApi.Models;
using virtualClosetApi.Services;

namespace virtualClosetApi.controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;
        
        public UserController( UserService dataFromService)
        {
            _data = dataFromService;
        }


        //Add Users - WORKS
        [HttpPost("AddUser")]
        public bool AddUser(CreateAccountModel User)
        {
            return _data.AddUser(User);
        }


        //Login Users - WORKS
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel User )
        {
            return _data.Login(User);
        }

        //Get all users - WORKS

        [HttpGet("GetAllUsers")]
        public IEnumerable<UserModel> GetAllUsers()
        {
            return _data.GetAllUsers();
        }

        //Get user by username - WORKS

        [HttpGet("getUserByUsername")]

        public UserModel GetUserByUsername(string Username)
        {
            return _data.GetUserByUsername(Username);
        }

        //get current user - WORKS

        [HttpPost("getCurrentUser")]
        
        public IEnumerable<UserModel> GetCurrentUser(UserModel currentUser)
        {
            return _data.GetCurrentUser(currentUser);
        }

    }

}