using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIforUpcomingProjects.DTOS;
using APIforUpcomingProjects.Helpers;
using APIforUpcomingProjects.Models;
using APIforUpcomingProjects.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIforUpcomingProjects.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IMapper _mapper;
        private IRoleService _roleService;

        public RolesController(IMapper mapper,
            IRoleService roleService)
        {
            _mapper = mapper;
            _roleService = roleService;
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

        [HttpGet("allroles")]
        public IActionResult AllRoles()
        {
            var roles = _roleService.GetAllRoles();
            var model = _mapper.Map<IList<RoleReadDto>>(roles);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            var role = _roleService.GetRoleById(id);
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
