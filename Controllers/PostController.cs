using System;
using System.Collections.Generic;
using FlexNewsApi.Models;
using FlexNewsApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlexNewsApi.Controllers
{
  [ApiController]
  public class PostController : ControllerBase
  {
    protected readonly IPostRepository _postReposritory;
    protected readonly IAuthorRepository _authorReposritory;

    public PostController(
      [FromServices] IPostRepository postReposritory,
      [FromServices] IAuthorRepository authorReposritory
    ) {
      _postReposritory = postReposritory;
      _authorReposritory = authorReposritory;
    }

    [HttpPost, Route("v1/posts")]
    public ActionResult<Post> Post([FromBody] Post newPost)
    {
      if (string.IsNullOrWhiteSpace(newPost.Title))
      {
        return StatusCode(500, new { message = "Post must have a valid title" });
      }

      if (string.IsNullOrWhiteSpace(newPost.Text))
      {
        return StatusCode(500, new { message = "Post must have valid text" });
      }

      if (newPost.AuthorId < 1)
      {
        return StatusCode(500, new { message = "Post must have a valid author id" });
      }

      var _author = _authorReposritory.Get(newPost.AuthorId);

      if (_author == null)
      {
        return StatusCode(500, new { message = "Post must have a valid author" });
      }

      newPost.Author = _author;
      newPost.DateCreate = DateTime.UtcNow;

      try
      {
        _postReposritory.Save(newPost);
        return Ok(newPost);
      }
      catch (Exception ex)
      {
        return StatusCode(500, new { message = ex.Message });
      }
    }

    [HttpGet, Route("v1/posts/{postId}")]
    public ActionResult<Post> Get([FromRoute] int postId)
    {
      if (postId < 1)
      {
        return StatusCode(500, new { message = "Post must have a valid post id" });
      }

      try
      {
        var authors = _postReposritory.Get(postId);
        return Ok(authors);
      }
      catch (Exception ex)
      {
        return StatusCode(500, new { message = ex.Message });
      } 
    }

    [HttpGet, Route("v1/posts")]
    public ActionResult<IEnumerable<Post>> GetAll()
    {
      try
      {
        var _posts = _postReposritory.GetAll();
        return Ok(_posts);
      }
      catch (Exception ex)
      {
        return StatusCode(500, new { message = ex.Message });
      }    
    }

    [HttpGet, Route("v1/posts/search")]
    public ActionResult<IEnumerable<Post>> Search([FromQuery] string keyword)
    {
      if (string.IsNullOrWhiteSpace(keyword))
      {
        return Ok(new List<Post>());
      }
      
      try
      {
        var _posts = _postReposritory.Search(keyword);
        return Ok(_posts);
      }
      catch (Exception ex)
      {
        return StatusCode(500, new { message = ex.Message });
      }
    }

    [HttpPatch, Route("v1/posts")]
    public ActionResult<Post> Patch([FromBody] PatchRequest patch)
    {
      var _post = _postReposritory.Get(patch.EntityId);

      if (_post == null)
      {
        return StatusCode(500, new { message = "You must enter a valid post id" });
      }

      if (patch.Field.Equals("Title") == false && patch.Field.Equals("Text") == false && patch.Field.Equals("AuthorId") == false)
      {
        return StatusCode(500, new { message = "You must enter a valid field" });
      }

      if (patch.Field.Equals("Title"))
      {
        if (string.IsNullOrWhiteSpace(patch.StringValue))
        {
          return StatusCode(500, new { message = "You must enter a valid title" });
        }
        
        try
        {
          _post.Title = patch.StringValue;
          _postReposritory.Patch(_post);
          return Ok(_post);
        }
        catch (Exception ex)
        {
          return StatusCode(500, new { message = ex.Message });
        }
      }

      if (patch.Field.Equals("Text"))
      {
        if (string.IsNullOrWhiteSpace(patch.StringValue))
        {
          return StatusCode(500, new { message = "You must enter a valid text" });
        }
        
        try
        {
          _post.Text = patch.StringValue;
          _postReposritory.Patch(_post);
          return Ok(_post);
        }
        catch (Exception ex)
        {
          return StatusCode(500, new { message = ex.Message });
        }
      }

      if (patch.Field.Equals("AuthorId"))
      {
        if (patch.IntValue == null || patch.IntValue < 1)
        {
          return StatusCode(500, new { message = "You must enter a valid author id" });
        }

        var _author = _authorReposritory.Get(patch.IntValue.Value);

        if (_author == null)
        {
          return StatusCode(500, new { message = "You must enter a valid author" });
        }
        
        try
        {
          _post.AuthorId = _author.AuthorId;
          _post.Author = _author;
          _postReposritory.Patch(_post);

          return Ok(_post);
        }
        catch (Exception ex)
        {
          return StatusCode(500, new { message = ex.Message });
        }
      }

      return StatusCode(500, new { message = "Something wrong is not right... 🤔" });
    }

    [HttpDelete, Route("v1/posts/{postId}")]
    public ActionResult Delete([FromRoute] int postId)
    {
      var _post = _postReposritory.Get(postId);

      if (_post == null)
      {
        return StatusCode(500, new { message = "You must enter a valid post id" });
      }

      try
      {
        _postReposritory.Remove(_post);
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(500, new { message = ex.Message });
      }    
    }
  }
}
