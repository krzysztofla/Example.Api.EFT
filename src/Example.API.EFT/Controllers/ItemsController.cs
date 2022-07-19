using Example.Application.EFT.Commands;
using Example.Application.EFT.DTO;
using Example.Application.EFT.Queries;
using Example.Shared.EFT.Commands;
using Example.Shared.EFT.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.EFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commadDispatcher;

        public ItemsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commadDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commadDispatcher = commadDispatcher;
        }

        [HttpGet("{page:int}")]
        public async Task<ActionResult<List<ItemDto>>> GetPage([FromRoute] GetPage query, CancellationToken token) {
            var result = await _queryDispatcher.DispatchAsync(query, token);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ItemDto>> Get([FromRoute] GetItem query, CancellationToken token)
        {
            var result = await _queryDispatcher.DispatchAsync(query, token);
            if(result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult<ItemDto>> Post([FromBody]CreateItem command, CancellationToken token)
        {
            await _commadDispatcher.DispatchAsync(command, token);
            return CreatedAtAction(nameof(Get), new { id = command.Id}, null);
        }
    }
}
