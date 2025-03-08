namespace BlogBackASPNETCore.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Extract { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }

        //Foreing Key Category
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
