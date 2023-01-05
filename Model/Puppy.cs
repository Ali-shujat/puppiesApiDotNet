namespace puppiesApiDotNet.Model
{
    public class Puppy
    {
        public Guid Id { get; set; }
        public string? Breed { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Image { get; set; }
    }
}
