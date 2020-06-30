using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DentaCare.Application;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Application.Queries;
using DentaCare.Application.Searches;
using DentaCare.Implementation.Validators;
using DentaCareDataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DentaCare.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly DentaCareContext _context;
        private readonly IMapper _mapper;
        private readonly CreateRoleValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public AppointmentController(DentaCareContext context,
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
        // GET: api/<AppointmentController>
        [HttpGet]
        public IActionResult Get([FromQuery] AppointmentSearch search,
            [FromServices] IGetAppointmentQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var role = _context.Appointments.Find(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AppointmentDto>(role));
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] AppointmentDto dto,
            [FromServices] ICreateAppointmentCommand command,
            [FromServices] CreateAppointmentValidator validator)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AppointmentDto dto, [FromServices] UpdateAppointmentValidator validator)
        {
            dto.Id = id;

            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
            {
                return NotFound();
            }

            var result = validator.Validate(dto);

            if (!result.IsValid)
            {
                throw new Exception();// prepraviti sa klasom error/ medelja 5-subota termin
            }

            _mapper.Map(dto, appointment);

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

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IDeleteAppointmentCommand command)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
            {
                return NotFound();
            }

            appointment.IsDeleted = true;
            appointment.IsActive = false;
            appointment.DeletedAt = DateTime.Now;


            _executor.ExecuteCommand(command, id);

            _context.SaveChanges();
            return NoContent();


        }
    }
}
