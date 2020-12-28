namespace AllegroRestApiTests.Allegro.Api.Model
{
    public class Error
    {
        public string Code { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
        public string UserMessage { get; set; }
    }
}