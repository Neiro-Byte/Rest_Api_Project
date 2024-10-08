namespace Project_Rest_API.Model
{
    public class User
    {
        public int Id { get; set; }
        public Event Event { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTimeOffset DateTime { get; set; }
    }

    public enum Event
    {
        Created,
        Updated,
        Deleted
    }
}