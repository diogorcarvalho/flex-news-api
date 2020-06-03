using FlexNewsApi.Data;
using FlexNewsApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FlexNewsApi.Repositories
{
  public interface IPostRepository
  {
    void Save(Post post);
    Post Get(int postId);
    IEnumerable<Post> GetAll();
    IEnumerable<Post> Search(string keyword);
    void Patch(Post post);
    void Remove(Post post);
  }

  public class PostRepository : IPostRepository
  {
    private readonly DataContext _context;

    public PostRepository(DataContext context)
    {
      _context = context;
    }

    public void Save(Post post)
    {
      _context.Posts.Add(post);
      _context.SaveChanges();
    }

    public Post Get(int postId)
    {
      return (from post in _context.Posts.Include("Author")
        where post.PostId == postId
        select post).FirstOrDefault();
    }

    public IEnumerable<Post> GetAll()
    {
      return (from post in _context.Posts.Include("Author") select post).ToList();
    }

    public IEnumerable<Post> Search(string keyword)
    {
      return (from post in _context.Posts.Include("Author")
        where post.Title.ToLower().Contains(keyword.ToLower()) || post.Text.ToLower().Contains(keyword.ToLower()) || post.Author.Name.ToLower().Contains(keyword.ToLower())
        select post).ToList();
    }

    public void Patch(Post post)
    {
      _context.Entry<Post>(post).State = EntityState.Modified;
      _context.SaveChanges();
    }

    public void Remove(Post post)
    {
      _context.Set<Post>().Remove(post);
      _context.SaveChanges();
    }
  }
}