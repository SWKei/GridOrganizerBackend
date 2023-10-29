namespace GridOrganizerBackend.Dtos.Grid
{
    public class AddGridDto
    {
        public required string Name { get; set; }
        public List<GridItem>? GridItems { get; set; }
    }
}