namespace GridOrganizerBackend.Models
{
    public class Grid
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<GridItem>? GridItems { get; set; }
    }
}