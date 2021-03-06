﻿using System;
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
    public class JawController : ControllerBase
    {
        private readonly DentaCareContext _context;
        private readonly IMapper _mapper;
        private readonly CreateJawValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly UseCaseExecutor _executor;

        public JawController(DentaCareContext context,
            IMapper mapper,
            CreateJawValidator validator,
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
        public IActionResult Get([FromQuery] JawSearch search,
            [FromServices] IGetJawQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var jaw = _context.Jaws.Find(id);

            if (jaw == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<JawDto>(jaw));
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] JawDto dto,
            [FromServices] ICreateJawCommand command,
            [FromServices] CreateJawValidator validator)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] JawDto dto, [FromServices] UpdateJawValidator validator)
        {
            dto.Id = id;

            var jaw = _context.Jaws.Find(id);

            if (jaw == null)
            {
                return NotFound();
            }

            var result = validator.Validate(dto);

            if (!result.IsValid)
            {
                throw new Exception();// prepraviti sa klasom error/ medelja 5-subota termin
            }

            _mapper.Map(dto, jaw);

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
            [FromServices] IDeleteJawSideCommand command)
        {
            var jaw = _context.Jaws.Find(id);

            if (jaw == null)
            {
                return NotFound();
            }

            jaw.IsDeleted = true;
            jaw.IsActive = false;
            jaw.DeletedAt = DateTime.Now;


            _executor.ExecuteCommand(command, id);

            _context.SaveChanges();
            return NoContent();
        }
    }
}
