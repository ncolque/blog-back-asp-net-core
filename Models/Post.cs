namespace BlogBackASPNETCore.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string extract { get; set; }
        public string body { get; set; }
        public string status { get; set; }
    }
}
