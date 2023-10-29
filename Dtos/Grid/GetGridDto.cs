namespace GridOrganizerBackend.Dtos.Grid
{
    public class GetGridDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<GridItem>? GridItems { get; set; }
    }
}