namespace GridOrganizerBackend.Dtos.Grid
{
    public class UpdateGridDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "New Grid";
        public List<GridItem>? GridItems { get; set; }
    }
}