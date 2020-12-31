namespace AllegroRestApiTests
{
    public class Parameter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Required { get; set; }
        public bool RequiredForProduct { get; set; }
        public string? Unit { get; set; }
        public ParameterOptions Options { get; set; }
        public Restrictions Restrictions { get; set; }
    }
}