namespace GridOrganizerBackend.Services.GridService
{
    public class GridService : IGridService
    {
        private static List<Grid> grids = new List<Grid>
        {
            new Grid
            {
                Id = 0,
                Name = "Grid1",
                GridItems = new StatusEnum[]
                {
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.Ok,
                    StatusEnum.Ok,
                    StatusEnum.Ok,
                    StatusEnum.Ok,
                    StatusEnum.Ok,
                    StatusEnum.Warning,
                    StatusEnum.Warning,
                    StatusEnum.Warning,
                    StatusEnum.Warning,
                    StatusEnum.Warning,
                    StatusEnum.Error,
                    StatusEnum.Error,
                    StatusEnum.Error,
                    StatusEnum.Error,
                    StatusEnum.Error,
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.None,
                }
            },
            new Grid
            {
                Id = 1,
                Name = "Grid2",
                GridItems = new StatusEnum[]
                {
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.Ok,
                    StatusEnum.Ok,
                    StatusEnum.Ok,
                    StatusEnum.Ok,
                    StatusEnum.Ok,
                    StatusEnum.Warning,
                    StatusEnum.Warning,
                    StatusEnum.Warning,
                    StatusEnum.Warning,
                    StatusEnum.Warning,
                    StatusEnum.Error,
                    StatusEnum.Error,
                    StatusEnum.Error,
                    StatusEnum.Error,
                    StatusEnum.Error,
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.None,
                    StatusEnum.None,
                }
            },

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

        public async Task<ServiceResponse<List<GetGridDto>>> DeleteGrid(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetGridDto>>();

            try
            {
                var grid = grids.First(g => g.Id == id);
                if (grid is null)
                {
                    throw new Exception($"Grid with Id '{id}' not found. ");
                }
                grids.Remove(grid);

                serviceResponse.Data = grids.Select(g => _mapper.Map<GetGridDto>(g)).ToList();
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

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

        public async Task<ServiceResponse<GetGridDto>> UpdateGrid(UpdateGridDto updatedGrid)
        {
            var serviceResponse = new ServiceResponse<GetGridDto>();

            try
            {
                var grid = grids.FirstOrDefault(g => g.Id == updatedGrid.Id);
                if (grid is null)
                {
                    throw new Exception($"Grid with Id '{updatedGrid.Id}' not found. ");
                }
                // _mapper.Map(updatedGrid, grid);

                grid.Name = updatedGrid.Name;
                grid.GridItems = updatedGrid.GridItems;

                serviceResponse.Data = _mapper.Map<GetGridDto>(grid);
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}