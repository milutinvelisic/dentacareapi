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
    public class EKartonController : ControllerBase
    {
        private readonly DentaCareContext _context;
        private readonly IMapper _mapper;
        private readonly CreateEKartonValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public EKartonController(DentaCareContext context,
            IMapper mapper,
            CreateEKartonValidator validator,
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
        public IActionResult Get([FromQuery] EKartonSearch search,
            [FromServices] IGetEKartonQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var eKarton = _context.EKarton.Find(id);

            if (eKarton == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EKartonDto>(eKarton));
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] EKartonDto dto,
            [FromServices] ICreateEKartonCommand command,
            [FromServices] CreateEKartonValidator validator)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EKartonDto dto, [FromServices] UpdateEKartonValidator validator)
        {
            dto.Id = id;

            var eKarton = _context.EKarton.Find(id);

            if (eKarton == null)
            {
                return NotFound();
            }

            var result = validator.Validate(dto);

            if (!result.IsValid)
            {
                throw new Exception();// prepraviti sa klasom error/ medelja 5-subota termin
            }

            _mapper.Map(dto, eKarton);

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
            [FromServices] IDeleteEKartonCommand command)
        {
            var eKarton = _context.EKarton.Find(id);

            if (eKarton == null)
            {
                return NotFound();
            }

            eKarton.IsDeleted = true;
            eKarton.IsActive = false;
            eKarton.DeletedAt = DateTime.Now;


            _executor.ExecuteCommand(command, id);

            _context.SaveChanges();
            return NoContent();
        }
    }
}
