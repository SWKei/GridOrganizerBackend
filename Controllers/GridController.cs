namespace GridOrganizerBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GridController : ControllerBase
    {
        private readonly IGridService _gridService;

        public GridController(IGridService gridService)
        {
            _gridService = gridService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetGridDto>>>> Get()
        {
            return Ok(await _gridService.GetAllGrids());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetGridDto>>> GetSingle(int id)
        {
            var response = await _gridService.GetGridById(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetGridDto>>>> AddGrid(AddGridDto newGrid)
        {
            if (!ModelState.IsValid)
            {
                // 400 Bad Request (Backend form validation)
                var errors = ModelState
                        .Where(e => e.Value?.Errors?.Any() ?? false)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value?.Errors?.Select(e => e.ErrorMessage).ToArray() ?? Array.Empty<string>());

                return BadRequest(new ServiceResponse<AddGridDto>
                {
                    Data = newGrid,
                    Success = false,
                    Message = "Validation failed.",
                    Errors = errors,
                });
            }

            var response = await _gridService.AddGrid(newGrid);

            if (!response.Success)
            {
                return Conflict(response); // 409 Conflict
            }

            return Ok(response); // 200 Ok
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetGridDto>>>> UpdateGrid(UpdateGridDto updatedGrid)
        {
            if (!ModelState.IsValid)
            {
                // 400 Bad Request (Backend form validation)
                var errors = ModelState
                        .Where(e => e.Value?.Errors?.Any() ?? false)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value?.Errors?.Select(e => e.ErrorMessage).ToArray() ?? Array.Empty<string>());

                return BadRequest(new ServiceResponse<UpdateGridDto>
                {
                    Data = updatedGrid,
                    Success = false,
                    Message = "Validation failed.",
                    Errors = errors,
                });
            }

            var response = await _gridService.UpdateGrid(updatedGrid);

            if (!response.Success)
            {
                return Conflict(response); // 409 Conflict
            }

            if (response.Data is null)
            {
                return NotFound(response); // 404 Not found
            }
            return Ok(response); // 200 Ok
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetGridDto>>>> DeleteGrid(int id)
        {
            var response = await _gridService.DeleteGrid(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}