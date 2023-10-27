namespace GridOrganizerBackend.Dtos.Grid
{
    public class GetGridDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "New Grid";
        public StatusEnum[] GridItems { get; set; } = Enumerable.Repeat(StatusEnum.None, 25).ToArray();
    }
}