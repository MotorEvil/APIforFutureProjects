﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APIforUpcomingProjects.Data;
using APIforUpcomingProjects.DTOS;
using APIforUpcomingProjects.Helpers;
using APIforUpcomingProjects.Models;
using APIforUpcomingProjects.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Services.UserAccountMapping;

namespace APIforUpcomingProjects.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private AppDbContext _context;

        public UserController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
             AppDbContext context)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterDto model)
        {
            var user = _mapper.Map<User>(model);

            try
            {
                // create user
                _userService.Register(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto model)
        {
            var user = _userService.Login(model.UserName, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                Token = tokenString
            });
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            var model = _mapper.Map<IList<UserReadDto>>(users);
            return Ok(model);
        }

        // Would be nice to implement in to service
        [Authorize(Roles = Role.Admin)]
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            //var user = _userService.GetUserById(id);
            var user = _context.Users.Where(x => x.Id == id).Select(x => new
            {
                x.Id,
                x.Username,
                x.FirstName,
                x.LastName,
                x.Role
            }).FirstOrDefault();
           // var model = _mapper.Map<UserReadDto>(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserUpdateDto model)
        {
            // map model to entity and set id
            var user = _mapper.Map<User>(model);
            user.Id = id;

            try
            {
                // update user 
                _userService.UpdateUser(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
