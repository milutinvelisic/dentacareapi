﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentaCare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/Test
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        [HttpPost]
        public void Post([FromBody] RoleDto dto, [FromServices] ICreateRoleCommand command)
        {
            command.Execute(dto);
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
