using System;

namespace FlexNewsApi.Models
{
  public class Post {
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime DateCreate { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
  }
}