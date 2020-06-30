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
    public class DentistController : ControllerBase
    {
        private readonly DentaCareContext _context;
        private readonly IMapper _mapper;
        private readonly CreateDentistValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public DentistController(DentaCareContext context,
            IMapper mapper,
            CreateDentistValidator validator,
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
        public IActionResult Get([FromQuery] DentistSearch search,
            [FromServices] IGetDentistQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dentist = _context.Dentists.Find(id);

            if (dentist == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DentistDto>(dentist));
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] DentistDto dto,
            [FromServices] ICreateDentistCommand command,
            [FromServices] CreateDentistValidator validator)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DentistDto dto, [FromServices] UpdateDentistValidator validator)
        {
            dto.Id = id;

            var dentist = _context.Dentists.Find(id);

            if (dentist == null)
            {
                return NotFound();
            }

            var result = validator.Validate(dto);

            if (!result.IsValid)
            {
                throw new Exception();// prepraviti sa klasom error/ medelja 5-subota termin
            }

            _mapper.Map(dto, dentist);

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
            [FromServices] IDeleteDentistCommand command)
        {
            var dentist = _context.Dentists.Find(id);

            if (dentist == null)
            {
                return NotFound();
            }

            dentist.IsDeleted = true;
            dentist.IsActive = false;
            dentist.DeletedAt = DateTime.Now;


            _executor.ExecuteCommand(command, id);

            _context.SaveChanges();
            return NoContent();


        }
    }
}
