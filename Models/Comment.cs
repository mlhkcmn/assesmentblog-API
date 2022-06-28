namespace Api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string ZComment { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string UserName { get; set; }

    }

    public class PostComment
    {
        public int UserId { get; set; }
        public string ZComment { get; set; }
        public int PostId { get; set; }
        public string UserName { get; set; }

    }
    public class GetComment
    {
        public int PostId { get; set; }
    }
}