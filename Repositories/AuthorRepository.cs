using FlexNewsApi.Data;
using FlexNewsApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace FlexNewsApi.Repositories
{
  public interface IAuthorRepository
  {
    Author Get(int authorId);
    IEnumerable<Author> GetAll();
  }

  public class AuthorRepository : IAuthorRepository
  {
    private readonly DataContext _context;

    public AuthorRepository(DataContext context)
    {
      _context = context;
    }

    public Author Get(int authorId)
    {
      return (from author in _context.Authors where author.AuthorId == authorId select author).FirstOrDefault();
    }
    
    public IEnumerable<Author> GetAll()
    {
      return (from author in _context.Authors select author).ToList();
    }
  }
}