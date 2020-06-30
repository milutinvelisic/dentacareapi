using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DentaCare.Implementation.Validators;
using DentaCare.Application;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Application.Queries;
using DentaCare.Application.Searches;
using DentaCareDataAccess;
using DentaCare.Domain;
using DentaCare.Implementation.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DentaCare.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly DentaCareContext _context;
        private readonly IMapper _mapper;
        private readonly CreateRoleValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public RolesController(DentaCareContext context,
            IMapper mapper,
            CreateRoleValidator validator,
            IApplicationActor actor,
            UseCaseExecutor executor)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _actor = actor;
            _executor = executor;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public IActionResult Get([FromQuery] RoleSearch search,
            [FromServices] IGetRoleQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var role = _context.Roles.Find(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RoleDto>(role));
        }

        // POST api/<RolesController>
        [HttpPost]
        public void Post([FromBody] RoleDto dto,
            [FromServices] ICreateRoleCommand command,
            [FromServices] CreateRoleValidator validator)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleDto dto, [FromServices] UpdateRoleValidator validator)
        {
            dto.Id = id;

            var role = _context.Roles.Find(id);

            if (role == null)
            {
                return NotFound();
            }
            
            var result = validator.Validate(dto);

            if (!result.IsValid)
            {
                throw new Exception();// prepraviti sa klasom error/ medelja 5-subota termin
            }

            _mapper.Map(dto, role);

            try
            {
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDeleteRoleCommand command)
        {
            var role = _context.Roles.Find(id);

            if (role == null)
            {
                return NotFound();
            }

            role.IsDeleted = true;
            role.IsActive = false;
            role.DeletedAt = DateTime.Now;

           
            _executor.ExecuteCommand(command, id);

            _context.SaveChanges();
            return NoContent();
            

        }
    }
}
