using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentaCare.Application;
using DentaCare.Application.Commands;
using DentaCare.Application.DataTransfer;
using DentaCare.Application.Email;
using DentaCare.Implementation.Validators;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DentaCare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IEmailSender _email;

        public RegisterController(UseCaseExecutor executor, IEmailSender email)
        {
            _executor = executor;
            _email = email;
        }


        // POST: api/Register
        [HttpPost]
        public void Post(
            [FromBody] UserDto dto,
            [FromServices] ICreateUserCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }
    }
}
