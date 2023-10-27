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
            return Ok(await _gridService.GetGridById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetGridDto>>>> AddGrid(AddGridDto newGrid)
        {
            return Ok(await _gridService.AddGrid(newGrid));
        }
    }
}