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
            return Ok(await _gridService.AddGrid(newGrid));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetGridDto>>>> UpdateGrid(UpdateGridDto updatedGrid)
        {
            var response = await _gridService.UpdateGrid(updatedGrid);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
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