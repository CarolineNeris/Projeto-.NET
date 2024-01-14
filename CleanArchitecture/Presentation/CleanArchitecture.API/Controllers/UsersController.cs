using CleanArchitecture.Aplication.UseCases.CreateUser;
using CleanArchitecture.Application.UseCases.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers;
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator){
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken) {
            var response = await _mediator.Send(new GetAllUserRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken) {
            var validator = new CreateUserValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if(!validatorResult.IsValid) return BadRequest(validatorResult.Errors);
            
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
