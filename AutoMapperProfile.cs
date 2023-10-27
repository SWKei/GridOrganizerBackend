namespace GridOrganizerBackend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Grid, GetGridDto>();
            CreateMap<AddGridDto, Grid>();
        }
    }
}