namespace BlogBackASPNETCore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        //Relación uno a muchos con Post
        public List<Post>? Posts { get; set; }       
    }
}
