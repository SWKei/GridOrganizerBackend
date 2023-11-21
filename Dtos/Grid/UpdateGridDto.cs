namespace GridOrganizerBackend.Dtos.Grid
{
    public class UpdateGridDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name field is required.")]
        public required string Name { get; set; }
        public List<GridItem>? GridItems { get; set; }
    }
}