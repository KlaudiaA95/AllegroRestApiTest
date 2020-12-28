namespace AllegroRestApiTests
{
    public class Category
    {
        public string Id { get; set; }
        public bool Leaf { get; set; }
        public string Name { get; set; }
        public Options Options { get; set; }
        public Parent Parent { get; set; }
    }
}