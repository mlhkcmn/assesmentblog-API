namespace Api.Models;

public class Post
    {
        public int Id {get; set;}
        public string Header {get; set;}
        public string Description {get; set;}
        public DateTime CreateDate {get; set;}
        public string UserName { get; set; }
        public int UserId { get; set; }
    }
