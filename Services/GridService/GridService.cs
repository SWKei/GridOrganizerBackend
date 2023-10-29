namespace GridOrganizerBackend.Services.GridService
{
    public class GridService : IGridService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public GridService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetGridDto>>> AddGrid(AddGridDto newGrid)
        {
            var serviceResponse = new ServiceResponse<List<GetGridDto>>();

            // Test Data start
            newGrid = new AddGridDto
            {
                Name = "Default rutnät",
                GridItems = new List<GridItem>()
            };
            for (int i = 0; i < 25; i++)
            {
                GridItem newObj = new GridItem
                {
                    Status = "None"
                };
                newGrid.GridItems.Add(newObj);
            }
            // Test Data end

            var grid = _mapper.Map<AddGridDto, Grid>(newGrid);

            _context.Grids.Add(grid);
            await _context.SaveChangesAsync();

            var dbGrids = await _context.Grids.Include(g => g.GridItems).ToListAsync();
            serviceResponse.Data = dbGrids.Select(g => _mapper.Map<GetGridDto>(g)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetGridDto>>> DeleteGrid(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetGridDto>>();

            try
            {
                var grid = await _context.Grids.Include(g => g.GridItems)
                    .FirstOrDefaultAsync(g => g.Id == id);

                if (grid is null)
                {
                    throw new Exception($"Grid with Id '{id}' not found. ");
                }

                _context.GridItems.RemoveRange(grid.GridItems);
                _context.Grids.Remove(grid);

                await _context.SaveChangesAsync();

                serviceResponse.Data =
                    await _context.Grids.Include(g => g.GridItems).Select(g => _mapper.Map<GetGridDto>(g)).ToListAsync();
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
            var serviceResponse = new ServiceResponse<List<GetGridDto>>();
            var dbGrids = await _context.Grids.Include(g => g.GridItems).ToListAsync();
            serviceResponse.Data = dbGrids.Select(g => _mapper.Map<GetGridDto>(g)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetGridDto>> GetGridById(int id)
        {
            var serviceResponse = new ServiceResponse<GetGridDto>();

            var dbGrid = await _context.Grids
                .Include(g => g.GridItems)
                .FirstOrDefaultAsync(g => g.Id == id);

            serviceResponse.Data = _mapper.Map<GetGridDto>(dbGrid);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetGridDto>> UpdateGrid(UpdateGridDto updatedGrid)
        {
            var serviceResponse = new ServiceResponse<GetGridDto>();

            try
            {
                // var grid = grids.FirstOrDefault(g => g.Id == updatedGrid.Id);

                var dbGrid = await _context.Grids
                    .Include(g => g.GridItems)
                    .FirstOrDefaultAsync(g => g.Id == updatedGrid.Id);

                if (dbGrid is null)
                {
                    throw new Exception($"Grid with Id '{updatedGrid.Id}' not found. ");
                }

                dbGrid.Name = updatedGrid.Name;
                dbGrid.GridItems = updatedGrid.GridItems;

                await _context.SaveChangesAsync();

                // _mapper.Map(updatedGrid, grid);

                serviceResponse.Data = _mapper.Map<GetGridDto>(dbGrid);
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