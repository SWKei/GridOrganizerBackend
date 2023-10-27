namespace GridOrganizerBackend.Services.GridService
{
    public class GridService : IGridService
    {
        private static List<Grid> grids = new List<Grid>
        {
            new Grid(),
            new Grid {
                Id = 1,
                Name = "Grid1"
            }
        };
        private readonly IMapper _mapper;

        public GridService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetGridDto>>> AddGrid(AddGridDto newGrid)
        {
            var serviceResponse = new ServiceResponse<List<GetGridDto>>();

            var grid = _mapper.Map<Grid>(newGrid);
            grid.Id = grids.Max(g => g.Id) + 1;
            grids.Add(grid);
            serviceResponse.Data = grids.Select(g => _mapper.Map<GetGridDto>(g)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetGridDto>>> GetAllGrids()
        {
            var serviceResponse = new ServiceResponse<List<GetGridDto>>
            {
                Data = grids.Select(g => _mapper.Map<GetGridDto>(g)).ToList()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetGridDto>> GetGridById(int id)
        {
            var serviceResponse = new ServiceResponse<GetGridDto>();

            var grid = grids.FirstOrDefault(g => g.Id == id);
            serviceResponse.Data = _mapper.Map<GetGridDto>(grid);

            return serviceResponse;
        }
    }
}