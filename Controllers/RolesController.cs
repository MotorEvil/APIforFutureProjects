using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIforUpcomingProjects.Data;
using APIforUpcomingProjects.DTOS;
using APIforUpcomingProjects.Helpers;
using APIforUpcomingProjects.Models;
using APIforUpcomingProjects.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIforUpcomingProjects.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IMapper _mapper;
        private IRoleService _roleService;
        private AppDbContext _context;

        public RolesController(IMapper mapper,
            IRoleService roleService,
            AppDbContext context)
        {
            _mapper = mapper;
            _roleService = roleService;
            _context = context;
        }

        [HttpPost("newrole")]
        public IActionResult CreateRole([FromBody] NewRoleDto model)
        {
            var role = _mapper.Map<Role>(model);

            try
            {
                //create role
                _roleService.CreateRole(role);
                return Ok();
            }
            catch (AppException ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult AllRoles()
        {
            var roles = _roleService.GetAllRoles();
            var model = _mapper.Map<IList<RoleReadDto>>(roles);

            return Ok(model);
        }

        // Would be nice to implement in to service
        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            var role = _context.Roles.Where(x => x.Id == id).Select(x => new
            {
                x.Id,
                x.Name,
                Role_Users = x.UsersRoles.Select(x => _mapper.Map<UserReadDto>(x.User)).ToList()
            }).FirstOrDefault();

            return Ok(role);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            _roleService.DeleteRole(id);
            return Ok();
        }
    }
}
