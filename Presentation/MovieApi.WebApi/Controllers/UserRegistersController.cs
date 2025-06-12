using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistersController : ControllerBase
    {
        private readonly CreateUserRegisterCommandHandler _handler;

        public UserRegistersController(CreateUserRegisterCommandHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRegister(CreateUserRegisterCommand command)
        {
            await _handler.Handle(command);
            return Ok("Kullanıcı başarıyla eklendi.");
        }
    }
}
