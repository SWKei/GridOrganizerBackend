namespace GridOrganizerBackend.Dtos.Grid
{
    public class AddGridDto
    {
        public string Name { get; set; }
        public StatusEnum[] GridItems { get; set; }
    }
}