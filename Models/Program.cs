namespace RediAPI.Models
{
    public class Platform
    {
        public string Id { get; set; } = $"Platform{Guid.NewGuid().ToString()}" ;

        public string Name { get; set; } = string.Empty;
    }
}