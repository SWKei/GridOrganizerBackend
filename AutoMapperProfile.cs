namespace GridOrganizerBackend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Grid, GetGridDto>();
            CreateMap<AddGridDto, Grid>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.GridItems, opt => opt.MapFrom(src => src.GridItems));

            CreateMap<UpdateGridDto, Grid>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.GridItems, opt => opt.MapFrom(src => src.GridItems));
        }
    }
}