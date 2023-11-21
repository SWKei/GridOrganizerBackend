namespace GridOrganizerBackend.Dtos.Grid
{
    public class AddGridDto
    {
        [Required(ErrorMessage = "Name field is required.")]
        public required string Name { get; set; }
        public List<GridItem>? GridItems { get; set; }
    }
}