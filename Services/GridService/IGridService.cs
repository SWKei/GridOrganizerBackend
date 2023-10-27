namespace GridOrganizerBackend.Services.GridService
{
    public interface IGridService
    {
        Task<ServiceResponse<List<GetGridDto>>> GetAllGrids();
        Task<ServiceResponse<GetGridDto>> GetGridById(int id);
        Task<ServiceResponse<List<GetGridDto>>> AddGrid(AddGridDto newGrid);
    }
}